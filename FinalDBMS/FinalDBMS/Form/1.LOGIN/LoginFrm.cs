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
    public partial class LoginFrm : Form
    {
        public LoginFrm()
        {
            InitializeComponent();
        }
        Mydb db = new Mydb();
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                DataTable table = new DataTable();

                SqlCommand command
                    = new SqlCommand
                    ("SELECT * FROM ACCOUNTEMPLOYEE WHERE Username= @user AND Password = @pass and TypeEmployee =@typeid and ID=@id", db.getConnection);

                command.Parameters.Add("@user", SqlDbType.VarChar).Value = textBoxUsername.Text;
                command.Parameters.Add("@pass", SqlDbType.VarChar).Value = textBoxPassword.Text;
                command.Parameters.Add("@id", SqlDbType.VarChar).Value = textBoxID.Text;
                string type = comboBoxTypeuser.Text;
                if (type == "Quản Lý") type = "QL";
                else if (type == "Nhân Viên") type = "NV";
                else type = "LC";

                command.Parameters.Add("@typeid", SqlDbType.VarChar).Value = type;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if ((table.Rows.Count > 0))
                {
                    if (type == "QL")
                    {
                        MessageBox.Show("Đăng nhập thành công", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MainFrm frm = new MainFrm();
                        frm.Show();
                    }
                    else if (type == "NV")
                    {
                        MessageBox.Show("Đăng nhập thành công", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (type == "LC")
                    {
                        MessageBox.Show("Đăng nhập thành công", "Đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin đăng nhập không hợp lệ", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            RegisterEmployeeFrm frm = new RegisterEmployeeFrm();
            frm.Show();
        }

        private void LoginFrm_Load(object sender, EventArgs e)
        {
            

            SqlCommand command = new SqlCommand("Select * from JOB", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBoxTypeuser.DataSource = table;
            comboBoxTypeuser.DisplayMember = "JobDetail";
            comboBoxTypeuser.ValueMember = "WorkID";
            comboBoxTypeuser.SelectedItem = null;

        }

        private void textBoxUsername_DoubleClick(object sender, EventArgs e)
        {
            textBoxUsername.Text = "";
        }

        private void textBoxID_DoubleClick(object sender, EventArgs e)
        {
            textBoxID.Text = "";
        }

        private void textBoxPassword_DoubleClick(object sender, EventArgs e)
        {
            textBoxPassword.Text = "";
        }

        
    }
}
