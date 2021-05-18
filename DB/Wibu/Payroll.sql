CREATE DATABASE Payroll
GO
USE Payroll
GO

CREATE TABLE JOB 
(
	WorkID nvarchar(100) PRIMARY KEY,				--Mã Công Việc (QL, NV, LC)
	CoefficientsSalary real,						--Hệ Số Lương (QL: x2, NV: x1, LC: x1.5)
	JobDetail nvarchar(100)							--Chi tiết công việc: (QL: Quản Lý, NV: Nhân Viên, LC: Lao Công)
)
INSERT INTO dbo.JOB
(
    WorkID,
    CoefficientsSalary,
    JobDetail
)
VALUES
(   N'1', -- WorkID - nvarchar(100)
    0.0, -- CoefficientsSalary - real
    N'1'  -- JobDetail - nvarchar(100)
    )
CREATE TABLE EMPLOYEE 
(
	IDEmployee nvarchar(100) PRIMARY KEY,			  --ID nhân viên									
	FullName nvarchar(100) not null,				    --Họ Tên
	Gender nvarchar(10),							          --Giới tính
	Birthday date,									            --Ngày sinh
	Phone int,										              --SĐT
	IdentityNumber nvarchar(100) not null,			--số CMND
	StatusEmployee nvarchar(100),
	Email nvarchar(100),
	WorkID nvarchar(100) references JOB(WorkID)	--MãCV
)
INSERT INTO dbo.EMPLOYEE
(
    IDEmployee,
    FullName,
    Gender,
    Birthday,
    Phone,
    IdentityNumber,
    StatusEmployee,
    Email,
    WorkID
)
VALUES
(   N'1',       -- IDEmployee - nvarchar(100)
    N'1',       -- FullName - nvarchar(100)
    N'1',       -- Gender - nvarchar(10)
    GETDATE(), -- Birthday - date
    02121,         -- Phone - int
    N'1',       -- IdentityNumber - nvarchar(100)
    N'1',       -- StatusEmployee - nvarchar(100)
    N'1',       -- Email - nvarchar(100)
    N'1'        -- WorkID - nvarchar(100)
    )
CREATE TABLE WORKSHIFT
(
	ShiftID nvarchar(100) PRIMARY KEY,						--Ca làm việc (1: 0h-8h // 2: 8h-16h // 3: 16h-0h)
	TimeBegin time not null,						--Thời gian bắt đầu
	TimeEnd time not null							--Thời gian kết thúc (thêm 1 trigger ràng buộc tgian bắt đầu < tgian kết thúc)
)
INSERT INTO dbo.WORKSHIFT
(
    ShiftID,
    TimeBegin,
    TimeEnd
)
VALUES
(   N'2',        -- ShiftID - nvarchar(100)
    '23:15:00', -- TimeBegin - time
    '00:15:00'  -- TimeEnd - time
    )
--*Tạo bảng Làm Việc (QT)
CREATE TABLE WORKS 
(
	ID nvarchar(100) references EMPLOYEE(IDEmployee),									--ID nhân viên làm việc
	ShiftID nvarchar(100) references WORKSHIFT(ShiftID),											--Ca làm việc
	TotalTimeWork time	DEFAULT N'00:00:00'																--Thời gian làm việc (Tao nghĩ này nên để int)
	PRIMARY KEY(ID,ShiftID),
)
INSERT INTO dbo.WORKS
(
    ID,
    ShiftID,
    TotalTimeWork
)
VALUES
(   N'1',       -- ID - nvarchar(100)
    N'2',       -- ShiftID - nvarchar(100)
    '16:12:30' -- TotalTimeWork - time
    )
CREATE TABLE TIMEKEEPING
(
	IDEmployee NVARCHAR(100),															--ID nhân viên
	CheckIn DATETIME,																	--Thời gian check in
	CheckOut DATETIME																	--Thời gian check out
	FOREIGN KEY (IDEmployee) REFERENCES dbo.EMPLOYEE(IDEmployee)
	PRIMARY KEY (IDEmployee, CheckIn)
)
--Tạo bảng lương nhân viên
CREATE TABLE SALARY
(
	IDEmployee NVARCHAR(100),															--ID nhân viên
	MonthWork INT,																		--Tháng của lương
	YearWork INT,																		--Năm của lương
	Reward REAL DEFAULT 0,																--Thưởng	
	Fine REAL DEFAULT 0,																--Phạt
	NumberofWorkShift INT DEFAULT 0,													--Số ca làm
	SalaryEmployee REAL DEFAULT 0,														--Lương nhân viên
	PRIMARY KEY (IDEmployee, MonthWork, YearWork)
)
GO
--PROCEDURE show tiền lương
CREATE PROCEDURE USP_ShowSalary
AS
BEGIN
	SELECT * FROM SALARY
END
GO
--PROCEDURE đưa toàn bộ điểm danh
CREATE PROCEDURE USP_ShowFullTimeKeeping 
AS
BEGIN
	SELECT * FROM TIMEKEEPING
END
GO
--PROCEDURE khi nhân viên check in thêm vào bảng WORK
CREATE PROCEDURE USP_CheckIn @IDEmployee NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.TIMEKEEPING (IDEmployee, CheckIn) VALUES (@IDEmployee, GETDATE())					--Thêm vào bảng WORK
END
GO
--PROCEDURE khi nhân viên check out update bảng WORK
CREATE PROCEDURE USP_CheckOut @IDEmployee NVARCHAR(100)
AS
BEGIN
	UPDATE TIMEKEEPING SET CheckOut = GETDATE() WHERE IDEmployee = @IDEmployee AND CheckOut IS NULL		--Thay đổi chỉnh sửa bảng WORK
END
GO
--PROCEDURE kiểm tra ID nhân viên có tồn tại hay không
CREATE PROCEDURE USP_CheckIDEmployee @IDEmployee NVARCHAR(100)
AS
BEGIN
	SELECT * FROM EMPLOYEE WHERE IDEmployee = @IDEmployee												--SELECT * để kiểm tra tồn tại của nhân viên
END
GO
--PROCEDURE kiểm tra nhân viên có đang trong ca làm hay không
CREATE PROCEDURE USP_CheckIDEmployeeWorking @IDEmployee NVARCHAR(100)
AS
BEGIN
	SELECT * FROM TIMEKEEPING WHERE IDEmployee = 1 AND CheckOut IS NULL					--SELECT * để kiểm tra nhân viên có đi làm hay không
END
GO
--TRIGGER không cho nhân viên check in nếu chưa tới giờ đi làm
CREATE TRIGGER UTG_WorkShiftCheckIn ON dbo.TIMEKEEPING
AFTER INSERT
AS
BEGIN
	--Lấy id nhân viên và thời gian check in của nhân viên đó
	DECLARE @iIDEmployee NVARCHAR(100), @iCheckIN DATETIME
	SELECT @iIDEmployee = Inserted.IDEmployee, @iCheckIN = Inserted.CheckIn
	FROM Inserted
	--Lấy ca làm của nhân viên
	DECLARE @WorkShift INT
	SELECT @WorkShift = ShiftID
	FROM dbo.WORKSHIFT
	WHERE DATEPART(HOUR,dbo.WORKSHIFT.TimeBegin) = DATEPART(HOUR,@iCheckIn)				--Nếu trễ 1 tiếng so với ca làm thì không được check in
	--Kiểm tra trong bảng ca có đúng ca làm của nhân viên đang check in không?
	DECLARE @CountID INT
	SELECT @CountID = COUNT(*)
	FROM dbo.WORKS
	WHERE @WorkShift = dbo.WORKS.ShiftID AND @iIDEmployee = dbo.WORKS.ID
	--Kiểm tra ca làm của nhân viên
	IF (@CountID < 1)
	BEGIN
		PRINT 'Chua toi ca lam nhan vien khong the check in'
		ROLLBACK
	END
END
GO
--TRIGGER thay đổi thưởng phạt khi check out tan làm sớm hoặc muộn để tính tiền thưởng phạt
CREATE TRIGGER UTG_RewardFineCheckOut ON dbo.TIMEKEEPING
AFTER UPDATE
AS
BEGIN
	--Lấy ID và thời gian check out trừ thời gian check in để kiểm tra xem có vượt quá thời gian làm hoặc thiếu so với thời gian làm của 1 ca
	DECLARE @iIDEmployee NVARCHAR(100), @Minute INT
	SELECT @iIDEmployee = IDEmployee, @Minute = DATEDIFF(MINUTE, CheckIn, CheckOut)
	FROM  Inserted
	--Lấy số ca làm và thời gian tháng năm của nhân viên trong bảng lương
	DECLARE @iNumberofWorkShift INT,  @iMonthWork INT, @iYearWork INT
	SELECT @iNumberofWorkShift= NumberofWorkShift, @iMonthWork = MonthWork, @iYearWork = YearWork
	FROM dbo.SALARY
	WHERE IDEmployee = @iIDEmployee
	--Nếu thời gian làm không đủ thì cứ mỗi 15 phút sẽ tính vào tiền phạt và ngược lại thời gian hơn trong ca làm cứ mỗi 15 phút sẽ được tính vào tiền thưởng
	DECLARE @Reward REAL, @Fine REAL 
	IF (@Minute >= 480)
	BEGIN
		SET @Reward = @Minute % 15
		SET @Fine = 0
	END
	ELSE IF (@Minute < 480)
	BEGIN
		SET @Fine = @Minute % 15
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

--TRIGGER cập nhật thay đổi bảng SALARY khi nhân viên check out
CREATE TRIGGER UTG_SalaryCheckOut ON dbo.TIMEKEEPING
AFTER UPDATE
AS
BEGIN
	--Lấy ID, thời gian check in, thời gian check out của nhân viên
	DECLARE @iIDEmployee NVARCHAR(100), @iCheckIn DATETIME, @iCheckOut DATETIME
	SELECT @iIDEmployee = Inserted.IDEmployee, @iCheckIn = Inserted.CheckIn, @iCheckOut = Inserted.CheckOut
	FROM Inserted
	--Lấy số thưởng, phạt và số ca làm của nhân viên đó
	DECLARE @iReward INT, @iFine INT, @iNumberofWorkShift INT	
	SELECT @iReward = Reward, @iFine = Fine, @iNumberofWorkShift = NumberofWorkShift
	FROM dbo.SALARY
	WHERE @iIDEmployee = dbo.SALARY.IDEmployee AND MONTH(@iCheckOut) = MonthWork AND YEAR(@iCheckOut) = YearWork
	--Lấy chức vụ của nhân viên
	DECLARE @iEmployeeType INT
	SELECT @iEmployeeType = WorkID
	FROM dbo.EMPLOYEE 
	WHERE @iIDEmployee = dbo.EMPLOYEE.IDEmployee	
	--Lấy hệ số của nhân viên dựa trên loại của nhân viên
	DECLARE @CoefficientsSalary REAL
	SELECT @CoefficientsSalary = CoefficientsSalary
	FROM dbo.JOB
	WHERE @iEmployeeType = dbo.JOB.WorkID
	--Lấy ca làm của nhân viên
	DECLARE @ShiftID INT
	SELECT @ShiftID = dbo.WORKSHIFT.ShiftID
	FROM dbo.WORKSHIFT, dbo.WORKS
	WHERE dbo.WORKS.ID = @iIDEmployee AND dbo.WORKSHIFT.ShiftID = dbo.WORKS.ShiftID AND DATEPART(HOUR,dbo.WORKSHIFT.TimeBegin) <= DATEPART(HOUR,@iCheckIn) AND DATEDIFF(HOUR,dbo.WORKSHIFT.TimeBegin, @iCheckIn) < 8
	--Tính lương của nhân viên
	DECLARE @Wages REAL
	IF (@ShiftID = 1)															--Làm giờ ban đêm từ 0h đến 8h
		SET @Wages = 8 * @CoefficientsSalary * 20000 * 1.5
	ELSE																		--Những giờ khác 0h đến 8h
		SET @Wages = 8 * @CoefficientsSalary * 20000

	DECLARE @SalarybyPosition INT
	SET @SalarybyPosition = @iNumberofWorkShift* @Wages + (@iReward - @iFine) * 30000							--Set tiền lương
	--Cập nhật thay đổi lương nhân viên
	UPDATE dbo.SALARY
	SET SalaryEmployee = @SalarybyPosition
	WHERE dbo.SALARY.IDEmployee = @iIDEmployee AND dbo.SALARY.MonthWork = MONTH(@iCheckOut) AND dbo.SALARY.YearWork = YEAR(@iCheckOut)
END
GO

--Thay đổi số ca làm nhân viên khi nhân viên check in
CREATE TRIGGER UTG_SalaryCheckIn ON dbo.TIMEKEEPING
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