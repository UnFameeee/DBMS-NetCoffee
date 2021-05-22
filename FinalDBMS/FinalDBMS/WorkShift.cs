using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FinalDBMS
{
    class WorkShift
    {
        Mydb db = new Mydb();

        #region phần trên
        public bool AddDivideShift(string EmpID, string ShiftID, string ShiftManagerID)
        {
            SqlCommand cmd = new SqlCommand("AddDivideShift", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = EmpID;
            cmd.Parameters.Add("@ShiftID", SqlDbType.NVarChar).Value = ShiftID;
            cmd.Parameters.Add("@ShiftManagerID", SqlDbType.NVarChar).Value = ShiftManagerID;
            db.Openconnection();
            if ((cmd.ExecuteNonQuery() == 1))
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
        public bool UpdateDivideShift(string EmpID, string ShiftID, string ShiftManagerID)
        {
            SqlCommand cmd = new SqlCommand("UpdateDivideShift", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = EmpID;
            cmd.Parameters.Add("@ShiftID", SqlDbType.NVarChar).Value = ShiftID;
            cmd.Parameters.Add("@ShiftManagerID", SqlDbType.NVarChar).Value = ShiftManagerID;
            db.Openconnection();
            if ((cmd.ExecuteNonQuery() == 1))
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
        public bool DeleteDivideShift(string EmpID, string ShiftID, string ShiftManagerID)
        {
            SqlCommand cmd = new SqlCommand("DeleteDivideShift", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = EmpID;
            cmd.Parameters.Add("@ShiftID", SqlDbType.NVarChar).Value = ShiftID;
            cmd.Parameters.Add("@ShiftManagerID", SqlDbType.NVarChar).Value = ShiftManagerID;
            db.Openconnection();
            if ((cmd.ExecuteNonQuery() == 1))
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

        public bool check1(string EmpID, string ShiftID, string ShiftManagerID)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM WORK WHERE EmpID = @EmpID and ShiftID = @ShiftID and ShiftManagerID = @ShiftManagerID", db.getConnection);
            cmd.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = EmpID;
            cmd.Parameters.Add("@ShiftID", SqlDbType.NVarChar).Value = ShiftID;
            cmd.Parameters.Add("@ShiftManagerID", SqlDbType.NVarChar).Value = ShiftManagerID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
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
        public DataTable Find1(string EmpID)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM WORK WHERE EmpID = @EmpID", db.getConnection);
            cmd.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = EmpID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        #endregion

        #region phần dưới
        public bool AddDivideTimeShift(string ShiftID, TimeSpan TimeBegin, TimeSpan TimeEnd)
        {
            SqlCommand cmd = new SqlCommand("AddDivideTimeShift", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ShiftID", SqlDbType.NVarChar).Value = ShiftID;
            cmd.Parameters.Add("@TimeBegin", SqlDbType.Time).Value = TimeBegin;
            cmd.Parameters.Add("@TimeEnd", SqlDbType.Time).Value = TimeEnd;
            db.Openconnection();
            if ((cmd.ExecuteNonQuery() == 1))
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
        public bool UpdateDivideTimeShift(string ShiftID, TimeSpan TimeBegin, TimeSpan TimeEnd)
        {
            SqlCommand cmd = new SqlCommand("UpdateDivideTimeShift", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ShiftID", SqlDbType.NVarChar).Value = ShiftID;
            cmd.Parameters.Add("@TimeBegin", SqlDbType.Time).Value = TimeBegin;
            cmd.Parameters.Add("@TimeEnd", SqlDbType.Time).Value = TimeEnd;
            db.Openconnection();
            if ((cmd.ExecuteNonQuery() == 1))
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
        public bool DeleteDivideTimeShift(string ShiftID)
        {
            SqlCommand cmd = new SqlCommand("DeleteDivideTimeShift", db.getConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ShiftID", SqlDbType.NVarChar).Value = ShiftID;
            db.Openconnection();
            if ((cmd.ExecuteNonQuery() == 1))
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
        public bool check2(string ShiftID)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM WORKSHIFT WHERE ShiftID = @ShiftID", db.getConnection);
            cmd.Parameters.Add("@ShiftID", SqlDbType.NVarChar).Value = ShiftID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if (table.Rows.Count > 0)
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
        public DataTable Find2(string ShiftID)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM WORKSHIFT WHERE ShiftID = @ShiftID", db.getConnection);
            cmd.Parameters.Add("@ShiftID", SqlDbType.NVarChar).Value = ShiftID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        #endregion

        #region fill DGV
        public DataTable fillDGV()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM WORK", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable fillDGV2()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM WORKSHIFT", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        #endregion
    }
}
