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
            SqlCommand command = new SqlCommand("USP_CheckIN @IDEmployee", db.getConnection);
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
            SqlCommand command = new SqlCommand("USP_CheckOut @IDEmployee", db.getConnection);
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
            SqlCommand command = new SqlCommand("USP_CheckIDEmployee @IDEmployee", db.getConnection);
            command.Parameters.Add("@IDEmployee", System.Data.SqlDbType.NVarChar).Value = ID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data.Rows.Count > 0;
        }
        public bool CheckIDWork(string ID)
        {
            SqlCommand command = new SqlCommand("USP_CheckIDEmployeeWorking @IDEmployee", db.getConnection);
            command.Parameters.Add("@IDEmployee", System.Data.SqlDbType.NVarChar).Value = ID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data.Rows.Count > 0;
        }
        public DataTable ShowTimeKeeping()
        {
            SqlCommand command = new SqlCommand("USP_ShowFullTimeKeeping", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
        public DataTable ShowSalary()
        {
            SqlCommand command = new SqlCommand("USP_ShowSalary", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
        public DataTable SearchSalaryByMonthYear(int month, int year)
        {
            SqlCommand command = new SqlCommand("USP_SearchSalaryByMonthYear @Month, @Year", db.getConnection);
            command.Parameters.Add("@Month", SqlDbType.Int).Value = month;
            command.Parameters.Add("@Year", SqlDbType.Int).Value = year;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
        public DataTable SearchSalaryByMonth(int month)
        {
            SqlCommand command = new SqlCommand("USP_SearchSalaryByMonth @Month", db.getConnection);
            command.Parameters.Add("@Month", SqlDbType.Int).Value = month;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
        public DataTable SearchSalaryByYear(int year)
        {
            SqlCommand command = new SqlCommand("USP_SearchSalaryByYear @Year", db.getConnection);
            command.Parameters.Add("@Year", SqlDbType.Int).Value = year;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return data;
        }
    }
}
