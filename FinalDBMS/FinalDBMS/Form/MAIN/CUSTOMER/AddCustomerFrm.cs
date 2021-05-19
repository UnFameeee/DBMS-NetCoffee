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
    public partial class AddCustomerFrm : Form
    {
        public AddCustomerFrm()
        {
            InitializeComponent();
        }
        Mydb db = new Mydb();
        CustomerData Cus = new CustomerData();
        AccountCustomerdata account = new AccountCustomerdata();
        private void buttonThem_Click(object sender, EventArgs e)
        {
            

            if (verif())
            {
                string id = textBoxID.Text;
                string hoten = textBoxHoten.Text;
                string cmnd = textBoxCmnd.Text;
                string sdt = textBoxPhone.Text;
                float tien = float.Parse(textBoxMoney.Text);
                if (Cus.CustomerAlrExist(id))
                {
                    if (Cus.AddCustomer(id, hoten, cmnd, sdt, tien))
                    {
                        MessageBox.Show("Khách hàng mới đã được thêm vào", "Thêm khách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadDatagridview();
                    }
                    else
                    {
                        MessageBox.Show("Không thể thêm khách vào", "Lỗi thêm khách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("ID khách hàng này đã tồn tại vui lòng đổi sang Id khác", "Lỗi chỉnh sửa thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi thêm khách", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AddCustomerFrm_Load(object sender, EventArgs e)
        {
            
            dataGridViewCus.DataSource = Cus.GetallCus();
            dataGridViewCus.AllowUserToAddRows = false;
            //dataGridViewCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            //godwidth(dataGridViewCus,this);

            buttonCreateAcc.Enabled = false;
            buttonDoimatkhau.Enabled = false;
            buttonNaptien.Enabled = false;
            buttonMomay.Enabled = false;
        }
        public void godwidth(DataGridView data, Form frm)
        {
            data.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            int widthdataGrid = 0;
            for (int i = 0; i < data.Columns.Count; i++)
            {

                    widthdataGrid += data.Columns[i].Width;

            }
            data.Width = widthdataGrid + 65;
            frm.Width = data.Location.X + data.Width + 30;
        }
        void reloadDatagridview()
        {
            dataGridViewCus.DataSource = Cus.GetallCus();
            dataGridViewCus.AllowUserToAddRows = false;
            //dataGridViewCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            //godwidth(dataGridViewCus, this);
        }
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string cusid = textBoxID.Text;
                  
            try
            {

                if (cusid != "")
                {
                    if (MessageBox.Show("Bạn có chắc là muốn xoá đi thông tin của khách hàng này?", "Xoá khách", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (Cus.RemoveCustomer(cusid))
                        {

                            MessageBox.Show("Thông tin khách hàng đã được xoá", "Xoá khách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            reloadDatagridview();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xoá thông tin khách hàng", "Lỗi xoá khách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập vào id mà bạn muốn xoá", "Lỗi xoá khách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi xoá khách", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            

            if (verif())
            {
                string id = textBoxID.Text;
                string hoten = textBoxHoten.Text;
                string cmnd = textBoxCmnd.Text;
                string phone = textBoxPhone.Text;
                float tien = float.Parse(textBoxMoney.Text);
                if (Cus.EditCustomer(id, hoten, cmnd, phone, tien))
                    {
                        MessageBox.Show("Thông tin khách hàng đã được chỉnh sửa", "Chỉnh sửa thông tin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reloadDatagridview();
                    }
                    else
                    {
                        MessageBox.Show("Không thể chỉnh sửa thông tin khách hàng", "Lỗi chỉnh sửa thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
               
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin", "Lỗi chỉnh sửa thông tin", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        bool verif()
        {
            if ((textBoxID.Text.Trim() == "")
                || (textBoxMoney.Text.Trim() == "")
                    || (textBoxPhone.Text.Trim() == "")
                    || (textBoxHoten.Text.Trim() == "")
                        ||(textBoxCmnd.Text.Trim()==""))
            {
                return false;
            }
            else return true;
        }

        private void dataGridViewCus_DoubleClick(object sender, EventArgs e)
        {
        
        }    

        private void dataGridViewCus_Click(object sender, EventArgs e)
        {
            textBoxID.Text = dataGridViewCus.CurrentRow.Cells[0].Value.ToString();
            textBoxHoten.Text = dataGridViewCus.CurrentRow.Cells[1].Value.ToString();
            textBoxCmnd.Text = dataGridViewCus.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridViewCus.CurrentRow.Cells[3].Value.ToString();
            textBoxMoney.Text = dataGridViewCus.CurrentRow.Cells[4].Value.ToString();


            dataGridViewCusAccount.DataSource = account.LoadDataAccCusById(dataGridViewCus.CurrentRow.Cells[0].Value.ToString());
            dataGridViewCusAccount.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
            //godwidth(dataGridViewCusAccount, this);

            dataGridViewCusAccount.AllowUserToAddRows = false;

            if(dataGridViewCusAccount.Rows.Count>0)
            {
                buttonCreateAcc.Enabled = false;
                buttonDoimatkhau.Enabled = true;
                buttonNaptien.Enabled = true;
                buttonMomay.Enabled = true;
            }
            else if(dataGridViewCusAccount.Rows.Count ==0)
            {

                buttonCreateAcc.Enabled = true;
                buttonDoimatkhau.Enabled = false;
                buttonNaptien.Enabled = false;
                buttonMomay.Enabled = false;

            }    
        }

        private void buttonCreateAcc_Click(object sender, EventArgs e)
        {
            RegisterAccountCus frm = new RegisterAccountCus("Tạo tài khoản");
            string cid = textBoxID.Text;
            frm.textBoxCusID.Text = cid;
            frm.labeltitle.Text = "Tạo tài khoản cho khách";
            frm.buttonCreate.Text = "Tạo tài khoản";
            frm.Show();
        }

        private void buttonDoimatkhau_Click(object sender, EventArgs e)
        {
            RegisterAccountCus frm = new RegisterAccountCus("Đổi mật khẩu");
            string cid = textBoxID.Text;
            frm.textBoxCusID.Text = cid;
            frm.textBoxUsername.Text = dataGridViewCusAccount.CurrentRow.Cells[0].Value.ToString();
            frm.labeltitle.Text = "Đổi mật khẩu tài khoản";
            frm.buttonCreate.Text = "Đổi mật khẩu";
            frm.Show();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxID.Text = "";
            textBoxHoten.Text = "";
            textBoxCmnd.Text = "";
            textBoxPhone.Text = "";
            textBoxMoney.Text = "";
            reloadDatagridview();
        }

        private void buttonNaptien_Click(object sender, EventArgs e)
        {
            float tiencus = float.Parse(textBoxMoney.Text);
            string accid = dataGridViewCus.CurrentRow.Cells[0].Value.ToString();
            NapTienFrm frm = new NapTienFrm(accid,tiencus);
            frm.Show();
        }

        private void buttonMomay_Click(object sender, EventArgs e)
        {
            MomayFrm frm = new MomayFrm(dataGridViewCusAccount.CurrentRow.Cells[4].Value.ToString());
            frm.Show();
        }
    }
}
