using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDBMS
{
    class Employee
    {
        Mydb db = new Mydb();

        public DataTable getEmployees(SqlCommand command)
        {
            command.Connection = db.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getEmployeesByID(string id)
        {
            SqlCommand com = new SqlCommand("select * from EMPLOYEE where ID = @id");

            com.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

            return getEmployees(com);
        }

        public DataTable getAllEmployees()
        {
            SqlCommand com = new SqlCommand("select ID, FullName as 'Họ Tên', Gender as 'Giới tính', Birthday as 'Ngày sinh', Phone as 'SĐT', " +
                "IdentityNumber as 'Số CMND', StatusEmployee as 'Trạng thái', Email, WorkID as 'Mã CV', Picture as 'Hình ảnh' from EMPLOYEE");
            DataTable tab = getEmployees(com);
            return tab;
        }

        public int totalEmps()              //đếm tổng số nhân viên
        {
            SqlCommand total = new SqlCommand("select count(ID) as totalEmp from EMPLOYEE group by ID");
            DataTable ttstu = getEmployees(total);
            return ttstu.Rows.Count;
        }

        public int totalMaleEmps()          //đếm tổng số nhân viên nam
        {
            SqlCommand totalmale = new SqlCommand("select * from EMPLOYEE where Gender = 'Nam'", db.getConnection);
            DataTable ttmstu = getEmployees(totalmale);
            return ttmstu.Rows.Count;
        }

        public int totalFemaleEmps()     //đếm tổng số nhân viên nữ
        {
            int total = totalEmps();
            int totalMale = totalMaleEmps();
            return total - totalMale;
        }

        public bool insertEmp(string id, string fullname, string gender, DateTime bdate, string phone, string identity, string status, string email, string workid, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("insert into EMPLOYEE (ID, FullName, Gender, BirthDay, Phone, IdentityNumber, StatusEmployee, Email, WorkID, Picture) " +
                "values (@id, @fn, @gdr, @bdt, @phn, @iden, @status, @mail, @wid, @pic)", db.getConnection);

            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fullname;
            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@iden", SqlDbType.NVarChar).Value = identity;
            command.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            command.Parameters.Add("@mail", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@wid", SqlDbType.NVarChar).Value = workid;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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

        public bool removeEmp(string id)
        {
            SqlCommand cmd = new SqlCommand("delete from EMPLOYEE where ID = @id", db.getConnection);

            cmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

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

        public bool updateEmp(string id, string fullname, string gender, DateTime bdate, string phone, string identity, string status, string email, string workid, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("update EMPLOYEE set FullName = @fn, Gender = @gdr, BirthDay = @bdt, Phone = @phn, IdentityNumber = @iden, StatusEmployee = @status, " +
                "Email = @mail, WorkID = @wid, picture = @pic where ID = @id ", db.getConnection);

            command.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fullname;
            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@phn", SqlDbType.NVarChar).Value = phone;
            command.Parameters.Add("@iden", SqlDbType.NVarChar).Value = identity;
            command.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            command.Parameters.Add("@mail", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@wid", SqlDbType.NVarChar).Value = workid;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

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

        public bool checkID(string id)
        {
            SqlCommand com = new SqlCommand("select * from EMPLOYEE where id = @id", db.getConnection);

            com.Parameters.Add("@id", SqlDbType.NVarChar).Value = id;

            SqlDataAdapter adapter = new SqlDataAdapter(com);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count == 0)
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
