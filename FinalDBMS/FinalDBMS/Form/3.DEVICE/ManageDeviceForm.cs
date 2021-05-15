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
    public partial class ManageDeviceForm : Form
    {
        Device device = new Device();
        public ManageDeviceForm()
        {
            InitializeComponent();
        }

        private void ManageDeviceForm_Load(object sender, EventArgs e)
        {
            //Hiển thị toàn bộ thông tin Device ngay khi vừa khởi động form

            DataGridView_ManageDevices.DataSource = device.getAllDevices();

            //Dùng ComboBox để hiển thị các loại thiết bị
            SqlCommand command = new SqlCommand("SELECT Distinct TypeID from DEVICES");
            ComboBox_SelectDevice.DataSource = device.getDevice(command);
            ComboBox_SelectDevice.DisplayMember = "TypeID";
            ComboBox_SelectDevice.ValueMember = "TypeID";
            ComboBox_SelectDevice.SelectedItem = null;

            //Dùng ComboBox để hiển thị các loại trạng thái
            SqlCommand command2 = new SqlCommand("SELECT Distinct DStatus from DEVICES");
            ComboBox_SelectStatus.DataSource = device.getDevice(command2);
            ComboBox_SelectStatus.DisplayMember = "DStatus";
            ComboBox_SelectStatus.ValueMember = "DStatus";
            ComboBox_SelectStatus.SelectedItem = null;

            EditWidth(DataGridView_ManageDevices, 100, 154);


        }

        public void EditWidth(DataGridView dgv,  int height, int width)
        {
            //Chỉnh lại kích thước của DataGridView
            dgv.RowTemplate.Height = 100;
            dgv.AllowUserToAddRows = false;
            dgv.RowHeadersWidth = 50;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].Height = height;
            }
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].Width = width;
            }
        }

        //Hàm để hiển thị ra ComboBox dựa vào index
        //public void FillCombo(int index)
        //{
        //    SqlCommand command = new SqlCommand("SELECT Distinct TypeID from DEVICES");
        //    ComboBox_SelectDevice.DataSource = device.getDevice(command);
        //    ComboBox_SelectDevice.DisplayMember = "TypeID";
        //    //ComboBox_SelectDevice.ValueMember = "DeviceID";
        //    ComboBox_SelectDevice.SelectedItem = index;
        //}

        //Thêm thiết bị mới
        private void Button_AddDevice_Click(object sender, EventArgs e)
        {
            string DeviceID = TextBox_DeviceID.Text;

            //Kiểm tra đã đầy đủ thông tin chưa

            if ((TextBox_DeviceID.Text.Trim() == "") || (ComboBox_SelectDevice.SelectedValue == null) 
                || (ComboBox_SelectStatus.SelectedValue == null))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    

            else
            {
                string TypeID = ComboBox_SelectDevice.SelectedValue.ToString();
                string status = ComboBox_SelectStatus.SelectedValue.ToString();

                if (!device.DeviceIDAvailable(DeviceID))
                {

                    if (device.InsertDevice(DeviceID, TypeID, status))
                    {
                        MessageBox.Show("Thêm máy thành công !!!", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        MessageBox.Show("Thêm máy không thành công !!!", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                else
                {
                    MessageBox.Show("Vi phạm ràng buộc khoá chính, mời nhập ID khác !!!", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }

        }

        //Kiểm tra điền thiếu thông tin
        bool verif()
        {
            if ((TextBox_DeviceID.Text.Trim() == "")
                || (ComboBox_SelectDevice.SelectedValue.ToString() == null)
                || (ComboBox_SelectStatus.SelectedValue.ToString() == null))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Button_UpdateStatus_Click(object sender, EventArgs e)
        {
            string DeviceID = TextBox_DeviceID.Text;

            //Kiểm tra đã đầy đủ thông tin chưa

            if ((TextBox_DeviceID.Text.Trim() == "") || (ComboBox_SelectDevice.SelectedValue == null)
                || (ComboBox_SelectStatus.SelectedValue == null))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                string TypeID = ComboBox_SelectDevice.SelectedValue.ToString();
                string status = ComboBox_SelectStatus.SelectedValue.ToString();

                if (device.EditDevice(DeviceID, TypeID, status))
                {
                    MessageBox.Show("Cập nhật máy thành công !!!", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Cập nhật máy không thành công !!!", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }

        private void Button_Show_Click(object sender, EventArgs e)
        {
            if ( ComboBox_SelectDevice.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại máy hợp lệ !!!", "Hiển thị danh sách", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string TypeID = ComboBox_SelectDevice.SelectedValue.ToString();
                DataGridView_ManageDevices.DataSource = device.Show_InfoCustomer_GroupBy_TypeID(TypeID);
                EditWidth(DataGridView_ManageDevices, 100, 70);
            }
        }

        private void Button_StartPlaying_Click(object sender, EventArgs e)
        {
            if (TextBox_DeviceID.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng chọn máy để tiến hành !!!", "Cập nhật máy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string devid = TextBox_DeviceID.Text;
                if (device.CheckAvailableDeviceFromUser(devid))
                {
                    MessageBox.Show("Máy đã có người sử dụng !!!", "Cập nhật máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    if (device.CheckAvailableDevice(devid))
                    {
                        MessageBox.Show("Máy còn trống !!!", "Cập nhật máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Máy đang được bảo trì !!!", "Cập nhật máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }    
                }    
            }    

        }

        private void DataGridView_ManageDevices_DoubleClick(object sender, EventArgs e)
        {
            string devid = DataGridView_ManageDevices.CurrentRow.Cells[0].Value.ToString();
            TextBox_DeviceID.Text = devid;
            //ComboBox_SelectDevice.SelectedValue = DataGridView_ManageDevices.CurrentRow.Cells[1].Value;
            //ComboBox_SelectStatus.SelectedValue = DataGridView_ManageDevices.CurrentRow.Cells[2].Value;
        }

        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            DataGridView_ManageDevices.DataSource = device.getAllDevices();
            EditWidth(DataGridView_ManageDevices, 100, 154);
        }

        private void Button_RemoveDevice_Click(object sender, EventArgs e)
        {
            string DeviceID = TextBox_DeviceID.Text;

            //Kiểm tra đã đầy đủ thông tin chưa

            if ((TextBox_DeviceID.Text.Trim() == ""))
            {
                MessageBox.Show("Vui lòng nhập ID máy cần dừng sử dụng !!!", "Dừng sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {

                if (device.DeleteDeviceByID(DeviceID))
                {
                    MessageBox.Show("Đã dừng sử dụng máy !!!", "Dừng sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Chưa dừng sử dụng máy !!!", "Dừng sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }


        }


    }
}
