CREATE DATABASE Payroll
GO
USE Payroll
GO

CREATE TABLE EMPLOYEE 
(
	IDEmployee nvarchar(100) PRIMARY KEY,					--ID nhân viên
	DisplaynameEmployee nvarchar(100) not null,				--Họ Tên
	EmployeeType INT										--0 là quản lý, 1 là nhân viên, 2 là lao công
)
GO
CREATE TABLE WORK
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
	MonthWork INT CHECK (MonthWork >= 1 AND MonthWork <= 12),
	YearWork INT CHECK (YearWork >= 0),
	Reward REAL DEFAULT 0,									
	Punish REAL DEFAULT 0,
	NumberofWorkShift INT DEFAULT 0,
	SalaryEmployee REAL DEFAULT 0,
	PRIMARY KEY (IDEmployee, MonthWork)
)
GO

CREATE TRIGGER RewardPunishCheckOut ON dbo.WORK
AFTER UPDATE
AS
BEGIN
	DECLARE @iIDEmployee NVARCHAR(100), @Second INT
	SELECT @iIDEmployee = IDEmployee, @Second = DATEDIFF(SECOND, CheckIn, CheckOut)
	FROM  Inserted
	
	DECLARE @iNumberofWorkShift INT,  @iMonthWork INT, @iYearWork INT
	SELECT @iNumberofWorkShift = NumberofWorkShift, @iMonthWork = MonthWork, @iYearWork = YearWork
	FROM dbo.SALARY
	WHERE IDEmployee = @iIDEmployee
	

	DECLARE @Reward FLOAT, @Punish FLOAT 
	IF (@Second >= 28800)
	BEGIN
		SET @Reward = @Second - 28800
		SET @Punish = 0
	END
	ELSE IF (@Second < 28800)
	BEGIN
		SET @Punish = 28800 - @Second
		SET @Reward = 0
	END

	IF (@iNumberofWorkShift >= 30 AND @Second >= 28800)
		SET @Reward = @Reward * 1.1

	UPDATE dbo.SALARY
	SET Reward = Reward + @Reward / 3600, Punish = Punish + @Punish / 3600
	WHERE @iIDEmployee = IDEmployee AND @iMonthWork = MonthWork AND @iYearWork = YearWork
END
GO


CREATE TRIGGER SalaryCheckOut ON dbo.WORK
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

	DECLARE @iReward INT, @iPunish INT
	SELECT @iReward = Reward, @iPunish = Punish, @iNumberofWorkShift = NumberofWorkShift
	FROM dbo.SALARY
	WHERE @iIDEmployee = dbo.SALARY.IDEmployee AND MONTH(@iCheckOut) = MonthWork AND YEAR(@iCheckOut) = YearWork

	DECLARE @iEmployeeType INT
	SELECT @iEmployeeType = EmployeeType
	FROM dbo.EMPLOYEE 
	WHERE @iIDEmployee = dbo.EMPLOYEE.EmployeeType	

	DECLARE @SalarybyPosition INT
	IF (@iEmployeeType = 0)
		SET @SalarybyPosition = @iNumberofWorkShift * 8 * 4000 + (@iReward - @iPunish) * 3000
	ELSE IF (@iEmployeeType = 1)
		SET @SalarybyPosition = @iNumberofWorkShift * 8 * 2000 + (@iReward - @iPunish) * 3000
	ELSE
		SET @SalarybyPosition = @iNumberofWorkShift * 8 * 3000 + (@iReward - @iPunish) * 3000
	
	IF (DATEPART(HOUR, @iCheckIN) >= 0 AND DATEPART(HOUR, @iCheckOut) <= 8)
		SET @SalarybyPosition = @SalarybyPosition * 1.5

	UPDATE dbo.SALARY
	SET SalaryEmployee = @SalarybyPosition
	WHERE dbo.SALARY.IDEmployee = @iIDEmployee AND dbo.SALARY.MonthWork = MONTH(@iCheckOut) AND dbo.SALARY.YearWork = YEAR(@iCheckOut)
END
GO
DROP TRIGGER dbo.InsertSalary
GO

CREATE TRIGGER SalaryCheckIn ON dbo.WORK
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
	WHERE @iIDEmployee = IDEmployee
END