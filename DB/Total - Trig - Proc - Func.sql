--CREATE DATABASE DBMS_FiNALBackup
USE DBMS_FinalProject
GO
----------------------------------------------------------------------TRIGGER------------------------------------------------------------------------------------
----------------------------------------------------------------------Phước Đăng------------------------------------------------------------------------------------
--1. Khi sửa lại máy Super vip thì không được nhập CPU là Intel Core i3 hoặc Core i5
CREATE or ALTER TRIGGER Add_Device_CPU_condition ON DEVICETYPE
AFTER INSERT,UPDATE AS
declare @CPU nvarchar(100)
BEGIN
	--CPU của máy đang được xét
	Select @CPU = inserted.CPU
	from DEVICETYPE, inserted
	Where DEVICETYPE.TypeID = inserted.TypeID
	and inserted.TypeID = 'Super Vip'
	
	--Trigger báo lỗi khi nhập Core i3 hoặc i5
	if @CPU = 'Core i3' OR @CPU = 'Core i5' 
	BEGIN
	PRINT ('Invalid CPU !!!')
	rollback
	END
END;
GO

--2.Khi sửa lại máy Vip thì Keyboard của máy Thường không được trùng với máy Vip 
CREATE or ALTER TRIGGER Add_Device_Keyboard_Condition ON DEVICETYPE
AFTER INSERT, UPDATE AS
declare 
		@Keyboard_Vip_Default nvarchar(100), 
		@Keyboard_Vip_Input nvarchar(100), 
		@Keyboard_Thuong_Default nvarchar(100),
		@Keyboard_Thuong_Input nvarchar(100)
BEGIN
	Select @Keyboard_Vip_Default = DEVICETYPE.KeyBoard
	From DEVICETYPE
	Where TypeID = 'Vip'

	Select @Keyboard_Vip_Input = inserted.KeyBoard
	From DEVICETYPE,inserted
	Where DEVICETYPE.TypeID = inserted.TypeID
	and inserted.TypeID = 'Vip'

	Select @Keyboard_Thuong_Default = DEVICETYPE.KeyBoard
	From DEVICETYPE
	Where TypeID = N'Thường'

	Select @Keyboard_Thuong_Input = inserted.KeyBoard
	From DEVICETYPE,inserted
	Where DEVICETYPE.TypeID = inserted.TypeID
	and inserted.TypeID = N'Thường'

	if (@Keyboard_Vip_Default = @Keyboard_Thuong_Input or  @Keyboard_Vip_Input = @Keyboard_Thuong_Default)
	BEGIN
	PRINT ('Invalid Keyboard !!!')
	rollback
	END
END;
GO

--3. Ram phải luôn bắt buộc là DDR4, DDR3, DDR2
CREATE or ALTER TRIGGER Add_Device_RAM_condition ON DEVICETYPE
AFTER INSERT,UPDATE AS
declare @Ram nvarchar(100)
BEGIN
	--CPU của máy đang được xét
	Select @Ram = inserted.RAM
	from DEVICETYPE, inserted
	Where DEVICETYPE.TypeID = inserted.TypeID
	
	--Trigger báo lỗi khi nhập sai RAM
	if @Ram != 'DDR4' AND @Ram != 'DDR3' AND @Ram != 'DDR2'
	BEGIN
	PRINT ('Invalid RAM !!!')
	rollback
	END
END;
GO

----------------------------------------------------------------------Nhật Tiến------------------------------------------------------------------------------------
--1. TRIGGER không cho nhân viên check in nếu chưa tới giờ đi làm
CREATE or ALTER TRIGGER UTG_WorkShiftCheckIn ON dbo.TIMEKEEPING
AFTER INSERT
AS
BEGIN
	--Lấy id nhân viên và thời gian check in của nhân viên đó
	DECLARE @iIDEmployee NVARCHAR(100), @iCheckIN TIME
	SELECT @iIDEmployee = Inserted.IDEmployee, @iCheckIN = Inserted.CheckIn
	FROM Inserted

	--Lấy ca làm của nhân viên
	DECLARE @WorkShift INT
	SELECT @WorkShift = WORKSHIFTTME.ShiftID
	FROM (SELECT CONVERT(TIME, dbo.WORKSHIFT.TimeBegin) AS TimeBegin, ShiftID FROM dbo.WORKSHIFT) AS WORKSHIFTTME
	WHERE DATEDIFF(MINUTE, WORKSHIFTTME.TimeBegin, @iCheckIN) <= 60	AND DATEDIFF(MINUTE, WORKSHIFTTME.TimeBegin, @iCheckIN) >= 0		--Nếu trễ 1 tiếng so với ca làm thì không được check in
	--Kiểm tra trong bảng ca có đúng ca làm của nhân viên đang check in không?
	DECLARE @CountID INT
	SELECT @CountID = COUNT(*)
	FROM dbo.WORK
	WHERE @WorkShift = dbo.WORK.ShiftID AND @iIDEmployee = dbo.WORK.EmpID
	--Kiểm tra ca làm của nhân viên
	IF (@CountID < 1)
	BEGIN
		PRINT 'Chua toi ca lam nhan vien khong the check in'
		ROLLBACK
	END
END
GO

--2. TRIGGER thay đổi thưởng phạt khi check out tan làm sớm hoặc muộn để tính tiền thưởng phạt
CREATE or ALTER TRIGGER UTG_RewardFineCheckOut ON dbo.TIMEKEEPING
AFTER UPDATE
AS
BEGIN
	--Lấy ID và thời gian check out trừ thời gian check in để kiểm tra xem có vượt quá thời gian làm hoặc thiếu so với thời gian làm của 1 ca
	DECLARE @iIDEmployee NVARCHAR(100), @Minute INT, @iCheckIn DATE
	SELECT @iIDEmployee = IDEmployee, @Minute = DATEDIFF(MINUTE, CheckIn, CheckOut), @iCheckIn = Inserted.CheckIn
	FROM  Inserted
	--Lấy số ca làm và thời gian tháng năm của nhân viên trong bảng lương
	DECLARE @iNumberofWorkShift INT,  @iMonthWork INT, @iYearWork INT
	SELECT @iNumberofWorkShift= NumberofWorkShift, @iMonthWork = MonthWork, @iYearWork = YearWork
	FROM dbo.SALARY
	WHERE IDEmployee = @iIDEmployee AND MONTH(@iCheckIn) = MonthWork AND YEAR(@iCheckIn) = YearWork
	--Nếu thời gian làm không đủ thì cứ mỗi 15 phút sẽ tính vào tiền phạt và ngược lại thời gian hơn trong ca làm cứ mỗi 15 phút sẽ được tính vào tiền thưởng
	DECLARE @Reward REAL, @Fine REAL 
	IF (@Minute >= 480)
	BEGIN
		SET @Reward = @Minute - 480
		SET @Fine = 0
	END
	ELSE IF (@Minute < 480)
	BEGIN
		SET @Fine = (480 - @Minute)
		SET @Reward = 0
	END
	--Nếu số ca làm được hơn trên 30 và số thời gian làm của buỗi đó hơn 8 tiếng thì tiền thưởng sẽ được nhân thêm 1.1
	IF (@iNumberofWorkShift >= 30 AND @Minute >= 480)
		SET @Reward = @Reward * 1.1
	--Cập nhật thay đổi thưởng phạt ở bảng tiền lương
	UPDATE dbo.SALARY
	SET Reward = Reward + @Reward / 60, Fine = Fine + @Fine / 60
	WHERE @iIDEmployee = IDEmployee AND @iMonthWork = MonthWork AND @iYearWork = YearWork
END
GO

--3. TRIGGER cập nhật thay đổi bảng SALARY khi nhân viên check out
CREATE or ALTER TRIGGER UTG_SalaryCheckOut ON dbo.TIMEKEEPING
AFTER UPDATE
AS
BEGIN
	--Lấy ID, thời gian check in, thời gian check out của nhân viên
	DECLARE @iIDEmployee NVARCHAR(100), @iCheckIn DATETIME, @iCheckOut DATETIME
	SELECT @iIDEmployee = Inserted.IDEmployee, @iCheckIn = Inserted.CheckIn, @iCheckOut = Inserted.CheckOut
	FROM Inserted
	--Lấy số thưởng, phạt và số ca làm của nhân viên đó
	DECLARE @iReward FLOAT, @iFine FLOAT, @iNumberofWorkShift INT	
	SELECT @iReward = Reward, @iFine = Fine, @iNumberofWorkShift = NumberofWorkShift
	FROM dbo.SALARY
	WHERE @iIDEmployee = dbo.SALARY.IDEmployee AND MONTH(@iCheckOut) = MonthWork AND YEAR(@iCheckOut) = YearWork
	--Lấy chức vụ của nhân viên
	DECLARE @iEmployeeType NVARCHAR(100)
	SELECT @iEmployeeType = WorkID
	FROM dbo.EMPLOYEE 
	WHERE @iIDEmployee = dbo.EMPLOYEE.ID	
	--Lấy hệ số của nhân viên dựa trên loại của nhân viên
	DECLARE @CoefficientsSalary REAL
	SELECT @CoefficientsSalary = CoefficientsSalary
	FROM dbo.JOB
	WHERE @iEmployeeType = dbo.JOB.WorkID
	--Lấy ca làm của nhân viên
	DECLARE @ShiftID INT
	SELECT @ShiftID = dbo.WORKSHIFT.ShiftID
	FROM dbo.WORKSHIFT, dbo.WORK
	WHERE dbo.WORK.EmpID = @iIDEmployee AND dbo.WORKSHIFT.ShiftID = dbo.WORK.ShiftID AND DATEPART(HOUR,dbo.WORKSHIFT.TimeBegin) <= DATEPART(HOUR,@iCheckIn) AND DATEDIFF(HOUR,dbo.WORKSHIFT.TimeBegin, @iCheckIn) < 8
	--Tính lương của nhân viên
	DECLARE @Wages REAL
	IF (@ShiftID = 1)															--Làm giờ ban đêm từ 0h đến 8h
		SET @Wages = 8 * @CoefficientsSalary * 20000 * 1.5
	ELSE																		--Những giờ khác 0h đến 8h
		SET @Wages = 8 * @CoefficientsSalary * 20000

	DECLARE @SalarybyPosition INT
	IF (@ShiftID = 1)
		SET @SalarybyPosition = @iNumberofWorkShift* @Wages + (@iReward - @iFine) * 20000							--Set tiền lương
	ELSE
		SET @SalarybyPosition = @iNumberofWorkShift* @Wages + (@iReward - @iFine) * 30000
	--Cập nhật thay đổi lương nhân viên
	UPDATE dbo.SALARY
	SET SalaryEmployee = @SalarybyPosition
	WHERE dbo.SALARY.IDEmployee = @iIDEmployee AND dbo.SALARY.MonthWork = MONTH(@iCheckOut) AND dbo.SALARY.YearWork = YEAR(@iCheckOut)
END
GO

--4. Thay đổi số ca làm nhân viên khi nhân viên check in
CREATE or ALTER TRIGGER UTG_SalaryCheckIn ON dbo.TIMEKEEPING
AFTER INSERT
AS
BEGIN
	--Lấy lương nhân viên check in và thời gian check in của nhân viên
	DECLARE @iIDEmployee NVARCHAR(100), @iCheckIN DATETIME
	SELECT @iIDEmployee = Inserted.IDEmployee, @iCheckIN = Inserted.CheckIn
	FROM Inserted
	--Kiểm tra xem tháng năm mà nhân viên check in có bảng lương chưa 
	DECLARE @CheckIDSalary INT
	SELECT @CheckIDSalary = COUNT(*)
	FROM dbo.SALARY
	WHERE @iIDEmployee = dbo.SALARY.IDEmployee AND MONTH(@iCheckIn) = MonthWork AND YEAR(@iCheckIn) = YearWork
	--Nếu nhân viên chưa có trong bảng lương thì thêm vào tháng năm đó
	IF (@CheckIDSalary < 1)	
		INSERT INTO dbo.SALARY
		(
		    IDEmployee,
		    MonthWork,
		    YearWork,
		    SalaryEmployee
		)
		VALUES
		(   @iIDEmployee,																				-- IDEmployee - nvarchar(100)
		    MONTH(@iCheckIn),																			-- MonthWork - int
		    YEAR(@iCheckIn),																			-- YearWork - int
		    0																							-- SalaryEmployee - real
		)
	--Cập nhật số ca làm của nhân viên
	UPDATE dbo.SALARY
	SET NumberofWorkShift = NumberofWorkShift + 1
	WHERE @iIDEmployee = IDEmployee AND MONTH(@iCheckIn) = MonthWork AND YEAR(@iCheckIn) = YearWork
END
GO

----------------------------------------------------------------------Dương Duy------------------------------------------------------------------------------------
--1. khi Cus đăng nhập vào máy để bắt đầu chơi (1 là đang sử dụng - 0 là không sử dụng) dibu
DECLARE @money INT;
SET @money = 7500;
DECLARE @sophut INT;
SET @sophut = 1440*370 + 75--@money*60/5000 24*60-1?=23h59
DECLARE @g Datetime;
SET @G = FORMAT(DATEADD(MINUTE, @sophut, '1900-01-01 00:00:00'), 'dd/MM/yyyy hh:mm:ss tt')
GO
----lỡ người chơi nạp nhiều tiền tới mức là số giờ chơi tính theo ngày
--SELECT CONVERT(varchar, @g, 108) + ' ' + CONVERT(VARCHAR, YEAR(@G) - 1900)
--+ '/' + CONVERT(VARCHAR, MONTH(@G)) + '/' + CONVERT(VARCHAR, DAY(@G))
----vipppppp
----hh:mi:ss yy/mm/dd
--GO
CREATE OR ALTER TRIGGER UserOnline_AccountCus ON dbo.ACCOUNTCUSTOMER
FOR INSERT,UPDATE
AS
BEGIN
	DECLARE @did NVARCHAR(100),@st INT,@cid NVARCHAR(100),@AccM FLOAT, @deT NVARCHAR(100),@Tavl DATETIME,@Tu DATETIME
	SELECT @did=Inserted.DeviceID , @st=Inserted.StatusCustomer, @cid =Inserted.CustomerID,
	@Tavl =Inserted.TimeAvailible,@AccM=Inserted.AccMoney,@Tu=Inserted.TimeUsed
	FROM Inserted
	IF(@st = 1 AND @did IS NOT NULL)
		BEGIN
			UPDATE dbo.DEVICES
			SET DStatus=N'Online'
			WHERE DeviceID=@did

			SELECT @deT= dbo.DEVICES.TypeID
			FROM dbo.DEVICES
			WHERE dbo.DEVICES.DeviceID=@did
			
			DECLARE @tienmay FLOAT
			IF(@deT =N'Vip')
				SET @tienmay=7000
			ELSE IF(@deT =N'Super Vip')
				SET @tienmay=12000
			ELSE 
				SET @tienmay=5000

			DECLARE @minuteMoney INT = @AccM*60/@tienmay
			SET @Tavl = FORMAT(DATEADD(MINUTE, @minuteMoney, @Tavl), 'dd/MM/yyyy hh:mm:ss tt')
			UPDATE dbo.ACCOUNTCUSTOMER
			SET	
				AccMoney=0,
				TimeAvailible=@Tavl,
				TimeUsed=SYSDATETIME()
			WHERE CustomerID=@cid
		END
END
GO

----------------------------------------------------------------------Hoàng Vũ------------------------------------------------------------------------------------
--Số CMND phải có hơn 8 kí tự và nhỏ hơn 13 kí tự (9 <= CMND <= 12) 
create or ALTER trigger TG_FormatIdentityNumber on EMPLOYEE
for insert, update as
declare @Identity nvarchar(100)
begin
	--Lấy ra IdentityNumber của nhân viên vừa nhập
	select @Identity = inserted.IdentityNumber
	from inserted

	if(len(@Identity) > 12 or len(@Identity) < 9)
	begin
		print ('IdentityNumber must have more than 8 and less than 13 characters!!!')
		rollback
	end
end
GO

--Nhân viên phải ít nhất ĐỦ 18 tuổi
create or ALTER trigger TG_EmpAtLeast18YO on EMPLOYEE
for insert, update as
declare @Bdate date
begin
	
	--Lấy ra Birthday của nhân viên vừa nhập
	select @Bdate = inserted.Birthday
	from inserted

	if(datediff(yy,@Bdate,getdate()) < 18)
	begin
		print('Employee has to be 18 year old!!!')
		rollback
	end
end
GO

--Số điện thoại nhân viên phải từ 10 đến 11 chữ số
create or ALTER trigger TG_FormatPhoneNumber on EMPLOYEE
for insert, update as
declare @Phone NVARCHAR(100)
begin
	--Lấy ra mã ID của nhân viên vừa nhập
	select @Phone = inserted.Phone
	from inserted

	if(len(@Phone) > 10 or len(@phone) < 9)
	begin
		print ('Phone Number must have more than 8 and less than 11 characters!!!')
		rollback
	end
end
GO



----------------------------------------------------------------------PROCEDURE------------------------------------------------------------------------------------
----------------------------------------------------------------------Quốc Thắng------------------------------------------------------------------------------------
CREATE or ALTER PROC Edit_MyInfo (@id nvarchar(100), @name nvarchar(100), @gender nvarchar(100), @birth DateTime , @phone nvarchar(100), @Identity nvarchar(100),@email nvarchar(100)) AS
BEGIN
	UPDATE dbo.EMPLOYEE
	SET FullName = @name,
		Gender = @gender,
		Birthday = @birth,
		Phone = @phone,
		IdentityNumber = @Identity,
		Email = @email
	WHERE
		ID = @id
END
GO

--Work
CREATE or ALTER PROC AddDivideShift (@EmpID nvarchar(100), @ShiftID nvarchar(100), @ShiftManagerID nvarchar(100)) AS
BEGIN
	INSERT INTO dbo.WORK
	(
		EmpID, ShiftID, ShiftManagerID
	)
	VALUES
	(
		@EmpID, @ShiftID, @ShiftManagerID
	)
END
GO

CREATE or ALTER PROC UpdateDivideShift (@EmpID nvarchar(100), @shiftID nvarchar(100), @ShiftManagerID nvarchar(100)) AS
BEGIN
	UPDATE dbo.WORK
	SET EmpID = @EmpID,
		ShiftID = @ShiftID,
		ShiftManagerID = @ShiftManagerID
	WHERE
		EmpID = @EmpID
END
GO
CREATE or ALTER PROC DeleteDivideShift (@EmpID nvarchar(100), @shiftID nvarchar(100), @ShiftManagerID nvarchar(100)) AS
BEGIN
	DELETE FROM dbo.WORK
	WHERE EmpID = @EmpID and ShiftID = @ShiftID and ShiftManagerID = @ShiftManagerID
END
GO



--WorkShift
CREATE or ALTER PROC AddDivideTimeShift (@ShiftID nvarchar(100), @TimeBegin nvarchar(100), @TimeEnd nvarchar(100)) AS
BEGIN
	INSERT INTO dbo.WORKSHIFT
	(
		ShiftID, TimeBegin, TimeEnd
	)
	VALUES
	(
		@ShiftID, @TimeBegin, @TimeEnd
	)
END
GO

CREATE or ALTER PROC UpdateDivideTimeShift (@ShiftID nvarchar(100), @TimeBegin time(7), @TimeEnd time(7)) AS
BEGIN
	UPDATE dbo.WORKSHIFT
	SET ShiftID = @ShiftID,
		TimeBegin = @TimeBegin,
		TimeEnd = @TimeEnd
	WHERE
		ShiftID = @ShiftID
END
GO

CREATE or ALTER PROC DeleteDivideTimeShift (@ShiftID nvarchar(100)) AS
BEGIN
	DELETE FROM dbo.WORKSHIFT
	WHERE ShiftID = @ShiftID
END
GO


----------------------------------------------------------------------Phước Đăng------------------------------------------------------------------------------------
--1. Stored-Procedure hiển thị thông tin của các khách hàng đang chơi máy Vip / Super Vip / Thuong
Go
CREATE or ALTER PROC ShowInfoCustomerGroupByTypeID @TypeID nvarchar(100)
as
begin
select a.UserName,a.PassWord,a.TimeAvailible,a.TimeUsed,a.CustomerID,a.DeviceID,a.StatusCustomer
from ACCOUNTCUSTOMER a, DEVICES d
where a.DeviceID = d.DeviceID
and d.TypeID = @TypeID
end
GO

--2.
CREATE or ALTER PROC Insert_Device (@devid nvarchar(100),@type nvarchar(100),@status nvarchar(100))
AS
BEGIN
 INSERT INTO dbo.DEVICES
 (
 DeviceID,
 TypeID,
 DStatus
 )

 VALUES
 (   @devid, 
     @type, 
     @status
     )
END
GO

--3. 
CREATE or ALTER PROC DeleteDeviceByID (@devID nvarchar(100))
AS
BEGIN
UPDATE  ACCOUNTCUSTOMER SET ACCOUNTCUSTOMER.DeviceID = null
WHERE ACCOUNTCUSTOMER.DeviceID = @devID
 DELETE FROM dbo.DEVICES
 WHERE DEVICES.DeviceID = @devID
END
GO

--4. 
create or ALTER PROC Edit_Device (@devid nvarchar(100),@type nvarchar(100))
AS
BEGIN
	UPDATE dbo.DEVICES
	SET 
		TypeID=@type
		--DStatus=@status
	WHERE DeviceID=@devid
END
go

--5. Stored-Procedure hiển thị thông tin của khách hàng đang sử dụng 1 máy cụ thể
Go
CREATE OR ALTER PROC ShowCustomerIsPlaying @DevID nvarchar(100)
as
begin
select c.CustomerID,c.FullName,c.PhoneNumber,c.MoneyCharged,a.UserName,a.Actualtimeavl,a.TimeUsed,a.DeviceID
from ACCOUNTCUSTOMER a, DEVICES d, CUSTOMER c
where a.DeviceID = d.DeviceID
and a.DeviceID = @DevID
and a.CustomerID = c.CustomerID
end
GO

--6. Chỉnh sửa trạng thái máy thành đã sử dụng
GO
CREATE or ALTER PROCEDURE UpdateStatus @devid nvarchar(MAX)
as 
begin
update DEVICES
set
DStatus = N'Online'
where DeviceID = @devid
end
GO

--7. Dừng cấp quyền sử dụng
GO
CREATE or ALTER PROCEDURE StopPlaying @devid nvarchar(MAX)
AS
BEGIN
UPDATE ACCOUNTCUSTOMER 
SET StatusCustomer = 0
WHERE ACCOUNTCUSTOMER.DeviceID = @devid
UPDATE DEVICES
SET DStatus = N'Offline'
WHERE DeviceID = @devid
UPDATE ACCOUNTCUSTOMER
SET DeviceID = NULL where DeviceID = @devid;
END;
GO

--8. Cấp quyền sử dụng
CREATE or ALTER PROCEDURE StartPlaying @devid nvarchar(MAX)

AS
BEGIN

UPDATE ACCOUNTCUSTOMER 
SET StatusCustomer = 1
WHERE ACCOUNTCUSTOMER.DeviceID = @devid

UPDATE DEVICES
SET DStatus = N'Online'
WHERE DeviceID = @devid
END;
GO

--9. Bắt đầu bảo trì
CREATE or ALTER PROCEDURE StartRepairing @devid nvarchar(MAX)

AS
BEGIN

UPDATE ACCOUNTCUSTOMER 
SET StatusCustomer = 0
WHERE ACCOUNTCUSTOMER.DeviceID = @devid

UPDATE DEVICES
SET DStatus = N'In maintenance'
WHERE DeviceID = @devid

UPDATE ACCOUNTCUSTOMER 
SET DeviceID = NULL where DeviceID = @devid
END;
GO

--10. Dừng bảo trì
CREATE or ALTER PROCEDURE StopRepairing @devid nvarchar(MAX)
AS
BEGIN
UPDATE DEVICES
SET DStatus = N'Offline'
WHERE DeviceID = @devid
END;
GO

--11.
GO
CREATE OR ALTER PROCEDURE FormatStatus
as 
BEGIN
UPDATE DEVICES
SET
DStatus = N'Offline'
WHERE DStatus = N'Online'

AND DeviceID not in
(select DEVICES.DeviceID from DEVICES, ACCOUNTCUSTOMER Where DEVICES.DeviceID = ACCOUNTCUSTOMER.DeviceID)
END
GO


----------------------------------------------------------------------Nhật Tiến------------------------------------------------------------------------------------
--PROCEDURE show tiền lương
CREATE or ALTER PROCEDURE USP_ShowSalary
AS
BEGIN
	SELECT * FROM SALARY											
END
GO

--PROCEDURE show toàn bộ điểm danh
CREATE or ALTER PROCEDURE USP_ShowFullTimeKeeping 
AS
BEGIN
	SELECT * FROM TIMEKEEPING
END
GO

--PROCEDURE khi nhân viên check in thêm vào bảng WORK
CREATE or ALTER PROCEDURE USP_CheckIn @IDEmployee NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.TIMEKEEPING (IDEmployee, CheckIn) VALUES (@IDEmployee, GETDATE())					--Thêm vào bảng WORK
END
GO

--PROCEDURE khi nhân viên check out update bảng WORK
CREATE or ALTER PROCEDURE USP_CheckOut @IDEmployee NVARCHAR(100)
AS
BEGIN
	UPDATE TIMEKEEPING SET CheckOut = GETDATE() WHERE IDEmployee = @IDEmployee AND CheckOut IS NULL		--Thay đổi chỉnh sửa bảng WORK
END
GO

--PROCEDURE kiểm tra ID nhân viên có tồn tại hay không
CREATE or ALTER PROCEDURE USP_CheckIDEmployee @IDEmployee NVARCHAR(100)
AS
BEGIN
	SELECT * FROM EMPLOYEE WHERE ID = @IDEmployee												--SELECT * để kiểm tra tồn tại của nhân viên
END
GO

--PROCEDURE kiểm tra nhân viên có đang trong ca làm hay không
CREATE or ALTER PROCEDURE USP_CheckIDEmployeeWorking @IDEmployee NVARCHAR(100)
AS
BEGIN
	SELECT * FROM TIMEKEEPING WHERE IDEmployee = @IDEmployee AND CheckOut IS NULL				--SELECT * để kiểm tra nhân viên có đi làm hay không
END
GO
--PROCEDURE tìm kiếm lương nhân viên bằng tháng và năm
CREATE or ALTER PROCEDURE USP_SearchSalaryByMonthYear @Month INT, @Year INT
AS
BEGIN
	Select * FROM Salary WHERE MonthWork = @Month AND YearWork = @Year
END
GO
--PROCEDURE tìm kiếm lương nhân viên bằng tháng
CREATE or ALTER PROCEDURE USP_SearchSalaryByMonth @Month INT
AS
BEGIN
	Select * FROM Salary WHERE MonthWork = @Month
END
GO
--PROCEDURE tìm kiếm lương nhân viên bằng năm
CREATE or ALTER PROCEDURE USP_SearchSalaryByYear @Year INT
AS
BEGIN
	Select * FROM Salary WHERE YearWork = @Year
END
GO
----------------------------------------------------------------------Dương Duy------------------------------------------------------------------------------------
--1. thêm mới khách hàng Cus
go
CREATE or ALTER PROC Create_customer (@cid nvarchar(100),@ful nvarchar(100),@phn nvarchar(100),@icn nvarchar(50),@mon int)
AS
BEGIN
 INSERT INTO dbo.CUSTOMER
 (
     CustomerID,
     FullName,
     PhoneNumber,
     IdentityCardNumber,
     MoneyCharged
 )
 VALUES
 (   @cid, -- CustomerID - nvarchar(100)
     @ful, -- FullName - nvarchar(100)
     @phn,   -- PhoneNumber - int
     @icn,   -- IdentityCardNumber - int
     @mon  -- MoneyCharged - float
     )
END;
GO

--2. xoá một khách hàng Cus theo Cid
GO
CREATE or ALTER PROC deleteById_customer (@cid nvarchar(100))
AS
BEGIN
 DELETE FROM dbo.CUSTOMER
 WHERE CustomerID=@cid
END;
GO

--3. chỉnh sửa thông tin khách hàng Cus theo Cid
go
CREATE or ALTER PROC EditInfo_customer(@cid nvarchar(100),@ful nvarchar(100),@phn nvarchar(100),@icn nvarchar(50),@mon int)
AS
BEGIN
	UPDATE dbo.CUSTOMER
	SET 
		FullName=@ful,
		PhoneNumber=@phn,
		IdentityCardNumber=@icn,
		MoneyCharged=@mon
	WHERE CustomerID=@cid
END
GO

--4. Khách hàng nạp tiền vào tài khoản Cus
go
CREATE or ALTER PROC DepositBudget_customer(@cid nvarchar(100),@mon float)
AS
BEGIN
	UPDATE dbo.CUSTOMER
	SET 
		MoneyCharged=MoneyCharged+@mon
	WHERE CUSTOMER.CustomerID=@cid
END
GO

--5. tạo tài khoản AccCus
go
CREATE or ALTER PROC Create_Accus (@un NVARCHAR(100),@pass NVARCHAR(100),@cid NVARCHAR(100))
AS
BEGIN
	INSERT INTO dbo.ACCOUNTCUSTOMER
	(
	    UserName,
	    PassWord,
	    CustomerID,
		AccMoney                  ---khi tao tai khoan moi thi so tien auto =0
	)
	VALUES
	(   @un,       -- UserName - nvarchar(100)
	    @pass,       -- PassWord - nvarchar(100)
	    @cid,
		0
	    )
END
GO

CREATE OR ALTER PROC UserLoginDevice_AccountCus (@cid NVARCHAR(100),@did NVARCHAR(100))
AS
BEGIN

	UPDATE dbo.DEVICES
	SET
		DStatus=N'Online'
	WHERE DeviceID=@did

	UPDATE dbo.ACCOUNTCUSTOMER
	SET	
		DeviceID=@did,
		StatusCustomer=1
	WHERE CustomerID=@cid
END
GO

--** Việc khách hàng nạp tiền vào Cus và Acus là 2 việc khác nhau vì 2 loại tiền này phục mục đích khác, 
--tiền của Cus là tiền chung có thể để nạp tiền giờ chơi hay order đồ ăn
--việc phân biệt này giúp cho việc tính toán số giờ chơi còn lại trong Acus trực quan hơn

--5. Khách hàng nạp tiền vào Account
go
CREATE OR ALTER PROC DepositBudget_Accountcustomer(@cid nvarchar(100),@mon float)
AS
BEGIN
	UPDATE dbo.ACCOUNTCUSTOMER
	SET 
	     AccMoney=AccMoney+@mon                    ---------- cột Accmoney mới thêm vào AccountCustomer để phân biệt với bên Customer
	FROM dbo.CUSTOMER,dbo.ACCOUNTCUSTOMER
	WHERE CUSTOMER.CustomerID=dbo.ACCOUNTCUSTOMER.CustomerID
	AND ACCOUNTCUSTOMER.CustomerID=@cid

	UPDATE dbo.CUSTOMER
	SET
		MoneyCharged=MoneyCharged-@mon
	FROM dbo.CUSTOMER,dbo.ACCOUNTCUSTOMER
	WHERE CUSTOMER.CustomerID=dbo.ACCOUNTCUSTOMER.CustomerID
	AND ACCOUNTCUSTOMER.CustomerID=@cid
END
GO

--6. khi Cus logout khỏi máy
GO
CREATE OR ALTER PROC Userlogout_AccountCus (@cid NVARCHAR(100),@did NVARCHAR(100))
AS
BEGIN

	DECLARE @tienmay FLOAT,@kieumay NVARCHAR(50)

	SELECT @kieumay=TypeID
	FROM dbo.DEVICES
	WHERE DeviceID=@did

	DECLARE @Tavl DATETIME,@Tu DATETIME
	SELECT @Tavl=TimeAvailible,@Tu=TimeUsed
	FROM dbo.ACCOUNTCUSTOMER
	WHERE CustomerID=@cid

	IF(@kieumay =N'Vip')
		SET @tienmay=7000
	ELSE IF(@kieumay =N'Super Vip')
		SET @tienmay=12000
	ELSE 
		SET @tienmay=5000

	UPDATE dbo.ACCOUNTCUSTOMER
	SET	
		AccMoney=AccMoney+CAST(ROUND((DATEDIFF(MINUTE, 0, @Tavl) - DATEDIFF(MINUTE, @Tu, SYSDATETIME()))*@tienmay/60,1) as float),
		TimeAvailible=0,
		TimeUsed=NULL,
		DeviceID=NULL,
		StatusCustomer=0,
		Actualtimeavl=null
	WHERE CustomerID=@cid
END
GO

go
------Thời gian sử dụng thực tế của khách
CREATE OR ALTER PROC AccCusActualTimeAvl(@cid NVARCHAR(100))
AS
BEGIN
	 DECLARE @Tavl DATETIME
	 SELECT @Tavl=TimeAvailible
	 FROM dbo.ACCOUNTCUSTOMER
	 WHERE CustomerID =@cid

	 UPDATE dbo.ACCOUNTCUSTOMER
	 SET
		ActualTimeAvl=(CONVERT(varchar, @Tavl, 108) + ' ' + CONVERT(VARCHAR, DAY(@Tavl)-1)) + 'ngay ' 
		+CONVERT(VARCHAR, MONTH(@Tavl)-1) + 'thang '+ CONVERT(VARCHAR, YEAR(@Tavl) - 1900) +'nam'
	 WHERE CustomerID =@cid
END
GO

----------------------------------------------------------------------FUNCTION------------------------------------------------------------------------------------
----------------------------------------------------------------------Quốc Thắng------------------------------------------------------------------------------------
--Tìm ra nhân viên theo từ khoá đã cho
CREATE or ALTER FUNCTION Func_SearchEmployeesWithName (@search_name nvarchar(100))
RETURNS TABLE AS
	RETURN SELECT * FROM dbo.EMPLOYEE
		   WHERE FullName LIKE '%' + @search_name + '%'
GO

--Tìm ra hình ảnh nhân viên lúc điểm danh xong bằng EmpID (CalendarFrm)
CREATE or ALTER FUNCTION Func_TakePicWhenCheckin (@EmpID varchar(100))
RETURNS TABLE AS
	RETURN SELECT Picture, FullName
		   FROM EMPLOYEE
	       WHERE EMPLOYEE.ID = @EmpID;
GO
--Tìm ra thông tin của nhân viên lúc điểm danh xong bằng EmpID (CalendarFrm)
CREATE or ALTER FUNCTION Func_TakeInfoWhenCheckin (@EmpID varchar(100))
RETURNS TABLE AS
	RETURN SELECT Id, FullName, Gender, Phone, IdentityNumber
		   FROM EMPLOYEE
	       WHERE EMPLOYEE.ID = @EmpID;
GO

--Tìm ra thông tin của nhân viên đang làm việc trong ca
CREATE or ALTER FUNCTION Func_CheckEmpWorking ()
RETURNS TABLE AS
	RETURN SELECT IDEmployee
		   FROM TIMEKEEPING
	       WHERE TIMEKEEPING.CheckOut is null;
GO

--Tìm ra thông tin cá nhân và chỉnh sửa
CREATE or ALTER FUNCTION Func_TakeMyInfo(@EmpID varchar(100))
RETURNS TABLE AS
	RETURN SELECT FullName, Gender, Birthday, Phone, IdentityNumber, Email
		   FROM EMPLOYEE
	       WHERE EMPLOYEE.ID = @EmpID;
GO

--Tìm ra tên và hình
CREATE or ALTER FUNCTION Func_TakeNameandPic(@EmpID varchar(100))
RETURNS TABLE AS
	RETURN SELECT FullName, Picture
		   FROM EMPLOYEE
	       WHERE EMPLOYEE.ID = @EmpID;
GO

----------------------------------------------------------------------Phước Đăng-----------------------------------------------------------------------------------
--1.
GO
CREATE or ALTER FUNCTION Func_CheckAvailableDevices (@devid nvarchar(100))
RETURNS table AS
	return SELECT * FROM DEVICES WHERE DeviceID = @devid and DStatus = N'Offline';
GO

--2.
CREATE or ALTER FUNCTION Func_CheckDevicesFromUser (@devid nvarchar(100))
RETURNS table AS
	return SELECT a.CustomerID,a.DeviceID,d.DStatus 
		FROM DEVICES d, ACCOUNTCUSTOMER a 
		WHERE d.DeviceID = @devid 
		and a.DeviceID = d.DeviceID;
GO

--3.
GO
CREATE or ALTER FUNCTION Func_CheckDevicesFromUser2 (@devid nvarchar(100))
RETURNS table AS
	return SELECT a.CustomerID,a.DeviceID,d.DStatus 
		FROM DEVICES d, ACCOUNTCUSTOMER a 
		WHERE d.DeviceID = @devid 
		and a.DeviceID = d.DeviceID
		and DStatus = N'Offline';
GO