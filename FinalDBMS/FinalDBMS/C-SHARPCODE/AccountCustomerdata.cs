using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDBMS
{
    class AccountCustomerdata
    {
        Mydb db = new Mydb();

        public bool NaptienAcc(string accid,float tiennap)
        {
            SqlCommand command = new SqlCommand("EXECUTE dbo.DepositBudget_Accountcustomer " +
                        "@cid = @id,  " +
                        "@mon = @money ", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = accid;
            command.Parameters.Add("@money", SqlDbType.Float).Value = tiennap;
            db.Openconnection();
            if (command.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                db.Closeconnection();
                return false;
            }
        }
        public bool updateAcc(string uname, string pass, string cusid)
        {
            SqlCommand command = new SqlCommand("update ACCOUNTCUSTOMER set password=@pass where username=@uname and customerid=@customerid ", db.getConnection);
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = uname;
            command.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pass;
            command.Parameters.Add("@customerid", SqlDbType.NVarChar).Value = cusid;
            db.Openconnection();
            if (command.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                db.Closeconnection();
                return false;
            }
        }
        public bool insertNewAcc(string uname, string pass,string cusid)
        {
            SqlCommand command = new SqlCommand("insert into ACCOUNTCUSTOMER (username,password,customerid) values (@uname,@pass,@customerid)", db.getConnection);
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = uname;
            command.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pass;
            command.Parameters.Add("@customerid", SqlDbType.NVarChar).Value = cusid;
            db.Openconnection();
            if (command.ExecuteNonQuery() == 1)
            {
                return true;
            }
            else
            {
                db.Closeconnection();
                return false;
            }
        }
        public bool IsExistUsername(string username)
        {
            SqlCommand command = new SqlCommand("select * from ACCOUNTCUSTOMER where username=@uname", db.getConnection);
            command.Parameters.Add("@uname", SqlDbType.NVarChar).Value = username;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if(table.Rows.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsCusAlrHaveAccount(string cusid)
        {
            SqlCommand command = new SqlCommand("select * from ACCOUNTCUSTOMER where customerid=@cid", db.getConnection);
            command.Parameters.Add("@cid", SqlDbType.NVarChar).Value = cusid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable LoadDataAccCusById(string cid)
        {
            SqlCommand command = new SqlCommand("select username as 'Tên tài khoản', password as 'Mật khẩu',Actualtimeavl as'Thời gian sử dụng còn lại', " +
                "Timeavailible,timeused,customerid as 'Mã khách',deviceid as 'Mã máy sử dụng'," +
                "statuscustomer as 'Trạng thái' from Accountcustomer where customerid=@cid", db.getConnection);
            command.Parameters.Add("cid", SqlDbType.NVarChar).Value = cid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
