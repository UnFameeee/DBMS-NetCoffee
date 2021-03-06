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
            command2.Parameters.Add("@Id", SqlDbType.NVarChar).Value = id;
            command2.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fn;
            command2.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gdr;
            command2.Parameters.Add("@bd", SqlDbType.DateTime).Value = bd;
            command2.Parameters.Add("@phone", SqlDbType.NVarChar).Value = ph;
            command2.Parameters.Add("@idt", SqlDbType.NVarChar).Value = idt;
            command2.Parameters.Add("@sta", SqlDbType.NVarChar).Value = status;
            command2.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command2.Parameters.Add("@workid", SqlDbType.NVarChar).Value = typeid;
            db.Openconnection();

            SqlCommand command = new SqlCommand("insert into ACCOUNTEMPLOYEE (ID,Username,Password,TypeEmployee)" + "values(@Id,@user,@pass,@typeid)", db.getConnection);
            command.Parameters.Add("@user", SqlDbType.NVarChar).Value = user;
            command.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pass;
            command.Parameters.Add("@typeid", SqlDbType.NVarChar).Value = typeid;
            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = id;

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
                MessageBox.Show("Error"+ex.Message, "Register User Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        public bool updateAccount(string id, string user, string pass, string typeid)
        {
            SqlCommand command = new SqlCommand("update ACCOUNTEMPLOYEE  set Username = @user,Password = @pass ,TypeEmployee = @typeid where ID = @Id", db.getConnection);
            command.Parameters.Add("@user", SqlDbType.NVarChar).Value = user;
            command.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pass;
            command.Parameters.Add("@typeid", SqlDbType.NVarChar).Value = typeid;
            command.Parameters.Add("@Id", SqlDbType.NVarChar).Value = id;

            db.Openconnection();
            if (command.ExecuteNonQuery() == 1)
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

        public bool removeAccount(string id)
        {
            SqlCommand cmd = new SqlCommand("delete from ACCOUNTEMPLOYEE where ID = @Id", db.getConnection);
            cmd.Parameters.Add("@Id", SqlDbType.NVarChar).Value = id;

            db.Openconnection();
            if (cmd.ExecuteNonQuery() == 1)
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
