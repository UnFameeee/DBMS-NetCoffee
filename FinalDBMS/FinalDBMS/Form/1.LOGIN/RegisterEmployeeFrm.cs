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
    public partial class RegisterEmployeeFrm : Form
    {
        public RegisterEmployeeFrm()
        {
            InitializeComponent();
        }
        Mydb db = new Mydb();
        LoginData login = new LoginData();
        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string Id = textBoxID.Text;
            string Email = textBoxEmail.Text;
            string User = textBoxUsername.Text;
            string Pass = textBoxPassword.Text;
            string Confirm = textBoxConfirmPass.Text;
            string type = comboBoxTypeUser.Text;
            string hoten = textBoxHoTen.Text;
            DateTime bd = dateTimePickerBirthday.Value;
            string phone = textBoxPhone.Text;
            string cmnd = textBoxCMND.Text;
            string status = textboxStatusE.Text;
            string gender = "Nam";
            if(radioButtonNu.Checked)
            {
                gender = "Nữ";
            }
            int born_y = dateTimePickerBirthday.Value.Year;
            int this_y = DateTime.Now.Year;

            if (type == "Quản Lý") type = "QL";
            else if (type == "Nhân Viên") type = "NV";
            else type = "LC";
            
            if (Pass != Confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không chính xác", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (this_y - born_y < 18 || this_y - born_y > 70)
            {
                MessageBox.Show("Vui lòng nhập độ tuổi trong khoảng từ 18 đến 70 tuổi", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (verif())
            {
                if (login.CreateNewUser(Id, User, Pass, type, Email,hoten,gender,bd,phone,cmnd,status))
                {
                    MessageBox.Show("Tạo tài khoản mới thành công", "Tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                //else
                //{
                //    MessageBox.Show("Error", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}

            }
            else
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        bool verif()
        {
            if ((textBoxUsername.Text.Trim() == "")
                || (textBoxPassword.Text.Trim() == "")
                    || (textBoxEmail.Text.Trim() == "")
                        || (textBoxConfirmPass.Text.Trim() == "")
                            || (comboBoxTypeUser.Text.Trim() == "")
                                ||(textBoxID.Text.Trim()==""))
            {
                return false;
            }
            else return true;
        }

        private void RegisterEmployeeFrm_Load(object sender, EventArgs e)
        {
           
            SqlCommand command = new SqlCommand("Select * from JOB",db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBoxTypeUser.DataSource = table;
            comboBoxTypeUser.DisplayMember = "JobDetail";
            comboBoxTypeUser.ValueMember = "WorkID";
            comboBoxTypeUser.SelectedItem = null;

        }

        
    }
}
