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
    public partial class Loại_máy : Form
    {
        Device device = new Device();
        public Loại_máy()
        {
            InitializeComponent();
        }

        private void Loại_máy_Load(object sender, EventArgs e)
        {
            DataGridView_DeviceType.DataSource = device.getAllDeviceTypes();
            EditWidth(DataGridView_DeviceType, 72, 88);
        }

        public void EditWidth(DataGridView dgv, int height, int width)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void DataGridView_DeviceType_Click(object sender, EventArgs e)
        {
            TextBox_CPU.Text = DataGridView_DeviceType.CurrentRow.Cells[1].Value.ToString();
            TextBox_Ram.Text = DataGridView_DeviceType.CurrentRow.Cells[2].Value.ToString();
            TextBox_PowerSupply.Text = DataGridView_DeviceType.CurrentRow.Cells[3].Value.ToString();
            TextBox_GraphicCard.Text = DataGridView_DeviceType.CurrentRow.Cells[4].Value.ToString();
            TextBox_MainBoard.Text = DataGridView_DeviceType.CurrentRow.Cells[5].Value.ToString();
            TextBox_Case.Text = DataGridView_DeviceType.CurrentRow.Cells[6].Value.ToString();
            TextBox_Monitor.Text = DataGridView_DeviceType.CurrentRow.Cells[7].Value.ToString();
            TextBox_Mouse.Text = DataGridView_DeviceType.CurrentRow.Cells[8].Value.ToString();
            TextBox_Keyboard.Text = DataGridView_DeviceType.CurrentRow.Cells[9].Value.ToString();
        }

        private void Button_Edit_Click(object sender, EventArgs e)
        {

            string TypeID = DataGridView_DeviceType.CurrentRow.Cells[0].Value.ToString();
            string CPU = TextBox_CPU.Text;
            string Ram = TextBox_Ram.Text;
            string PowerSupply = TextBox_PowerSupply.Text;
            string GraphicCard = TextBox_GraphicCard.Text;
            string MainBoard = TextBox_MainBoard.Text;
            string Case = TextBox_Case.Text;
            string Monitor = TextBox_Monitor.Text;
            string Mouse = TextBox_Mouse.Text;
            string Keyboard = TextBox_Keyboard.Text;

            //try
            //{
                if (device.updateDeviceType(TypeID, CPU, Ram, PowerSupply, GraphicCard, MainBoard, Case, Monitor, Mouse, Keyboard))
                {
                    MessageBox.Show("Cập nhật thành công", "Cập nhật thiết bị", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataGridView_DeviceType.DataSource = device.getAllDeviceTypes();
                    TextBox_CPU.Text = DataGridView_DeviceType.CurrentRow.Cells[1].Value.ToString();
                    TextBox_Ram.Text = DataGridView_DeviceType.CurrentRow.Cells[2].Value.ToString();
                    TextBox_PowerSupply.Text = DataGridView_DeviceType.CurrentRow.Cells[3].Value.ToString();
                    TextBox_GraphicCard.Text = DataGridView_DeviceType.CurrentRow.Cells[4].Value.ToString();
                    TextBox_MainBoard.Text = DataGridView_DeviceType.CurrentRow.Cells[5].Value.ToString();
                    TextBox_Case.Text = DataGridView_DeviceType.CurrentRow.Cells[6].Value.ToString();
                    TextBox_Monitor.Text = DataGridView_DeviceType.CurrentRow.Cells[7].Value.ToString();
                    TextBox_Mouse.Text = DataGridView_DeviceType.CurrentRow.Cells[8].Value.ToString();
                    TextBox_Keyboard.Text = DataGridView_DeviceType.CurrentRow.Cells[9].Value.ToString();
                }
                else
                {
                    MessageBox.Show("Cập nhật không thành công", "Cập nhật thiết bị", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show( ex.ToString(),  "Cập nhật thiết bị", MessageBoxButtons.OK, MessageBoxIcon.Warning );
            //}
        }
    }
}
