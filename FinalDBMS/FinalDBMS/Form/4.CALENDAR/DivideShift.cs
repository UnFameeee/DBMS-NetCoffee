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
    public partial class DivideShift : Form
    {
        public DivideShift()
        {
            InitializeComponent();
        }

        WorkShift ws = new WorkShift();

        private void DivideShift_Load(object sender, EventArgs e)
        {
            fillAllDGV();
        }

        private void fillAllDGV()
        {
            //DGV1
            dgv.DataSource = ws.fillDGV();
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = false;

            //DGV2
            dgv2.DataSource = ws.fillDGV2();
            dgv2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv2.AllowUserToAddRows = false;
            dgv2.AllowUserToResizeRows = false;
            dgv2.AllowUserToOrderColumns = false;
            dgv2.AllowUserToResizeColumns = false;
        }

        private void dgv_DoubleClick(object sender, EventArgs e)
        {
            tbEmpID.Text = dgv.CurrentRow.Cells[0].Value.ToString();
            tbShiftID.Text = dgv.CurrentRow.Cells[1].Value.ToString();
            tbShiftManagerID.Text = dgv.CurrentRow.Cells[2].Value.ToString();
        }

        private void dgv2_DoubleClick(object sender, EventArgs e)
        {
            tbShiftID2.Text = dgv2.CurrentRow.Cells[0].Value.ToString();
            TimeSpan timestart = (TimeSpan)dgv2.CurrentRow.Cells[1].Value;
            TimeSpan timeend = (TimeSpan)dgv2.CurrentRow.Cells[2].Value;
            timeStart.Text = timestart.ToString();
            timeEnd.Text = timeend.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            fillAllDGV();
            tbEmpID.Text = "";
            tbShiftID.Text = "";
            tbShiftID2.Text = "";
            tbShiftManagerID.Text = "";
            timeStart.Text = "00:00:00";
            timeEnd.Text = "00:00:00";
        }

        #region Phần trên

        private bool verif1()
        {
            if (tbEmpID.Text == "" || tbShiftID.Text == "")
                return false;
            return true;
        }
        private void btnAddShift_Click(object sender, EventArgs e)
        {
            string empid = tbEmpID.Text;
            string shiftid = tbShiftID.Text;
            string shiftmanagerid = tbShiftManagerID.Text;
            try
            {
                if(verif1())
                {
                    if(ws.check1(empid, shiftid, shiftmanagerid))
                    {
                        MessageBox.Show("Ca làm này đã có sẵn!!!", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (ws.AddDivideShift(empid, shiftid, shiftmanagerid))
                        {
                            MessageBox.Show("Thêm ca làm thành công", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm ca làm!!!", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    } 
                }
                else
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditShift_Click(object sender, EventArgs e)
        {
            string empid = tbEmpID.Text;
            string shiftid = tbShiftID.Text;
            string shiftmanagerid = tbShiftManagerID.Text;
            try
            {
                if (verif1())
                {
                    if (ws.check1(empid, shiftid, shiftmanagerid))
                    {
                        MessageBox.Show("Ca làm này đã có sẵn!!!", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (ws.UpdateDivideShift(empid, shiftid, shiftmanagerid))
                        {
                            MessageBox.Show("Sửa ca làm thành công", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể sửa ca làm!!!", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }    
                }
                else
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteShift_Click(object sender, EventArgs e)
        {
            string empid = tbEmpID.Text;
            string shiftid = tbShiftID.Text;
            string shiftmanagerid = tbShiftManagerID.Text;
            try
            {
                if (verif1())
                {
                    if (!ws.check1(empid, shiftid, shiftmanagerid))
                    {
                        MessageBox.Show("Ca làm này không có thực!!!", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (ws.DeleteDivideShift(empid, shiftid, shiftmanagerid))
                        {
                            MessageBox.Show("Xóa ca làm thành công", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa ca làm!!!", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region phần dưới
        private bool verif2()
        {
            if (tbShiftID2.Text == "")
                return false;
            return true;
        }

        private void btnAddTime_Click(object sender, EventArgs e)
        {
            string shiftid = tbShiftID2.Text;
            TimeSpan timestart = timeStart.Value.TimeOfDay;
            TimeSpan timeend = timeEnd.Value.TimeOfDay;
            try
            {
                if (verif2())
                {
                    if (ws.check2(shiftid))
                    {
                        MessageBox.Show("Thời gian ca làm này đã có sẵn!!!", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (ws.AddDivideTimeShift(shiftid, timestart, timeend))
                        {
                            MessageBox.Show("Thêm thời gian ca làm thành công", "Chỉnh sửa thời gian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể thêm thời gian ca làm!!!", "Chỉnh sửa thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin", "Chỉnh sửa thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEditTime_Click(object sender, EventArgs e)
        {
            string shiftid = tbShiftID2.Text;
            TimeSpan timestart = timeStart.Value.TimeOfDay;
            TimeSpan timeend = timeEnd.Value.TimeOfDay;
            try
            {
                if (verif2())
                {
                    if (!ws.check2(shiftid))
                    {
                        MessageBox.Show("Thời gian ca làm này không tồn tại!!!", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (ws.UpdateDivideTimeShift(shiftid, timestart, timeend))
                        {
                            MessageBox.Show("Sửa thời gian ca làm thành công", "Chỉnh sửa thời gian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể Sửa thời gian ca làm!!!", "Chỉnh sửa thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin", "Chỉnh sửa thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteTime_Click(object sender, EventArgs e)
        {
            string shiftid = tbShiftID2.Text;
            try
            {
                if (verif2())
                {
                    if (!ws.check2(shiftid))
                    {
                        MessageBox.Show("Thời gian ca làm này không có thực!!!", "Chỉnh sửa ca làm", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (ws.DeleteDivideTimeShift(shiftid))
                        {
                            MessageBox.Show("Xóa thời gian ca làm thành công", "Chỉnh sửa thời gian", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không thể Xóa thời gian ca làm!!!", "Chỉnh sửa thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }  
                }
                else
                {
                    MessageBox.Show("Hãy điền đầy đủ thông tin", "Chỉnh sửa thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void btnFind1_Click(object sender, EventArgs e)
        {
            DataTable table = ws.Find1(tbEmpID.Text);
            dgv.DataSource = table;
        }

        private void btnFind2_Click(object sender, EventArgs e)
        {
            DataTable table = ws.Find2(tbShiftID2.Text);
            dgv2.DataSource = table;
        }
    }
}
