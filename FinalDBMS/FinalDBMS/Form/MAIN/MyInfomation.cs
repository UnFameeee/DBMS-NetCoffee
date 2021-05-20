using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace FinalDBMS
{
    public partial class MyInfomation : Form
    {
        public MyInfomation()
        {
            InitializeComponent();
        }
        MyInfo mif = new MyInfo();

        private void MyInfomation_Load(object sender, EventArgs e)
        {
            loadInfo();
        }
        bool verif()
        {
            if (tbName.Text.Trim() == ""
                || tbPhone.Text.Trim() == ""
                || tbMail.Text.Trim() == ""
                || tbIdentity.Text.Trim() == "")
                return false;
            else return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string id = Global.GlobalUserID;
            string fname = tbName.Text;

            string gender = "Nam";
            if (rdbtnFemale.Checked)
                gender = "Nữ";

            DateTime bdate = dtpBDate.Value;
            string phone = tbPhone.Text;
            string identity = tbIdentity.Text;
            string email = tbMail.Text;

            if (verif())
            {
                if (mif.editMyInfo(id, fname, gender, bdate, phone, identity, email))
                {
                    MessageBox.Show("Thông tin đã được cập nhật", "Chỉnh sửa thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Không thể cập nhật thông tin", "Chỉnh sửa thông tin", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Hãy điền đầy đủ thông tin", "Chỉnh sửa thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        void loadInfo()
        {
            DataTable table = mif.takeMyInfo(Global.GlobalUserID);
            tbName.Text = table.Rows[0]["Fullname"].ToString();
            rdbtnMale.Checked = true;
            if (table.Rows[0]["Gender"].ToString() == "Nữ")
            {
                rdbtnFemale.Checked = true;
            }
            dtpBDate.Text = table.Rows[0]["Birthday"].ToString();
            tbPhone.Text = table.Rows[0]["Phone"].ToString();
            tbIdentity.Text = table.Rows[0]["IdentityNumber"].ToString();
            tbMail.Text = table.Rows[0]["Email"].ToString();

            table = mif.takeNameandPic(Global.GlobalUserID);
            lbName.Text = table.Rows[0]["Fullname"].ToString();
            if(Global.Role == "QL")
            {
                lbPosition.Text = "Quản Lý";
            }
            else if (Global.Role == "NV")
            {
                lbPosition.Text = "Nhân viên";
            }
            else if (Global.Role == "LC")
            {
                lbPosition.Text = "Lao công";
            }

            byte[] picture = (byte[])table.Rows[0]["Picture"];
            MemoryStream Picture = new MemoryStream(picture);
            pic.Image = Image.FromStream(Picture);
        }

        private void rdbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            if(rdbtnMale.Checked == true)
            {
                rdbtnFemale.Checked = false;
            }
            else
            {
                rdbtnFemale.Checked = true;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadInfo();
        }
    }
}
