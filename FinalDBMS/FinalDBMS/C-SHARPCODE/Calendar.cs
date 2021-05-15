using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace FinalDBMS
{
    class Calendar
    {
        Mydb db = new Mydb();

        public DataTable takePic(string EmpID)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Func_TakePicWhenCheckin('@EmpID')", db.getConnection);
            cmd.Parameters.Add("@EmpID", SqlDbType.VarChar).Value = EmpID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable takeInfoForCalendar(string EmpID)
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Func_TakeInfoWhenCheckin('@EmpID')", db.getConnection);
            cmd.Parameters.Add("@EmpID", SqlDbType.VarChar).Value = EmpID;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
