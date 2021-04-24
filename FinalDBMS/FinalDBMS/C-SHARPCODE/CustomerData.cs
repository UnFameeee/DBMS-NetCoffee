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
            SqlCommand command = new SqlCommand("delete from CUSTOMER where CustomerID=@cid", db.getConnection);
            command.Parameters.Add("@cid", SqlDbType.VarChar).Value = Cusid;
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
        public bool EditCustomer(string cid,string fn,string phone,string cmnd,string money)
        {
            SqlCommand command = new SqlCommand("update CUSTOMER set CustomerID=@cid,FullName=@fn,PhoneNumber=@phone,IdentityCardNumber=@cmnd,MoneyCharged=@money" +
                "  where CustomerID=@cid", db.getConnection);
            command.Parameters.Add("@cid", SqlDbType.VarChar).Value = cid;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fn;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cmnd", SqlDbType.VarChar).Value =cmnd;
            command.Parameters.Add("@money", SqlDbType.VarChar).Value = money;
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
        public bool AddCustomer(string cid, string fn, string phone, string cmnd, string money)
        {
            SqlCommand command = new SqlCommand("insert into CUSTOMER (CustomerID,FullName,PhoneNumber,IdentityCardNumber,MoneyCharged) values(@id,@fn,@phone,@cmnd,@money)", db.getConnection);
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = cid;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fn;
            command.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@cmnd", SqlDbType.VarChar).Value = cmnd;
            command.Parameters.Add("@money", SqlDbType.VarChar).Value = money;
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
            command.Parameters.Add("@cid", SqlDbType.VarChar).Value = cid;

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

    }
}
