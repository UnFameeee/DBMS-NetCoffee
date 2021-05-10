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
	WorkID nvarchar(100) references JOB(WorkID),	--MãCV
	Picture image									--Hình ảnh nhân viên
)
--Thêm 3 quản lý, 12 nhân viên, 6 lao công (QT)
INSERT INTO EMPLOYEE VALUES ('NV1', N'Lê Thị Hai', N'Nữ', '2000-10-20', 123456789, '079200001910', '', '', 'LC', '')
INSERT INTO EMPLOYEE VALUES ('NV2', N'Đặng Văn Đôn', N'Nam', '1999-9-22', 123456987, '079200001911','', '', 'LC', '')
INSERT INTO EMPLOYEE VALUES ('NV3', N'Thành Nam', N'Nam', '2000-10-23', 123654987,'079200001912','', '', 'LC', '')
INSERT INTO EMPLOYEE VALUES ('NV4', N'Nguyễn Thành Hải', N'Nam', '1989-3-26', 789456123, '079200001913','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV5', N'Lê Thanh Tú', N'Nam', '1990-3-29', 987654321, '079200001914','', '', 'QL', '')
INSERT INTO EMPLOYEE VALUES ('NV6', N'Lê Thị Hải Tú', N'Nữ', '1995-2-19', 456789123, '079200001915','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV7', N'Nguyễn Sơn Tùng', N'Nam', '1996-2-11', 753421869, '079200001916','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV8', N'Lê Thành Kim', N'Nam', '1997-7-15', 428675391, '079200001917','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV9', N'Nguyễn Văn Lễ', N'Nam', '1998-8-18', 428695137, '079200001918','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV10', N'Nguyễn Hải Thanh', N'Nam', '1985-10-1', 753916824, '079200001919','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV11', N'Nguyễn Thị Diễm', N'Nữ', '1991-11-2', 425896731, '079200011910','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV12', N'Nguyễn Văn Khanh', N'Nam', '1992-12-9', 142589763, '079200011911','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV13', N'Nguyễn Thành Long', N'Nam', '1993-11-6', 132658974, '079200011912','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV14', N'Lê Thành Lễ', N'Nam', '1994-12-24', 465987321, '079200011913','', '', 'QL', '')
INSERT INTO EMPLOYEE VALUES ('NV15', N'Nguyễn Sơn Thạch', N'Nam', '1995-4-27', 156248937, '079200011914','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV16', N'Đăng Thị Kim Thu', N'Nữ', '1996-5-20', 321658974, '079200011915','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV17', N'Huỳnh Xuân Phong', N'Nam', '1997-8-14', 865392147, '079200011916','', '', 'NV', '')
INSERT INTO EMPLOYEE VALUES ('NV18', N'Nguyễn Thiện Thuật', N'Nam', '1998-9-15', 486957321, '079200011917','', '', 'LC', '')
INSERT INTO EMPLOYEE VALUES ('NV19', N'Lê Quang Định', N'Nam', '2001-5-25', 456829731, '079200011918','', '', 'LC', '')
INSERT INTO EMPLOYEE VALUES ('NV20', N'Nguyễn Thanh Thị Minh', N'Nữ', '1999-6-18', 125497465,'079200021919','', '', 'QL', '')
INSERT INTO EMPLOYEE VALUES ('NV21', N'Lê Thanh Như', N'Nữ', '2002-10-20', 465893721, '079200021910','', '', 'LC', '')

--Này là bảng giao thoa giữa ca làm và nhân viên
CREATE TABLE WORK									--Ca làm (trong 1 ca làm thì có 1 ql, 4 nv, 3 lc)
(
	EmpID nvarchar(100),
	ShiftID int,
	ShiftManagerID nvarchar(100),
	PRIMARY KEY(EmpID, ShiftID)
)
ALTER TABLE WORK DROP CONSTRAINT FK_EmpIDandID
ALTER TABLE WORK ADD CONSTRAINT FK_EmpIDandID FOREIGN KEY(EmpID) REFERENCES EMPLOYEE(ID)					--FK là FOREIGN KEY

ALTER TABLE WORK ADD CONSTRAINT FK_ShiftIDandWorkShift FOREIGN KEY(ShiftID) REFERENCES WORKSHIFT(ShiftID)

--Ca 1
INSERT INTO WORK VALUES ('NV5', 1, '')		--QL
INSERT INTO WORK VALUES ('NV1', 1, 'NV5')	--LC
INSERT INTO WORK VALUES ('NV2', 1, 'NV5')	--LC
INSERT INTO WORK VALUES ('NV4', 1, 'NV5')	--NV
INSERT INTO WORK VALUES ('NV6', 1, 'NV5')	--NV
INSERT INTO WORK VALUES ('NV7', 1, 'NV5')	--NV
INSERT INTO WORK VALUES ('NV8', 1, 'NV5')	--NV
--Ca 2
INSERT INTO WORK VALUES ('NV14', 2, '')		--QL
INSERT INTO WORK VALUES ('NV3', 2, 'NV14')	--LC
INSERT INTO WORK VALUES ('NV18', 2, 'NV14')	--LC
INSERT INTO WORK VALUES ('NV9', 2, 'NV14')	--NV
INSERT INTO WORK VALUES ('NV10', 2, 'NV14')	--NV
INSERT INTO WORK VALUES ('NV11', 2, 'NV14')	--NV
INSERT INTO WORK VALUES ('NV12', 2, 'NV14')	--NV
--Ca 3
INSERT INTO WORK VALUES ('NV20', 3, '')		--QL
INSERT INTO WORK VALUES ('NV19', 3, 'NV20')	--LC
INSERT INTO WORK VALUES ('NV21', 3, 'NV20')	--LC
INSERT INTO WORK VALUES ('NV13', 3, 'NV20')	--NV
INSERT INTO WORK VALUES ('NV15', 3, 'NV20')	--NV
INSERT INTO WORK VALUES ('NV16', 3, 'NV20')	--NV
INSERT INTO WORK VALUES ('NV17', 3, 'NV20')	--NV



------------------------------TRIGGER-----------------------------------------
--Trigger ở bảng Work--
--Khi thêm ID của 1 nhân viên vào ShiftManagerID thì người đó bắt buộc phải là quản lý
--Nếu người được thêm là quản lý thì ShiftManagerID = null
DROP TRIGGER TG_ShiftManagerMustBeManager
CREATE TRIGGER TG_ShiftManagerMustBeManager On WORK
FOR INSERT, UPDATE AS
DECLARE @ShiftManagerID nvarchar(100), @Position nvarchar(100), @EmpID nvarchar(100)
BEGIN 
	--Lấy ra mã quản lý của 1 nhân viên vừa thêm/cập nhật vào
	SELECT @EmpID = inserted.EmpID, @ShiftManagerID = inserted.ShiftManagerID
	FROM inserted
	--Nếu mãQL là null
	IF(@ShiftManagerID = '')				
	BEGIN
		--Tìm ra vị trí của EmpID
		SELECT @Position = EMPLOYEE.WorkID
		FROM EMPLOYEE
		WHERE EMPLOYEE.ID = @EmpID
		--Nếu đó không là quản lý thì RollBack (Vì quản lý không thể quản lý quản lý)
		IF(@Position = 'QL')
		BEGIN
			PRINT ('Cant Insert or Update because Manager cant be managed by Manager!!!')
			ROLLBACK
		END
	END

	ELSE	--Nếu mã quản lý != null
	BEGIN
		--Tìm ra vị trí của mã quản lý đó
		SELECT @Position = EMPLOYEE.WorkID
		FROM EMPLOYEE
		WHERE EMPLOYEE.ID = @ShiftManagerID
		--Nếu đó không phải là Quản Lý (QL) Rollback
		IF(@Position != 'QL')
		BEGIN
			PRINT ('Shift Manager must be a Manager!!!')
			ROLLBACK
		END
	END
END

--Test nhập
INSERT INTO WORK VALUES ('NV13', 2, 'NV1')	--LC
--Test update
UPDATE WORK SET ShiftManagerID = 'NV1' WHERE EmpID = 'NV1' and ShiftID = 1




------------------------------FUNCTION-----------------------------------------
--Tìm ra nhân viên theo từ khoá đã cho
DROP FUNCTION Func_SearchEmployeesWithName
CREATE FUNCTION Func_SearchEmployeesWithName (@search_name nvarchar(100))
RETURNS TABLE AS
	RETURN SELECT * FROM dbo.EMPLOYEE
		   WHERE FullName LIKE '%' + @search_name + '%'

GO
SELECT * FROM dbo.Func_SearchEmployeesWithName(N'Thành')					--chạy function

--Tìm ra hình ảnh nhân viên lúc điểm danh xong bằng EmpID (CalendarFrm)
DROP FUNCTION Func_TakePicWhenCheckin
CREATE FUNCTION Func_TakePicWhenCheckin (@EmpID varchar(100))
RETURNS TABLE AS
	RETURN SELECT Picture, FullName
		   FROM EMPLOYEE
	       WHERE EMPLOYEE.ID = @EmpID

SELECT * FROM dbo.Func_TakePicWhenCheckin('NV1')

--Tìm ra thông tin của nhân viên lúc điểm danh xong bằng EmpID (CalendarFrm)
DROP FUNCTION Func_TakeInfoWhenCheckin
CREATE FUNCTION Func_TakeInfoWhenCheckin (@EmpID varchar(100))
RETURNS TABLE AS
	RETURN SELECT Id, FullName, Gender, Phone, IdentityNumber
		   FROM EMPLOYEE
	       WHERE EMPLOYEE.ID = @EmpID

SELECT * FROM dbo.Func_TakeInfoWhenCheckin('NV1')