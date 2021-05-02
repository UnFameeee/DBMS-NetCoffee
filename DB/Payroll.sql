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
CREATE TABLE TIMEKEEPING
(
	IDEmployee NVARCHAR(100),
	MonthWork INT CHECK (MonthWork >= 1 AND MonthWork <= 12),
	YearWork INT CHECK (YearWork >= 0),
	Reward INT DEFAULT 0,									
	Punish INT DEFAULT 0,
	NumberofWorkShift INT DEFAULT 0,
	DoYouGotoWork BIT,											--Chỗ để điểm danh thôi :v
	PRIMARY KEY (IDEmployee, MonthWork, YearWork),
	FOREIGN KEY (IDEmployee) REFERENCES dbo.EMPLOYEE(IDEmployee)
)
GO
CREATE TABLE SALARY
(
	IDEmployee NVARCHAR(100),
	MonthWork INT,
	YearWork INT,
	SalaryEmployee REAL DEFAULT 0,
	PRIMARY KEY (IDEmployee, MonthWork),
	FOREIGN KEY (IDEmployee, MonthWork, YearWork) REFERENCES Timekeeping(IDEmployee, MonthWork, YearWork)
)
GO


CREATE TRIGGER UpdateRewardPunish ON dbo.TIMEKEEPING
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @NumberofWorkShift INT, @IDEmployee NVARCHAR(100), @MonthWork INT, @YearWork INT
	SELECT @NumberofWorkShift = Inserted.NumberofWorkShift,  @IDEmployee = Inserted.IDEmployee, @MonthWork = Inserted.MonthWork, @YearWork = Inserted.YearWork
	FROM Inserted
	--Mặc định số ca làm là 30 ca trong 1 tháng
	DECLARE @Reward INT, @Punish INT 
	IF (@NumberofWorkShift > 30)
		SET @Reward = @NumberofWorkShift - 30, @Punish = 0
	ELSE
		SET @Punish = 30 - @NumberofWorkShift, @Reward = 0

	UPDATE dbo.TIMEKEEPING
	SET Reward = @Reward, Punish = @Punish
	WHERE @IDEmployee = IDEmployee AND @MonthWork = MonthWork AND @YearWork = YearWork
END
GO

CREATE TRIGGER SalaryBasedonTimekeeping ON dbo.TIMEKEEPING
AFTER INSERT, UPDATE
AS
BEGIN
	DECLARE @iIDEmployee NVARCHAR(100), @iMonthWork INT, @iYearWork INT, @iReward INT, @iPunish INT
	SELECT @iIDEmployee = Inserted.IDEmployee, @iMonthWork = Inserted.MonthWork, @iYearWork = Inserted.YearWork, @iReward = Inserted.Reward, @iPunish = Inserted.Punish
	FROM Inserted

	DECLARE @iEmployeeType INT
	SELECT @iEmployeeType = EmployeeType
	FROM dbo.EMPLOYEE 
	WHERE @iIDEmployee = dbo.EMPLOYEE.EmployeeType	

	DECLARE @CheckIDSalary INT
	SELECT @CheckIDSalary = COUNT(*)
	FROM dbo.SALARY
	WHERE @iIDEmployee = dbo.SALARY.IDEmployee AND @iMonthWork = dbo.SALARY.MonthWork AND @iYearWork = dbo.SALARY.YearWork

	DECLARE @SalarybyPosition INT
	IF (@iEmployeeType = 0)
		SET @SalarybyPosition = 4000 + 30 * 8 * 2000 + (@iReward - @iPunish) * 3000 * 8
	ELSE IF (@iEmployeeType = 1)
		SET @SalarybyPosition = 2000 + 30 * 8 * 2000 + (@iReward - @iPunish) * 3000 * 8
	ELSE
		SET @SalarybyPosition = 3000 + 30 * 8 * 2000 + (@iReward - @iPunish) * 3000 * 8
	
	IF (@CheckIDSalary > 0)
		UPDATE dbo.SALARY
		SET SalaryEmployee = @SalarybyPosition 
		WHERE dbo.SALARY.IDEmployee = @iIDEmployee AND dbo.SALARY.MonthWork = @iMonthWork AND dbo.SALARY.YearWork = @iYearWork
	ELSE IF (@CheckIDSalary < 1)
		INSERT INTO dbo.SALARY
		(
		    IDEmployee,
		    MonthWork,
		    YearWork,
		    SalaryEmployee
		)
		VALUES
		(   @iIDEmployee,																				-- IDEmployee - nvarchar(100)
		    @iMonthWork,																				-- MonthWork - int
		    @iYearWork,																					-- YearWork - int
		    @SalarybyPosition																			-- SalaryEmployee - real
		)
END
GO

CREATE TRIGGER DeleteSalaryBasedonTimekeeping ON dbo.TIMEKEEPING
AFTER DELETE
AS
BEGIN
	DECLARE @dIDEmployee NVARCHAR(100), @dMonthWork INT, @dYearWork INT, @dNumberofWorkShift INT
	SELECT @dIDEmployee = Deleted.IDEmployee, @dMonthWork = Deleted.MonthWork, @dYearWork = Deleted.YearWork
	FROM Deleted

	DELETE FROM dbo.SALARY
	WHERE IDEmployee = @dIDEmployee AND MonthWork = @dMonthWork AND YearWork = @dYearWork
END