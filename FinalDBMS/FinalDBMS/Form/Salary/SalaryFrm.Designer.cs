
namespace FinalDBMS
{
    partial class SalaryFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalaryFrm));
            this.dataGridViewShow = new System.Windows.Forms.DataGridView();
            this.btnWord = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewShow
            // 
            this.dataGridViewShow.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShow.Location = new System.Drawing.Point(17, 139);
            this.dataGridViewShow.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewShow.Name = "dataGridViewShow";
            this.dataGridViewShow.RowHeadersWidth = 62;
            this.dataGridViewShow.RowTemplate.Height = 28;
            this.dataGridViewShow.Size = new System.Drawing.Size(1040, 411);
            this.dataGridViewShow.TabIndex = 0;
            // 
            // btnWord
            // 
            this.btnWord.BackColor = System.Drawing.Color.White;
            this.btnWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnWord.Location = new System.Drawing.Point(17, 109);
            this.btnWord.Margin = new System.Windows.Forms.Padding(2);
            this.btnWord.Name = "btnWord";
            this.btnWord.Size = new System.Drawing.Size(128, 26);
            this.btnWord.TabIndex = 1;
            this.btnWord.Text = "In ra file WORD";
            this.btnWord.UseVisualStyleBackColor = false;
            this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label6.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(313, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(453, 34);
            this.label6.TabIndex = 12;
            this.label6.Text = "BẢNG LƯƠNG NHÂN VIÊN";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label1.Font = new System.Drawing.Font("Arial", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(604, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(453, 10);
            this.label1.TabIndex = 13;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label2.Location = new System.Drawing.Point(605, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 34);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tháng:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbMonth
            // 
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Location = new System.Drawing.Point(665, 97);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(88, 21);
            this.cbMonth.TabIndex = 15;
            // 
            // cbYear
            // 
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(823, 97);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(125, 21);
            this.cbYear.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label3.Location = new System.Drawing.Point(763, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 34);
            this.label3.TabIndex = 16;
            this.label3.Text = "Năm:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFind
            // 
            this.btnFind.BackColor = System.Drawing.Color.White;
            this.btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.btnFind.Location = new System.Drawing.Point(969, 93);
            this.btnFind.Margin = new System.Windows.Forms.Padding(2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(88, 26);
            this.btnFind.TabIndex = 18;
            this.btnFind.Text = "Tìm kiếm";
            this.btnFind.UseVisualStyleBackColor = false;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // SalaryFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1068, 561);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnWord);
            this.Controls.Add(this.dataGridViewShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "SalaryFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salary";
            this.Load += new System.EventHandler(this.SalaryFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewShow;
        private System.Windows.Forms.Button btnWord;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMonth;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnFind;
    }
}