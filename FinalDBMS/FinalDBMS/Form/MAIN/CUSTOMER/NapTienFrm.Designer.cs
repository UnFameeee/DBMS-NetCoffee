
namespace FinalDBMS
{
    partial class NapTienFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNaptien = new System.Windows.Forms.TextBox();
            this.buttonNaptien = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(175, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập số tiền nạp";
            // 
            // textBoxNaptien
            // 
            this.textBoxNaptien.Location = new System.Drawing.Point(223, 51);
            this.textBoxNaptien.Name = "textBoxNaptien";
            this.textBoxNaptien.Size = new System.Drawing.Size(217, 26);
            this.textBoxNaptien.TabIndex = 1;
            // 
            // buttonNaptien
            // 
            this.buttonNaptien.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNaptien.Location = new System.Drawing.Point(114, 122);
            this.buttonNaptien.Name = "buttonNaptien";
            this.buttonNaptien.Size = new System.Drawing.Size(264, 53);
            this.buttonNaptien.TabIndex = 2;
            this.buttonNaptien.Text = "Nạp tiền";
            this.buttonNaptien.UseVisualStyleBackColor = true;
            this.buttonNaptien.Click += new System.EventHandler(this.buttonNaptien_Click);
            // 
            // NapTienFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 198);
            this.Controls.Add(this.buttonNaptien);
            this.Controls.Add(this.textBoxNaptien);
            this.Controls.Add(this.label1);
            this.Name = "NapTienFrm";
            this.Text = "NapTienFrm";
            this.Load += new System.EventHandler(this.NapTienFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNaptien;
        private System.Windows.Forms.Button buttonNaptien;
    }
}