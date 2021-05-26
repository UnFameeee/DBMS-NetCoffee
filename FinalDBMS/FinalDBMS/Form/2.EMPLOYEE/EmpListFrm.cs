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
            dgvEmp.AllowUserToAddRows = false;
            dgvEmp.AllowUserToResizeRows = false;
            dgvEmp.AllowUserToOrderColumns = false;
            dgvEmp.AllowUserToResizeColumns = false;
        }

        void reload()
        {
            SqlCommand com = new SqlCommand("select ID, FullName as 'Họ Tên', Gender as 'Giới tính', Birthday as 'Ngày sinh', Phone as 'SĐT', " +
                "IdentityNumber as 'Số CMND', StatusEmployee as 'Trạng thái', Email, WorkID as 'Mã CV', Picture as 'Hình ảnh' from EMPLOYEE");
            dgvEmp.DataSource = emp.getEmployees(com);

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

            lbToTal.Text = "Tổng nhân viên " + emp.totalEmps().ToString();
            lbMale.Text = "Nam: " + emp.totalMaleEmps().ToString();
            lbFemale.Text = "Nữ: " + emp.totalFemaleEmps().ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEmpFrm frm = new AddEmpFrm();
            frm.ShowDialog();
            reload();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            string id = dgvEmp.CurrentRow.Cells[0].Value.ToString();
            EmpDetailFrm frm = new EmpDetailFrm(id);
            frm.ShowDialog();
            reload();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            reload();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (tbSearch.Text == "")
                MessageBox.Show("Vui lòng điền ID");
            else
            {
                SqlCommand com = new SqlCommand("select ID, FullName as 'Họ Tên', Gender as 'Giới tính', Birthday as 'Ngày sinh', Phone as 'SĐT', " +
                    "IdentityNumber as 'Số CMND', StatusEmployee as 'Trạng thái', Email, WorkID as 'Mã CV', Picture as 'Hình ảnh' from EMPLOYEE where ID = '" + tbSearch.Text + "'");

                DataTable tab = emp.getEmployees(com);

                if (tab.Rows.Count == 0)
                    MessageBox.Show("Không tìm thấy ID " + tbSearch.Text);
                else
                {
                    dgvEmp.DataSource = tab;

                    DataGridViewImageColumn picCol = new DataGridViewImageColumn();
                    dgvEmp.RowTemplate.Height = 80;
                    //if(dgvEmp.Columns[9] != DBNull.Value)
                    //{ 

                    //}
                    picCol = (DataGridViewImageColumn)dgvEmp.Columns[9];
                    picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

                    dgvEmp.Columns[0].Width = 40;
                    dgvEmp.Columns[1].Width = 150;
                    dgvEmp.Columns[2].Width = 80;
                    dgvEmp.Columns[5].Width = 150;
                    dgvEmp.Columns[6].Width = 150;
                    dgvEmp.Columns[8].Width = 50;
                }
            }
        }

        private void btnFemale_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select ID, FullName as 'Họ Tên', Gender as 'Giới tính', Birthday as 'Ngày sinh', Phone as 'SĐT', " +
               "IdentityNumber as 'Số CMND', StatusEmployee as 'Trạng thái', Email, WorkID as 'Mã CV', Picture as 'Hình ảnh' from EMPLOYEE where Gender = N'Nữ'");
            dgvEmp.DataSource = emp.getEmployees(com);

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
        }

        private void btnMale_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("select ID, FullName as 'Họ Tên', Gender as 'Giới tính', Birthday as 'Ngày sinh', Phone as 'SĐT', " +
                "IdentityNumber as 'Số CMND', StatusEmployee as 'Trạng thái', Email, WorkID as 'Mã CV', Picture as 'Hình ảnh' from EMPLOYEE where Gender = 'Nam'");
            dgvEmp.DataSource = emp.getEmployees(com);

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
        }

        private void dgvEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnSearchName_Click(object sender, EventArgs e)
        {
            Mydb db = new Mydb();
            if(tbSearchName.Text != "")
            {
                string EmpID = tbSearchName.Text;
                SqlCommand cmd = new SqlCommand("SELECT * FROM dbo.Func_SearchEmployeesWithName('" + EmpID + "')", db.getConnection);
                cmd.Parameters.Add("@EmpID", SqlDbType.NVarChar).Value = EmpID;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable table = new DataTable();
                adapter.Fill(table);
                table.Columns["ID"].ColumnName = "ID";
                table.Columns["FullName"].ColumnName = "Họ tên";
                table.Columns["Gender"].ColumnName = "Giới tính";
                table.Columns["Birthday"].ColumnName = "Ngày sinh";
                table.Columns["Phone"].ColumnName = "SĐT";
                table.Columns["IdentityNumber"].ColumnName = "Số CMND";
                table.Columns["StatusEmployee"].ColumnName = "Trạng thái";
                table.Columns["Email"].ColumnName = "Email";
                table.Columns["WorkID"].ColumnName = "Mã CV";
                table.Columns["Picture"].ColumnName = "Hình ảnh";
                //fill dgv
                dgvEmp.DataSource = table;
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
            }
            else
            {
                MessageBox.Show("Hãy điền tên nhân viên!!!", "Tìm kiếm theo tên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
