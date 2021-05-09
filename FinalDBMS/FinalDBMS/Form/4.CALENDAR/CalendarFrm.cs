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
    public partial class CalendarFrm : Form
    {
        public CalendarFrm()
        {
            InitializeComponent();
        }

        Mydb db = new Mydb();
        Salary salary = new Salary();

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (salary.CheckIDEmployee(txtID.Text))
            {
                if (!salary.CheckIDWork(txtID.Text))
                {
                    salary.AddCheckIn(txtID.Text);
                    dataGridViewTimeKeeping.DataSource = salary.ShowTimeKeeping();
                }
                else
                    MessageBox.Show("ID is working. Can't check in");
            }
            else
                MessageBox.Show("Can't find the ID");
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (salary.CheckIDWork(txtID.Text))
            {
                salary.AddCheckOut(txtID.Text);
                dataGridViewTimeKeeping.DataSource = salary.ShowTimeKeeping();
            }
            else
                MessageBox.Show("Can't find the ID");
        }
    }
}
