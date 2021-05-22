
namespace FinalDBMS
{
    partial class MainFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tHÔNGTINCÁNHÂNToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cUSTOMERToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eMPLOYEEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TimeKeepingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SalaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aCCOUNTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.cHIACAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tHÔNGTINCÁNHÂNToolStripMenuItem,
            this.cUSTOMERToolStripMenuItem,
            this.manageDeviceToolStripMenuItem,
            this.eMPLOYEEToolStripMenuItem,
            this.aCCOUNTToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1069, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tHÔNGTINCÁNHÂNToolStripMenuItem
            // 
            this.tHÔNGTINCÁNHÂNToolStripMenuItem.Name = "tHÔNGTINCÁNHÂNToolStripMenuItem";
            this.tHÔNGTINCÁNHÂNToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.tHÔNGTINCÁNHÂNToolStripMenuItem.Text = "THÔNG TIN CÁ NHÂN";
            this.tHÔNGTINCÁNHÂNToolStripMenuItem.Click += new System.EventHandler(this.tHÔNGTINCÁNHÂNToolStripMenuItem_Click);
            // 
            // cUSTOMERToolStripMenuItem
            // 
            this.cUSTOMERToolStripMenuItem.Name = "cUSTOMERToolStripMenuItem";
            this.cUSTOMERToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.cUSTOMERToolStripMenuItem.Text = "KHÁCH HÀNG";
            this.cUSTOMERToolStripMenuItem.Click += new System.EventHandler(this.cUSTOMERToolStripMenuItem_Click);
            // 
            // manageDeviceToolStripMenuItem
            // 
            this.manageDeviceToolStripMenuItem.Name = "manageDeviceToolStripMenuItem";
            this.manageDeviceToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.manageDeviceToolStripMenuItem.Text = "THIẾT BỊ";
            this.manageDeviceToolStripMenuItem.Click += new System.EventHandler(this.manageDeviceToolStripMenuItem_Click);
            // 
            // eMPLOYEEToolStripMenuItem
            // 
            this.eMPLOYEEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoToolStripMenuItem,
            this.TimeKeepingToolStripMenuItem,
            this.SalaryToolStripMenuItem,
            this.cHIACAToolStripMenuItem});
            this.eMPLOYEEToolStripMenuItem.Name = "eMPLOYEEToolStripMenuItem";
            this.eMPLOYEEToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.eMPLOYEEToolStripMenuItem.Text = "NHÂN VIÊN";
            // 
            // InfoToolStripMenuItem
            // 
            this.InfoToolStripMenuItem.Name = "InfoToolStripMenuItem";
            this.InfoToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.InfoToolStripMenuItem.Text = "DANH SÁCH NHÂN VIÊN";
            this.InfoToolStripMenuItem.Click += new System.EventHandler(this.InfoToolStripMenuItem_Click);
            // 
            // TimeKeepingToolStripMenuItem
            // 
            this.TimeKeepingToolStripMenuItem.Name = "TimeKeepingToolStripMenuItem";
            this.TimeKeepingToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.TimeKeepingToolStripMenuItem.Text = "CHẤM CÔNG";
            this.TimeKeepingToolStripMenuItem.Click += new System.EventHandler(this.TimeKeepingToolStripMenuItem_Click);
            // 
            // SalaryToolStripMenuItem
            // 
            this.SalaryToolStripMenuItem.Name = "SalaryToolStripMenuItem";
            this.SalaryToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.SalaryToolStripMenuItem.Text = "LƯƠNG";
            this.SalaryToolStripMenuItem.Click += new System.EventHandler(this.SalaryToolStripMenuItem_Click);
            // 
            // aCCOUNTToolStripMenuItem
            // 
            this.aCCOUNTToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.aCCOUNTToolStripMenuItem.Name = "aCCOUNTToolStripMenuItem";
            this.aCCOUNTToolStripMenuItem.Size = new System.Drawing.Size(132, 20);
            this.aCCOUNTToolStripMenuItem.Text = "QUẢN LÝ TÀI KHOẢN";
            this.aCCOUNTToolStripMenuItem.Click += new System.EventHandler(this.aCCOUNTToolStripMenuItem_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.White;
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1069, 561);
            this.pnlMain.TabIndex = 1;
            // 
            // cHIACAToolStripMenuItem
            // 
            this.cHIACAToolStripMenuItem.Name = "cHIACAToolStripMenuItem";
            this.cHIACAToolStripMenuItem.Size = new System.Drawing.Size(208, 22);
            this.cHIACAToolStripMenuItem.Text = "CHIA CA";
            this.cHIACAToolStripMenuItem.Click += new System.EventHandler(this.cHIACAToolStripMenuItem_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1069, 585);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUẢN LÝ QUÁN CYBER NET";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cUSTOMERToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eMPLOYEEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aCCOUNTToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripMenuItem InfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TimeKeepingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SalaryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tHÔNGTINCÁNHÂNToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cHIACAToolStripMenuItem;
    }
}