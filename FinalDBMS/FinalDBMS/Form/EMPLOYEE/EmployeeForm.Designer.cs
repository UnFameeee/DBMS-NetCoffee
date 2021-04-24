
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
            this.btnHelp = new System.Windows.Forms.Button();
            this.btnLeftMenu = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pnTop = new System.Windows.Forms.Panel();
            this.btn_ = new System.Windows.Forms.Button();
            this.btnbig = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbMenu = new System.Windows.Forms.Label();
            this.pnLeft.SuspendLayout();
            this.flpLeftMenu.SuspendLayout();
            this.pnLeftTop.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnLeft
            // 
            this.pnLeft.BackColor = System.Drawing.SystemColors.Window;
            this.pnLeft.Controls.Add(this.flpLeftMenu);
            this.pnLeft.Controls.Add(this.pnLeftTop);
            this.pnLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnLeft.Location = new System.Drawing.Point(0, 0);
            this.pnLeft.Name = "pnLeft";
            this.pnLeft.Size = new System.Drawing.Size(200, 578);
            this.pnLeft.TabIndex = 2;
            // 
            // flpLeftMenu
            // 
            this.flpLeftMenu.Controls.Add(this.btnProfile);
            this.flpLeftMenu.Controls.Add(this.btnTasks);
            this.flpLeftMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpLeftMenu.Location = new System.Drawing.Point(0, 117);
            this.flpLeftMenu.Name = "flpLeftMenu";
            this.flpLeftMenu.Size = new System.Drawing.Size(200, 461);
            this.flpLeftMenu.TabIndex = 2;
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Aquamarine;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnProfile.Location = new System.Drawing.Point(3, 3);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(194, 33);
            this.btnProfile.TabIndex = 2;
            this.btnProfile.Tag = "Profile";
            this.btnProfile.Text = "Profile";
            this.btnProfile.UseVisualStyleBackColor = false;
            // 
            // btnTasks
            // 
            this.btnTasks.FlatAppearance.BorderSize = 0;
            this.btnTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTasks.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTasks.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnTasks.Location = new System.Drawing.Point(3, 42);
            this.btnTasks.Name = "btnTasks";
            this.btnTasks.Size = new System.Drawing.Size(194, 33);
            this.btnTasks.TabIndex = 3;
            this.btnTasks.Tag = "Tasks";
            this.btnTasks.Text = "Tasks";
            this.btnTasks.UseVisualStyleBackColor = true;
            // 
            // pnLeftTop
            // 
            this.pnLeftTop.Controls.Add(this.btnHelp);
            this.pnLeftTop.Controls.Add(this.btnLeftMenu);
            this.pnLeftTop.Controls.Add(this.label1);
            this.pnLeftTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLeftTop.Location = new System.Drawing.Point(0, 0);
            this.pnLeftTop.Name = "pnLeftTop";
            this.pnLeftTop.Size = new System.Drawing.Size(200, 117);
            this.pnLeftTop.TabIndex = 2;
            // 
            // btnHelp
            // 
            this.btnHelp.FlatAppearance.BorderSize = 0;
            this.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelp.Location = new System.Drawing.Point(3, 63);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(50, 51);
            this.btnHelp.TabIndex = 6;
            this.btnHelp.Tag = "Help";
            this.btnHelp.Text = "?";
            this.btnHelp.UseVisualStyleBackColor = true;
            // 
            // btnLeftMenu
            // 
            this.btnLeftMenu.FlatAppearance.BorderSize = 0;
            this.btnLeftMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeftMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLeftMenu.Location = new System.Drawing.Point(3, 0);
            this.btnLeftMenu.Name = "btnLeftMenu";
            this.btnLeftMenu.Size = new System.Drawing.Size(50, 51);
            this.btnLeftMenu.TabIndex = 5;
            this.btnLeftMenu.Text = "=";
            this.btnLeftMenu.UseVisualStyleBackColor = true;
            this.btnLeftMenu.Click += new System.EventHandler(this.btnLeftMenu_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // pnTop
            // 
            this.pnTop.Controls.Add(this.btn_);
            this.pnTop.Controls.Add(this.btnbig);
            this.pnTop.Controls.Add(this.btnX);
            this.pnTop.Controls.Add(this.label2);
            this.pnTop.Controls.Add(this.lbMenu);
            this.pnTop.Location = new System.Drawing.Point(200, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(602, 53);
            this.pnTop.TabIndex = 3;
            // 
            // btn_
            // 
            this.btn_.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_.FlatAppearance.BorderSize = 0;
            this.btn_.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_.Location = new System.Drawing.Point(455, 0);
            this.btn_.Name = "btn_";
            this.btn_.Size = new System.Drawing.Size(49, 51);
            this.btn_.TabIndex = 3;
            this.btn_.Text = "_";
            this.btn_.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_.UseVisualStyleBackColor = true;
            this.btn_.Click += new System.EventHandler(this.btn__Click);
            // 
            // btnbig
            // 
            this.btnbig.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnbig.FlatAppearance.BorderSize = 0;
            this.btnbig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbig.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbig.Location = new System.Drawing.Point(504, 0);
            this.btnbig.Name = "btnbig";
            this.btnbig.Size = new System.Drawing.Size(49, 51);
            this.btnbig.TabIndex = 2;
            this.btnbig.Text = "+";
            this.btnbig.UseVisualStyleBackColor = true;
            this.btnbig.Click += new System.EventHandler(this.btnbig_Click);
            // 
            // btnX
            // 
            this.btnX.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnX.FlatAppearance.BorderSize = 0;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.Location = new System.Drawing.Point(553, 0);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(49, 51);
            this.btnX.TabIndex = 1;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = true;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.CadetBlue;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(0, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(602, 2);
            this.label2.TabIndex = 4;
            // 
            // lbMenu
            // 
            this.lbMenu.AutoSize = true;
            this.lbMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMenu.Location = new System.Drawing.Point(19, 12);
            this.lbMenu.Name = "lbMenu";
            this.lbMenu.Size = new System.Drawing.Size(66, 25);
            this.lbMenu.TabIndex = 0;
            this.lbMenu.Text = "Menu";
            this.lbMenu.Click += new System.EventHandler(this.lbMenu_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 578);
            this.Controls.Add(this.pnLeft);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            this.pnLeft.ResumeLayout(false);
            this.flpLeftMenu.ResumeLayout(false);
            this.pnLeftTop.ResumeLayout(false);
            this.pnLeftTop.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnLeft;
        private System.Windows.Forms.FlowLayoutPanel flpLeftMenu;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnTasks;
        private System.Windows.Forms.Panel pnLeftTop;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Button btnLeftMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Button btn_;
        private System.Windows.Forms.Button btnbig;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbMenu;
    }
}