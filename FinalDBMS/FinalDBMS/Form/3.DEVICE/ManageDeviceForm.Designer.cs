
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
            this.Button_RemoveDevice = new System.Windows.Forms.Button();
            this.ComboBox_SelectDevice = new System.Windows.Forms.ComboBox();
            this.Button_AddDevice = new System.Windows.Forms.Button();
            this.TextBox_DeviceID = new System.Windows.Forms.TextBox();
            this.Label_DeviceStatus = new System.Windows.Forms.Label();
            this.Label_TypeID = new System.Windows.Forms.Label();
            this.Label_DeviceID = new System.Windows.Forms.Label();
            this.Button_Refresh = new System.Windows.Forms.Button();
            this.DataGridView_ManageDevices = new System.Windows.Forms.DataGridView();
            this.Button_Update = new System.Windows.Forms.Button();
            this.ComboBox_SelectStatus = new System.Windows.Forms.ComboBox();
            this.Button_StartPlaying = new System.Windows.Forms.Button();
            this.Button_Show = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_ManageDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // Button_RemoveDevice
            // 
            this.Button_RemoveDevice.BackColor = System.Drawing.Color.PaleGreen;
            this.Button_RemoveDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_RemoveDevice.Location = new System.Drawing.Point(263, 314);
            this.Button_RemoveDevice.Name = "Button_RemoveDevice";
            this.Button_RemoveDevice.Size = new System.Drawing.Size(206, 73);
            this.Button_RemoveDevice.TabIndex = 143;
            this.Button_RemoveDevice.Text = "Remove Device";
            this.Button_RemoveDevice.UseVisualStyleBackColor = false;
            this.Button_RemoveDevice.Click += new System.EventHandler(this.Button_RemoveDevice_Click);
            // 
            // ComboBox_SelectDevice
            // 
            this.ComboBox_SelectDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_SelectDevice.FormattingEnabled = true;
            this.ComboBox_SelectDevice.Location = new System.Drawing.Point(189, 127);
            this.ComboBox_SelectDevice.Name = "ComboBox_SelectDevice";
            this.ComboBox_SelectDevice.Size = new System.Drawing.Size(165, 28);
            this.ComboBox_SelectDevice.TabIndex = 142;
            // 
            // Button_AddDevice
            // 
            this.Button_AddDevice.BackColor = System.Drawing.Color.PeachPuff;
            this.Button_AddDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_AddDevice.Location = new System.Drawing.Point(26, 314);
            this.Button_AddDevice.Name = "Button_AddDevice";
            this.Button_AddDevice.Size = new System.Drawing.Size(206, 73);
            this.Button_AddDevice.TabIndex = 141;
            this.Button_AddDevice.Text = "Add Device";
            this.Button_AddDevice.UseVisualStyleBackColor = false;
            this.Button_AddDevice.Click += new System.EventHandler(this.Button_AddDevice_Click);
            // 
            // TextBox_DeviceID
            // 
            this.TextBox_DeviceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBox_DeviceID.Location = new System.Drawing.Point(189, 51);
            this.TextBox_DeviceID.Name = "TextBox_DeviceID";
            this.TextBox_DeviceID.Size = new System.Drawing.Size(165, 30);
            this.TextBox_DeviceID.TabIndex = 138;
            // 
            // Label_DeviceStatus
            // 
            this.Label_DeviceStatus.AutoSize = true;
            this.Label_DeviceStatus.BackColor = System.Drawing.Color.Aquamarine;
            this.Label_DeviceStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_DeviceStatus.Location = new System.Drawing.Point(35, 203);
            this.Label_DeviceStatus.Name = "Label_DeviceStatus";
            this.Label_DeviceStatus.Size = new System.Drawing.Size(139, 25);
            this.Label_DeviceStatus.TabIndex = 136;
            this.Label_DeviceStatus.Text = "Device_Status";
            // 
            // Label_TypeID
            // 
            this.Label_TypeID.AutoSize = true;
            this.Label_TypeID.BackColor = System.Drawing.Color.Aquamarine;
            this.Label_TypeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_TypeID.Location = new System.Drawing.Point(33, 127);
            this.Label_TypeID.Name = "Label_TypeID";
            this.Label_TypeID.Size = new System.Drawing.Size(87, 25);
            this.Label_TypeID.TabIndex = 135;
            this.Label_TypeID.Text = "Type ID:";
            // 
            // Label_DeviceID
            // 
            this.Label_DeviceID.AutoSize = true;
            this.Label_DeviceID.BackColor = System.Drawing.Color.Aquamarine;
            this.Label_DeviceID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_DeviceID.Location = new System.Drawing.Point(33, 54);
            this.Label_DeviceID.Name = "Label_DeviceID";
            this.Label_DeviceID.Size = new System.Drawing.Size(102, 25);
            this.Label_DeviceID.TabIndex = 134;
            this.Label_DeviceID.Text = "Device ID:";
            // 
            // Button_Refresh
            // 
            this.Button_Refresh.BackColor = System.Drawing.Color.Violet;
            this.Button_Refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Refresh.Location = new System.Drawing.Point(26, 559);
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(206, 73);
            this.Button_Refresh.TabIndex = 132;
            this.Button_Refresh.Text = "Refresh";
            this.Button_Refresh.UseVisualStyleBackColor = false;
            this.Button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // DataGridView_ManageDevices
            // 
            this.DataGridView_ManageDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_ManageDevices.Location = new System.Drawing.Point(494, 29);
            this.DataGridView_ManageDevices.Name = "DataGridView_ManageDevices";
            this.DataGridView_ManageDevices.RowHeadersWidth = 51;
            this.DataGridView_ManageDevices.RowTemplate.Height = 24;
            this.DataGridView_ManageDevices.Size = new System.Drawing.Size(707, 653);
            this.DataGridView_ManageDevices.TabIndex = 131;
            this.DataGridView_ManageDevices.DoubleClick += new System.EventHandler(this.DataGridView_ManageDevices_DoubleClick);
            // 
            // Button_Update
            // 
            this.Button_Update.BackColor = System.Drawing.Color.Aqua;
            this.Button_Update.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Update.Location = new System.Drawing.Point(26, 436);
            this.Button_Update.Name = "Button_Update";
            this.Button_Update.Size = new System.Drawing.Size(206, 73);
            this.Button_Update.TabIndex = 145;
            this.Button_Update.Text = "Update ";
            this.Button_Update.UseVisualStyleBackColor = false;
            this.Button_Update.Click += new System.EventHandler(this.Button_UpdateStatus_Click);
            // 
            // ComboBox_SelectStatus
            // 
            this.ComboBox_SelectStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboBox_SelectStatus.FormattingEnabled = true;
            this.ComboBox_SelectStatus.Location = new System.Drawing.Point(189, 204);
            this.ComboBox_SelectStatus.Name = "ComboBox_SelectStatus";
            this.ComboBox_SelectStatus.Size = new System.Drawing.Size(165, 28);
            this.ComboBox_SelectStatus.TabIndex = 146;
            // 
            // Button_StartPlaying
            // 
            this.Button_StartPlaying.BackColor = System.Drawing.Color.Ivory;
            this.Button_StartPlaying.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_StartPlaying.Location = new System.Drawing.Point(263, 436);
            this.Button_StartPlaying.Name = "Button_StartPlaying";
            this.Button_StartPlaying.Size = new System.Drawing.Size(206, 73);
            this.Button_StartPlaying.TabIndex = 147;
            this.Button_StartPlaying.Text = "Start Playing";
            this.Button_StartPlaying.UseVisualStyleBackColor = false;
            this.Button_StartPlaying.Click += new System.EventHandler(this.Button_StartPlaying_Click);
            // 
            // Button_Show
            // 
            this.Button_Show.BackColor = System.Drawing.Color.Pink;
            this.Button_Show.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Show.Location = new System.Drawing.Point(263, 559);
            this.Button_Show.Name = "Button_Show";
            this.Button_Show.Size = new System.Drawing.Size(206, 73);
            this.Button_Show.TabIndex = 148;
            this.Button_Show.Text = "Show Players";
            this.Button_Show.UseVisualStyleBackColor = false;
            this.Button_Show.Click += new System.EventHandler(this.Button_Show_Click);
            // 
            // ManageDeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 710);
            this.Controls.Add(this.Button_Show);
            this.Controls.Add(this.Button_StartPlaying);
            this.Controls.Add(this.ComboBox_SelectStatus);
            this.Controls.Add(this.Button_Update);
            this.Controls.Add(this.Button_RemoveDevice);
            this.Controls.Add(this.ComboBox_SelectDevice);
            this.Controls.Add(this.Button_AddDevice);
            this.Controls.Add(this.TextBox_DeviceID);
            this.Controls.Add(this.Label_DeviceStatus);
            this.Controls.Add(this.Label_TypeID);
            this.Controls.Add(this.Label_DeviceID);
            this.Controls.Add(this.Button_Refresh);
            this.Controls.Add(this.DataGridView_ManageDevices);
            this.Name = "ManageDeviceForm";
            this.Text = "ManageDeviceForm";
            this.Load += new System.EventHandler(this.ManageDeviceForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_ManageDevices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button Button_Update;
        private System.Windows.Forms.ComboBox ComboBox_SelectStatus;
        private System.Windows.Forms.Button Button_StartPlaying;
        private System.Windows.Forms.Button Button_Show;
    }
}