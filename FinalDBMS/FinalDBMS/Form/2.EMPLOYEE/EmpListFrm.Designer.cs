﻿
namespace FinalDBMS
{
    partial class EmpListFrm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpListFrm));
            this.pnData = new System.Windows.Forms.Panel();
            this.dgvEmp = new System.Windows.Forms.DataGridView();
            this.btnDetail = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lbToTal = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pbButton = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbMale = new System.Windows.Forms.Label();
            this.lbFemale = new System.Windows.Forms.Label();
            this.btnFemale = new System.Windows.Forms.Button();
            this.btnMale = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.pnTop = new System.Windows.Forms.Panel();
            this.pnData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmp)).BeginInit();
            this.pbButton.SuspendLayout();
            this.pnTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnData
            // 
            this.pnData.Controls.Add(this.dgvEmp);
            this.pnData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnData.Location = new System.Drawing.Point(0, 92);
            this.pnData.Name = "pnData";
            this.pnData.Size = new System.Drawing.Size(1063, 418);
            this.pnData.TabIndex = 2;
            // 
            // dgvEmp
            // 
            this.dgvEmp.AllowUserToAddRows = false;
            this.dgvEmp.AllowUserToDeleteRows = false;
            this.dgvEmp.AllowUserToResizeColumns = false;
            this.dgvEmp.AllowUserToResizeRows = false;
            this.dgvEmp.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmp.ColumnHeadersHeight = 25;
            this.dgvEmp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEmp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmp.Location = new System.Drawing.Point(0, 0);
            this.dgvEmp.Name = "dgvEmp";
            this.dgvEmp.ReadOnly = true;
            this.dgvEmp.RowHeadersWidth = 25;
            this.dgvEmp.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvEmp.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvEmp.Size = new System.Drawing.Size(1063, 418);
            this.dgvEmp.TabIndex = 0;
            // 
            // btnDetail
            // 
            this.btnDetail.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnDetail.Location = new System.Drawing.Point(24, 6);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(82, 32);
            this.btnDetail.TabIndex = 0;
            this.btnDetail.Text = "Detail";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAdd.Location = new System.Drawing.Point(129, 6);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 32);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lbToTal
            // 
            this.lbToTal.AutoSize = true;
            this.lbToTal.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbToTal.Location = new System.Drawing.Point(875, 12);
            this.lbToTal.Name = "lbToTal";
            this.lbToTal.Size = new System.Drawing.Size(50, 20);
            this.lbToTal.TabIndex = 4;
            this.lbToTal.Text = "label2";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnRefresh.Location = new System.Drawing.Point(234, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(82, 32);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // pbButton
            // 
            this.pbButton.BackColor = System.Drawing.Color.White;
            this.pbButton.Controls.Add(this.btnRefresh);
            this.pbButton.Controls.Add(this.lbToTal);
            this.pbButton.Controls.Add(this.btnAdd);
            this.pbButton.Controls.Add(this.btnDetail);
            this.pbButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbButton.Location = new System.Drawing.Point(0, 510);
            this.pbButton.Name = "pbButton";
            this.pbButton.Size = new System.Drawing.Size(1063, 46);
            this.pbButton.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "SEARCH";
            // 
            // lbMale
            // 
            this.lbMale.AutoSize = true;
            this.lbMale.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMale.Location = new System.Drawing.Point(920, 59);
            this.lbMale.Name = "lbMale";
            this.lbMale.Size = new System.Drawing.Size(50, 20);
            this.lbMale.TabIndex = 2;
            this.lbMale.Text = "label2";
            // 
            // lbFemale
            // 
            this.lbFemale.AutoSize = true;
            this.lbFemale.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFemale.Location = new System.Drawing.Point(761, 59);
            this.lbFemale.Name = "lbFemale";
            this.lbFemale.Size = new System.Drawing.Size(50, 20);
            this.lbFemale.TabIndex = 3;
            this.lbFemale.Text = "label3";
            // 
            // btnFemale
            // 
            this.btnFemale.BackColor = System.Drawing.Color.Transparent;
            this.btnFemale.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFemale.BackgroundImage")));
            this.btnFemale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnFemale.FlatAppearance.BorderSize = 0;
            this.btnFemale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFemale.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.btnFemale.Location = new System.Drawing.Point(765, 12);
            this.btnFemale.Name = "btnFemale";
            this.btnFemale.Size = new System.Drawing.Size(58, 44);
            this.btnFemale.TabIndex = 5;
            this.btnFemale.UseVisualStyleBackColor = false;
            this.btnFemale.Click += new System.EventHandler(this.btnFemale_Click);
            // 
            // btnMale
            // 
            this.btnMale.BackColor = System.Drawing.Color.Transparent;
            this.btnMale.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnMale.BackgroundImage")));
            this.btnMale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnMale.FlatAppearance.BorderSize = 0;
            this.btnMale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMale.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.btnMale.Location = new System.Drawing.Point(923, 12);
            this.btnMale.Name = "btnMale";
            this.btnMale.Size = new System.Drawing.Size(58, 44);
            this.btnMale.TabIndex = 6;
            this.btnMale.UseVisualStyleBackColor = false;
            this.btnMale.Click += new System.EventHandler(this.btnMale_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Transparent;
            this.btnSearch.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSearch.BackgroundImage")));
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.btnSearch.Location = new System.Drawing.Point(629, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(29, 25);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(103, 28);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(512, 29);
            this.tbSearch.TabIndex = 8;
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.White;
            this.pnTop.Controls.Add(this.tbSearch);
            this.pnTop.Controls.Add(this.btnSearch);
            this.pnTop.Controls.Add(this.btnMale);
            this.pnTop.Controls.Add(this.btnFemale);
            this.pnTop.Controls.Add(this.lbFemale);
            this.pnTop.Controls.Add(this.lbMale);
            this.pnTop.Controls.Add(this.label1);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(0, 0);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(1063, 92);
            this.pnTop.TabIndex = 0;
            // 
            // EmpListFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 556);
            this.Controls.Add(this.pnData);
            this.Controls.Add(this.pbButton);
            this.Controls.Add(this.pnTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EmpListFrm";
            this.Text = "EmpListFrm";
            this.Load += new System.EventHandler(this.EmpListFrm_Load);
            this.pnData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmp)).EndInit();
            this.pbButton.ResumeLayout(false);
            this.pbButton.PerformLayout();
            this.pnTop.ResumeLayout(false);
            this.pnTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnData;
        private System.Windows.Forms.DataGridView dgvEmp;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lbToTal;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pbButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbMale;
        private System.Windows.Forms.Label lbFemale;
        private System.Windows.Forms.Button btnFemale;
        private System.Windows.Forms.Button btnMale;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Panel pnTop;
    }
}