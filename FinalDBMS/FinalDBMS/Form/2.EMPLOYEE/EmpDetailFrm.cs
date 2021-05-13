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
            tbGender.Text = tab.Rows[0][2].ToString();
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

            string gender = tbGender.Text;

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
                    MessageBox.Show("Update Employee " + fname + " Successfully", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Can't Update Employee " + fname, "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Add Enough Employee's Info", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string id = tbEmpID.Text;
            string fname = tbName.Text;

            try
            {
                if (MessageBox.Show("Are you sure to REMOVE " + tbName.Text, "Remove Employee", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (emp.removeEmp(id))
                    {
                        MessageBox.Show("Employee " + tbName.Text + " Has Been Removed", "Remove Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Can't Remove Employee " + tbName.Text, "Remove Employee", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        bool verif()
        {
            if (tbEmpID.Text.Trim() == ""
                || tbGender.Text.Trim() == ""
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
