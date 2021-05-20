using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FinalDBMS
{
    class MyInfo
    {
        Mydb db = new Mydb();
        public DataTable takeMyInfo(string EmpID)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Func_TakeMyInfo('" + @EmpID + "')", db.getConnection);
            cmd.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = EmpID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable takeNameandPic(string EmpID)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Func_TakeNameandPic('" + @EmpID + "')", db.getConnection);
            cmd.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = EmpID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public bool editMyInfo(string ID, string name, string gender, DateTime birth, string phone, string identity, string email)
        {
            SqlCommand command = new SqlCommand("Edit_MyInfo", db.getConnection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = ID;
            command.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
            command.Parameters.Add("@gender", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@birth", SqlDbType.DateTime).Value = birth;
            command.Parameters.Add("@phone", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@Identity", SqlDbType.NVarChar).Value = identity;
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;

            db.Openconnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                db.Closeconnection();
                return true;
            }
            else
            {
                db.Closeconnection();
                return false;
            }
        }
    }
}
