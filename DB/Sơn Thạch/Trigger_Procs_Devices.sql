										--TRIGGERS / PROCS / FUNCTION / GRANT phần THIẾT BỊ--
--Tạo CSDL để TEST

USE DBMS_FinalProject_Week11

--Loại Máy--
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

--Máy--
CREATE TABLE DEVICES
(
	DeviceID nvarchar(100) PRIMARY KEY,												--số máy
	TypeID nvarchar(100) references DEVICETYPE(TypeID),								--loại máy (super vjp, vip, thường)
	DStatus nvarchar(100)															--tình trạng máy (đang đc sử dụng, đang đc bảo trì,....)
)

INSERT INTO DEVICETYPE VALUES('Thuong','AMD Ryzen 5 3600','DDR4','CoolerMaster MWE 400','RTX 3080 GameRock 10G','ASROCK H410M-HVS','XIGMATEK MASTER X 3FX','ViewSonic VA2406','Logitech G102 Lightsync RGB White','Razer Blackwidow Lite')
INSERT INTO DEVICETYPE VALUES('Vip','AMD Ryzen 5 5600X','DDR4','Gigabyte P450B','RX 6700 XT OC Edition','MSI A320M-A PRO MAX','MSI MAG VAMPIRIC 100R','LG 24GN600-B','Logitech G102 Lightsync RGB Black','Razer Huntsman Mini')
INSERT INTO DEVICETYPE VALUES('Super Vip','Intel Core i9','DDR4','SilverStone ST50F-ES230','Radeon RX 6800 XT Gaming','sus PRIME H310M-CS R2.0 LGA1151v2','GIGABYTE C200 Glass','LG 24GN600-B','Logitech G102 Lightsync RGB Black','Razer Huntsman V2 Analog')
--INSERT INTO DEVICETYPE VALUES('Super Vip','Intel Core i7-10570H @ 2.60GHz','DDR4','Gigabyte P450B','RTX™ 3060 ELITE','MSI A320M-A PRO MAX','XIGMATEK MASTER X 3FX','Samsung LS24R350','Logitech G102 Lightsync RGB Black','Razer Huntsman Mini Mercury')

INSERT INTO DEVICES VALUES('MAY01','Vip','In use')
INSERT INTO DEVICES VALUES('MAY02','Super Vip','In repair')
INSERT INTO DEVICES VALUES('MAY03','Thuong','Not in use')
INSERT INTO DEVICES VALUES('MAY04','Vip','In use')
INSERT INTO DEVICES VALUES('MAY05','Super Vip','Not in use')
INSERT INTO DEVICES VALUES('MAY06','Vip','In repair')
INSERT INTO DEVICES VALUES('MAY07','Thuong','Not in use')
INSERT INTO DEVICES VALUES('MAY08','Thuong','Not in use')
INSERT INTO DEVICES VALUES('MAY09','Thuong','Not in use')

--Trigger:
--1. Khi sửa lại máy Super vip thì không được nhập CPU là Intel Core i3 hoặc Core i5
CREATE TRIGGER Add_Device_CPU_condition ON DEVICETYPE
AFTER INSERT,UPDATE 
AS
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
END

--Test Trigger
--TH Sai
UPDATE DEVICETYPE  SET CPU = 'Core i3' WHERE TypeID = 'Super Vip'
UPDATE DEVICETYPE  SET CPU = 'Core i5' WHERE TypeID = 'Super Vip'
--TH Đúng
UPDATE DEVICETYPE  SET CPU = 'Core i9' WHERE TypeID = 'Super Vip'

--2.Khi sửa lại máy Vip thì Keyboard của máy Thường không được trùng với máy Vip 
CREATE TRIGGER Add_Device_Keyboard_Condition ON DEVICETYPE
AFTER INSERT, UPDATE
AS
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
END

--Test Trigger
--Keyboard hiện tại của Vip là Razer Huntsman Mini Mercury còn Thường là Razer Blackwidow Lite
--Trường hợp sai
UPDATE DEVICETYPE  SET KeyBoard = 'Razer Huntsman Mini Mercury' WHERE TypeID = 'Thuong'

--3. Ram phải luôn bắt buộc là DDR4, DDR3, DDR2
CREATE TRIGGER Add_Device_RAM_condition ON DEVICETYPE
AFTER INSERT,UPDATE 
AS
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
END

--Khách hàng--
create table CUSTOMER
(
	CustomerID nvarchar(100) primary key,
	FullName nvarchar(100),
	PhoneNumber int,
	IdentityCardNumber int,															--số CMND
	MoneyCharged float																--số tiền nạp
)

INSERT INTO CUSTOMER Values('KH1','Nguyen Van A',12345678,1,50000)
INSERT INTO CUSTOMER Values('KH2','Nguyen Van B',12345678,2,40000)
INSERT INTO CUSTOMER Values('KH3','Nguyen Van C',12345678,3,30000)
INSERT INTO CUSTOMER Values('KH4','Nguyen Van D',12345678,4,20000)
INSERT INTO CUSTOMER Values('KH5','Nguyen Van E',12345678,5,10000)
INSERT INTO CUSTOMER Values('KH6','Nguyen Van F',12345678,5,10000)

create table ACCOUNTCUSTOMER
(
	UserName nvarchar(100) PRIMARY KEY,
	PassWord nvarchar(100),
	TimeAvailible int,												--dựa vào số tiền nạp và id máy để tính thời gian			
	TimeUsed int,													--thời gian đã dùng
	TimeRemain int,													--thời gian còn lại = thời gian có - thời gian đã dùng
	CustomerID nvarchar(100) references CUSTOMER(CustomerID),					
	DeviceID nvarchar(100) references DEVICES(DeviceID),
	StatusCustomer INT
)

INSERT INTO ACCOUNTCUSTOMER Values('Van A','1',10,2,8,'KH1','MAY01',0)
INSERT INTO ACCOUNTCUSTOMER Values('Van B','1',10,2,8,'KH2','MAY02',0)
INSERT INTO ACCOUNTCUSTOMER Values('Van C','1',10,2,8,'KH3','MAY03',0)
INSERT INTO ACCOUNTCUSTOMER Values('Van D','1',10,2,8,'KH4','MAY04',0)
INSERT INTO ACCOUNTCUSTOMER Values('Van E','1',10,2,8,'KH5','MAY05',0)
INSERT INTO ACCOUNTCUSTOMER Values('Van F','1',10,2,8,'KH6','MAY06',0)

--Stored-Procedure hiển thị thông tin của các khách hàng đang chơi máy Vip / Super Vip / Thuong
Go
CREATE PROC Show_InfoCustomer_GroupBy_TypeID(@TypeID nvarchar(100))
as
begin
select a.UserName,a.PassWord,a.TimeAvailible,a.TimeUsed,a.TimeRemain,a.CustomerID,a.DeviceID,a.StatusCustomer
from ACCOUNTCUSTOMER a, DEVICES d
where a.DeviceID = d.DeviceID
and d.TypeID = @TypeID
end

EXEC Show_InfoCustomer_GroupBy_TypeID 'Thuong'

-- Trigger kiểm tra người dùng không được dùng máy đang bảo trì hoặc đang được sử dụng
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
END
