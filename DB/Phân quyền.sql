use DBMS_FinalProject
GO

------QUẢN LÝ
--Tạo quyền
CREATE ROLE manager
GO

--Cấp quyền cho trên bảng cho manager
GRANT SELECT, INSERT, UPDATE, DELETE ON EMPLOYEE TO
manager
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON SALARY TO
manager
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON ACCOUNTEMPLOYEEE TO
manager
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON JOB TO
manager
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON WORK TO
manager
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON TIMEKEEPING TO
manager
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON WORKSHIFT TO
manager
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON ACCOUNTCUSTOMER TO
manager
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON CUSTOMER TO
manager
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON DEVICES TO
manager
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON DEVICETYPE TO
manager
GO

-- Cấp quyền các Store procedure cho manager
GRANT EXEC, ALTER ON Edit_MyInfo TO manager
GRANT EXEC, ALTER ON AddDivideShift TO manager
GRANT EXEC, ALTER ON UpdateDivideShift TO manager
GRANT EXEC, ALTER ON DeleteDivideShift TO manager
GRANT EXEC, ALTER ON AddDivideTimeShift TO manager
GRANT EXEC, ALTER ON UpdateDivideTimeShift TO manager
GRANT EXEC, ALTER ON DeleteDivideTimeShift TO manager

GRANT EXEC, ALTER ON ShowInfoCustomerGroupByTypeID TO manager
GRANT EXEC, ALTER ON Insert_Device TO manager
GRANT EXEC, ALTER ON DeleteDeviceByID TO manager
GRANT EXEC, ALTER ON Edit_Device TO manager
GRANT EXEC, ALTER ON ShowCustomerIsPlaying TO manager
GRANT EXEC, ALTER ON UpdateStatus TO manager
GRANT EXEC, ALTER ON StopPlaying TO manager
GRANT EXEC, ALTER ON StartPlaying TO manager
GRANT EXEC, ALTER ON StartRepairing TO manager
GRANT EXEC, ALTER ON StopRepairing TO manager
GRANT EXEC, ALTER ON FormatStatus TO manager

GRANT EXEC, ALTER ON USP_ShowSalary TO manager
GRANT EXEC, ALTER ON USP_ShowFullTimeKeeping TO manager
GRANT EXEC, ALTER ON USP_CheckIn TO manager
GRANT EXEC, ALTER ON USP_CheckOut TO manager
GRANT EXEC, ALTER ON USP_CheckIDEmployee TO manager
GRANT EXEC, ALTER ON USP_CheckIDEmployeeWorking TO manager
GRANT EXEC, ALTER ON USP_SearchSalaryByMonthYear TO manager
GRANT EXEC, ALTER ON USP_SearchSalaryByMonth TO manager
GRANT EXEC, ALTER ON USP_SearchSalaryByYear TO manager

GRANT EXEC, ALTER ON Create_customer TO manager
GRANT EXEC, ALTER ON deleteById_customer TO manager
GRANT EXEC, ALTER ON EditInfo_customer TO manager
GRANT EXEC, ALTER ON DepositBudget_customer TO manager
GRANT EXEC, ALTER ON Create_Accus TO manager
GRANT EXEC, ALTER ON UserLoginDevice_AccountCus TO manager
GRANT EXEC, ALTER ON DepositBudget_Accountcustomer TO manager
GRANT EXEC, ALTER ON Userlogout_AccountCus TO manager
GRANT EXEC, ALTER ON AccCusActualTimeAvl TO manager

-- Cấp quyền các Function cho manager
GRANT SELECT, ALTER ON Func_SearchEmployeesWithName TO manager
GRANT SELECT, ALTER ON Func_TakePicWhenCheckin TO manager
GRANT SELECT, ALTER ON Func_TakeInfoWhenCheckin TO manager
GRANT SELECT, ALTER ON Func_CheckEmpWorking TO manager
GRANT SELECT, ALTER ON Func_TakeMyInfo TO manager
GRANT SELECT, ALTER ON Func_TakeNameandPic TO manager

GRANT SELECT, ALTER ON Func_CheckAvailableDevices TO manager
GRANT SELECT, ALTER ON Func_CheckDevicesFromUser TO manager
GRANT SELECT, ALTER ON Func_CheckDevicesFromUser2 TO manager


------NHÂN VIÊN
--Tạo quyền
CREATE ROLE employee
GO

--Cấp quyền cho trên bảng cho employee
GRANT SELECT, UPDATE ON EMPLOYEE TO
employee
GO

GRANT SELECT ON ACCOUNTEMPLOYEEE TO
employee
GO

GRANT SELECT ON ACCOUNTCUSTOMER TO
employee
GO

GRANT SELECT ON CUSTOMER TO
employee
GO

GRANT SELECT ON DEVICES TO
employee
GO

GRANT SELECT ON DEVICETYPE TO
employee
GO

-- Cấp quyền các Store procedure cho employee
GRANT EXEC ON Edit_MyInfo TO employee
GRANT EXEC ON AddDivideShift TO employee
GRANT EXEC ON UpdateDivideShift TO employee
GRANT EXEC ON DeleteDivideShift TO employee
GRANT EXEC ON AddDivideTimeShift TO employee
GRANT EXEC ON UpdateDivideTimeShift TO employee
GRANT EXEC ON DeleteDivideTimeShift TO employee

GRANT EXEC ON ShowInfoCustomerGroupByTypeID TO employee
GRANT EXEC ON Insert_Device TO employee
GRANT EXEC ON DeleteDeviceByID TO employee
GRANT EXEC ON Edit_Device TO employee
GRANT EXEC ON ShowCustomerIsPlaying TO employee
GRANT EXEC ON UpdateStatus TO employee
GRANT EXEC ON StopPlaying TO employee
GRANT EXEC ON StartPlaying TO employee
GRANT EXEC ON StartRepairing TO employee
GRANT EXEC ON StopRepairing TO employee
GRANT EXEC ON FormatStatus TO employee

GRANT EXEC ON Create_customer TO employee
GRANT EXEC ON deleteById_customer TO employee
GRANT EXEC ON EditInfo_customer TO employee
GRANT EXEC ON DepositBudget_customer TO employee
GRANT EXEC ON Create_Accus TO employee
GRANT EXEC ON UserLoginDevice_AccountCus TO employee
GRANT EXEC ON DepositBudget_Accountcustomer TO employee
GRANT EXEC ON Userlogout_AccountCus TO employee
GRANT EXEC ON AccCusActualTimeAvl TO employee

-- Cấp quyền các Function cho employee
GRANT SELECT ON Func_CheckAvailableDevices TO employee
GRANT SELECT ON Func_CheckDevicesFromUser TO employee
GRANT SELECT ON Func_CheckDevicesFromUser2 TO employee
GRANT SELECT ON Func_TakeMyInfo TO employee
GRANT SELECT ON Func_TakeNameandPic TO employee