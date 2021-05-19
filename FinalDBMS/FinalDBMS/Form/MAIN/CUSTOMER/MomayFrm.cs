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
    public partial class MomayFrm : Form
    {
        public MomayFrm()
        {
            InitializeComponent();
        }
        string cusid;
        public MomayFrm(string cid)
        {
            InitializeComponent();
            cusid = cid;
        }
        Device device = new Device();
        private void MomayFrm_Load(object sender, EventArgs e)
        {
            comboBoxChonmay.DataSource = device.getAllDevicesNotInUse();
            comboBoxChonmay.DisplayMember = "Máy";
            comboBoxChonmay.ValueMember = "Máy";
            comboBoxChonmay.SelectedItem = null;
        }
        Mydb db = new Mydb();
        AccountCustomerdata account = new AccountCustomerdata();
        private void buttonMomay_Click(object sender, EventArgs e)
        {
            if (verif())
            {
                string mamay = comboBoxChonmay.SelectedValue.ToString();
                mamay = mamay.Substring2(0, 5);
                if (account.MomaychoAcc(cusid, mamay))
                {
                    MessageBox.Show("Mở máy cho khách thành công", "Mở máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    account.accountShowTimeAvl(cusid);
                }
                else
                {
                    MessageBox.Show("Lỗi xảy ra khi mở máy", "Lỗi mở máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn máy", "Lỗi mở máy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }    
        }
        public bool verif()
        {
            if (comboBoxChonmay.Text.Trim() == "")
                return false;
            else return true;
        }

      
    }
}
