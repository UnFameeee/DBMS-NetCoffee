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
        private void buttonThem_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;
            string hoten = textBoxHoten.Text;
            string cmnd = textBoxCmnd.Text;
            string sdt = textBoxPhone.Text;
            string tien = (textBoxMoney.Text);

            if (verif())
            {
                if (Cus.CustomerAlrExist(id))
                {
                    if (Cus.AddCustomer(id, hoten, cmnd, sdt, tien))
                    {
                        MessageBox.Show("Khách hàng mới đẫ được thêm vào", "Thêm khách", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            SqlCommand command = new SqlCommand("select * from CUSTOMER", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewCus.DataSource = table;
            dataGridViewCus.AllowUserToAddRows = false;
            dataGridViewCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }
        void reloadDatagridview()
        {
            SqlCommand command = new SqlCommand("select * from CUSTOMER", db.getConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            dataGridViewCus.DataSource = table;
            dataGridViewCus.AllowUserToAddRows = false;
            dataGridViewCus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }
        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string cusid = dataGridViewCus.CurrentRow.Cells[0].Value.ToString();
                  
            try
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
                        MessageBox.Show("Khong thể xoá thông tin khách hàng", "Lỗi xoá khách", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi " + ex.Message, "Lỗi xoá khách", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            string id = textBoxID.Text;
            string hoten = textBoxHoten.Text;
            string cmnd = textBoxCmnd.Text;
            string phone = textBoxPhone.Text;
            string money = textBoxMoney.Text;

            if (verif())
            {
                
                    if (Cus.EditCustomer(id, hoten, cmnd, phone, money))
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

        private void buttonThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridViewCus_DoubleClick(object sender, EventArgs e)
        {
            textBoxID.Text = dataGridViewCus.CurrentRow.Cells[0].Value.ToString();
            textBoxHoten.Text = dataGridViewCus.CurrentRow.Cells[1].Value.ToString();
            textBoxCmnd.Text = dataGridViewCus.CurrentRow.Cells[2].Value.ToString();
            textBoxPhone.Text = dataGridViewCus.CurrentRow.Cells[3].Value.ToString();
            textBoxMoney.Text = dataGridViewCus.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
