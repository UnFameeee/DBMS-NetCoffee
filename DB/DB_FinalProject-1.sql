													--ĐỒ ÁN CUỐI KỲ MÔN DBMS--
CREATE DATABASE DBMS_FinalProject
GO

USE DBMS_FinalProject
GO

--Tạo bảng CôngViệc (QT)
CREATE TABLE JOB 
(
	WorkID nvarchar(100) PRIMARY KEY,				--Mã Công Việc (QL, NV, LC)
	CoefficientsSalary real,						--Hệ Số Lương (QL: x2, NV: x1, LC: x1.5)
	JobDetail nvarchar(100)							--Chi tiết công việc: (QL: Quản Lý, NV: Nhân Viên, LC: Lao Công)
)
--Thêm ndung bảng CôngViệc (QT)
INSERT INTO JOB VALUES('QL', 2, N'Quản Lý')
INSERT INTO JOB VALUES('NV', 1, N'Nhân Viên')
INSERT INTO JOB VALUES('LC', 1.5, N'Lao Công')


--*Tạo bảng CaLàm (QT)
CREATE TABLE WORKSHIFT
(
	ShiftID int PRIMARY KEY,						--Ca làm việc (1: 0h-8h // 2: 8h-16h // 3: 16h-0h)
	TimeBegin time not null,						--Thời gian bắt đầu
	TimeEnd time not null							--Thời gian kết thúc (thêm 1 trigger ràng buộc tgian bắt đầu < tgian kết thúc)
)
--Thêm dữ liệu vào bảng CaLàm (QT)
INSERT INTO WORKSHIFT VALUES(1, '00:00:00', '08:00:00')
INSERT INTO WORKSHIFT VALUES(2, '08:00:00', '16:00:00')
INSERT INTO WORKSHIFT VALUES(3, '16:00:00', '00:00:00')


--*Tạo table NhânViên (QT)
CREATE TABLE EMPLOYEE 
(
	ID nvarchar(100) PRIMARY KEY,					--ID nhân viên
	FullName nvarchar(100) not null,				--Họ Tên
	Gender nvarchar(10),							--Giới tính
	Birthday date,									--Ngày sinh
	Phone int,										--SĐT
	IdentityNumber nvarchar(100) not null,			--số CMND
	StatusEmployee nvarchar(100),					--Work / not Work (wibu)
	Email nvarchar(100),
	WorkID nvarchar(100) references JOB(WorkID)		--MãCV
)
--Thêm 3 quản lý, 12 nhân viên, 6 lao công (QT)
INSERT INTO EMPLOYEE VALUES ('NV1', N'Lê Thị Hai', N'Nữ', '2000-10-20', 123456789, '079200001910', '', '', 'LC')
INSERT INTO EMPLOYEE VALUES ('NV2', N'Đặng Văn Đôn', N'Nam', '1999-9-22', 123456987, '079200001911','', '', 'LC')
INSERT INTO EMPLOYEE VALUES ('NV3', N'Thành Nam', N'Nam', '2000-10-23', 123654987,'079200001912','', '', 'LC')
INSERT INTO EMPLOYEE VALUES ('NV4', N'Nguyễn Thành Hải', N'Nam', '1989-3-26', 789456123, '079200001913','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV5', N'Lê Thanh Tú', N'Nam', '1990-3-29', 987654321, '079200001914','', '', 'QL')
INSERT INTO EMPLOYEE VALUES ('NV6', N'Lê Thị Hải Tú', N'Nữ', '1995-2-19', 456789123, '079200001915','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV7', N'Nguyễn Sơn Tùng', N'Nam', '1996-2-11', 753421869, '079200001916','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV8', N'Lê Thành Kim', N'Nam', '1997-7-15', 428675391, '079200001917','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV9', N'Nguyễn Văn Lễ', N'Nam', '1998-8-18', 428695137, '079200001918','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV10', N'Nguyễn Hải Thanh', N'Nam', '1985-10-1', 753916824, '079200001919','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV11', N'Nguyễn Thị Diễm', N'Nữ', '1991-11-2', 425896731, '079200011910','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV12', N'Nguyễn Văn Khanh', N'Nam', '1992-12-9', 142589763, '079200011911','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV13', N'Nguyễn Thành Long', N'Nam', '1993-11-6', 132658974, '079200011912','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV14', N'Lê Thành Lễ', N'Nam', '1994-12-24', 465987321, '079200011913','', '', 'QL')
INSERT INTO EMPLOYEE VALUES ('NV15', N'Nguyễn Sơn Thạch', N'Nam', '1995-4-27', 156248937, '079200011914','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV16', N'Đăng Thị Kim Thu', N'Nữ', '1996-5-20', 321658974, '079200011915','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV17', N'Huỳnh Xuân Phong', N'Nam', '1997-8-14', 865392147, '079200011916','', '', 'NV')
INSERT INTO EMPLOYEE VALUES ('NV18', N'Nguyễn Thiện Thuật', N'Nam', '1998-9-15', 486957321, '079200011917','', '', 'LC')
INSERT INTO EMPLOYEE VALUES ('NV19', N'Lê Quang Định', N'Nam', '2001-5-25', 456829731, '079200011918','', '', 'LC')
INSERT INTO EMPLOYEE VALUES ('NV20', N'Nguyễn Thanh Thị Minh', N'Nữ', '1999-6-18', 125497465,'079200021919','', '', 'QL')
INSERT INTO EMPLOYEE VALUES ('NV21', N'Lê Thanh Như', N'Nữ', '2002-10-20', 465893721, '079200021910','', '', 'LC')

--*Tạo bảng QuảnLý (Nhân Viên được thành quản lý) (QT) 
--(Tao cũng không biết cái bảng này để làm cái gì, quên mất rồi)
CREATE TABLE MANAGER 
(
	MNGID nvarchar(100) references EMPLOYEE(ID),										--ID quản lý
	ShiftID int references WORKSHIFT(ShiftID),										--Ca làm việc 
	PRIMARY KEY(MNGID, ShiftID)
)
--Thêm 3 quản lý vào bảng này (NV14, NV20, NV5) (QT)
INSERT INTO MANAGER VALUES ('NV5', 1)
INSERT INTO MANAGER VALUES ('NV14', 2)
INSERT INTO MANAGER VALUES ('NV20', 3)


--*Tạo bảng Làm Việc (QT)
CREATE TABLE WORKS 
(
	ID nvarchar(100) references EMPLOYEE(ID),										--ID nhân viên làm việc
	ShiftID int references WORKSHIFT(ShiftID),										--Ca làm việc
	TotalTimeWork time																--Thời gian làm việc (Tao nghĩ này nên để int)
	PRIMARY KEY(ID,ShiftID),
)
--Chưa biết thêm gì

------------------------------------------------------------------------------------------------------------------------
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
INSERT INTO DEVICETYPE VALUES('Thuong','AMD Ryzen 5 3600','DDR4','CoolerMaster MWE 400','RTX 3080 GameRock 10G','ASROCK H410M-HVS','XIGMATEK MASTER X 3FX','ViewSonic VA2406','Logitech G102 Lightsync RGB White','Razer Blackwidow Lite')
INSERT INTO DEVICETYPE VALUES('Vip','AMD Ryzen 5 5600X','DDR4','Gigabyte P450B','RX 6700 XT OC Edition','MSI A320M-A PRO MAX','MSI MAG VAMPIRIC 100R','LG 24GN600-B','Logitech G102 Lightsync RGB Black','Razer Huntsman Mini')
INSERT INTO DEVICETYPE VALUES('Super Vip','Intel Core i9','DDR4','SilverStone ST50F-ES230','Radeon RX 6800 XT Gaming','sus PRIME H310M-CS R2.0 LGA1151v2','GIGABYTE C200 Glass','LG 24GN600-B','Logitech G102 Lightsync RGB Black','Razer Huntsman V2 Analog')
--INSERT INTO DEVICETYPE VALUES('Super Vip','Intel Core i7-10570H @ 2.60GHz','DDR4','Gigabyte P450B','RTX™ 3060 ELITE','MSI A320M-A PRO MAX','XIGMATEK MASTER X 3FX','Samsung LS24R350','Logitech G102 Lightsync RGB Black','Razer Huntsman Mini Mercury')

--Máy--
CREATE TABLE DEVICES
(
	DeviceID nvarchar(100) PRIMARY KEY,												--số máy
	TypeID nvarchar(100) references DEVICETYPE(TypeID),								--loại máy (super vjp, vip, thường)
	DStatus nvarchar(100)															--tình trạng máy (đang đc sử dụng, đang đc bảo trì,....)
)
INSERT INTO DEVICES VALUES('MAY01','Vip','In use')
INSERT INTO DEVICES VALUES('MAY02','Super Vip','In repair')
INSERT INTO DEVICES VALUES('MAY03','Thuong','Not in use')
INSERT INTO DEVICES VALUES('MAY04','Vip','In use')
INSERT INTO DEVICES VALUES('MAY05','Super Vip','Not in use')
INSERT INTO DEVICES VALUES('MAY06','Vip','In repair')
INSERT INTO DEVICES VALUES('MAY07','Thuong','Not in use')
INSERT INTO DEVICES VALUES('MAY08','Thuong','Not in use')
INSERT INTO DEVICES VALUES('MAY09','Thuong','Not in use')

------------------------------------------------------------------------------------------------------------------------
--Khách hàng--
create table CUSTOMER
(
	CustomerID nvarchar(100) primary key,
	FullName nvarchar(100),
	PhoneNumber nvarchar(100),
	IdentityCardNumber nvarchar(100),									--số CMND
	MoneyCharged float													--số tiền nạp
)
INSERT INTO CUSTOMER Values('KH1','Nguyen Van A',12345678,1,50000)
INSERT INTO CUSTOMER Values('KH2','Nguyen Van B',12345678,2,40000)
INSERT INTO CUSTOMER Values('KH3','Nguyen Van C',12345678,3,30000)
INSERT INTO CUSTOMER Values('KH4','Nguyen Van D',12345678,4,20000)
INSERT INTO CUSTOMER Values('KH5','Nguyen Van E',12345678,5,10000)
INSERT INTO CUSTOMER Values('KH6','Nguyen Van F',12345678,5,10000)

--Tài khoản khách hàng--
create table ACCOUNTCUSTOMER
(
	UserName nvarchar(100) PRIMARY KEY,
	PassWord nvarchar(100),
	TimeAvailible float,												--dựa vào số tiền nạp và id máy để tính thời gian			
	TimeUsed float,														--thời gian đã dùng
	--TimeRemain float,													--thời gian còn lại = thời gian có - thời gian đã dùng
	CustomerID nvarchar(100) references CUSTOMER(CustomerID),					
	DeviceID nvarchar(100) references DEVICES(DeviceID),
	StatusCustomer nvarchar(100),
	AccMoney FLOAT ----------- mới thêm vào + đổi tiền từ float thành int
)
INSERT INTO ACCOUNTCUSTOMER Values('Van A','1',10,2,8,'KH1','MAY01',0)
INSERT INTO ACCOUNTCUSTOMER Values('Van B','1',10,2,8,'KH2','MAY02',0)
INSERT INTO ACCOUNTCUSTOMER Values('Van C','1',10,2,8,'KH3','MAY03',0)
INSERT INTO ACCOUNTCUSTOMER Values('Van D','1',10,2,8,'KH4','MAY04',0)
INSERT INTO ACCOUNTCUSTOMER Values('Van E','1',10,2,8,'KH5','MAY05',0)
INSERT INTO ACCOUNTCUSTOMER Values('Van F','1',10,2,8,'KH6','MAY06',0)
--Tài khoản nhân viên--
CREATE TABLE ACCOUNTEMPLOYEE 
(
	ID NVARCHAR(100) PRIMARY KEY REFERENCES dbo.EMPLOYEE(ID),
	Username nvarchar(100),
	Password nvarchar(1000),
	TypeEmployee nvarchar(100)										--0 là nhân viên, 1 là quản lí
)

 
