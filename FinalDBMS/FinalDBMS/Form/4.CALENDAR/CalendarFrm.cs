using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FinalDBMS
{
    public partial class CalendarFrm : Form
    {
        public CalendarFrm()
        {
            InitializeComponent();
        }

        //Wibu
        Mydb db = new Mydb();
        Salary salary = new Salary();
        
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (salary.CheckIDEmployee(txtID.Text))
            {
                if (!salary.CheckIDWork(txtID.Text))
                {
                    salary.AddCheckIn(txtID.Text);
                    dataGridViewTimeKeeping.DataSource = salary.ShowTimeKeeping();

                    //Thắng
                    /*
                    takePicture(txtID.Text);
                    changeLBcheckin("Checkin");
                    loadInfo(txtID.Text, "Load");*/
                }
                else
                    MessageBox.Show("ID is working. Can't check in");
            }
            else
                MessageBox.Show("Can't find the ID");
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (salary.CheckIDWork(txtID.Text) )
            {
                salary.AddCheckOut(txtID.Text);
                dataGridViewTimeKeeping.DataSource = salary.ShowTimeKeeping();





                //Thắng
                /*
                deletePicture(txtID.Text);
                changeLBcheckin("Checkout");
                loadInfo(txtID.Text, "Unload");*/
            }
            else
                MessageBox.Show("Can't find the ID");
        }

        //Thắng
        //Calendar cld = new Calendar();
        #region Properties
        private List<PictureBox> matrixPic;
        public List<PictureBox> MatrixPic
        {
            get { return matrixPic; }
            set { matrixPic = value; }
        }

        private List<Label> matrixName;
        public List<Label> MatrixName
        {
            get { return matrixName; }
            set { matrixName = value; }
        }
        public int count = 0; //Số nhân viên đang trong ca
        List<string> MatrixEmpID = new List<string>();
        #endregion

        private void CalendarFrm_Load(object sender, EventArgs e)
        {
            MatrixPic = new List<PictureBox>();      //Hình 
            MatrixName = new List<Label>();          //Tên
            MatrixPic.Add(pb1); MatrixPic.Add(pb2); MatrixPic.Add(pb3); MatrixPic.Add(pb4); MatrixPic.Add(pb5); MatrixPic.Add(pb6); MatrixPic.Add(pb7);
            MatrixName.Add(lb1); MatrixName.Add(lb2); MatrixName.Add(lb3); MatrixName.Add(lb4); MatrixName.Add(lb5); MatrixName.Add(lb6); MatrixName.Add(lb7);
            for (int i = 0; i < 7; ++i)
                MatrixName[i].Visible = false;
            for (int j = 0; j < 7; ++j)
                MatrixEmpID.Add("");
            dataGridViewTimeKeeping.DataSource = salary.ShowTimeKeeping();
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        //Phần báo cáo điểm danh
        void changeLBcheckin(string operation)
        {
            if(operation == "Checkin")
            {
                if (true) //Điểm danh đúng giờ
                {
                    lbCheckin.Text = "You have been checked in. Have a nice day at work";
                }
                else     //Điểm danh trễ giờ
                {
                    lbCheckin.Text = "You have been checked in. But you are late!!!";
                }
            }
            else if(operation == "Checkout")
            {
                lbCheckin.Text = "You have been checked out. Have a nice day!";
            }
        }
        /*
        //Phần hình ảnh đang làm trong ca
        void takePicture(string EmpID)
        {
            if(count >= 0 && count <= 6)
            {
                DataTable table = cld.takePic(EmpID);
                //Phần hình
                byte[] pic = (byte[])table.Rows[0][0];
                MemoryStream Picture = new MemoryStream(pic);
                MatrixPic[count].Image = Image.FromStream(Picture);
                //Phần tên
                MatrixName[count].Text = table.Rows[0][1].ToString();
                MatrixName[count].Visible = true;
                //Phần mã nhân viên
                MatrixEmpID[count] = EmpID;
                count++;
            }
        }
        void deletePicture(string EmpID)
        {
            for(int i = 0; i < 7; ++i)
            {
                if(EmpID == MatrixEmpID[i])
                {
                    MatrixPic[i].Image = null;
                    MatrixName[i].Text = "";
                    MatrixName[i].Visible = false;
                    MatrixEmpID[i] = "";
                    break;
                }
            }
            count--;
            rearrange();
        }
        void rearrange()
        {
            for (int i = 0; i < 6; ++i)
            {
                if(MatrixEmpID[i] == "")
                {
                    //Chức năng giống hàm swap
                    MatrixPic[i].Image = MatrixPic[i + 1].Image;
                    MatrixName[i].Text = MatrixName[i + 1].Text;
                    MatrixEmpID[i] = MatrixEmpID[i + 1];

                    MatrixPic[i + 1].Image = null;
                    MatrixName[i + 1].Text = "";
                    MatrixEmpID[i + 1] = "";
                }
            }
        }*//*
        //Phần tải thông tin nhân viên
        void loadInfo(string EmpID, string operation)
        {
            if(operation == "Load")
            {
                DataTable table = cld.takeInfoForCalendar(EmpID);
                tbInfo.Text = "ID Nhân viên: " + table.Rows[0][0].ToString()
                            + "\nHọ Tên: " + table.Rows[0][1].ToString()
                            + "\nGiới tính: " + table.Rows[0][2].ToString()
                            + "\nĐiện thoại: " + table.Rows[0][3].ToString()
                            + "\nCMND: " + table.Rows[0][4].ToString();
            }
            else if(operation == "Unload")
            {
                tbInfo.Text = "";
            }
        }*/
    }
}
