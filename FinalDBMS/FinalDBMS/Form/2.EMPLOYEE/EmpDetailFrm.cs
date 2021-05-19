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
    public partial class EmpDetailFrm : Form
    {        
        public EmpDetailFrm()
        {
            InitializeComponent();            
        }

        string empid;
        public EmpDetailFrm(string id) : this()
        {
            empid = id;
        }

        Employee emp = new Employee();

        private void EmpDetailFrm_Load(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("Select * from JOB");           //lấy thông tin chi tiết từ mã WorkID
            cbboxWorkID.DataSource = emp.getEmployees(com);
            cbboxWorkID.DisplayMember = "JobDetail";
            cbboxWorkID.ValueMember = "WorkID";
            cbboxWorkID.SelectedItem = null;


            DataTable tab = emp.getEmployeesByID(empid);

            tbEmpID.Text = tab.Rows[0][0].ToString();
            tbName.Text = tab.Rows[0][1].ToString();
            cbboxGender.SelectedItem = tab.Rows[0][2].ToString();
            dtpBdate.Value = (DateTime)tab.Rows[0][3];
            tbPhone.Text = tab.Rows[0][4].ToString();
            tbIdentity.Text = tab.Rows[0][5].ToString();
            tbStatus.Text = tab.Rows[0][6].ToString();
            tbMail.Text = tab.Rows[0][7].ToString();
            cbboxWorkID.SelectedValue = tab.Rows[0][8].ToString();

            byte[] pic;
            pic = (byte[])tab.Rows[0][9];
            MemoryStream picture = new MemoryStream(pic);
            ptbEmp.Image = Image.FromStream(picture);
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = tbEmpID.Text;
            string fname = tbName.Text;

            string gender = cbboxGender.SelectedItem.ToString();

            DateTime bdate = dtpBdate.Value;
            string phone = tbPhone.Text;
            string identity = tbIdentity.Text;
            string status = tbStatus.Text;
            string email = tbMail.Text;
            string workid = cbboxWorkID.SelectedValue.ToString();

            if(verif())
            {
                MemoryStream pic = new MemoryStream();
                ptbEmp.Image.Save(pic, ptbEmp.Image.RawFormat);
                if (emp.updateEmp(id, fname, gender, bdate, phone, identity, status, email, workid, pic))
                {
                    MessageBox.Show("Cập nhật thông tin nhân viên " + fname + " thành công", "Cập nhật thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin nhân viên " + fname, "Cập nhật thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Hãy điển đầy đủ thông tin nhân viên", "Cập nhật thông tin nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string id = tbEmpID.Text;
            string fname = tbName.Text;

            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên " + tbName.Text, "Xóa nhân viên", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (emp.removeEmp(id))
                    {
                        MessageBox.Show("Nhân viên " + tbName.Text + " đã được xóa", "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa nhân viên " + tbName.Text, "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Xóa nhân viên", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        bool verif()
        {
            if (tbEmpID.Text.Trim() == ""
                || cbboxGender.SelectedItem == null
                || tbName.Text.Trim() == ""
                || tbPhone.Text.Trim() == ""
                || tbMail.Text.Trim() == ""
                || tbIdentity.Text.Trim() == ""
                // || tbStatus.Text.Trim() == ""
                || cbboxWorkID.SelectedItem == null
                || dtpBdate.Value == null) 
                return false;
            else return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
