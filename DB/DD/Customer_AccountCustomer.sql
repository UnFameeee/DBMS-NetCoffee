



---***********BIG NOTE:  CÁC BẢNG DƯỚI ĐÂY ĐÃ CÓ NHỮNG THUỘC TÍNH BỊ THAY ĐỔI, THÊM, XOÁ SO VỚI BẢNG TRONG DATABASE BAN ĐẦU !!!!!!!!!!!OK
--Khách hàng--
create table CUSTOMER
(
	CustomerID nvarchar(100) primary key,
	FullName nvarchar(100),
	PhoneNumber NVARCHAR(100),
	IdentityCardNumber NVARCHAR(100),												--số CMND
	MoneyCharged FLOAT																--số tiền nạp
)

CREATE TABLE DEVICETYPE
(
	TypeID nvarchar(100) PRIMARY KEY,
	CPU nvarchar(100) NOT NULL,
	RAM nvarchar(100) NOT NULL,
	PowerSupply nvarchar(100) NOT NULL,
	GraphicCard nvarchar(100) NOT NULL,
	Mainboard nvarchar(100) NOT NULL,
	DeviceCase nvarchar(100) NOT NULL,
	Monitor nvarchar(100) NOT NULL,
	Mouse nvarchar(100) NOT NULL,
	KeyBoard nvarchar(100) NOT NULL
)
CREATE TABLE DEVICES
(
	DeviceID nvarchar(100) PRIMARY KEY,												--số máy
	TypeID nvarchar(100) references DEVICETYPE(TypeID),								--loại máy (super vjp, vip, thường)
	DStatus nvarchar(100)															--tình trạng máy (đang đc sử dụng, đang đc bảo trì,....)
)

--Tài khoản khách hàng--
create table ACCOUNTCUSTOMER
(
	UserName nvarchar(100) PRIMARY KEY,
	PassWord nvarchar(100),
	TimeAvailible DATETIME DEFAULT 0,	--dựa vào số tiền nạp và id máy để tính thời gian			time tính theo giờ 
	TimeUsed DATETIME,		--thời gian đã dùng											
	CustomerID nvarchar(100) references CUSTOMER(CustomerID),					
	DeviceID nvarchar(100) references DEVICES(DeviceID),
	StatusCustomer int,
	AccMoney FLOAT DEFAULT 0, ----------- mới thêm vào + đổi tiền từ float thành int
	Actualtimeavl NVARCHAR(50)
)
---------------------------------------------------



--***:Stored Procedure 
--thêm mới khách hàng Cus
go
CREATE PROC Create_customer (@cid nvarchar(100),@ful nvarchar(100),@phn nvarchar(100),@icn nvarchar(50),@mon int)
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
--vi du tao 1 khach hang moi
EXECUTE dbo.Create_customer @cid = N'42', -- nvarchar(100)
                            @ful = N'duy', -- nvarchar(100)
                            @phn = N'3213', -- nvarchar(100)
                            @icn = N'42145', -- nvarchar(50)
                            @mon = 22220    -- int

go
--xoá một khách hàng Cus theo Cid
GO
CREATE PROC deleteById_customer (@cid nvarchar(100))
AS
BEGIN
 DELETE FROM dbo.CUSTOMER
 WHERE CustomerID=@cid
END;
GO
--vi du xoa khach hang
EXECUTE dbo.deleteById_customer @cid = N'43' -- nvarchar(100)

go
--chỉnh sửa thông tin khách hàng Cus theo Cid
go
CREATE PROC EditInfo_customer(@cid nvarchar(100),@ful nvarchar(100),@phn nvarchar(100),@icn nvarchar(50),@mon int)
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
--vi du edit thong tin khach hang
EXECUTE dbo.EditInfo_customer @cid = N'42', -- nvarchar(100)
                              @ful = N'duy duong', -- nvarchar(100)
                              @phn = N'4123', -- nvarchar(100)
                              @icn = N'44551', -- nvarchar(50)
                              @mon = 550    -- int

GO
go
--Khách hàng nạp tiền vào tài khoản Cus
go
CREATE PROC DepositBudget_customer(@cid nvarchar(100),@mon float)
AS
BEGIN
	UPDATE dbo.CUSTOMER
	SET 
		MoneyCharged=MoneyCharged+@mon
	WHERE CUSTOMER.CustomerID=@cid
END
GO
--vi du khach nap tien
EXECUTE dbo.DepositBudget_customer @cid = N'42', -- nvarchar(100)
                                   @mon = 1000  -- float


GO
-- tạo tài khoản AccCus
go
CREATE PROC Create_Accus (@un NVARCHAR(100),@pass NVARCHAR(100),@cid NVARCHAR(100))
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
--vi du tao account moi
dbo.Create_Accus @un = N'rante2',   -- nvarchar(100)
                 @pass = N'123', -- nvarchar(100)
                 @cid = N'42'   -- nvarchar(100)

go
--** Việc khách hàng nạp tiền vào Cus và Acus là 2 việc khác nhau vì 2 loại tiền này phục mục đích khác, 
--tiền của Cus là tiền chung có thể để nạp tiền giờ chơi hay order đồ ăn
--việc phân biệt này giúp cho việc tính toán số giờ chơi còn lại trong Acus trực quan hơn
--Khách hàng nạp tiền vào Account

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
--vi du 
EXECUTE dbo.DepositBudget_Accountcustomer @cid = N'kh1', -- nvarchar(100)
                                          @mon = 2000.0  -- float


go

---***Trigger
--khi Cus đăng nhập vào máy để bắt đầu chơi (1 là đang sử dụng - 0 là không sử dụng) dibu
go
GO
DECLARE @money INT;
SET @money = 7500;
DECLARE @sophut INT;
SET @sophut = 1440*370 + 75--@money*60/5000 24*60-1?=23h59
DECLARE @g Datetime;
SET @G = FORMAT(DATEADD(MINUTE, @sophut, '1900-01-01 00:00:00'), 'dd/MM/yyyy hh:mm:ss tt')
--lỡ người chơi nạp nhiều tiền tới mức là số giờ chơi tính theo ngày
SELECT CONVERT(varchar, @g, 108) + ' ' + CONVERT(VARCHAR, YEAR(@G) - 1900)
+ '/' + CONVERT(VARCHAR, MONTH(@G)) + '/' + CONVERT(VARCHAR, DAY(@G))
--vipppppp
--hh:mi:ss yy/mm/dd

GO
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
			SET DStatus=N'Đang sử dụng'
			WHERE DeviceID=@did

			SELECT @deT= dbo.DEVICES.TypeID
			FROM dbo.DEVICES
			WHERE dbo.DEVICES.DeviceID=@did
			
			DECLARE @tienmay FLOAT
			IF(@deT =N'Vip')
				SET @tienmay=7000
			ELSE IF(@deT =N'Super Vip')
				SET @tienmay=12000
			else set @tienmay =5000

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
--khi Cus logout khỏi máy
GO
CREATE OR ALTER PROC Userlogout_AccountCus (@cid NVARCHAR(100),@did NVARCHAR(100))
AS
BEGIN

	UPDATE dbo.DEVICES
	SET
		DStatus=N'Chưa sử dụng'
	WHERE DeviceID=@did

	DECLARE @tienmay FLOAT, @kieumay nvarchar(50)

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
	else set @tienmay =5000

	--RELOAD LAI CAI SQL DI
	UPDATE dbo.ACCOUNTCUSTOMER
	SET	
		AccMoney=AccMoney+CAST(ROUND((DATEDIFF(MINUTE, 0, @Tavl) - DATEDIFF(MINUTE, @Tu, SYSDATETIME()))*@tienmay/60,1) as float),
		TimeAvailible=0,
		TimeUsed=NULL,
		DeviceID=NULL,
		StatusCustomer=0
	WHERE CustomerID=@cid -- cuu di tran 9
END
--vi du
EXECUTE dbo.Userlogout_AccountCus @cid = N'kh6', -- nvarchar(100)
                                  @did = N'MAY03'  -- nvarchar(100)
GO	
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
		+CONVERT(VARCHAR, MONTH(@Tavl)-1) +'thang '+ CONVERT(VARCHAR, YEAR(@Tavl) - 1900) +'nam'
	 WHERE CustomerID =@cid
END
GO --help
SELECT SYSDATETIME()
--vi du
EXECUTE dbo.AccCusActualTimeAvl @cid = N'kh6' -- nvarchar(100)
--doned
