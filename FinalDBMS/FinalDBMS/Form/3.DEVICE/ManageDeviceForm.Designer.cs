
namespace FinalDBMS
{
    partial class ManageDeviceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageDeviceForm));
            this.Button_RemoveDevice = new System.Windows.Forms.Button();
            this.ComboBox_SelectDevice = new System.Windows.Forms.ComboBox();
            this.Button_AddDevice = new System.Windows.Forms.Button();
            this.TextBox_DeviceID = new System.Windows.Forms.TextBox();
            this.Label_DeviceStatus = new System.Windows.Forms.Label();
            this.Label_TypeID = new System.Windows.Forms.Label();
            this.Label_DeviceID = new System.Windows.Forms.Label();
            this.Button_Refresh = new System.Windows.Forms.Button();
            this.DataGridView_ManageDevices = new System.Windows.Forms.DataGridView();
            this.ComboBox_SelectStatus = new System.Windows.Forms.ComboBox();
            this.Button_StartPlaying = new System.Windows.Forms.Button();
            this.Button_Show = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ButtonRepairing = new System.Windows.Forms.Button();
            this.ButtonRemoveFromList = new System.Windows.Forms.Button();
            this.Button_Update = new System.Windows.Forms.Button();
            this.Panel_ShowInfo = new System.Windows.Forms.Panel();
            this.Label_Info = new System.Windows.Forms.Label();
            this.Label_ShowInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_ManageDevices)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.Panel_ShowInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // Button_RemoveDevice
            // 
            this.Button_RemoveDevice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.Button_RemoveDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_RemoveDevice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_RemoveDevice.ForeColor = System.Drawing.Color.White;
            this.Button_RemoveDevice.Location = new System.Drawing.Point(338, 179);
            this.Button_RemoveDevice.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Button_RemoveDevice.Name = "Button_RemoveDevice";
            this.Button_RemoveDevice.Size = new System.Drawing.Size(136, 38);
            this.Button_RemoveDevice.TabIndex = 143;
            this.Button_RemoveDevice.Text = "Dừng cấp";
            this.Button_RemoveDevice.UseVisualStyleBackColor = false;
            this.Button_RemoveDevice.Click += new System.EventHandler(this.Button_RemoveDevice_Click);
            // 
            // ComboBox_SelectDevice
            // 
            this.ComboBox_SelectDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_SelectDevice.FormattingEnabled = true;
            this.ComboBox_SelectDevice.Location = new System.Drawing.Point(126, 38);
            this.ComboBox_SelectDevice.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ComboBox_SelectDevice.Name = "ComboBox_SelectDevice";
            this.ComboBox_SelectDevice.Size = new System.Drawing.Size(293, 25);
            this.ComboBox_SelectDevice.TabIndex = 142;
            // 
            // Button_AddDevice
            // 
            this.Button_AddDevice.BackColor = System.Drawing.Color.White;
            this.Button_AddDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_AddDevice.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_AddDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.Button_AddDevice.Location = new System.Drawing.Point(4, 5);
            this.Button_AddDevice.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Button_AddDevice.Name = "Button_AddDevice";
            this.Button_AddDevice.Size = new System.Drawing.Size(127, 38);
            this.Button_AddDevice.TabIndex = 141;
            this.Button_AddDevice.Text = "Thêm Thiết Bị";
            this.Button_AddDevice.UseVisualStyleBackColor = false;
            this.Button_AddDevice.Click += new System.EventHandler(this.Button_AddDevice_Click);
            // 
            // TextBox_DeviceID
            // 
            this.TextBox_DeviceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_DeviceID.Location = new System.Drawing.Point(126, 8);
            this.TextBox_DeviceID.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.TextBox_DeviceID.Name = "TextBox_DeviceID";
            this.TextBox_DeviceID.Size = new System.Drawing.Size(293, 26);
            this.TextBox_DeviceID.TabIndex = 138;
            // 
            // Label_DeviceStatus
            // 
            this.Label_DeviceStatus.AutoSize = true;
            this.Label_DeviceStatus.BackColor = System.Drawing.Color.White;
            this.Label_DeviceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_DeviceStatus.Location = new System.Drawing.Point(9, 69);
            this.Label_DeviceStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_DeviceStatus.Name = "Label_DeviceStatus";
            this.Label_DeviceStatus.Size = new System.Drawing.Size(84, 20);
            this.Label_DeviceStatus.TabIndex = 136;
            this.Label_DeviceStatus.Text = "Trạng thái:";
            // 
            // Label_TypeID
            // 
            this.Label_TypeID.AutoSize = true;
            this.Label_TypeID.BackColor = System.Drawing.Color.White;
            this.Label_TypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_TypeID.Location = new System.Drawing.Point(9, 39);
            this.Label_TypeID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_TypeID.Name = "Label_TypeID";
            this.Label_TypeID.Size = new System.Drawing.Size(43, 20);
            this.Label_TypeID.TabIndex = 135;
            this.Label_TypeID.Text = "Loại:";
            // 
            // Label_DeviceID
            // 
            this.Label_DeviceID.AutoSize = true;
            this.Label_DeviceID.BackColor = System.Drawing.Color.White;
            this.Label_DeviceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_DeviceID.Location = new System.Drawing.Point(9, 12);
            this.Label_DeviceID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_DeviceID.Name = "Label_DeviceID";
            this.Label_DeviceID.Size = new System.Drawing.Size(85, 20);
            this.Label_DeviceID.TabIndex = 134;
            this.Label_DeviceID.Text = "ID Thiết bị:";
            // 
            // Button_Refresh
            // 
            this.Button_Refresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.Button_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Refresh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Refresh.ForeColor = System.Drawing.Color.White;
            this.Button_Refresh.Location = new System.Drawing.Point(965, 43);
            this.Button_Refresh.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(66, 27);
            this.Button_Refresh.TabIndex = 132;
            this.Button_Refresh.Text = "Refresh";
            this.Button_Refresh.UseVisualStyleBackColor = false;
            this.Button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // DataGridView_ManageDevices
            // 
            this.DataGridView_ManageDevices.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.DataGridView_ManageDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_ManageDevices.Location = new System.Drawing.Point(501, 72);
            this.DataGridView_ManageDevices.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.DataGridView_ManageDevices.Name = "DataGridView_ManageDevices";
            this.DataGridView_ManageDevices.RowHeadersWidth = 51;
            this.DataGridView_ManageDevices.RowTemplate.Height = 24;
            this.DataGridView_ManageDevices.Size = new System.Drawing.Size(530, 417);
            this.DataGridView_ManageDevices.TabIndex = 131;
            this.DataGridView_ManageDevices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_ManageDevices_CellContentClick);
            this.DataGridView_ManageDevices.DoubleClick += new System.EventHandler(this.DataGridView_ManageDevices_DoubleClick);
            // 
            // ComboBox_SelectStatus
            // 
            this.ComboBox_SelectStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_SelectStatus.FormattingEnabled = true;
            this.ComboBox_SelectStatus.Items.AddRange(new object[] {
            "Đang sử dụng",
            "Đang bảo trì",
            "Chưa sử dụng"});
            this.ComboBox_SelectStatus.Location = new System.Drawing.Point(127, 68);
            this.ComboBox_SelectStatus.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ComboBox_SelectStatus.Name = "ComboBox_SelectStatus";
            this.ComboBox_SelectStatus.Size = new System.Drawing.Size(292, 25);
            this.ComboBox_SelectStatus.TabIndex = 146;
            // 
            // Button_StartPlaying
            // 
            this.Button_StartPlaying.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.Button_StartPlaying.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_StartPlaying.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_StartPlaying.ForeColor = System.Drawing.Color.White;
            this.Button_StartPlaying.Location = new System.Drawing.Point(188, 179);
            this.Button_StartPlaying.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Button_StartPlaying.Name = "Button_StartPlaying";
            this.Button_StartPlaying.Size = new System.Drawing.Size(115, 38);
            this.Button_StartPlaying.TabIndex = 147;
            this.Button_StartPlaying.Text = "Cấp sử dụng";
            this.Button_StartPlaying.UseVisualStyleBackColor = false;
            this.Button_StartPlaying.Click += new System.EventHandler(this.Button_StartPlaying_Click);
            // 
            // Button_Show
            // 
            this.Button_Show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.Button_Show.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Show.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Show.ForeColor = System.Drawing.Color.White;
            this.Button_Show.Location = new System.Drawing.Point(40, 179);
            this.Button_Show.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Button_Show.Name = "Button_Show";
            this.Button_Show.Size = new System.Drawing.Size(127, 38);
            this.Button_Show.TabIndex = 148;
            this.Button_Show.Text = "Hiển thị khách";
            this.Button_Show.UseVisualStyleBackColor = false;
            this.Button_Show.Click += new System.EventHandler(this.Button_Show_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ComboBox_SelectStatus);
            this.panel1.Controls.Add(this.Label_DeviceID);
            this.panel1.Controls.Add(this.Label_TypeID);
            this.panel1.Controls.Add(this.Label_DeviceStatus);
            this.panel1.Controls.Add(this.TextBox_DeviceID);
            this.panel1.Controls.Add(this.ComboBox_SelectDevice);
            this.panel1.Location = new System.Drawing.Point(40, 72);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 103);
            this.panel1.TabIndex = 149;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label1.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(370, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(297, 34);
            this.label1.TabIndex = 150;
            this.label1.Text = "DANH SÁCH THIẾT BỊ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ButtonRepairing);
            this.panel2.Controls.Add(this.ButtonRemoveFromList);
            this.panel2.Controls.Add(this.Button_AddDevice);
            this.panel2.Controls.Add(this.Button_Update);
            this.panel2.Location = new System.Drawing.Point(501, 493);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(529, 47);
            this.panel2.TabIndex = 151;
            // 
            // ButtonRepairing
            // 
            this.ButtonRepairing.BackColor = System.Drawing.Color.White;
            this.ButtonRepairing.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRepairing.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRepairing.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.ButtonRepairing.Location = new System.Drawing.Point(342, 5);
            this.ButtonRepairing.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ButtonRepairing.Name = "ButtonRepairing";
            this.ButtonRepairing.Size = new System.Drawing.Size(185, 38);
            this.ButtonRepairing.TabIndex = 155;
            this.ButtonRepairing.Text = "Bắt đầu/ Dừng bảo trì";
            this.ButtonRepairing.UseVisualStyleBackColor = false;
            this.ButtonRepairing.Click += new System.EventHandler(this.ButtonRepairing_Click);
            // 
            // ButtonRemoveFromList
            // 
            this.ButtonRemoveFromList.BackColor = System.Drawing.Color.White;
            this.ButtonRemoveFromList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonRemoveFromList.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRemoveFromList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.ButtonRemoveFromList.Location = new System.Drawing.Point(261, 5);
            this.ButtonRemoveFromList.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.ButtonRemoveFromList.Name = "ButtonRemoveFromList";
            this.ButtonRemoveFromList.Size = new System.Drawing.Size(68, 38);
            this.ButtonRemoveFromList.TabIndex = 154;
            this.ButtonRemoveFromList.Text = "Xoá";
            this.ButtonRemoveFromList.UseVisualStyleBackColor = false;
            this.ButtonRemoveFromList.Click += new System.EventHandler(this.ButtonRemoveFromList_Click);
            // 
            // Button_Update
            // 
            this.Button_Update.BackColor = System.Drawing.Color.White;
            this.Button_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Update.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Update.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.Button_Update.Location = new System.Drawing.Point(143, 5);
            this.Button_Update.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Button_Update.Name = "Button_Update";
            this.Button_Update.Size = new System.Drawing.Size(105, 38);
            this.Button_Update.TabIndex = 145;
            this.Button_Update.Text = "Sửa loại";
            this.Button_Update.UseVisualStyleBackColor = false;
            this.Button_Update.Click += new System.EventHandler(this.Button_UpdateStatus_Click);
            // 
            // Panel_ShowInfo
            // 
            this.Panel_ShowInfo.Controls.Add(this.Label_Info);
            this.Panel_ShowInfo.Controls.Add(this.Label_ShowInfo);
            this.Panel_ShowInfo.Location = new System.Drawing.Point(40, 222);
            this.Panel_ShowInfo.Name = "Panel_ShowInfo";
            this.Panel_ShowInfo.Size = new System.Drawing.Size(434, 318);
            this.Panel_ShowInfo.TabIndex = 152;
            this.Panel_ShowInfo.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel_ShowInfo_Paint);
            // 
            // Label_Info
            // 
            this.Label_Info.AutoSize = true;
            this.Label_Info.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Info.Location = new System.Drawing.Point(5, 23);
            this.Label_Info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Info.Name = "Label_Info";
            this.Label_Info.Size = new System.Drawing.Size(76, 21);
            this.Label_Info.TabIndex = 1;
            this.Label_Info.Text = "Thông tin";
            // 
            // Label_ShowInfo
            // 
            this.Label_ShowInfo.AutoSize = true;
            this.Label_ShowInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_ShowInfo.Location = new System.Drawing.Point(-4, 0);
            this.Label_ShowInfo.Name = "Label_ShowInfo";
            this.Label_ShowInfo.Size = new System.Drawing.Size(0, 24);
            this.Label_ShowInfo.TabIndex = 0;
            this.Label_ShowInfo.Click += new System.EventHandler(this.Label_ShowInfo_Click);
            // 
            // ManageDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1063, 556);
            this.Controls.Add(this.Button_RemoveDevice);
            this.Controls.Add(this.Panel_ShowInfo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Button_Show);
            this.Controls.Add(this.Button_StartPlaying);
            this.Controls.Add(this.Button_Refresh);
            this.Controls.Add(this.DataGridView_ManageDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "ManageDeviceForm";
            this.Text = "ManageDeviceForm";
            this.Load += new System.EventHandler(this.ManageDeviceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_ManageDevices)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.Panel_ShowInfo.ResumeLayout(false);
            this.Panel_ShowInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Button_RemoveDevice;
        private System.Windows.Forms.ComboBox ComboBox_SelectDevice;
        private System.Windows.Forms.Button Button_AddDevice;
        public System.Windows.Forms.TextBox TextBox_DeviceID;
        private System.Windows.Forms.Label Label_DeviceStatus;
        private System.Windows.Forms.Label Label_TypeID;
        private System.Windows.Forms.Label Label_DeviceID;
        private System.Windows.Forms.Button Button_Refresh;
        private System.Windows.Forms.DataGridView DataGridView_ManageDevices;
        private System.Windows.Forms.ComboBox ComboBox_SelectStatus;
        private System.Windows.Forms.Button Button_StartPlaying;
        private System.Windows.Forms.Button Button_Show;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel Panel_ShowInfo;
        private System.Windows.Forms.Label Label_ShowInfo;
        private System.Windows.Forms.Label Label_Info;
        private System.Windows.Forms.Button ButtonRemoveFromList;
        private System.Windows.Forms.Button ButtonRepairing;
        private System.Windows.Forms.Button Button_Update;
    }
}