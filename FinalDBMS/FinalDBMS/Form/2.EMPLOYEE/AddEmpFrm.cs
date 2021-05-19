using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalDBMS
{
    public partial class AddEmpFrm : Form
    {
        public AddEmpFrm()
        {
            InitializeComponent();
        }

        Employee emp = new Employee();

        private void AddEmpFrm_Load(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("Select * from JOB");           //lấy thông tin chi tiết từ mã WorkID
            cbbxWorkID.DataSource = emp.getEmployees(com);
            cbbxWorkID.DisplayMember = "JobDetail";
            cbbxWorkID.ValueMember = "WorkID";
            cbbxWorkID.SelectedItem = null;
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Select Image(*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif";
            if (opf.ShowDialog() == DialogResult.OK)
            {
                ptbEmp.Image = Image.FromFile(opf.FileName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string id = tbEmpID.Text;
            string fname = tbName.Text;

            string gender = "Nam";
            if (rdbtnFemale.Checked)
                gender = "Nữ";

            DateTime bdate = dtpBDate.Value;
            string phone = tbPhone.Text;
            string identity = tbIdentity.Text;
            string status = tbStatus.Text;
            string email = tbMail.Text;
            string workid = cbbxWorkID.SelectedValue.ToString();

            if(verif())
            {
                MemoryStream pic = new MemoryStream();
                ptbEmp.Image.Save(pic, ptbEmp.Image.RawFormat);

                if (emp.checkID(id))
                {
                    if (emp.insertEmp(id, fname, gender, bdate, phone, identity, status, email, workid, pic))
                    {
                        MessageBox.Show("Nhân viên " + fname + " đã được thêm vào", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadFrm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm nhân viên " + fname, "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Nhân viên " + fname + " đã có trong danh sách", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin của nhân viên", "Thêm nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        bool verif()
        {
            if (tbEmpID.Text.Trim() == ""
                || tbName.Text.Trim() == ""
                || tbPhone.Text.Trim() == ""
                || tbMail.Text.Trim() == ""
               // || tbStatus.Text.Trim() == ""
                || tbIdentity.Text.Trim() == ""
                || cbbxWorkID.SelectedItem == null
                || ptbEmp.Image == null)
                return false;
            else return true;
        }

        void reloadFrm()
        {
            tbEmpID.Text = null;
            tbName.Text = null;
            rdbtnMale.Checked = true;
            tbPhone.Text = null;
            tbIdentity.Text = null;
            tbStatus.Text = null;
            tbMail.Text = null;
            cbbxWorkID.SelectedItem = null;
            ptbEmp.Image = null;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
