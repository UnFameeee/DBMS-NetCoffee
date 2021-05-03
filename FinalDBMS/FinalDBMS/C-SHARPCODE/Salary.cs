using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDBMS
{
    public class Salary
    {
        Mydb db = new Mydb();
        public bool AddCheckIn(string ID)
        {
            
            SqlCommand command = new SqlCommand("INSERT INTO dbo.WORK (IDEmployee, CheckIn) VALUES (@IDEmployee, GETDATE())", db.getConnection);
            command.Parameters.Add("@IDEmployee", System.Data.SqlDbType.NVarChar).Value = ID;
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
        public bool AddCheckOut(string ID)
        {
            SqlCommand command = new SqlCommand("UPDATE WORK SET CheckOut = GETDATE() WHERE IDEmployee = @IDEmployee", db.getConnection);
            command.Parameters.Add("@IDEmployee", System.Data.SqlDbType.NVarChar).Value = ID;
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
        public bool CheckIDEmployee (string ID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM EMPLOYEE WHERE IDEmployee = @IDEmployee", db.getConnection);
            command.Parameters.Add("@IDEmployee", System.Data.SqlDbType.NVarChar).Value = ID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data.Rows.Count > 0;
        }
        public bool CheckIDWork(string ID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM WORK WHERE IDEmployee = @IDEmployee", db.getConnection);
            command.Parameters.Add("@IDEmployee", System.Data.SqlDbType.NVarChar).Value = ID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data.Rows.Count > 0;
        }
        public DataTable ShowTimeKeeping()
        {
            SqlCommand command = new SqlCommand("SELECT IDEmployee, CheckIn, CheckOut FROM WORK", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
        public DataTable ShowSalary()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM SALARY", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
