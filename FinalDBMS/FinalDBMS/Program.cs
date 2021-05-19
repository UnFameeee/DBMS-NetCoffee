using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalDBMS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //LoginFrm frm = new LoginFrm();
            //Application.Run(frm);
            //if (frm.DialogResult == DialogResult.OK)
            //{
            //    Application.Run(new MainFrm());
            //}
            Application.Run(new MainFrm());
        }
    }
}
