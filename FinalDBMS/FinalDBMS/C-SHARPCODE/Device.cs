using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDBMS
{
    class Device
    {
        Mydb mydb = new Mydb();

        //Hiển thị Device tuỳ theo câu lệnh SQL
        public DataTable getDevice(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //Hiển thị toàn bộ thông tin Device
        public DataTable getAllDevices()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM DEVICES");
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getAllDevicesNotInUse()
        {
            SqlCommand command = new SqlCommand("SELECT CONCAT(deviceid,' (',typeid,')')  AS Máy " +
                "FROM DEVICES " +
                "WHERE dbo.DEVICES.DStatus = N'Offline'");
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //Thêm máy mới sử dụng Store Procedure
        public bool InsertDevice(string DeviceID, string TypeID, string DStatus)
        {
            //SqlCommand command = new SqlCommand("INSERT INTO DEVICES (DeviceID,TypeID,DStatus)" + " VALUES (@DevID,@Type,@Dsta)", mydb.getConnection);
            
            SqlCommand command = new SqlCommand("Insert_Device", mydb.getConnection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@devid", SqlDbType.NVarChar).Value = DeviceID;
            command.Parameters.Add("@type", SqlDbType.NVarChar).Value = TypeID;
            command.Parameters.Add("@status", SqlDbType.NVarChar).Value = DStatus;


            mydb.Openconnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.Closeconnection();
                return true;
            }
            else
            {
                mydb.Closeconnection();
                return false;
            }
        }




        //Cập nhật máy mới sử dụng Store Procedure
        public bool EditDevice(string DeviceID, string TypeID)
        {
 
            SqlCommand command = new SqlCommand("Edit_Device", mydb.getConnection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@devid", SqlDbType.NVarChar).Value = DeviceID;
            command.Parameters.Add("@type", SqlDbType.NVarChar).Value = TypeID;

            mydb.Openconnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.Closeconnection();
                return true;
            }
            else
            {
                mydb.Closeconnection();
                return false;
            }
        }


        //Cập nhật máy mới sử dụng Store Procedure
        public bool DeleteDeviceByID(string DeviceID)
        {

            SqlCommand command = new SqlCommand("DeleteDeviceByID", mydb.getConnection);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@devid", SqlDbType.VarChar).Value = DeviceID;

            mydb.Openconnection();

            if ((command.ExecuteNonQuery() < 1))
            {
                mydb.Closeconnection();
                return false;
            }
            else
            {
                mydb.Closeconnection();
                return true;
            }
        }


        //Kiểm tra ID máy đã được thêm trước đó hay chưa
        public bool DeviceIDAvailable(string device)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM DEVICES where DeviceID = @dev", mydb.getConnection);
            command.Parameters.Add("@dev", SqlDbType.VarChar).Value = device;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if ((table.Rows.Count == 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Stored - Procedure hiển thị thông tin của các khách hàng đang chơi máy Vip / Super Vip / Thuong
        public DataTable Show_InfoCustomer_GroupBy_TypeID(string typeid)
        {
            //Đưa stored procedure vào
            //Không cần truyền tham số ngay command nhưng phải thêm Parameter bên dưới
            SqlCommand command = new SqlCommand("ShowInfoCustomerGroupByTypeID", mydb.getConnection);
            command.Parameters.Add("@TypeID", System.Data.SqlDbType.VarChar).Value = typeid;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //Function - kiểm tra máy có đang được sử dụng hay chưa
        public bool CheckAvailableDevice(string devid)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Func_CheckAvailableDevices (@devid)", mydb.getConnection);
            command.Parameters.Add("@devid", System.Data.SqlDbType.NVarChar).Value = devid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows.Count > 0;
        }

        //Function - kiểm tra máy có đang được được sử dụng và cấp cho người dùng nào hay chưa
        public bool CheckAvailableDeviceFromUser(string devid)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Func_CheckDevicesFromUser (@devid)", mydb.getConnection);
            command.Parameters.Add("@devid", System.Data.SqlDbType.NVarChar).Value = devid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table.Rows.Count > 0;
        }
        //public bool Func_CheckDevicesFromUser2(string devid)
        //{
        //    SqlCommand command = new SqlCommand("SELECT * FROM Func_CheckDevicesFromUser2 (@devid)", mydb.getConnection);
        //    command.Parameters.Add("@devid", System.Data.SqlDbType.NVarChar).Value = devid;
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    DataTable table = new DataTable();
        //    adapter.Fill(table);
        //    return table.Rows.Count > 0;
        //}

        public DataTable ShowCustomerIsPlaying(string devid)
        {
            //Đưa stored procedure vào
            //Không cần truyền tham số ngay command nhưng phải thêm Parameter bên dưới
            SqlCommand command = new SqlCommand("ShowCustomerIsPlaying", mydb.getConnection);
            command.Parameters.Add("@DevID", System.Data.SqlDbType.NVarChar).Value = devid;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public void UpdateStatus (string devid)
        {
            SqlCommand command = new SqlCommand("UpdateStatus", mydb.getConnection);
            command.Parameters.Add("@devid", System.Data.SqlDbType.NVarChar).Value = devid;
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
        }
        public bool UpdateUserlogout(string cid,string devid)
        {
            SqlCommand command = new SqlCommand("execute Userlogout_AccountCus " +
                "@cid =@cusid, " +
                "@did =@deviceid ", mydb.getConnection);
            command.Parameters.Add("@deviceid", System.Data.SqlDbType.NVarChar).Value = devid;
            command.Parameters.Add("@cusid", System.Data.SqlDbType.NVarChar).Value = cid;
           // command.CommandType = CommandType.StoredProcedure;
            mydb.Openconnection();
            if ((command.ExecuteNonQuery() >= 1))
            {
                mydb.Closeconnection();
                return true;
            }
            else
            {
                mydb.Closeconnection();
                return false;
            }

        }

        public bool StopPlaying(string devid)
        {
            SqlCommand command = new SqlCommand("StopPlaying", mydb.getConnection);
            command.Parameters.Add("@devid", System.Data.SqlDbType.NVarChar).Value = devid;
            command.CommandType = CommandType.StoredProcedure;
            mydb.Openconnection();
            if ((command.ExecuteNonQuery() >= 1))
            {
                mydb.Closeconnection();
                return true;
            }
            else
            {
                mydb.Closeconnection();
                return false;
            }

        }

        public bool StartPlaying(string devid)
        {
            SqlCommand command = new SqlCommand("StartPlaying", mydb.getConnection);
            command.Parameters.Add("@devid", System.Data.SqlDbType.NVarChar).Value = devid;
            command.CommandType = CommandType.StoredProcedure;
            mydb.Openconnection();
            if ((command.ExecuteNonQuery() >= 1))
            {
                mydb.Closeconnection();
                return true;
            }
            else
            {
                mydb.Closeconnection();
                return false;
            }

        }

        public bool StartRepairing(string devid)
        {
            SqlCommand command = new SqlCommand("StartRepairing", mydb.getConnection);
            command.Parameters.Add("@devid", System.Data.SqlDbType.NVarChar).Value = devid;
            command.CommandType = CommandType.StoredProcedure;
            mydb.Openconnection();
            if ((command.ExecuteNonQuery() >= 1))
            {
                mydb.Closeconnection();
                return true;
            }
            else
            {
                mydb.Closeconnection();
                return false;
            }

        }

        public bool StopRepairing(string devid)
        {
            SqlCommand command = new SqlCommand("StopRepairing", mydb.getConnection);
            command.Parameters.Add("@devid", System.Data.SqlDbType.NVarChar).Value = devid;
            command.CommandType = CommandType.StoredProcedure;
            mydb.Openconnection();
            if ((command.ExecuteNonQuery() >= 1))
            {
                mydb.Closeconnection();
                return true;
            }
            else
            {
                mydb.Closeconnection();
                return false;
            }

        }

        public void FormatStatus()
        {
            //Đưa stored procedure vào
            //Không cần truyền tham số ngay command nhưng phải thêm Parameter bên dưới
            SqlCommand command = new SqlCommand("FormatStatus", mydb.getConnection);
            command.CommandType = CommandType.StoredProcedure;
            mydb.Openconnection();
            command.ExecuteNonQuery();
        }

    }
}
