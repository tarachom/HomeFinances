
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
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxTypeRecord = new System.Windows.Forms.ComboBox();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.maskedTextBoxTime = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonOpenBrouser = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxUrlLink = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.buttonSaveAndSpend = new System.Windows.Forms.Button();
            this.labelStateSpend = new System.Windows.Forms.Label();
            this.label_TypeRecord_Desc = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.labelOstatokCasa = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.калькуляторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonRefreshOstatokCasa = new System.Windows.Forms.Button();
            this.Suma = new HomeFinances.NumericControl();
            this.CursObmin = new HomeFinances.NumericControl();
            this.SumaObmin = new HomeFinances.NumericControl();
            this.directoryControl3 = new HomeFinances.DirectoryControl();
            this.directoryControl2 = new HomeFinances.DirectoryControl();
            this.directoryControl1 = new HomeFinances.DirectoryControl();
            this.buttonSpend = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(60, 65);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(915, 20);
            this.textBoxName.TabIndex = 1;
            // 
            // textBoxOpys
            // 
            this.textBoxOpys.Location = new System.Drawing.Point(60, 91);
            this.textBoxOpys.Multiline = true;
            this.textBoxOpys.Name = "textBoxOpys";
            this.textBoxOpys.Size = new System.Drawing.Size(915, 112);
            this.textBoxOpys.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Опис:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата:";
            // 
            // dateTimePickerRecord
            // 
            this.dateTimePickerRecord.Location = new System.Drawing.Point(60, 39);
            this.dateTimePickerRecord.Name = "dateTimePickerRecord";
            this.dateTimePickerRecord.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerRecord.TabIndex = 6;
            this.dateTimePickerRecord.Value = new System.DateTime(2021, 3, 5, 13, 45, 55, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 239);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Сума:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Тип:";
            // 
            // comboBoxTypeRecord
            // 
            this.comboBoxTypeRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeRecord.FormattingEnabled = true;
            this.comboBoxTypeRecord.Location = new System.Drawing.Point(60, 209);
            this.comboBoxTypeRecord.Name = "comboBoxTypeRecord";
            this.comboBoxTypeRecord.Size = new System.Drawing.Size(164, 21);
            this.comboBoxTypeRecord.TabIndex = 12;
            this.comboBoxTypeRecord.SelectedIndexChanged += new System.EventHandler(this.comboBoxTypeRecord_SelectedIndexChanged);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(182, 405);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(153, 23);
            this.buttonSave.TabIndex = 13;
            this.buttonSave.Text = "Зберегти без проведення";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(545, 405);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(164, 23);
            this.buttonClose.TabIndex = 14;
            this.buttonClose.Text = "Закрити";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // maskedTextBoxTime
            // 
            this.maskedTextBoxTime.Location = new System.Drawing.Point(302, 39);
            this.maskedTextBoxTime.Mask = "00:00:00";
            this.maskedTextBoxTime.Name = "maskedTextBoxTime";
            this.maskedTextBoxTime.Size = new System.Drawing.Size(100, 20);
            this.maskedTextBoxTime.TabIndex = 16;
            this.maskedTextBoxTime.ValidatingType = typeof(System.DateTime);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 331);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Стаття:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Час:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 360);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Сайт:";
            // 
            // buttonOpenBrouser
            // 
            this.buttonOpenBrouser.Location = new System.Drawing.Point(943, 355);
            this.buttonOpenBrouser.Name = "buttonOpenBrouser";
            this.buttonOpenBrouser.Size = new System.Drawing.Size(32, 23);
            this.buttonOpenBrouser.TabIndex = 21;
            this.buttonOpenBrouser.Text = "...";
            this.buttonOpenBrouser.UseVisualStyleBackColor = true;
            this.buttonOpenBrouser.Click += new System.EventHandler(this.buttonOpenBrouser_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 269);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Каса:";
            // 
            // textBoxUrlLink
            // 
            this.textBoxUrlLink.Location = new System.Drawing.Point(60, 357);
            this.textBoxUrlLink.Name = "textBoxUrlLink";
            this.textBoxUrlLink.Size = new System.Drawing.Size(877, 20);
            this.textBoxUrlLink.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(482, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "--> Каса переміщення:";
            // 
            // buttonSaveAndSpend
            // 
            this.buttonSaveAndSpend.Location = new System.Drawing.Point(12, 405);
            this.buttonSaveAndSpend.Name = "buttonSaveAndSpend";
            this.buttonSaveAndSpend.Size = new System.Drawing.Size(164, 23);
            this.buttonSaveAndSpend.TabIndex = 26;
            this.buttonSaveAndSpend.Text = "Зберегти та провести";
            this.buttonSaveAndSpend.UseVisualStyleBackColor = true;
            this.buttonSaveAndSpend.Click += new System.EventHandler(this.buttonSaveAndSpend_Click);
            // 
            // labelStateSpend
            // 
            this.labelStateSpend.AutoSize = true;
            this.labelStateSpend.Location = new System.Drawing.Point(408, 45);
            this.labelStateSpend.Name = "labelStateSpend";
            this.labelStateSpend.Size = new System.Drawing.Size(79, 13);
            this.labelStateSpend.TabIndex = 27;
            this.labelStateSpend.Text = "<проведений>";
            // 
            // label_TypeRecord_Desc
            // 
            this.label_TypeRecord_Desc.AutoSize = true;
            this.label_TypeRecord_Desc.Location = new System.Drawing.Point(230, 212);
            this.label_TypeRecord_Desc.Name = "label_TypeRecord_Desc";
            this.label_TypeRecord_Desc.Size = new System.Drawing.Size(43, 13);
            this.label_TypeRecord_Desc.TabIndex = 28;
            this.label_TypeRecord_Desc.Text = "... опис";
            this.label_TypeRecord_Desc.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(759, 301);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "Сума:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(565, 301);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 13);
            this.label12.TabIndex = 32;
            this.label12.Text = "Курс:";
            // 
            // labelOstatokCasa
            // 
            this.labelOstatokCasa.AutoSize = true;
            this.labelOstatokCasa.Location = new System.Drawing.Point(266, 239);
            this.labelOstatokCasa.Name = "labelOstatokCasa";
            this.labelOstatokCasa.Size = new System.Drawing.Size(95, 13);
            this.labelOstatokCasa.TabIndex = 36;
            this.labelOstatokCasa.Text = "... залишок в касі";
            this.labelOstatokCasa.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.калькуляторToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(989, 24);
            this.menuStrip1.TabIndex = 37;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // калькуляторToolStripMenuItem
            // 
            this.калькуляторToolStripMenuItem.Image = global::HomeFinances.Properties.Resources.calculator;
            this.калькуляторToolStripMenuItem.Name = "калькуляторToolStripMenuItem";
            this.калькуляторToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.калькуляторToolStripMenuItem.Text = "Калькулятор";
            this.калькуляторToolStripMenuItem.Click += new System.EventHandler(this.калькуляторToolStripMenuItem_Click);
            // 
            // buttonRefreshOstatokCasa
            // 
            this.buttonRefreshOstatokCasa.Image = global::HomeFinances.Properties.Resources.refresh;
            this.buttonRefreshOstatokCasa.Location = new System.Drawing.Point(227, 234);
            this.buttonRefreshOstatokCasa.Name = "buttonRefreshOstatokCasa";
            this.buttonRefreshOstatokCasa.Size = new System.Drawing.Size(33, 23);
            this.buttonRefreshOstatokCasa.TabIndex = 38;
            this.buttonRefreshOstatokCasa.UseVisualStyleBackColor = true;
            this.buttonRefreshOstatokCasa.Click += new System.EventHandler(this.buttonRefreshOstatokCasa_Click);
            // 
            // Suma
            // 
            this.Suma.Location = new System.Drawing.Point(60, 236);
            this.Suma.Name = "Suma";
            this.Suma.Size = new System.Drawing.Size(187, 20);
            this.Suma.TabIndex = 35;
            this.Suma.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // CursObmin
            // 
            this.CursObmin.Location = new System.Drawing.Point(605, 298);
            this.CursObmin.Name = "CursObmin";
            this.CursObmin.Size = new System.Drawing.Size(147, 20);
            this.CursObmin.TabIndex = 34;
            this.CursObmin.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // SumaObmin
            // 
            this.SumaObmin.Location = new System.Drawing.Point(797, 298);
            this.SumaObmin.Name = "SumaObmin";
            this.SumaObmin.Size = new System.Drawing.Size(178, 20);
            this.SumaObmin.TabIndex = 33;
            this.SumaObmin.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // directoryControl3
            // 
            this.directoryControl3.CallBack = null;
            this.directoryControl3.DirectoryPointerItem = null;
            this.directoryControl3.Location = new System.Drawing.Point(605, 262);
            this.directoryControl3.Name = "directoryControl3";
            this.directoryControl3.Size = new System.Drawing.Size(370, 27);
            this.directoryControl3.TabIndex = 24;
            // 
            // directoryControl2
            // 
            this.directoryControl2.CallBack = null;
            this.directoryControl2.DirectoryPointerItem = null;
            this.directoryControl2.Location = new System.Drawing.Point(60, 262);
            this.directoryControl2.Name = "directoryControl2";
            this.directoryControl2.Size = new System.Drawing.Size(416, 27);
            this.directoryControl2.TabIndex = 22;
            // 
            // directoryControl1
            // 
            this.directoryControl1.CallBack = null;
            this.directoryControl1.DirectoryPointerItem = null;
            this.directoryControl1.Location = new System.Drawing.Point(60, 324);
            this.directoryControl1.Name = "directoryControl1";
            this.directoryControl1.Size = new System.Drawing.Size(416, 27);
            this.directoryControl1.TabIndex = 15;
            // 
            // buttonSpend
            // 
            this.buttonSpend.Location = new System.Drawing.Point(341, 405);
            this.buttonSpend.Name = "buttonSpend";
            this.buttonSpend.Size = new System.Drawing.Size(78, 23);
            this.buttonSpend.TabIndex = 39;
            this.buttonSpend.Text = "Провести";
            this.buttonSpend.UseVisualStyleBackColor = true;
            this.buttonSpend.Click += new System.EventHandler(this.buttonSpend_Click);
            // 
            // FormAddRecord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 446);
            this.Controls.Add(this.buttonSpend);
            this.Controls.Add(this.buttonRefreshOstatokCasa);
            this.Controls.Add(this.labelOstatokCasa);
            this.Controls.Add(this.Suma);
            this.Controls.Add(this.CursObmin);
            this.Controls.Add(this.SumaObmin);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label_TypeRecord_Desc);
            this.Controls.Add(this.labelStateSpend);
            this.Controls.Add(this.buttonSaveAndSpend);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.directoryControl3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.directoryControl2);
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
            this.Controls.Add(this.dateTimePickerRecord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxOpys);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormAddRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Записи";
            this.Load += new System.EventHandler(this.FormAddRecord_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxTypeRecord;
		private System.Windows.Forms.Button buttonSave;
		private System.Windows.Forms.Button buttonClose;
		private DirectoryControl directoryControl1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonOpenBrouser;
        private System.Windows.Forms.Label label9;
        private DirectoryControl directoryControl2;
        private System.Windows.Forms.TextBox textBoxUrlLink;
        private System.Windows.Forms.Label label10;
        private DirectoryControl directoryControl3;
        private System.Windows.Forms.Button buttonSaveAndSpend;
        private System.Windows.Forms.Label labelStateSpend;
        private System.Windows.Forms.Label label_TypeRecord_Desc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private NumericControl SumaObmin;
        private NumericControl CursObmin;
        private NumericControl Suma;
        private System.Windows.Forms.Label labelOstatokCasa;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem калькуляторToolStripMenuItem;
        private System.Windows.Forms.Button buttonRefreshOstatokCasa;
        private System.Windows.Forms.Button buttonSpend;
    }
}