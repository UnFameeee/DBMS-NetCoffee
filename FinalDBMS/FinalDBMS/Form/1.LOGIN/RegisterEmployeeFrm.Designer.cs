
namespace FinalDBMS
{
    partial class RegisterEmployeeFrm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterEmployeeFrm));
            this.comboBoxTypeUser = new System.Windows.Forms.ComboBox();
            this.jOBBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.jOBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxConfirmPass = new System.Windows.Forms.TextBox();
            this.buttonRegister = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.textBoxPhone = new System.Windows.Forms.TextBox();
            this.textBoxHoTen = new System.Windows.Forms.TextBox();
            this.radioButtonNam = new System.Windows.Forms.RadioButton();
            this.radioButtonNu = new System.Windows.Forms.RadioButton();
            this.dateTimePickerBirthday = new System.Windows.Forms.DateTimePicker();
            this.textBoxCMND = new System.Windows.Forms.TextBox();
            this.textboxStatusE = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxTypeUser
            // 
            this.comboBoxTypeUser.DataSource = this.jOBBindingSource1;
            this.comboBoxTypeUser.DisplayMember = "JobDetail";
            this.comboBoxTypeUser.FormattingEnabled = true;
            this.comboBoxTypeUser.Location = new System.Drawing.Point(120, 181);
            this.comboBoxTypeUser.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBoxTypeUser.Name = "comboBoxTypeUser";
            this.comboBoxTypeUser.Size = new System.Drawing.Size(108, 24);
            this.comboBoxTypeUser.TabIndex = 15;
            this.comboBoxTypeUser.TabStop = false;
            this.comboBoxTypeUser.ValueMember = "WorkID";
            // 
            // jOBBindingSource1
            // 
            this.jOBBindingSource1.DataMember = "JOB";
            // 
            // jOBBindingSource
            // 
            this.jOBBindingSource.DataMember = "JOB";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxEmail.Location = new System.Drawing.Point(36, 212);
            this.textBoxEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(192, 24);
            this.textBoxEmail.TabIndex = 3;
            this.textBoxEmail.Text = "Email";
            // 
            // textBoxConfirmPass
            // 
            this.textBoxConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConfirmPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxConfirmPass.Location = new System.Drawing.Point(36, 143);
            this.textBoxConfirmPass.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxConfirmPass.Name = "textBoxConfirmPass";
            this.textBoxConfirmPass.Size = new System.Drawing.Size(192, 24);
            this.textBoxConfirmPass.TabIndex = 2;
            this.textBoxConfirmPass.Text = "Nhập Lại Mật Khẩu";
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.White;
            this.buttonRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.buttonRegister.Location = new System.Drawing.Point(153, 294);
            this.buttonRegister.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(192, 36);
            this.buttonRegister.TabIndex = 13;
            this.buttonRegister.Text = "Đăng ký";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxPassword.Location = new System.Drawing.Point(36, 106);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(192, 24);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.Text = "Mật Khẩu";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxUsername.Location = new System.Drawing.Point(36, 65);
            this.textBoxUsername.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(192, 24);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.Text = "Tên tài khoản";
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxID.Location = new System.Drawing.Point(36, 246);
            this.textBoxID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(192, 24);
            this.textBoxID.TabIndex = 4;
            this.textBoxID.Text = "ID";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhone.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxPhone.Location = new System.Drawing.Point(268, 176);
            this.textBoxPhone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(192, 24);
            this.textBoxPhone.TabIndex = 6;
            this.textBoxPhone.Text = "Điện thoại";
            // 
            // textBoxHoTen
            // 
            this.textBoxHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHoTen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxHoTen.Location = new System.Drawing.Point(268, 65);
            this.textBoxHoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxHoTen.Name = "textBoxHoTen";
            this.textBoxHoTen.Size = new System.Drawing.Size(192, 24);
            this.textBoxHoTen.TabIndex = 5;
            this.textBoxHoTen.Text = "Họ Tên";
            // 
            // radioButtonNam
            // 
            this.radioButtonNam.AutoSize = true;
            this.radioButtonNam.Location = new System.Drawing.Point(276, 105);
            this.radioButtonNam.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonNam.Name = "radioButtonNam";
            this.radioButtonNam.Size = new System.Drawing.Size(58, 21);
            this.radioButtonNam.TabIndex = 7;
            this.radioButtonNam.Text = "Nam";
            this.radioButtonNam.UseVisualStyleBackColor = true;
            // 
            // radioButtonNu
            // 
            this.radioButtonNu.AutoSize = true;
            this.radioButtonNu.Location = new System.Drawing.Point(341, 106);
            this.radioButtonNu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.radioButtonNu.Name = "radioButtonNu";
            this.radioButtonNu.Size = new System.Drawing.Size(47, 21);
            this.radioButtonNu.TabIndex = 8;
            this.radioButtonNu.Text = "Nữ";
            this.radioButtonNu.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerBirthday
            // 
            this.dateTimePickerBirthday.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerBirthday.Location = new System.Drawing.Point(268, 142);
            this.dateTimePickerBirthday.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            this.dateTimePickerBirthday.Size = new System.Drawing.Size(136, 22);
            this.dateTimePickerBirthday.TabIndex = 9;
            this.dateTimePickerBirthday.TabStop = false;
            // 
            // textBoxCMND
            // 
            this.textBoxCMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCMND.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxCMND.Location = new System.Drawing.Point(268, 212);
            this.textBoxCMND.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxCMND.Name = "textBoxCMND";
            this.textBoxCMND.Size = new System.Drawing.Size(192, 24);
            this.textBoxCMND.TabIndex = 7;
            this.textBoxCMND.Text = "CMND";
            // 
            // textboxStatusE
            // 
            this.textboxStatusE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxStatusE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textboxStatusE.Location = new System.Drawing.Point(268, 246);
            this.textboxStatusE.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textboxStatusE.Name = "textboxStatusE";
            this.textboxStatusE.Size = new System.Drawing.Size(192, 24);
            this.textboxStatusE.TabIndex = 8;
            this.textboxStatusE.Text = "Tình Trạng";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.White;
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(467, 2);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 36);
            this.btnExit.TabIndex = 159;
            this.btnExit.Text = "x";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 18.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(88)))), ((int)(((byte)(254)))));
            this.label11.Location = new System.Drawing.Point(103, 9);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(313, 41);
            this.label11.TabIndex = 160;
            this.label11.Text = "ĐĂNG KÝ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(19, 178);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 32);
            this.label3.TabIndex = 161;
            this.label3.Text = "Chức vụ:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RegisterEmployeeFrm
            // 
            this.AcceptButton = this.buttonRegister;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(509, 343);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.textboxStatusE);
            this.Controls.Add(this.textBoxCMND);
            this.Controls.Add(this.dateTimePickerBirthday);
            this.Controls.Add(this.radioButtonNu);
            this.Controls.Add(this.radioButtonNam);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxHoTen);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.comboBoxTypeUser);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxConfirmPass);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "RegisterEmployeeFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ĐĂNG KÝ";
            this.Load += new System.EventHandler(this.RegisterEmployeeFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTypeUser;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxConfirmPass;
        private System.Windows.Forms.Button buttonRegister;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.TextBox textBoxID;
       // private DBMS_FinalProjectDataSet dBMS_FinalProjectDataSet;
        private System.Windows.Forms.BindingSource jOBBindingSource;
      //  private DBMS_FinalProjectDataSetTableAdapters.JOBTableAdapter jOBTableAdapter;
        private System.Windows.Forms.TextBox textBoxPhone;
        private System.Windows.Forms.TextBox textBoxHoTen;
        private System.Windows.Forms.RadioButton radioButtonNam;
        private System.Windows.Forms.RadioButton radioButtonNu;
        private System.Windows.Forms.DateTimePicker dateTimePickerBirthday;
        private System.Windows.Forms.TextBox textBoxCMND;
        private System.Windows.Forms.TextBox textboxStatusE;
      //  private DBMS_FinalProjectDataSet1 dBMS_FinalProjectDataSet1;
        private System.Windows.Forms.BindingSource jOBBindingSource1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        // private DBMS_FinalProjectDataSet1TableAdapters.JOBTableAdapter jOBTableAdapter1;
    }
}