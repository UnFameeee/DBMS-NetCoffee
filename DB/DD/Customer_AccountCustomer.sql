



---***********BIG NOTE:  CÁC BẢNG DƯỚI ĐÂY ĐÃ CÓ NHỮNG THUỘC TÍNH BỊ THAY ĐỔI, THÊM, XOÁ SO VỚI BẢNG TRONG DATABASE BAN ĐẦU !!!!!!!!!!!
--Khách hàng--
create table CUSTOMER
(
	CustomerID nvarchar(100) primary key,
	FullName nvarchar(100),
	PhoneNumber NVARCHAR(100),
	IdentityCardNumber NVARCHAR(100),												--số CMND
	MoneyCharged FLOAT																--số tiền nạp
)

--Tài khoản khách hàng--
create table ACCOUNTCUSTOMER
(
	UserName nvarchar(100) PRIMARY KEY,
	PassWord nvarchar(100),
	TimeAvailible int,	--dựa vào số tiền nạp và id máy để tính thời gian			time tính theo giờ 
	TimeUsed INT,		--thời gian đã dùng											
	CustomerID nvarchar(100) references CUSTOMER(CustomerID),					
	DeviceID nvarchar(100) references DEVICES(DeviceID),
	AccMoney FLOAT, ----------- mới thêm vào + đổi tiền từ float thành int
	StatusCustomer int
)
go
--***:Stored Procedure 
--thêm mới khách hàng Cus
CREATE PROC Creat_customer (@cid nvarchar(100),@ful nvarchar(100),@phn nvarchar(100),@icn nvarchar(50),@mon int)
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
go
--xoá một khách hàng Cus theo Cid
GO
CREATE PROC deleteById_customer (@cid nvarchar(100))
AS
BEGIN
 DELETE FROM dbo.CUSTOMER
 WHERE CustomerID=@cid
END;
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
go
--** Việc khách hàng nạp tiền vào Cus và Acus là 2 việc khác nhau vì 2 loại tiền này phục mục đích khác, tiền của Cus là tiền chung có thể để nạp tiền giờ chơi hay order đồ ăn
--việc phân biệt này giúp cho việc tính toán số giơf chơi còn lại trong Acus trực quan hơn
--Khách hàng nạp tiền vào Account

go
CREATE PROC DepositBudget_Accountcustomer(@cid nvarchar(100),@mon float)
AS
BEGIN
	UPDATE dbo.ACCOUNTCUSTOMER
	SET 
	     AccMoney=AccMoney+@mon                    ---------- cột Accmoney mới thêm vào AccountCustomer để phân biệt với bên Customer
	FROM dbo.CUSTOMER,dbo.ACCOUNTCUSTOMER
	WHERE CUSTOMER.CustomerID=dbo.ACCOUNTCUSTOMER.CustomerID

	UPDATE dbo.CUSTOMER
	SET
	MoneyCharged=MoneyCharged-@mon
	FROM dbo.CUSTOMER,dbo.ACCOUNTCUSTOMER
	WHERE CUSTOMER.CustomerID=dbo.ACCOUNTCUSTOMER.CustomerID
END
go
-- tạo tài khoản AccCus
go
CREATE PROC Create_Accus (@un NVARCHAR(100),@pass NVARCHAR(100),@cid NVARCHAR(100))
AS
BEGIN
	INSERT INTO dbo.ACCOUNTCUSTOMER
	(
	    UserName,
	    PassWord,
	    CustomerID
	)
	VALUES
	(   @un,       -- UserName - nvarchar(100)
	    @pass,       -- PassWord - nvarchar(100)
	    @cid
	    )
END
go
---***Trigger
--khi Cus đăng nhập vào máy để bắt đầu chơi
go
CREATE TRIGGER Useronline_AccountCus ON dbo.ACCOUNTCUSTOMER
FOR INSERT
AS
BEGIN
	DECLARE @did NVARCHAR(100),@st NVARCHAR(100),@cid NVARCHAR(100),@AccM INT, @deT NVARCHAR(100) 

	SELECT @did=Inserted.DeviceID , @st=Inserted.StatusCustomer, @cid =Inserted.CustomerID
	FROM Inserted

	IF(@st =1 AND @did IS NOT NULL)
		BEGIN
			UPDATE dbo.DEVICES
			SET DStatus=1
			WHERE DeviceID=@did

			SELECT @deT= dbo.DEVICES.TypeID
			FROM dbo.DEVICES
			WHERE dbo.DEVICES.DeviceID=@did

			SELECT @AccM =AccMoney
			FROM dbo.ACCOUNTCUSTOMER
			WHERE dbo.ACCOUNTCUSTOMER.CustomerID=@cid
			
			DECLARE @temp int
			IF(@deT =1)
				SET @temp=5000
			ELSE IF(@deT =2)
				SET @temp=7000
			ELSE SET @temp=12000

			UPDATE dbo.ACCOUNTCUSTOMER
			SET 
				TimeUsed =0,
				TimeAvailible=CAST(AccMoney/@temp AS INT),
				AccMoney=0
				
		END
end
GO
--khi Cus logout khỏi máy
go
CREATE TRIGGER UserOffline_AccountCus ON dbo.ACCOUNTCUSTOMER
FOR INSERT
AS
BEGIN
	DECLARE @did NVARCHAR(100),@st NVARCHAR(100),@cid NVARCHAR(100),@AccM INT, @deT NVARCHAR(100),@Tu INT ,@Tavl int

	SELECT @did=Inserted.DeviceID , @st=Inserted.StatusCustomer, @cid =Inserted.CustomerID
	FROM Inserted

	IF(@st =0 AND @did IS NULL)
		BEGIN
			UPDATE dbo.DEVICES
			SET DStatus=0
			WHERE DeviceID=@did

			SELECT @deT= dbo.DEVICES.TypeID
			FROM dbo.DEVICES
			WHERE dbo.DEVICES.DeviceID=@did

			SELECT @AccM =AccMoney
			FROM dbo.ACCOUNTCUSTOMER
			WHERE dbo.ACCOUNTCUSTOMER.CustomerID=@cid
			
			DECLARE @temp int
			IF(@deT =1)
				SET @temp=5000
			ELSE IF(@deT =2)
				SET @temp=7000
			ELSE SET @temp=12000
			
			SELECT @Tavl =TimeAvailible,@Tu=TimeUsed
			FROM dbo.ACCOUNTCUSTOMER
			WHERE dbo.ACCOUNTCUSTOMER.CustomerID=@cid

			UPDATE dbo.ACCOUNTCUSTOMER
			SET 
				AccMoney=(@Tavl -@Tu) *@temp,
				TimeAvailible=0,
				TimeUsed=0
		END
end
GO
--Khi tạo tài khoản cho Cus mà không nhập đủ thông tin
GO
CREATE TRIGGER InvalidInsert_Customer ON dbo.CUSTOMER
FOR INSERT
AS
BEGIN
	DECLARE @cid nvarchar(100),@ful nvarchar(100),@phn nvarchar(100),@icn nvarchar(50),@mon INT
    
	SELECT @cid=Inserted.CustomerID,@ful=Inserted.FullName,@phn=Inserted.PhoneNumber,@icn=Inserted.IdentityCardNumber,@mon=Inserted.MoneyCharged
	FROM Inserted

	IF(LEN(@cid)=0) 
		BEGIN
			PRINT 'Please Enter Customer ID'
			ROLLBACK 
		END
	IF EXISTS (SELECT * FROM dbo.CUSTOMER WHERE dbo.CUSTOMER.CustomerID=@cid) 
		BEGIN
		   PRINT 'Customer id đã tồn tại vui lòng nhập id khác'
		   ROLLBACK
		END
	
	IF(LEN(@ful)=0) 
		BEGIN
			PRINT 'Please Enter Customer Full name'
			ROLLBACK 
		END

	IF(LEN(@phn)=0) 
		BEGIN
			PRINT 'Please Enter Customer Phone number'
			ROLLBACK 
		END

	IF(LEN(@icn) <> 8) 
		BEGIN
			PRINT 'Please Enter a valid Customer Identical card number'
			ROLLBACK 
		END
END
