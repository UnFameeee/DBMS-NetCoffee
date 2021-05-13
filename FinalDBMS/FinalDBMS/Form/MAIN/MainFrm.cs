using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalDBMS
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCustomerFrm frm = new AddCustomerFrm();
            frm.Show();
        }

        private void TimeKeepingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CalendarFrm frm = new CalendarFrm() { TopLevel = false, TopMost = false};
            pnlMain.Controls.Add(frm);
            frm.Show();
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EmpListFrm frm = new EmpListFrm() { TopLevel = false, TopMost = false };
            pnlMain.Controls.Add(frm);
            frm.Show();
        }
    }
}
