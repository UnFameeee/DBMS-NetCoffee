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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void EmployeeForm_Load(object sender, EventArgs e)
        {
            foreach (Control item in flpLeftMenu.Controls)
                item.Width = flpLeftMenu.Width;
            btnProfile.PerformClick();
        }
        private void btn__Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnbig_Click(object sender, EventArgs e)
        {
            this.WindowState = (this.WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnLeftMenu_Click(object sender, EventArgs e)
        {
            pnLeft.Width = (pnLeft.Width == 200) ? 50 : 200;
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            lbMenu.Text = btn.Tag.ToString();

            foreach (Control item in flpLeftMenu.Controls)
                item.BackColor = flpLeftMenu.BackColor;

            if (btn.Name != btnHelp.Name)
                btnHelp.BackColor = flpLeftMenu.BackColor;

            btn.BackColor = Color.Aquamarine;
        }
    }
}
