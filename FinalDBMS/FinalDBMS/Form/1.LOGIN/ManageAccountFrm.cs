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
    public partial class ManageAccountFrm : Form
    {
        public ManageAccountFrm()
        {
            InitializeComponent();
        }

        LoginData frm = new LoginData();

        private void ManageAccountFrm_Load(object sender, EventArgs e)
        {
            reload();
        }

        private void dgvAccount_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBoxID.Text = dgvAccount.CurrentRow.Cells[0].Value.ToString();
            textBoxUsername.Text = dgvAccount.CurrentRow.Cells[1].Value.ToString();
            textBoxPassword.Text = dgvAccount.CurrentRow.Cells[2].Value.ToString();
            cbbboxType.SelectedItem = dgvAccount.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;
            string username = textBoxUsername.Text;
            string pass = textBoxPassword.Text;
            string workid = cbbboxType.SelectedValue.ToString();

            if(verif())
            {
                if (frm.updateAccount(id, username, pass, workid))
                {
                    MessageBox.Show("Cập nhật tài khoản cho nhân viên " + id + " thành công", "Cập nhật tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reload();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật tài khoản cho nhân viên " + id, "Cập nhật tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Cập nhật tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;

            if (id == "")
            {
                if (frm.removeAccount(id))
                {
                    MessageBox.Show("Xoá tài khoản cho nhân viên " + id + " thành công", "Xoá tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reload();
                }
                else
                {
                    MessageBox.Show("Không thể cập nhật tài khoản cho nhân viên " + id, "Xoá tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền ID", "Xoá tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void reload()
        {
            SqlCommand com = new SqlCommand("select * from ACCOUNTEMPLOYEE");
            dgvAccount.DataSource = frm.getUser(com);


            SqlCommand command = new SqlCommand("Select * from JOB");
            DataTable table = frm.getUser(command);
            cbbboxType.DataSource = table;
            cbbboxType.DisplayMember = "JobDetail";
            cbbboxType.ValueMember = "WorkID";
            cbbboxType.SelectedItem = null;
        }

        bool verif()
        {
            if (textBoxID.Text == null
                    || textBoxUsername.Text == null
                        || textBoxPassword.Text == null
                            || cbbboxType.SelectedItem == null)
                return false;
            else return true;
        }
    }
}
