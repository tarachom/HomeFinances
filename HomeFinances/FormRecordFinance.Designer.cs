
namespace HomeFinances
{
	partial class FormRecordFinance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRecordFinance));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelCalculateBalance = new System.Windows.Forms.Label();
            this.buttonCalculateBalance = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.directoryControl3 = new HomeFinances.DirectoryControl();
            this.label8 = new System.Windows.Forms.Label();
            this.directoryControl2 = new HomeFinances.DirectoryControl();
            this.label7 = new System.Windows.Forms.Label();
            this.directoryControl1 = new HomeFinances.DirectoryControl();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxTypeRecord = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerStop = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridViewRecords = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStripRecords = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCopy = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSpend = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonClearSpend = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.довідникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.класифікаторВитратToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.контактиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.валютиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.касиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.записникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.константиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.періодичніЗавданняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.калькуляторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).BeginInit();
            this.panel1.SuspendLayout();
            this.toolStripRecords.SuspendLayout();
            this.menuStripTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel4);
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1MinSize = 430;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1079, 579);
            this.splitContainer1.SplitterDistance = 437;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.labelCalculateBalance);
            this.panel4.Controls.Add(this.buttonCalculateBalance);
            this.panel4.Location = new System.Drawing.Point(5, 243);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(429, 333);
            this.panel4.TabIndex = 2;
            // 
            // labelCalculateBalance
            // 
            this.labelCalculateBalance.AutoSize = true;
            this.labelCalculateBalance.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCalculateBalance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelCalculateBalance.Location = new System.Drawing.Point(3, 52);
            this.labelCalculateBalance.Name = "labelCalculateBalance";
            this.labelCalculateBalance.Size = new System.Drawing.Size(200, 18);
            this.labelCalculateBalance.TabIndex = 13;
            this.labelCalculateBalance.Text = "Calculate balance result";
            // 
            // buttonCalculateBalance
            // 
            this.buttonCalculateBalance.Location = new System.Drawing.Point(116, 12);
            this.buttonCalculateBalance.Name = "buttonCalculateBalance";
            this.buttonCalculateBalance.Size = new System.Drawing.Size(215, 23);
            this.buttonCalculateBalance.TabIndex = 12;
            this.buttonCalculateBalance.Text = "Порахувати залишки по касах";
            this.buttonCalculateBalance.UseVisualStyleBackColor = true;
            this.buttonCalculateBalance.Click += new System.EventHandler(this.buttonCalculateBalance_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.directoryControl3);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.directoryControl2);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.directoryControl1);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.comboBoxTypeRecord);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dateTimePickerStart);
            this.panel3.Controls.Add(this.buttonRefresh);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dateTimePickerStop);
            this.panel3.Location = new System.Drawing.Point(3, 39);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(431, 198);
            this.panel3.TabIndex = 7;
            // 
            // directoryControl3
            // 
            this.directoryControl3.CallBack = null;
            this.directoryControl3.DirectoryPointerItem = null;
            this.directoryControl3.Location = new System.Drawing.Point(118, 98);
            this.directoryControl3.Name = "directoryControl3";
            this.directoryControl3.Size = new System.Drawing.Size(296, 27);
            this.directoryControl3.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Каса переміщення:";
            // 
            // directoryControl2
            // 
            this.directoryControl2.CallBack = null;
            this.directoryControl2.DirectoryPointerItem = null;
            this.directoryControl2.Location = new System.Drawing.Point(118, 65);
            this.directoryControl2.Name = "directoryControl2";
            this.directoryControl2.Size = new System.Drawing.Size(296, 27);
            this.directoryControl2.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Каса:";
            // 
            // directoryControl1
            // 
            this.directoryControl1.CallBack = null;
            this.directoryControl1.DirectoryPointerItem = null;
            this.directoryControl1.Location = new System.Drawing.Point(118, 131);
            this.directoryControl1.Name = "directoryControl1";
            this.directoryControl1.Size = new System.Drawing.Size(296, 27);
            this.directoryControl1.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Стаття витрат:";
            // 
            // comboBoxTypeRecord
            // 
            this.comboBoxTypeRecord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeRecord.FormattingEnabled = true;
            this.comboBoxTypeRecord.Location = new System.Drawing.Point(118, 38);
            this.comboBoxTypeRecord.Name = "comboBoxTypeRecord";
            this.comboBoxTypeRecord.Size = new System.Drawing.Size(149, 21);
            this.comboBoxTypeRecord.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Тип:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Період:";
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Location = new System.Drawing.Point(119, 10);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(128, 20);
            this.dateTimePickerStart.TabIndex = 0;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(118, 164);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(215, 23);
            this.buttonRefresh.TabIndex = 5;
            this.buttonRefresh.Text = "Обновити";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "з";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "по";
            // 
            // dateTimePickerStop
            // 
            this.dateTimePickerStop.Location = new System.Drawing.Point(278, 10);
            this.dateTimePickerStop.Name = "dateTimePickerStop";
            this.dateTimePickerStop.Size = new System.Drawing.Size(125, 20);
            this.dateTimePickerStop.TabIndex = 3;
            this.dateTimePickerStop.Value = new System.DateTime(2021, 8, 9, 23, 59, 0, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Відбір";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridViewRecords);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 28);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(638, 551);
            this.panel2.TabIndex = 2;
            // 
            // dataGridViewRecords
            // 
            this.dataGridViewRecords.AllowUserToAddRows = false;
            this.dataGridViewRecords.AllowUserToDeleteRows = false;
            this.dataGridViewRecords.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dataGridViewRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewRecords.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewRecords.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewRecords.Name = "dataGridViewRecords";
            this.dataGridViewRecords.ReadOnly = true;
            this.dataGridViewRecords.RowHeadersVisible = false;
            this.dataGridViewRecords.Size = new System.Drawing.Size(638, 551);
            this.dataGridViewRecords.TabIndex = 0;
            this.dataGridViewRecords.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRecords_CellDoubleClick);
            this.dataGridViewRecords.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dataGridViewRecords_ColumnWidthChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStripRecords);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(638, 28);
            this.panel1.TabIndex = 1;
            // 
            // toolStripRecords
            // 
            this.toolStripRecords.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAdd,
            this.toolStripButtonRefresh,
            this.toolStripButtonCopy,
            this.toolStripButtonSpend,
            this.toolStripButtonClearSpend,
            this.toolStripButtonDelete,
            this.toolStripSeparator1,
            this.toolStripDropDownButton1});
            this.toolStripRecords.Location = new System.Drawing.Point(0, 0);
            this.toolStripRecords.Name = "toolStripRecords";
            this.toolStripRecords.Size = new System.Drawing.Size(638, 25);
            this.toolStripRecords.TabIndex = 0;
            this.toolStripRecords.Text = "toolStrip1";
            // 
            // toolStripButtonAdd
            // 
            this.toolStripButtonAdd.Image = global::HomeFinances.Properties.Resources.page;
            this.toolStripButtonAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAdd.Name = "toolStripButtonAdd";
            this.toolStripButtonAdd.Size = new System.Drawing.Size(66, 22);
            this.toolStripButtonAdd.Text = "Додати";
            this.toolStripButtonAdd.Click += new System.EventHandler(this.toolStripButtonAdd_Click);
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.Image = global::HomeFinances.Properties.Resources.page_refresh;
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(82, 22);
            this.toolStripButtonRefresh.Text = "Обновити";
            this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
            // 
            // toolStripButtonCopy
            // 
            this.toolStripButtonCopy.Image = global::HomeFinances.Properties.Resources.page_copy;
            this.toolStripButtonCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCopy.Name = "toolStripButtonCopy";
            this.toolStripButtonCopy.Size = new System.Drawing.Size(85, 22);
            this.toolStripButtonCopy.Text = "Копіювати";
            this.toolStripButtonCopy.Click += new System.EventHandler(this.toolStripButtonCopy_Click);
            // 
            // toolStripButtonSpend
            // 
            this.toolStripButtonSpend.Image = global::HomeFinances.Properties.Resources.report;
            this.toolStripButtonSpend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSpend.Name = "toolStripButtonSpend";
            this.toolStripButtonSpend.Size = new System.Drawing.Size(80, 22);
            this.toolStripButtonSpend.Text = "Провести";
            this.toolStripButtonSpend.Click += new System.EventHandler(this.toolStripButtonSpend_Click);
            // 
            // toolStripButtonClearSpend
            // 
            this.toolStripButtonClearSpend.Image = global::HomeFinances.Properties.Resources.page;
            this.toolStripButtonClearSpend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonClearSpend.Name = "toolStripButtonClearSpend";
            this.toolStripButtonClearSpend.Size = new System.Drawing.Size(149, 22);
            this.toolStripButtonClearSpend.Text = "Відмінити проведення";
            this.toolStripButtonClearSpend.Click += new System.EventHandler(this.toolStripButtonClearSpend_Click);
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.Image = global::HomeFinances.Properties.Resources.page_white_delete;
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(79, 22);
            this.toolStripButtonDelete.Text = "Видалити";
            this.toolStripButtonDelete.Click += new System.EventHandler(this.toolStripButtonDelete_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.Image = global::HomeFinances.Properties.Resources.layers;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(62, 22);
            this.toolStripDropDownButton1.Text = "Обмін";
            this.toolStripDropDownButton1.Click += new System.EventHandler(this.toolStripDropDownButton1_Click);
            // 
            // menuStripTop
            // 
            this.menuStripTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.довідникиToolStripMenuItem,
            this.калькуляторToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(1079, 24);
            this.menuStripTop.TabIndex = 1;
            this.menuStripTop.Text = "menuStripTop";
            // 
            // довідникиToolStripMenuItem
            // 
            this.довідникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.класифікаторВитратToolStripMenuItem,
            this.контактиToolStripMenuItem,
            this.валютиToolStripMenuItem,
            this.касиToolStripMenuItem,
            this.записникToolStripMenuItem,
            this.константиToolStripMenuItem,
            this.періодичніЗавданняToolStripMenuItem});
            this.довідникиToolStripMenuItem.Image = global::HomeFinances.Properties.Resources.blog;
            this.довідникиToolStripMenuItem.Name = "довідникиToolStripMenuItem";
            this.довідникиToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.довідникиToolStripMenuItem.Text = "Довідники";
            // 
            // класифікаторВитратToolStripMenuItem
            // 
            this.класифікаторВитратToolStripMenuItem.Image = global::HomeFinances.Properties.Resources.report;
            this.класифікаторВитратToolStripMenuItem.Name = "класифікаторВитратToolStripMenuItem";
            this.класифікаторВитратToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.класифікаторВитратToolStripMenuItem.Text = "Статті витрат";
            this.класифікаторВитратToolStripMenuItem.Click += new System.EventHandler(this.класифікаторВитратToolStripMenuItem_Click);
            // 
            // контактиToolStripMenuItem
            // 
            this.контактиToolStripMenuItem.Image = global::HomeFinances.Properties.Resources.user;
            this.контактиToolStripMenuItem.Name = "контактиToolStripMenuItem";
            this.контактиToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.контактиToolStripMenuItem.Text = "Контакти";
            this.контактиToolStripMenuItem.Click += new System.EventHandler(this.контактиToolStripMenuItem_Click);
            // 
            // валютиToolStripMenuItem
            // 
            this.валютиToolStripMenuItem.Image = global::HomeFinances.Properties.Resources.coins;
            this.валютиToolStripMenuItem.Name = "валютиToolStripMenuItem";
            this.валютиToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.валютиToolStripMenuItem.Text = "Валюти";
            this.валютиToolStripMenuItem.Click += new System.EventHandler(this.валютиToolStripMenuItem_Click);
            // 
            // касиToolStripMenuItem
            // 
            this.касиToolStripMenuItem.Image = global::HomeFinances.Properties.Resources.drawer;
            this.касиToolStripMenuItem.Name = "касиToolStripMenuItem";
            this.касиToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.касиToolStripMenuItem.Text = "Каси";
            this.касиToolStripMenuItem.Click += new System.EventHandler(this.касиToolStripMenuItem_Click);
            // 
            // записникToolStripMenuItem
            // 
            this.записникToolStripMenuItem.Image = global::HomeFinances.Properties.Resources.doc_text_image;
            this.записникToolStripMenuItem.Name = "записникToolStripMenuItem";
            this.записникToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.записникToolStripMenuItem.Text = "Записник";
            this.записникToolStripMenuItem.Click += new System.EventHandler(this.записникToolStripMenuItem_Click);
            // 
            // константиToolStripMenuItem
            // 
            this.константиToolStripMenuItem.Image = global::HomeFinances.Properties.Resources.cog;
            this.константиToolStripMenuItem.Name = "константиToolStripMenuItem";
            this.константиToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.константиToolStripMenuItem.Text = "Константи";
            this.константиToolStripMenuItem.Click += new System.EventHandler(this.константиToolStripMenuItem_Click);
            // 
            // періодичніЗавданняToolStripMenuItem
            // 
            this.періодичніЗавданняToolStripMenuItem.Image = global::HomeFinances.Properties.Resources.data;
            this.періодичніЗавданняToolStripMenuItem.Name = "періодичніЗавданняToolStripMenuItem";
            this.періодичніЗавданняToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.періодичніЗавданняToolStripMenuItem.Text = "Періодичні завдання";
            this.періодичніЗавданняToolStripMenuItem.Click += new System.EventHandler(this.періодичніЗавданняToolStripMenuItem_Click);
            // 
            // калькуляторToolStripMenuItem
            // 
            this.калькуляторToolStripMenuItem.Image = global::HomeFinances.Properties.Resources.calculator;
            this.калькуляторToolStripMenuItem.Name = "калькуляторToolStripMenuItem";
            this.калькуляторToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.калькуляторToolStripMenuItem.Text = "Калькулятор";
            this.калькуляторToolStripMenuItem.Click += new System.EventHandler(this.калькуляторToolStripMenuItem_Click);
            // 
            // FormRecordFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 603);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStripTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStripTop;
            this.Name = "FormRecordFinance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Домашні фінанси 1.0";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRecordFinance_FormClosing);
            this.Load += new System.EventHandler(this.FormRecordFinance_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRecords)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStripRecords.ResumeLayout(false);
            this.toolStripRecords.PerformLayout();
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.DataGridView dataGridViewRecords;
		private System.Windows.Forms.MenuStrip menuStripTop;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ToolStrip toolStripRecords;
		private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
		private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
		private System.Windows.Forms.ToolStripButton toolStripButtonAdd;
		private System.Windows.Forms.ToolStripButton toolStripButtonCopy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem довідникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem класифікаторВитратToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem контактиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem валютиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem касиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem записникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem константиToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker dateTimePickerStop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxTypeRecord;
        private System.Windows.Forms.Label label5;
        private DirectoryControl directoryControl1;
        private System.Windows.Forms.Label label6;
        private DirectoryControl directoryControl2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolStripMenuItem періодичніЗавданняToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonCalculateBalance;
        private System.Windows.Forms.Label labelCalculateBalance;
        private System.Windows.Forms.ToolStripButton toolStripButtonSpend;
        private System.Windows.Forms.ToolStripButton toolStripDropDownButton1;
        private DirectoryControl directoryControl3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripButton toolStripButtonClearSpend;
        private System.Windows.Forms.ToolStripMenuItem калькуляторToolStripMenuItem;
    }
}

