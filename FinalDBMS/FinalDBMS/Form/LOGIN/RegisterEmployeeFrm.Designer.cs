﻿
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
            this.comboBoxTypeUser = new System.Windows.Forms.ComboBox();
            this.jOBBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.jOBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxTypeUser
            // 
            this.comboBoxTypeUser.DataSource = this.jOBBindingSource1;
            this.comboBoxTypeUser.DisplayMember = "JobDetail";
            this.comboBoxTypeUser.FormattingEnabled = true;
            this.comboBoxTypeUser.Location = new System.Drawing.Point(41, 177);
            this.comboBoxTypeUser.Name = "comboBoxTypeUser";
            this.comboBoxTypeUser.Size = new System.Drawing.Size(121, 28);
            this.comboBoxTypeUser.TabIndex = 2;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(227, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 29);
            this.label1.TabIndex = 13;
            this.label1.Text = "Đăng Ký";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxEmail.Location = new System.Drawing.Point(41, 220);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(216, 28);
            this.textBoxEmail.TabIndex = 3;
            this.textBoxEmail.Text = "Email";
            // 
            // textBoxConfirmPass
            // 
            this.textBoxConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxConfirmPass.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxConfirmPass.Location = new System.Drawing.Point(41, 307);
            this.textBoxConfirmPass.Name = "textBoxConfirmPass";
            this.textBoxConfirmPass.Size = new System.Drawing.Size(216, 28);
            this.textBoxConfirmPass.TabIndex = 5;
            this.textBoxConfirmPass.Text = "Password";
            this.textBoxConfirmPass.UseSystemPasswordChar = true;
            // 
            // buttonRegister
            // 
            this.buttonRegister.BackColor = System.Drawing.Color.DarkTurquoise;
            this.buttonRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRegister.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.buttonRegister.Location = new System.Drawing.Point(172, 368);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(216, 39);
            this.buttonRegister.TabIndex = 13;
            this.buttonRegister.Text = "Đăng ký";
            this.buttonRegister.UseVisualStyleBackColor = false;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPassword.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxPassword.Location = new System.Drawing.Point(41, 264);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(216, 28);
            this.textBoxPassword.TabIndex = 4;
            this.textBoxPassword.Text = "Password";
            this.textBoxPassword.UseSystemPasswordChar = true;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxUsername.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxUsername.Location = new System.Drawing.Point(41, 82);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(216, 28);
            this.textBoxUsername.TabIndex = 0;
            this.textBoxUsername.Text = "Tên tài khoản";
            // 
            // textBoxID
            // 
            this.textBoxID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxID.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxID.Location = new System.Drawing.Point(41, 128);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(216, 28);
            this.textBoxID.TabIndex = 1;
            this.textBoxID.Text = "ID";
            // 
            // textBoxPhone
            // 
            this.textBoxPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPhone.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxPhone.Location = new System.Drawing.Point(302, 220);
            this.textBoxPhone.Name = "textBoxPhone";
            this.textBoxPhone.Size = new System.Drawing.Size(216, 28);
            this.textBoxPhone.TabIndex = 10;
            this.textBoxPhone.Text = "Điện thoại";
            // 
            // textBoxHoTen
            // 
            this.textBoxHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHoTen.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxHoTen.Location = new System.Drawing.Point(302, 82);
            this.textBoxHoTen.Name = "textBoxHoTen";
            this.textBoxHoTen.Size = new System.Drawing.Size(216, 28);
            this.textBoxHoTen.TabIndex = 6;
            this.textBoxHoTen.Text = "Họ Tên";
            // 
            // radioButtonNam
            // 
            this.radioButtonNam.AutoSize = true;
            this.radioButtonNam.Location = new System.Drawing.Point(311, 131);
            this.radioButtonNam.Name = "radioButtonNam";
            this.radioButtonNam.Size = new System.Drawing.Size(67, 24);
            this.radioButtonNam.TabIndex = 7;
            this.radioButtonNam.TabStop = true;
            this.radioButtonNam.Text = "Nam";
            this.radioButtonNam.UseVisualStyleBackColor = true;
            // 
            // radioButtonNu
            // 
            this.radioButtonNu.AutoSize = true;
            this.radioButtonNu.Location = new System.Drawing.Point(384, 132);
            this.radioButtonNu.Name = "radioButtonNu";
            this.radioButtonNu.Size = new System.Drawing.Size(54, 24);
            this.radioButtonNu.TabIndex = 8;
            this.radioButtonNu.TabStop = true;
            this.radioButtonNu.Text = "Nữ";
            this.radioButtonNu.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerBirthday
            // 
            this.dateTimePickerBirthday.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerBirthday.Location = new System.Drawing.Point(302, 177);
            this.dateTimePickerBirthday.Name = "dateTimePickerBirthday";
            this.dateTimePickerBirthday.Size = new System.Drawing.Size(153, 26);
            this.dateTimePickerBirthday.TabIndex = 9;
            // 
            // textBoxCMND
            // 
            this.textBoxCMND.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCMND.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textBoxCMND.Location = new System.Drawing.Point(302, 264);
            this.textBoxCMND.Name = "textBoxCMND";
            this.textBoxCMND.Size = new System.Drawing.Size(216, 28);
            this.textBoxCMND.TabIndex = 11;
            this.textBoxCMND.Text = "CMND";
            // 
            // textboxStatusE
            // 
            this.textboxStatusE.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textboxStatusE.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.textboxStatusE.Location = new System.Drawing.Point(302, 307);
            this.textboxStatusE.Name = "textboxStatusE";
            this.textboxStatusE.Size = new System.Drawing.Size(216, 28);
            this.textboxStatusE.TabIndex = 12;
            this.textboxStatusE.Text = "Tình Trạng";
            // 
            // RegisterEmployeeFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 430);
            this.Controls.Add(this.textboxStatusE);
            this.Controls.Add(this.textBoxCMND);
            this.Controls.Add(this.dateTimePickerBirthday);
            this.Controls.Add(this.radioButtonNu);
            this.Controls.Add(this.radioButtonNam);
            this.Controls.Add(this.textBoxPhone);
            this.Controls.Add(this.textBoxHoTen);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.comboBoxTypeUser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxConfirmPass);
            this.Controls.Add(this.buttonRegister);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxUsername);
            this.Name = "RegisterEmployeeFrm";
            this.Text = "ĐĂNG KÝ";
            this.Load += new System.EventHandler(this.RegisterEmployeeFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jOBBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTypeUser;
        private System.Windows.Forms.Label label1;
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
       // private DBMS_FinalProjectDataSet1TableAdapters.JOBTableAdapter jOBTableAdapter1;
    }
}