using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalDBMS
{
    public partial class EmpListFrm : Form
    {
        public EmpListFrm()
        {
            InitializeComponent();
        }

        Employee emp = new Employee();

        private void EmpListFrm_Load(object sender, EventArgs e)
        {
            reload();
        }

        void reload()
        {
            dgvEmp.DataSource = emp.getAllEmployees();

            DataGridViewImageColumn picCol = new DataGridViewImageColumn();
            dgvEmp.RowTemplate.Height = 80;
            picCol = (DataGridViewImageColumn)dgvEmp.Columns[9];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dgvEmp.Columns[0].Width = 40;
            dgvEmp.Columns[1].Width = 150;
            dgvEmp.Columns[2].Width = 80;
            dgvEmp.Columns[5].Width = 150;
            dgvEmp.Columns[6].Width = 150;
            dgvEmp.Columns[8].Width = 50;

            lbToTal.Text = "Total Employees: " + emp.totalEmps().ToString();
            lbMale.Text = "Male: " + emp.totalMaleEmps().ToString();
            lbFemale.Text = "Female: " + emp.totalFemaleEmps().ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmpFrm frm = new AddEmpFrm();
            frm.Show();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            string id = dgvEmp.CurrentRow.Cells[0].Value.ToString();
            EmpDetailFrm frm = new EmpDetailFrm(id);
            frm.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from EMPLOYEE where FullName LIKE '%" + tbSearch.Text + "%'");
            dgvEmp.DataSource = emp.getEmployees(com);
        }

        private void btnFemale_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from EMPLOYEE where Gender = 'Nu'");
            dgvEmp.DataSource = emp.getEmployees(com);
        }

        private void btnMale_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select * from EMPLOYEE where Gender = 'Nam'");
            dgvEmp.DataSource = emp.getEmployees(com);
        }
    }
}
