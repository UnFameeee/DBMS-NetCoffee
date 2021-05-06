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
    public partial class SalaryFrm : Form
    {
        public SalaryFrm()
        {
            InitializeComponent();
        }
        Salary salary = new Salary();
        private void btnShow_Click(object sender, EventArgs e)
        {
            dataGridViewShow.DataSource = salary.ShowSalary();
            dataGridViewShow.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
