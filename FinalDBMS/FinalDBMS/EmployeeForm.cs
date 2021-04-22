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


        private void Menu_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            lbMenu.Text = btn.ToString();

            foreach (Control item in flpLeftMenu.Controls)
                item.BackColor = flpLeftMenu.BackColor;            

            btn.BackColor = Color.WhiteSmoke;
        }
    }
}
