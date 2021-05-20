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
    public partial class RegisterAccountCus : Form
    {
        string act;
        public RegisterAccountCus(string operation)
        {
            InitializeComponent();
            act = operation;
        }
        
       
        AccountCustomerdata acount = new AccountCustomerdata();
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            try
            {
                    if (verif())
                    {
                        string uname = textBoxUsername.Text;
                        string pass = textBoxPassword.Text;
                        string confirm = textBoxReenter.Text;
                        string cusid = textBoxCusID.Text;

                        if (confirm == pass)
                        {
                            if (!acount.IsExistUsername(uname) && act=="Tạo tài khoản")
                            {
                                if (!acount.IsCusAlrHaveAccount(cusid) && act == "Tạo tài khoản")
                                {
                                    if (acount.insertNewAcc(uname, pass, cusid))
                                    {
                                        MessageBox.Show(act+" cho khách thành công!", act, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Lỗi không thể "+act, "Lỗi "+act, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                if (acount.updateAcc(uname, pass, cusid))
                                {
                                    MessageBox.Show(act + " cho khách thành công!", act, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Lỗi không thể " + act, "Lỗi " + act, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }    
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu xác nhận không chính xác!", "Lỗi "+act, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Lỗi "+act, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi "+ex.Message, "Lỗi khi tiến hành tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public bool verif()
        {
            if (textBoxUsername.Text.Trim() == ""
                || textBoxPassword.Text.Trim() == ""
                || textBoxReenter.Text.Trim() == "")
                return false;
            else
                return true;
        }

        private void RegisterAccountCus_Load(object sender, EventArgs e)
        {
            textBoxCusID.Enabled = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
