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
            device.FormatStatus();
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

            if (!device.DeviceIDAvailable(DeviceID))
            {

                //Kiểm tra đã đầy đủ thông tin chưa
                try
                {
                    if ((TextBox_DeviceID.Text.Trim() == "") || (ComboBox_SelectDevice.SelectedValue == null)
                    || (ComboBox_SelectStatus.SelectedValue == null))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        string TypeID = ComboBox_SelectDevice.SelectedValue.ToString();
                        string status = ComboBox_SelectStatus.SelectedValue.ToString();


                        if (status == "Chưa sử dụng" || status == "Đang bảo trì")
                        {
                            if (device.InsertDevice(DeviceID, TypeID, status))
                            {
                                MessageBox.Show("Thêm máy thành công.", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else
                            {
                                MessageBox.Show("Thêm máy không thành công.", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Máy chưa được sử dụng. Kiểm tra lại trạng thái máy.", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            else
            {
                MessageBox.Show("Máy này đã có trong danh sách. ", "Thêm máy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            if (device.DeviceIDAvailable(DeviceID))
            {
                try
                {
                    if ((TextBox_DeviceID.Text.Trim() == "") || (ComboBox_SelectDevice.SelectedValue == null)
                        || (ComboBox_SelectStatus.SelectedValue == null))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cập nhật máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        string TypeID = ComboBox_SelectDevice.SelectedValue.ToString();
                        string status = ComboBox_SelectStatus.SelectedValue.ToString();

                        if (status == "Đang sử dụng")
                        {
                            MessageBox.Show("Máy đang có khách hàng sử dụng. Không thể chỉnh sửa lúc này.", "Cập nhật máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            if (device.EditDevice(DeviceID, TypeID))

                            {

                                MessageBox.Show("Cập nhật máy thành công.", "Cập nhật máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else
                            {
                                MessageBox.Show("Cập nhật máy không thành công.", "Cập nhật máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                        }


                    }
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập/ chọn đầy đủ thông tin.", "Cập nhật máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show("Máy này không tồn tại trong danh sách. ", "Cập nhật máy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Button_Show_Click(object sender, EventArgs e)
        {
             string DeviceID = TextBox_DeviceID.Text;
            try
            {
                        //Kiểm tra đã đầy đủ thông tin chưa

                        if ((TextBox_DeviceID.Text.Trim() == "") || (ComboBox_SelectDevice.SelectedValue == null)
                        || (ComboBox_SelectStatus.SelectedValue == null))
                        {
                            MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                        else
                        {
                                DataTable table = device.ShowCustomerIsPlaying(DeviceID);
                                if (table.Rows.Count == 0)
                                {
                                    MessageBox.Show("Chưa có khách hàng nào sử dụng máy này.", "Thông tin khách hàng", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    Label_Info.Text =
                                    "THÔNG TIN KHÁCH HÀNG ĐANG DÙNG MÁY " + table.Rows[0]["DeviceID"].ToString() + "\n"
                                    + "ID khách hàng: " + table.Rows[0]["CustomerID"].ToString() + "\n"
                                    + "Họ và tên: " + table.Rows[0]["FullName"].ToString() + "\n"
                                    + "SĐT: " + table.Rows[0]["PhoneNumber"].ToString() + "\n"
                                    + "Tổng tài khoản: " + table.Rows[0]["MoneyCharged"].ToString() + "\n"
                                    + "Tên đăng nhập: " + table.Rows[0]["UserName"].ToString() + "\n"
                                    + "Tổng thời gian: " + table.Rows[0]["TimeAvailible"].ToString() + "\n"
                                    + "Thời gian đã sử dụng: " + table.Rows[0]["TimeUsed"].ToString() + "\n"
                                    ;
                                }
                        }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập/ chọn đầy đủ thông tin.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            /*else 
            { 
                Label_Info.Text =
                "THÔNG TIN KHÁCH HÀNG ĐANG DÙNG MÁY " + table.Rows[0]["DeviceID"].ToString() + "\n"
                + "ID khách hàng: " + table.Rows[0]["CustomerID"].ToString() + "\n"
                + "Họ và tên: " + table.Rows[0]["FullName"].ToString() + "\n"
                + "SĐT: " + table.Rows[0]["PhoneNumber"].ToString() + "\n"
                + "Tổng tài khoản: " + table.Rows[0]["MoneyCharged"].ToString() + "\n"
                + "Tên đăng nhập: " + table.Rows[0]["UserName"].ToString() + "\n"
                + "Tổng thời gian: " + table.Rows[0]["Actualtimeavl"].ToString() + "\n"
                + "Thời gian đã sử dụng: " + table.Rows[0]["TimeUsed"].ToString() + "\n"
                ;*/
        }

        private void Button_StartPlaying_Click(object sender, EventArgs e)
        {
            string DeviceID = TextBox_DeviceID.Text;

            try
            {
                //Kiểm tra đã đầy đủ thông tin chưa

                if ((TextBox_DeviceID.Text.Trim() == "") || (ComboBox_SelectDevice.SelectedValue == null)
                || (ComboBox_SelectStatus.SelectedValue == null))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (!device.DeviceIDAvailable(DeviceID))
                    {
                        MessageBox.Show("Máy này không tồn tại trong danh sách. ", "Cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    else
                    {

                        string TypeID = ComboBox_SelectDevice.SelectedValue.ToString();
                        string status = ComboBox_SelectStatus.SelectedValue.ToString();

                        if (device.CheckAvailableDeviceFromUser(DeviceID))
                        {
                            if (status == "Chưa sử dụng")
                            {
                                if (device.StartPlaying(DeviceID))
                                {
                                    MessageBox.Show("Đã cấp sử dụng máy.", "Cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else
                                {
                                    MessageBox.Show("Lỗi cấp sử dụng máy.", "Cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Đã có khách hàng sử dụng máy này.", "Cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Chưa có khách hàng nào đăng kí sử dụng máy này.", "Cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập/ chọn đầy đủ thông tin.", "Cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void DataGridView_ManageDevices_DoubleClick(object sender, EventArgs e)
        {
            string devid = DataGridView_ManageDevices.CurrentRow.Cells[0].Value.ToString();
            TextBox_DeviceID.Text = devid;
            ComboBox_SelectDevice.SelectedValue = DataGridView_ManageDevices.CurrentRow.Cells[1].Value;
            ComboBox_SelectStatus.SelectedValue = DataGridView_ManageDevices.CurrentRow.Cells[2].Value;
        }

        private void Button_Refresh_Click(object sender, EventArgs e)
        {
            DataGridView_ManageDevices.DataSource = device.getAllDevices();
            EditWidth(DataGridView_ManageDevices, 100, 154);
        }

        private void Button_RemoveDevice_Click(object sender, EventArgs e)
        {
            string DeviceID = TextBox_DeviceID.Text;

            try
            {
                //Kiểm tra đã đầy đủ thông tin chưa




                if ((TextBox_DeviceID.Text.Trim() == "") || (ComboBox_SelectDevice.SelectedValue == null)
                || (ComboBox_SelectStatus.SelectedValue == null))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    if (!device.DeviceIDAvailable(DeviceID))
                    {
                        MessageBox.Show("Máy này không tồn tại trong danh sách. ", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    else
                    {

                        string TypeID = ComboBox_SelectDevice.SelectedValue.ToString();
                        string status = ComboBox_SelectStatus.SelectedValue.ToString();

                        if (device.CheckAvailableDeviceFromUser(DeviceID))
                        {
                            if (status == "Dang test")
                            {
                                if (device.StopPlaying(DeviceID))
                                {
                                    MessageBox.Show("Đã dừng cấp sử dụng máy.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                                else
                                {
                                    MessageBox.Show("Lỗi cấp sử dụng máy.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Máy chưa được cấp sử dụng.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Chưa có khách hàng nào đăng kí sử dụng máy này.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }



            }
            catch
            {
                MessageBox.Show("Vui lòng nhập/ chọn đầy đủ thông tin.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Label_ShowInfo_Click(object sender, EventArgs e)
        {

        }

        private void Panel_ShowInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button_Remove_Click(object sender, EventArgs e)
        {
            string DeviceID = TextBox_DeviceID.Text;

            if (device.DeviceIDAvailable(DeviceID))
            {
                try
                {
                    //Kiểm tra đã đầy đủ thông tin chưa

                    if ((TextBox_DeviceID.Text.Trim() == "") || (ComboBox_SelectDevice.SelectedValue == null)
                    || (ComboBox_SelectStatus.SelectedValue == null))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Bảo trì máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    //PHẦN CHÍNH
                    else
                    {
                        string TypeID = ComboBox_SelectDevice.SelectedValue.ToString();
                        string status = ComboBox_SelectStatus.SelectedValue.ToString();
                        if (status == "Đang sử dụng")
                        {

                            if (device.StopPlaying(DeviceID))
                            {
                                MessageBox.Show("Đã dừng cấp sử dụng máy.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else
                            {
                                MessageBox.Show("Chưa dừng cấp sử dụng máy.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không có khách hàng nào sử dụng máy này.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập/ chọn đầy đủ thông tin.", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show("Máy này không tồn tại trong danh sách. ", "Dừng cấp sử dụng máy", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void ButtonRemoveFromList_Click(object sender, EventArgs e)
        {
            string DeviceID = TextBox_DeviceID.Text;

            //Kiểm tra đã đầy đủ thông tin chưa

            if (device.DeviceIDAvailable(DeviceID))
            {
                try
                {
                    if ((TextBox_DeviceID.Text.Trim() == "") || (ComboBox_SelectDevice.SelectedValue == null)
                    || (ComboBox_SelectStatus.SelectedValue == null))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Xoá máy khỏi danh sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {

                        string TypeID = ComboBox_SelectDevice.SelectedValue.ToString();
                        string status = ComboBox_SelectStatus.SelectedValue.ToString();
                        if (status == "Chưa sử dụng")
                        {

                            if (device.DeleteDeviceByID(DeviceID))
                            {
                                MessageBox.Show("Xoá máy khỏi danh sách thành công.", "Xoá máy khỏi danh sách", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else
                            {
                                MessageBox.Show("Xoá máy khỏi danh sách không thành công.", "Xoá máy khỏi danh sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else if (status == "Đang sử dụng")
                        {
                            MessageBox.Show("Máy đang có khách hàng sử dụng. Không thể xoá lúc này.", "Xoá máy khỏi danh sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (status == "Đang bảo trì")
                        {
                            MessageBox.Show("Máy đang được bảo trì. Không thể xoá lúc này.", "Xoá máy khỏi danh sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập/ chọn đầy đủ thông tin.", "Xoá máy khỏi danh sách", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show("Máy này không tồn tại trong danh sách. ", "Xoá máy khỏi danh sách", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
        }

        private void comboBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void ButtonRepairing_Click(object sender, EventArgs e)
        {
            string DeviceID = TextBox_DeviceID.Text;

            //Kiểm tra đã đầy đủ thông tin chưa

            if (device.DeviceIDAvailable(DeviceID))
            {
                try
                {
                    if ((TextBox_DeviceID.Text.Trim() == "") || (ComboBox_SelectDevice.SelectedValue == null)
                    || (ComboBox_SelectStatus.SelectedValue == null))
                    {
                        MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cài đặt bảo trì", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    else
                    {
                        string TypeID = ComboBox_SelectDevice.SelectedValue.ToString();
                        string status = ComboBox_SelectStatus.SelectedValue.ToString();
                        SqlCommand command2 = new SqlCommand("SELECT Distinct DStatus from DEVICES");
                        if (status == "Chưa sử dụng")
                        {

                            if (device.StartRepairing(DeviceID))
                            {
                                ComboBox_SelectStatus.DataSource = device.getDevice(command2);
                                MessageBox.Show("Đã tiến hành bảo trì.", "Tiến hành bảo trì", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else
                            {
                                MessageBox.Show("Tiến hành bảo trì không thành công.", "Tiến hành bảo trì", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else if (status == "Đang sử dụng")
                        {
                            MessageBox.Show("Máy đang có khách hàng sử dụng. Không thể cài đặt bảo trì lúc này.", "Cài đặt bảo trì", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                        else if (status == "Đang bảo trì")
                        {
                            if (device.StopRepairing(DeviceID))
                            {
                                ComboBox_SelectStatus.DataSource = device.getDevice(command2);
                                MessageBox.Show("Đã dừng bảo trì.", "Dừng bảo trì", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            else
                            {
                                MessageBox.Show("Dừng bào trì không thành công.", "Dừng bảo trì", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }




                    }
                }
                catch
                {
                    MessageBox.Show("Vui lòng nhập/ chọn đầy đủ thông tin.", "Cài đặt bảo trì", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            else
            {
                MessageBox.Show("Máy này không tồn tại trong danh sách. ", "Cài đặt bảo trì", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
