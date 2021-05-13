USE DBMS_FinalProject
GO
----------------------------------------------------------------------TRIGGER------------------------------------------------------------------------------------
----------------------------------------------------------------------Phước Đăng------------------------------------------------------------------------------------
--1. Khi sửa lại máy Super vip thì không được nhập CPU là Intel Core i3 hoặc Core i5
CREATE TRIGGER Add_Device_CPU_condition ON DEVICETYPE
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

--Test Trigger
--TH Sai
--UPDATE DEVICETYPE  SET CPU = 'Core i3' WHERE TypeID = 'Super Vip'
--UPDATE DEVICETYPE  SET CPU = 'Core i5' WHERE TypeID = 'Super Vip'
--TH Đúng
--UPDATE DEVICETYPE  SET CPU = 'Core i9' WHERE TypeID = 'Super Vip'

--2.Khi sửa lại máy Vip thì Keyboard của máy Thường không được trùng với máy Vip 
CREATE TRIGGER Add_Device_Keyboard_Condition ON DEVICETYPE
AFTER INSERT, UPDATE AS
--declare @TypeID_Vip nvarchar(100), @TypeID_Thuong nvarchar(100),
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
	Where TypeID = 'Thuong'

	Select @Keyboard_Thuong_Input = inserted.KeyBoard
	From DEVICETYPE,inserted
	Where DEVICETYPE.TypeID = inserted.TypeID
	and inserted.TypeID = 'Thuong'

	if (@Keyboard_Vip_Default = @Keyboard_Thuong_Input or  @Keyboard_Vip_Input = @Keyboard_Thuong_Default)
	BEGIN
	PRINT ('Invalid Keyboard !!!')
	rollback
	END
END;
--Test Trigger
--Keyboard hiện tại của Vip là Razer Huntsman Mini Mercurycòn Thường là Razer Blackwidow Lite
--Trường hợp sai
--UPDATE DEVICETYPE  SET KeyBoard = 'Razer Huntsman Mini Mercury' WHERE TypeID = 'Thuong'

--3. Ram phải luôn bắt buộc là DDR4, DDR3, DDR2
CREATE TRIGGER Add_Device_RAM_condition ON DEVICETYPE
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
--4. Trigger kiểm tra người dùng không được dùng máy đang bảo trì hoặc đang được sử dụng
CREATE Trigger Check_Available_Computer ON ACCOUNTCUSTOMER
AFTER INSERT, UPDATE 
AS
declare @DeviceID nvarchar(100),@de nvarchar(100)
BEGIN
	SELECT @DeviceID = inserted.DeviceID
	FROM inserted

	SELECT @de = DStatus
	FROM DEVICES
	where DeviceID = @DeviceID

	if (@de != 'Not in use')
	BEGIN
	PRINT 'This computer is in use or in repair !!!'
	rollback
	END
END;

--SELECT DISTINCT TypeID from DEVICES
----------------------------------------------------------------------Hoàng Vũ------------------------------------------------------------------------------------
--Số CMND phải có hơn 8 kí tự và nhỏ hơn 13 kí tự (9 <= CMND <= 12)
--drop trigger TG_FormatIdentityNumber
create trigger TG_FormatIdentityNumber on EMPLOYEE
for insert, update as
declare @ID nvarchar(100), @Identity nvarchar(100)
begin
	--Lấy ra mã ID của nhân viên vừa nhập
	select @ID = inserted.ID
	from inserted

	--Lấy ra số CMND của ID vừa nhập
	select @Identity = IdentityNumber
	from EMPLOYEE
	where EMPLOYEE.ID = @ID

	if(len(@Identity) <= 12 and len(@Identity) >= 9)
	begin
		print ('IdentityNumber must have more than 8 characters!!!')
		rollback
	end
end;

--Nhân viên phải ít nhất ĐỦ 18 tuổi
create trigger TG_EmpAtLeast18YO on EMPLOYEE
for insert, update as
declare @ID nvarchar(100), @Bdate date
begin
	
	--Lấy ra mã ID của nhân viên vừa nhập
	select @ID = inserted.ID
	from inserted

	--Lấy ra ngày sinh nhật của ID vừa nhập
	select @Bdate = Birthday
	from EMPLOYEE
	where EMPLOYEE.ID = @ID

	if(datediff(dd,@Bdate,getdate()) != 0)
	begin
		print('Employee has to be 18 year old!!!')
		rollback
	end
end;

--Số điện thoại nhân viên phải từ 10 đến 11 chữ số
--drop trigger TG_FormatPhoneNumber
create trigger TG_FormatPhoneNumber on EMPLOYEE
for insert, update as
declare @ID nvarchar(100), @Phone int
begin
	--Lấy ra mã ID của nhân viên vừa nhập
	select @ID = inserted.ID
	from inserted

	--Lấy ra số CMND của ID vừa nhập
	select @Phone = Phone
	from EMPLOYEE
	where EMPLOYEE.ID = @ID

	if(len(@Phone) <= 11 and len(@phone) >= 10)
	begin
		print ('IdentityNumber must have more than 8 characters!!!')
		rollback
	end
end;




----------------------------------------------------------------------PROCEDURE------------------------------------------------------------------------------------
----------------------------------------------------------------------Phước Đăng------------------------------------------------------------------------------------
--1. Stored-Procedure hiển thị thông tin của các khách hàng đang chơi máy Vip / Super Vip / Thuong
Go
CREATE PROC ShowInfoCustomerGroupByTypeID @TypeID nvarchar(100)
as
begin
select a.UserName,a.PassWord,a.TimeAvailible,a.TimeUsed,a.CustomerID,a.DeviceID,a.StatusCustomer
from ACCOUNTCUSTOMER a, DEVICES d
where a.DeviceID = d.DeviceID
and d.TypeID = @TypeID
end;
--go
--EXEC ShowInfoCustomerGroupByTypeID 'Thuong'
--2.
CREATE PROC Insert_Device (@devid nvarchar(100),@type nvarchar(100),@status nvarchar(100))
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
END;

--3. 
CREATE PROC DeleteDeviceByID (@devID nvarchar(100))
AS
BEGIN
UPDATE  ACCOUNTCUSTOMER SET ACCOUNTCUSTOMER.DeviceID = null
WHERE ACCOUNTCUSTOMER.DeviceID = @devID
 DELETE FROM dbo.DEVICES
 WHERE DEVICES.DeviceID = @devID
END;

--4. 
create PROC Edit_Device (@devid nvarchar(100),@type nvarchar(100),@status nvarchar(100))
AS
BEGIN
	UPDATE dbo.DEVICES
	SET 
		TypeID=@type,
		DStatus=@status
	WHERE DeviceID=@devid
END;
go

----------------------------------------------------------------------FUNCTION------------------------------------------------------------------------------------
----------------------------------------------------------------------Thắng------------------------------------------------------------------------------------
--Tìm ra nhân viên theo từ khoá đã cho
--DROP FUNCTION Func_SearchEmployeesWithName
CREATE FUNCTION Func_SearchEmployeesWithName (@search_name nvarchar(100))
RETURNS TABLE AS
	RETURN SELECT * FROM dbo.EMPLOYEE
		   WHERE FullName LIKE '%' + @search_name + '%'
GO
--SELECT * FROM dbo.Func_SearchEmployeesWithName(N'Thành')					--chạy function

--Tìm ra hình ảnh nhân viên lúc điểm danh xong bằng EmpID (CalendarFrm)
--DROP FUNCTION Func_TakePicWhenCheckin
CREATE FUNCTION Func_TakePicWhenCheckin (@EmpID varchar(100))
RETURNS TABLE AS
	RETURN SELECT Picture, FullName
		   FROM EMPLOYEE
	       WHERE EMPLOYEE.ID = @EmpID;
--SELECT * FROM dbo.Func_TakePicWhenCheckin('NV1')

--Tìm ra thông tin của nhân viên lúc điểm danh xong bằng EmpID (CalendarFrm)
--DROP FUNCTION Func_TakeInfoWhenCheckin
CREATE FUNCTION Func_TakeInfoWhenCheckin (@EmpID varchar(100))
RETURNS TABLE AS
	RETURN SELECT Id, FullName, Gender, Phone, IdentityNumber
		   FROM EMPLOYEE
	       WHERE EMPLOYEE.ID = @EmpID;
--SELECT * FROM dbo.Func_TakeInfoWhenCheckin('NV1')





----------------------------------------------------------------------Phước Đăng-----------------------------------------------------------------------------------
--1.
CREATE FUNCTION Func_CheckAvailableDevices (@devid nvarchar(100))
RETURNS table AS
	return SELECT * FROM DEVICES WHERE DeviceID = @devid and DStatus = 'Not in use';

--SELECT * FROM dbo.Func_CheckAvailableDevice('MAY03') Check01
--SELECT * FROM dbo.Func_CheckAvailableDevice('MAY01') Check01
--3.
CREATE FUNCTION Func_CheckDevicesFromUser (@devid nvarchar(100))
RETURNS table AS
	return SELECT a.CustomerID,a.DeviceID,d.DStatus 
		FROM DEVICES d, ACCOUNTCUSTOMER a 
		WHERE d.DeviceID = @devid 
		and a.DeviceID = d.DeviceID
		and DStatus = 'In use';
CREATE FUNCTION Func_CheckDevicesFromUser2 (@devid nvarchar(100))
RETURNS table AS
	return SELECT a.CustomerID,a.DeviceID,d.DStatus 
		FROM DEVICES d, ACCOUNTCUSTOMER a 
		WHERE d.DeviceID = @devid 
		and a.DeviceID = d.DeviceID
		and DStatus = 'Not in use';








-----------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------Sự cố-------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------------------------------------
--USE DBMS_FinalProject 
--GO
--    -- Turn recursive triggers OFF in the database. 
--      ALTER DATABASE DBMS_FinalProject    
--      SET RECURSIVE_TRIGGERS OFF 
--GO
