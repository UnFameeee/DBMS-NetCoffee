using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalDBMS
{
    class Mydb
    {
        //SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-7RGSHQT;Initial Catalog=DBMS_FinalProject;Integrated Security=True");              //--Dibu
        //SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-7RGSHQT;Initial Catalog=DBMS_FinalProjectBackup;Integrated Security=True");  //TEST DIBU

        //SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-26GDDIM\SQLEXPRESS;Initial Catalog=DBMS_FinalProject;Integrated Security=True");   //--2 dụ

        //SqlConnection db = new SqlConnection(@"Data Source=.\;Initial Catalog=Payroll;Integrated Security=True");                                     //Tien

        //SqlConnection db = new SqlConnection(@"Data Source=DESKTOP-0NTKRTC\MSSQLSERVER03;Initial Catalog=DBMS_FinalProject;Integrated Security=True");//--Sơn Thạch

       SqlConnection db = new SqlConnection(@"Data Source=.\;Initial Catalog=DBMS_FinalProject;Integrated Security=True");
        public SqlConnection getConnection
        {
            get { return db; }
        }
        public void Openconnection()
        {
            if (db.State == ConnectionState.Closed) 
                db.Open();
        }
        public void Closeconnection()
        {
            if (db.State == ConnectionState.Open) 
                db.Close();
        }
    }
}
