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
    public partial class NapTienFrm : Form
    {
        public NapTienFrm()
        {
            InitializeComponent();
        }
        string accid;
        float cusmoney;
        Mydb db = new Mydb();
        AccountCustomerdata account = new AccountCustomerdata();
        public NapTienFrm(string id,float tienCus)
        {
            InitializeComponent();
            accid = id;
            cusmoney = tienCus; 
        }

        private void NapTienFrm_Load(object sender, EventArgs e)
        {

        }

        private void buttonNaptien_Click(object sender, EventArgs e)
        {
            if (textBoxNaptien.Text != "")
            {
                float tiennap = float.Parse(textBoxNaptien.Text);
                if (cusmoney > tiennap)
                {
                    if(account.NaptienAcc(accid,tiennap))
                    {
                        MessageBox.Show("Đã nạp tiền thành công!", "Nạp tiền", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Xảy ra lỗi khi nạp tiền!", "Lỗi nạp tiền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
                }
                else
                {
                    MessageBox.Show("Số tiền nạp phải bé hoặc bằng số tiền trong tài khoản của khách!", "Lỗi nạp tiền", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }
            else
            {

                MessageBox.Show("Vui lòng nhập số tiền nạp!", "Lỗi nạp tiền", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
