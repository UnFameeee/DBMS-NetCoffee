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


CREATE TABLE WORKSHIFT
(
	IDEmployee NVARCHAR(100),
	CheckIn DATETIME,
	CheckOut DATETIME
	FOREIGN KEY (IDEmployee) REFERENCES dbo.EMPLOYEE(IDEmployee)
	PRIMARY KEY (IDEmployee, CheckIn)
)

CREATE TABLE SALARY
(
	IDEmployee NVARCHAR(100),
	MonthWork INT,
	YearWork INT CONSTRAINT CHK_Month CHECK (YearWork >= 0),
	Reward REAL DEFAULT 0,									
	Fine REAL DEFAULT 0,
	NumberofWorkShift INT DEFAULT 0,
	SalaryEmployee REAL DEFAULT 0,
	PRIMARY KEY (IDEmployee, MonthWork)
)
GO

CREATE PROCEDURE PRC_CheckIn @IDEmployee NVARCHAR(100)
AS
BEGIN
	INSERT INTO dbo.WORKSHIFT (IDEmployee, CheckIn) VALUES (@IDEmployee, GETDATE())
END
GO
CREATE PROCEDURE PRC_CheckOut @IDEmployee NVARCHAR(100)
AS
BEGIN
	UPDATE WORKSHIFT SET CheckOut = GETDATE() WHERE IDEmployee = @IDEmployee
END
GO
CREATE PROCEDURE PRC_CheckIDEmployee @IDEmployee NVARCHAR(100)
AS
BEGIN
	SELECT * FROM EMPLOYEE WHERE IDEmployee = @IDEmployee
END
GO
CREATE PROCEDURE PRC_CheckIDEmployeeWorking @IDEmployee NVARCHAR(100)
AS
BEGIN
	SELECT * FROM WORKSHIFT WHERE IDEmployee = @IDEmployee
END
GO
CREATE TRIGGER TRG_RewardFineCheckOut ON dbo.WORKSHIFT
AFTER UPDATE
AS
BEGIN
	DECLARE @iIDEmployee NVARCHAR(100), @Minute INT
	SELECT @iIDEmployee = IDEmployee, @Minute = DATEDIFF(MINUTE, CheckIn, CheckOut)
	FROM  Inserted
	
	DECLARE @iNumberofWorkShift INT,  @iMonthWork INT, @iYearWork INT
	SELECT @iNumberofWorkShift = NumberofWorkShift, @iMonthWork = MonthWork, @iYearWork = YearWork
	FROM dbo.SALARY
	WHERE IDEmployee = @iIDEmployee
	
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

	IF (@iNumberofWorkShift >= 30 AND @Minute >= 480)
		SET @Reward = @Reward * 1.1

	UPDATE dbo.SALARY
	SET Reward = Reward + @Reward / 60, Fine = Fine + @Fine / 60
	WHERE @iIDEmployee = IDEmployee AND @iMonthWork = MonthWork AND @iYearWork = YearWork
END
GO


CREATE TRIGGER TRG_SalaryCheckOut ON dbo.WORKSHIFT
AFTER UPDATE
AS
BEGIN
	DECLARE @iIDEmployee NVARCHAR(100), @iCheckIN DATETIME, @iCheckOut DATETIME, @iNumberofWorkShift INT
	SELECT @iIDEmployee = Inserted.IDEmployee, @iCheckIN = Inserted.CheckIn, @iCheckOut = Inserted.CheckOut
	FROM Inserted

	DECLARE @CheckIDSalary INT
	SELECT @CheckIDSalary = COUNT(*)
	FROM dbo.SALARY
	WHERE @iIDEmployee = dbo.SALARY.IDEmployee AND MONTH(@iCheckOut) = MonthWork AND YEAR(@iCheckOut) = YearWork

	DECLARE @iReward INT, @iFine INT
	SELECT @iReward = Reward, @iFine = Fine, @iNumberofWorkShift = NumberofWorkShift
	FROM dbo.SALARY
	WHERE @iIDEmployee = dbo.SALARY.IDEmployee AND MONTH(@iCheckOut) = MonthWork AND YEAR(@iCheckOut) = YearWork

	DECLARE @iEmployeeType INT
	SELECT @iEmployeeType = WorkID
	FROM dbo.EMPLOYEE 
	WHERE @iIDEmployee = dbo.EMPLOYEE.IDEmployee	

	DECLARE @CoefficientsSalary REAL
	SELECT @CoefficientsSalary = CoefficientsSalary
	FROM dbo.JOB
	WHERE @iEmployeeType = dbo.JOB.WorkID

	DECLARE @Wages REAL
	--Nên chỉnh sửa lại nếu có ca làm
	IF (DATEPART(HOUR, @iCheckIN) >= 0 AND DATEPART(HOUR, @iCheckIN) <= 8)										--Làm giờ ban đêm
		SET @Wages = 8 * @CoefficientsSalary * 20000 * 1.5
	ELSE
		SET @Wages = 8 * @CoefficientsSalary * 20000

	DECLARE @SalarybyPosition INT
	SET @SalarybyPosition = @iNumberofWorkShift * @Wages + (@iReward - @iFine) * 30000							--Set tiền lương
	
	UPDATE dbo.SALARY
	SET SalaryEmployee = @SalarybyPosition
	WHERE dbo.SALARY.IDEmployee = @iIDEmployee AND dbo.SALARY.MonthWork = MONTH(@iCheckOut) AND dbo.SALARY.YearWork = YEAR(@iCheckOut)
END
GO


CREATE TRIGGER TRG_SalaryCheckIn ON dbo.WORKSHIFT
AFTER INSERT
AS
BEGIN
	DECLARE @iIDEmployee NVARCHAR(100), @iCheckIN DATETIME
	SELECT @iIDEmployee = Inserted.IDEmployee, @iCheckIN = Inserted.CheckIn
	FROM Inserted

	DECLARE @CheckIDSalary INT
	SELECT @CheckIDSalary = COUNT(*)
	FROM dbo.SALARY
	WHERE @iIDEmployee = dbo.SALARY.IDEmployee AND MONTH(@iCheckIn) = MonthWork AND YEAR(@iCheckIn) = YearWork

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
	UPDATE dbo.SALARY
	SET NumberofWorkShift = NumberofWorkShift + 1
	WHERE @iIDEmployee = IDEmployee AND MONTH(@iCheckIn) = MonthWork AND YEAR(@iCheckIn) = YearWork
END