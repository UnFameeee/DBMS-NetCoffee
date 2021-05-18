using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDBMS
{
    class CustomerData
    {
        Mydb db = new Mydb();
        public bool RemoveCustomer(string Cusid)
        {
            SqlCommand command = new SqlCommand("EXECUTE dbo.deleteById_customer @cid = @id", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = Cusid;
            db.Openconnection();
            if(command.ExecuteNonQuery()==1)
            {
                return true;
            }
            else
            {
                db.Closeconnection();
                return false;
            }
        }
        public bool EditCustomer(string cid,string fn,string phone,string cmnd,float money)
        {
            //SqlCommand command = new SqlCommand("update CUSTOMER set CustomerID=@cid,FullName=@fn,PhoneNumber=@phone,IdentityCardNumber=@cmnd,MoneyCharged=@money" +
            //    "  where CustomerID=@cid", db.getConnection);
            SqlCommand command = new SqlCommand("EXECUTE dbo.EditInfo_customer " +
                "@cid = @id, " +
                "@ful = @fn , " +
                "@phn = @phone, " +
                "@icn = @cmnd, " +
                "@mon = @money  ", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = cid;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fn;
            command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@cmnd", SqlDbType.NVarChar).Value =cmnd;
            command.Parameters.Add("@money", SqlDbType.Float).Value = money;
            db.Openconnection();
            if(command.ExecuteNonQuery()==1)
            {
                return true;
            }
            else
            {
                db.Closeconnection();
                return false;
            }
        }
        public bool AddCustomer(string cid, string fn, string phone, string cmnd, float money)
        {
            
            SqlCommand command = new SqlCommand("EXECUTE dbo.Create_customer " +
                "@cid = @id, " +
                "@ful = @fn, " +
                "@phn = @phone,  " +
                "@icn = @cmnd,  " +
                "@mon = @money ", db.getConnection);

            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = cid;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fn;
            command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@cmnd", SqlDbType.NVarChar).Value = cmnd;
            command.Parameters.Add("@money", SqlDbType.Float).Value = money;
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
        public bool CustomerAlrExist(string cid)
        {
            SqlCommand command = new SqlCommand("select * from CUSTOMER where CustomerID=@cid", db.getConnection);
            command.Parameters.Add("@cid", SqlDbType.NVarChar).Value = cid;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable taable = new DataTable();
            adapter.Fill(taable);
            if (taable.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable GetallCus()
        {
            SqlCommand command = new SqlCommand("select customerid as 'Mã khách',fullname as 'Họ tên'," +
                "phonenumber as 'Sdt', identitycardnumber as 'CMND',moneycharged as 'Số tiền' from CUSTOMER", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

    }
}
