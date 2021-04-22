
namespace FinalDBMS
{
    partial class EmployeeForm
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
            this.pnLeft = new System.Windows.Forms.Panel();
            this.flpLeftMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnTasks = new System.Windows.Forms.Button();
            this.pnLeftTop = new System.Windows.Forms.Panel();
            this.pnTop = new System.Windows.Forms.Panel();
            this.lbMenu = new System.Windows.Forms.Label();
            this.pnLeft.SuspendLayout();
            this.flpLeftMenu.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnLeft.Controls.Add(this.flpLeftMenu);
            this.pnLeft.Controls.Add(this.pnLeftTop);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(200, 634);
            this.pnLeft.TabIndex = 0;
            // 
            // flpLeftMenu
            // 
            this.flpLeftMenu.Controls.Add(this.btnProfile);
            this.flpLeftMenu.Controls.Add(this.btnTasks);
            this.flpLeftMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLeftMenu.Location = new System.Drawing.Point(0, 117);
            this.flpLeftMenu.Name = "flpLeftMenu";
            this.flpLeftMenu.Size = new System.Drawing.Size(200, 517);
            this.flpLeftMenu.TabIndex = 2;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Snow;
            this.btnProfile.Location = new System.Drawing.Point(3, 3);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(194, 33);
            this.btnProfile.TabIndex = 2;
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.Menu_Click);
            // 
            // btnTasks
            // 
            this.btnTasks.Location = new System.Drawing.Point(3, 42);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(194, 33);
            this.btnTasks.TabIndex = 3;
            this.btnTasks.Text = "Tasks";
            this.btnTasks.UseVisualStyleBackColor = true;
            this.btnTasks.Click += new System.EventHandler(this.Menu_Click);
            // 
            // pnLeftTop
            // 
            this.pnLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnLeftTop.Name = "pnLeftTop";
            this.pnLeftTop.Size = new System.Drawing.Size(200, 117);
            this.pnLeftTop.TabIndex = 2;
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.lbMenu);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(200, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(845, 68);
            this.pnTop.TabIndex = 1;
            // 
            // lbMenu
            // 
            this.lbMenu.AutoSize = true;
            this.lbMenu.Location = new System.Drawing.Point(25, 28);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(35, 13);
            this.lbMenu.TabIndex = 0;
            this.lbMenu.Text = "label1";
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 634);
            this.Controls.Add(this.pnTop);
            this.Controls.Add(this.pnLeft);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.pnLeft.ResumeLayout(false);
            this.flpLeftMenu.ResumeLayout(false);
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnLeftTop;
        private System.Windows.Forms.Label lbMenu;
        private System.Windows.Forms.FlowLayoutPanel flpLeftMenu;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnTasks;
    }
}