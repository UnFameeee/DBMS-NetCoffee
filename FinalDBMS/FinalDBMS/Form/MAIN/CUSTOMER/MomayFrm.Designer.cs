
namespace FinalDBMS
{
    partial class MomayFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MomayFrm));
            this.comboBoxChonmay = new System.Windows.Forms.ComboBox();
            this.buttonMomay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBoxChonmay
            // 
            this.comboBoxChonmay.FormattingEnabled = true;
            this.comboBoxChonmay.Location = new System.Drawing.Point(15, 31);
            this.comboBoxChonmay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxChonmay.Name = "comboBoxChonmay";
            this.comboBoxChonmay.Size = new System.Drawing.Size(352, 24);
            this.comboBoxChonmay.TabIndex = 0;
            // 
            // buttonMomay
            // 
            this.buttonMomay.BackColor = System.Drawing.Color.White;
            this.buttonMomay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMomay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonMomay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.buttonMomay.Location = new System.Drawing.Point(101, 79);
            this.buttonMomay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonMomay.Name = "buttonMomay";
            this.buttonMomay.Size = new System.Drawing.Size(185, 39);
            this.buttonMomay.TabIndex = 2;
            this.buttonMomay.Text = "Mở máy";
            this.buttonMomay.UseVisualStyleBackColor = false;
            this.buttonMomay.Click += new System.EventHandler(this.buttonMomay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label1.Location = new System.Drawing.Point(15, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chọn máy";
            // 
            // MomayFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 134);
            this.Controls.Add(this.buttonMomay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxChonmay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MomayFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mở máy ";
            this.Load += new System.EventHandler(this.MomayFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxChonmay;
        private System.Windows.Forms.Button buttonMomay;
        private System.Windows.Forms.Label label1;
    }
}