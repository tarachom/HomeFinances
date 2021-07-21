﻿
namespace HomeFinances
{
	partial class FormAddRecord
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxOpys = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerRecord = new System.Windows.Forms.DateTimePicker();
            this.maskedTextBoxSuma = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTypeRecord = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.maskedTextBoxTime = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxUrlLink = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonOpenBrouser = new System.Windows.Forms.Button();
            this.directoryControl1 = new HomeFinances.DirectoryControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(60, 35);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(667, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxOpys
            // 
            this.textBoxOpys.Location = new System.Drawing.Point(60, 61);
            this.textBoxOpys.Multiline = true;
            this.textBoxOpys.Name = "textBoxOpys";
            this.textBoxOpys.Size = new System.Drawing.Size(667, 162);
            this.textBoxOpys.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Опис:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата:";
            // 
            // dateTimePickerRecord
            // 
            this.dateTimePickerRecord.Location = new System.Drawing.Point(60, 9);
            this.dateTimePickerRecord.Name = "dateTimePickerRecord";
            this.dateTimePickerRecord.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerRecord.TabIndex = 6;
            this.dateTimePickerRecord.Value = new System.DateTime(2021, 3, 5, 13, 45, 55, 0);
            // 
            // maskedTextBoxSuma
            // 
            this.maskedTextBoxSuma.Location = new System.Drawing.Point(60, 256);
            this.maskedTextBoxSuma.Mask = "00000";
            this.maskedTextBoxSuma.Name = "maskedTextBoxSuma";
            this.maskedTextBoxSuma.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxSuma.TabIndex = 9;
            this.maskedTextBoxSuma.ValidatingType = typeof(int);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Сума:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Тип:";
            // 
            // comboBoxTypeRecord
            // 
            this.comboBoxTypeRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeRecord.FormattingEnabled = true;
            this.comboBoxTypeRecord.Location = new System.Drawing.Point(60, 229);
            this.comboBoxTypeRecord.Name = "comboBoxTypeRecord";
            this.comboBoxTypeRecord.Size = new System.Drawing.Size(164, 21);
            this.comboBoxTypeRecord.TabIndex = 12;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(60, 359);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(164, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(563, 359);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(164, 23);
            this.buttonClose.TabIndex = 14;
            this.buttonClose.Text = "Закрити";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // maskedTextBoxTime
            // 
            this.maskedTextBoxTime.Location = new System.Drawing.Point(302, 9);
            this.maskedTextBoxTime.Mask = "00:00:00";
            this.maskedTextBoxTime.Name = "maskedTextBoxTime";
            this.maskedTextBoxTime.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxTime.TabIndex = 16;
            this.maskedTextBoxTime.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Стаття витрат:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Час:";
            // 
            // textBoxUrlLink
            // 
            this.textBoxUrlLink.Location = new System.Drawing.Point(99, 315);
            this.textBoxUrlLink.Name = "textBoxUrlLink";
            this.textBoxUrlLink.Size = new System.Drawing.Size(589, 20);
            this.textBoxUrlLink.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Ссилка на сайт:";
            // 
            // buttonOpenBrouser
            // 
            this.buttonOpenBrouser.Location = new System.Drawing.Point(694, 313);
            this.buttonOpenBrouser.Name = "buttonOpenBrouser";
            this.buttonOpenBrouser.Size = new System.Drawing.Size(33, 23);
            this.buttonOpenBrouser.TabIndex = 21;
            this.buttonOpenBrouser.Text = "...";
            this.buttonOpenBrouser.UseVisualStyleBackColor = true;
            this.buttonOpenBrouser.Click += new System.EventHandler(this.buttonOpenBrouser_Click);
            // 
            // directoryControl1
            // 
            this.directoryControl1.DirectoryPointerItem = null;
            this.directoryControl1.Location = new System.Drawing.Point(99, 282);
            this.directoryControl1.Name = "directoryControl1";
            this.directoryControl1.Size = new System.Drawing.Size(453, 27);
            this.directoryControl1.TabIndex = 15;
            // 
            // FormAddRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 396);
            this.Controls.Add(this.buttonOpenBrouser);
            this.Controls.Add(this.textBoxUrlLink);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextBoxTime);
            this.Controls.Add(this.directoryControl1);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxTypeRecord);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBoxSuma);
            this.Controls.Add(this.dateTimePickerRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxOpys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAddRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новий запис";
            this.Load += new System.EventHandler(this.FormAddRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxName;
		private System.Windows.Forms.TextBox textBoxOpys;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateTimePickerRecord;
		private System.Windows.Forms.MaskedTextBox maskedTextBoxSuma;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxTypeRecord;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonClose;
		private DirectoryControl directoryControl1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxUrlLink;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonOpenBrouser;
    }
}