
namespace FinalDBMS
{
    partial class DivideShift
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
            this.label11 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmpID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddShift = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnEditShift = new System.Windows.Forms.Button();
            this.btnDeleteShift = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.tbShiftID = new System.Windows.Forms.TextBox();
            this.tbShiftManagerID = new System.Windows.Forms.TextBox();
            this.dgv2 = new System.Windows.Forms.DataGridView();
            this.btnDeleteTime = new System.Windows.Forms.Button();
            this.btnEditTime = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnAddTime = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tbShiftID2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.timeStart = new System.Windows.Forms.DateTimePicker();
            this.timeEnd = new System.Windows.Forms.DateTimePicker();
            this.btnFind1 = new System.Windows.Forms.Button();
            this.btnFind2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label11.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(317, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(420, 34);
            this.label11.TabIndex = 152;
            this.label11.Text = "CHIA CA LÀM VIỆC";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv
            // 
            this.dgv.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 113);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(523, 214);
            this.dgv.TabIndex = 153;
            this.dgv.DoubleClick += new System.EventHandler(this.dgv_DoubleClick);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(523, 34);
            this.label1.TabIndex = 154;
            this.label1.Text = "DANH SÁCH CA LÀM CỦA NHÂN VIÊN";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbEmpID
            // 
            this.tbEmpID.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmpID.Location = new System.Drawing.Point(765, 148);
            this.tbEmpID.Name = "tbEmpID";
            this.tbEmpID.Size = new System.Drawing.Size(189, 22);
            this.tbEmpID.TabIndex = 156;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(648, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 34);
            this.label2.TabIndex = 157;
            this.label2.Text = "Mã nhân viên:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddShift
            // 
            this.btnAddShift.BackColor = System.Drawing.Color.White;
            this.btnAddShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddShift.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnAddShift.Location = new System.Drawing.Point(636, 272);
            this.btnAddShift.Name = "btnAddShift";
            this.btnAddShift.Size = new System.Drawing.Size(123, 31);
            this.btnAddShift.TabIndex = 158;
            this.btnAddShift.Text = "Thêm ca làm";
            this.btnAddShift.UseVisualStyleBackColor = false;
            this.btnAddShift.Click += new System.EventHandler(this.btnAddShift_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(642, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 34);
            this.label3.TabIndex = 159;
            this.label3.Text = "Mã ca làm:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(642, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 34);
            this.label4.TabIndex = 160;
            this.label4.Text = "Mã quản lý:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label5.Location = new System.Drawing.Point(678, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 34);
            this.label5.TabIndex = 161;
            this.label5.Text = "CHỈNH SỬA CA LÀM";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEditShift
            // 
            this.btnEditShift.BackColor = System.Drawing.Color.White;
            this.btnEditShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditShift.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnEditShift.Location = new System.Drawing.Point(765, 272);
            this.btnEditShift.Name = "btnEditShift";
            this.btnEditShift.Size = new System.Drawing.Size(124, 31);
            this.btnEditShift.TabIndex = 162;
            this.btnEditShift.Text = "Sửa ca làm";
            this.btnEditShift.UseVisualStyleBackColor = false;
            this.btnEditShift.Click += new System.EventHandler(this.btnEditShift_Click);
            // 
            // btnDeleteShift
            // 
            this.btnDeleteShift.BackColor = System.Drawing.Color.White;
            this.btnDeleteShift.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteShift.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteShift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnDeleteShift.Location = new System.Drawing.Point(895, 272);
            this.btnDeleteShift.Name = "btnDeleteShift";
            this.btnDeleteShift.Size = new System.Drawing.Size(121, 31);
            this.btnDeleteShift.TabIndex = 163;
            this.btnDeleteShift.Text = "Xóa ca làm";
            this.btnDeleteShift.UseVisualStyleBackColor = false;
            this.btnDeleteShift.Click += new System.EventHandler(this.btnDeleteShift_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label6.Location = new System.Drawing.Point(12, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(523, 34);
            this.label6.TabIndex = 164;
            this.label6.Text = "DANH SÁCH THỜI GIAN LÀM VIỆC";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbShiftID
            // 
            this.tbShiftID.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbShiftID.Location = new System.Drawing.Point(765, 182);
            this.tbShiftID.Name = "tbShiftID";
            this.tbShiftID.Size = new System.Drawing.Size(189, 22);
            this.tbShiftID.TabIndex = 165;
            // 
            // tbShiftManagerID
            // 
            this.tbShiftManagerID.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbShiftManagerID.Location = new System.Drawing.Point(765, 216);
            this.tbShiftManagerID.Name = "tbShiftManagerID";
            this.tbShiftManagerID.Size = new System.Drawing.Size(189, 22);
            this.tbShiftManagerID.TabIndex = 166;
            // 
            // dgv2
            // 
            this.dgv2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgv2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv2.Location = new System.Drawing.Point(12, 406);
            this.dgv2.Name = "dgv2";
            this.dgv2.Size = new System.Drawing.Size(523, 143);
            this.dgv2.TabIndex = 167;
            this.dgv2.DoubleClick += new System.EventHandler(this.dgv2_DoubleClick);
            // 
            // btnDeleteTime
            // 
            this.btnDeleteTime.BackColor = System.Drawing.Color.White;
            this.btnDeleteTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnDeleteTime.Location = new System.Drawing.Point(886, 519);
            this.btnDeleteTime.Name = "btnDeleteTime";
            this.btnDeleteTime.Size = new System.Drawing.Size(121, 31);
            this.btnDeleteTime.TabIndex = 175;
            this.btnDeleteTime.Text = "Xóa ca làm";
            this.btnDeleteTime.UseVisualStyleBackColor = false;
            this.btnDeleteTime.Click += new System.EventHandler(this.btnDeleteTime_Click);
            // 
            // btnEditTime
            // 
            this.btnEditTime.BackColor = System.Drawing.Color.White;
            this.btnEditTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnEditTime.Location = new System.Drawing.Point(756, 519);
            this.btnEditTime.Name = "btnEditTime";
            this.btnEditTime.Size = new System.Drawing.Size(124, 31);
            this.btnEditTime.TabIndex = 174;
            this.btnEditTime.Text = "Sửa ca làm";
            this.btnEditTime.UseVisualStyleBackColor = false;
            this.btnEditTime.Click += new System.EventHandler(this.btnEditTime_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label7.Location = new System.Drawing.Point(641, 371);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(352, 34);
            this.label7.TabIndex = 173;
            this.label7.Text = "CHỈNH SỬA THỜI GIAN CA LÀM";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(617, 478);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 34);
            this.label8.TabIndex = 172;
            this.label8.Text = "Thời gian kết thúc:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(614, 444);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 34);
            this.label9.TabIndex = 171;
            this.label9.Text = "Thời gian bắt đầu:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnAddTime
            // 
            this.btnAddTime.BackColor = System.Drawing.Color.White;
            this.btnAddTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTime.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnAddTime.Location = new System.Drawing.Point(627, 519);
            this.btnAddTime.Name = "btnAddTime";
            this.btnAddTime.Size = new System.Drawing.Size(123, 31);
            this.btnAddTime.TabIndex = 170;
            this.btnAddTime.Text = "Thêm ca làm";
            this.btnAddTime.UseVisualStyleBackColor = false;
            this.btnAddTime.Click += new System.EventHandler(this.btnAddTime_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.White;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(609, 410);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 34);
            this.label10.TabIndex = 169;
            this.label10.Text = "Mã ca làm:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbShiftID2
            // 
            this.tbShiftID2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbShiftID2.Location = new System.Drawing.Point(765, 416);
            this.tbShiftID2.Name = "tbShiftID2";
            this.tbShiftID2.Size = new System.Drawing.Size(189, 22);
            this.tbShiftID2.TabIndex = 168;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label12.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(12, 346);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(1045, 10);
            this.label12.TabIndex = 178;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnRefresh.Location = new System.Drawing.Point(934, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(123, 31);
            this.btnRefresh.TabIndex = 179;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // timeStart
            // 
            this.timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeStart.Location = new System.Drawing.Point(765, 449);
            this.timeStart.Name = "timeStart";
            this.timeStart.Size = new System.Drawing.Size(101, 20);
            this.timeStart.TabIndex = 180;
            // 
            // timeEnd
            // 
            this.timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.timeEnd.Location = new System.Drawing.Point(765, 483);
            this.timeEnd.Name = "timeEnd";
            this.timeEnd.Size = new System.Drawing.Size(101, 20);
            this.timeEnd.TabIndex = 181;
            // 
            // btnFind1
            // 
            this.btnFind1.BackColor = System.Drawing.Color.White;
            this.btnFind1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind1.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnFind1.Location = new System.Drawing.Point(960, 148);
            this.btnFind1.Name = "btnFind1";
            this.btnFind1.Size = new System.Drawing.Size(69, 22);
            this.btnFind1.TabIndex = 182;
            this.btnFind1.Text = "Find";
            this.btnFind1.UseVisualStyleBackColor = false;
            this.btnFind1.Click += new System.EventHandler(this.btnFind1_Click);
            // 
            // btnFind2
            // 
            this.btnFind2.BackColor = System.Drawing.Color.White;
            this.btnFind2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind2.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnFind2.Location = new System.Drawing.Point(960, 416);
            this.btnFind2.Name = "btnFind2";
            this.btnFind2.Size = new System.Drawing.Size(69, 22);
            this.btnFind2.TabIndex = 183;
            this.btnFind2.Text = "Find";
            this.btnFind2.UseVisualStyleBackColor = false;
            this.btnFind2.Click += new System.EventHandler(this.btnFind2_Click);
            // 
            // DivideShift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1069, 561);
            this.Controls.Add(this.btnFind2);
            this.Controls.Add(this.btnFind1);
            this.Controls.Add(this.timeEnd);
            this.Controls.Add(this.timeStart);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnDeleteTime);
            this.Controls.Add(this.btnEditTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnAddTime);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbShiftID2);
            this.Controls.Add(this.dgv2);
            this.Controls.Add(this.tbShiftManagerID);
            this.Controls.Add(this.tbShiftID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDeleteShift);
            this.Controls.Add(this.btnEditShift);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddShift);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEmpID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label11);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DivideShift";
            this.Text = "DivideShift";
            this.Load += new System.EventHandler(this.DivideShift_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEmpID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddShift;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnEditShift;
        private System.Windows.Forms.Button btnDeleteShift;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbShiftID;
        private System.Windows.Forms.TextBox tbShiftManagerID;
        private System.Windows.Forms.DataGridView dgv2;
        private System.Windows.Forms.Button btnDeleteTime;
        private System.Windows.Forms.Button btnEditTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnAddTime;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbShiftID2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DateTimePicker timeStart;
        private System.Windows.Forms.DateTimePicker timeEnd;
        private System.Windows.Forms.Button btnFind1;
        private System.Windows.Forms.Button btnFind2;
    }
}