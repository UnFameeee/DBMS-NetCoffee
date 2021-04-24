using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalDBMS
{
    class LoginData
    {
        Mydb db = new Mydb();
        public bool CreateNewUser(string id,string user, string pass,string typeid, string email,string fn,string gdr,DateTime bd,string ph,string idt,string status)
        {
            SqlCommand command2 = new SqlCommand("insert into EMPLOYEE (ID,FullName,Gender,Birthday,Phone,IdentityNumber,StatusEmployee,Email,WorkID)" + 
                "values(@Id,@fn,@gdr,@bd,@phone,@idt,@sta,@email,@workid)", db.getConnection);
            command2.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;
            command2.Parameters.Add("@fn", SqlDbType.VarChar).Value = fn;
            command2.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gdr;
            command2.Parameters.Add("@bd", SqlDbType.DateTime).Value = bd;
            command2.Parameters.Add("@phone", SqlDbType.VarChar).Value = ph;
            command2.Parameters.Add("@idt", SqlDbType.VarChar).Value = idt;
            command2.Parameters.Add("@sta", SqlDbType.VarChar).Value = status;
            command2.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command2.Parameters.Add("@workid", SqlDbType.VarChar).Value = typeid;


            SqlCommand command = new SqlCommand("insert into ACCOUNTEMPLOYEE (ID,Username,Password,TypeEmployee,Gmail)" + "values(@Id,@user,@pass,@typeid,@email)", db.getConnection);
            command.Parameters.Add("@user", SqlDbType.VarChar).Value = user;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = pass;
            command.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@typeid", SqlDbType.VarChar).Value = typeid;
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = id;

            db.Openconnection();
            try
            {
                if ((command2.ExecuteNonQuery() == 1) &&(command.ExecuteNonQuery()==1))
                {

                    db.Closeconnection();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ten tai khoan hoac Id nay da duoc su dung Error"+ex.Message, "Register User", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.Closeconnection();
            return false;
        }
        public DataTable getUser(SqlCommand command)
        {
            command.Connection = db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool RocoveryPass(string username, string newpass)
        {
            SqlCommand command = new SqlCommand("update Login set Password =@newpass where Username =@username", db.getConnection);
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@newpass", SqlDbType.VarChar).Value = newpass;
            db.Openconnection();
            try
            {
                if ((command.ExecuteNonQuery() == 1))
                {
                    db.Closeconnection();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.InnerException.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            db.Closeconnection();
            return false;
        }
    }
}
