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
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
            loadForm();
        }

        CalendarFrm frmCalendar = new CalendarFrm() { TopLevel = false, TopMost = false };
        AddCustomerFrm frmAddCustomer = new AddCustomerFrm() { TopLevel = false, TopMost = false };
        EmpListFrm frmEmplistFrm = new EmpListFrm() { TopLevel = false, TopMost = false };
        ManageDeviceForm frmManageDevice = new ManageDeviceForm() { TopLevel = false, TopMost = false };
        ManageAccountFrm frmManageAccount = new ManageAccountFrm() { TopLevel = false, TopMost = false };
        SalaryFrm frmSalary = new SalaryFrm() { TopLevel = false, TopMost = false };


        void loadForm()
        {
            if(Global.GlobalUserID == "NV")
            {
                aCCOUNTToolStripMenuItem.Visible = false;
                eMPLOYEEToolStripMenuItem.Visible = false;
            }
            pnlMain.Controls.Add(frmAddCustomer);
            pnlMain.Controls.Add(frmCalendar);
            pnlMain.Controls.Add(frmEmplistFrm);
            pnlMain.Controls.Add(frmManageDevice);
            pnlMain.Controls.Add(frmManageAccount);
            pnlMain.Controls.Add(frmSalary);
        }

        private void addCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetForm();
            frmAddCustomer.Show();
        }

        private void TimeKeepingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetForm();
            frmCalendar.Show();
        }

        private void InfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetForm();
            frmEmplistFrm.Show();
        }
        private void manageDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetForm();
            frmManageDevice.Show();
        }
        private void aCCOUNTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetForm();
            frmManageAccount.Show();
        }

        private void SalaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            resetForm();
            frmSalary.Show();
        }

        void resetForm()
        {
            //Thêm khách hàng
            frmAddCustomer.Hide();
            //Tính lương
            frmCalendar.Hide();
            //Thông tin nhân viên
            frmEmplistFrm.Hide();
            //Thông tin thiết bị
            frmManageDevice.Hide();
            //Thong tin tai khoan
            frmManageAccount.Hide();
            //Thông tin lương nhân viên
            frmSalary.Hide();
        }
    }
}
