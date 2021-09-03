
namespace HomeFinances
{
    partial class FormConstants
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCatalogFiles = new System.Windows.Forms.TextBox();
            this.textBoxExportFolder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxImportFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonExportFolder = new System.Windows.Forms.Button();
            this.buttonImportFolder = new System.Windows.Forms.Button();
            this.directoryControl2 = new HomeFinances.DirectoryControl();
            this.directoryControl1 = new HomeFinances.DirectoryControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Основна каса:";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(397, 628);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(164, 23);
            this.buttonClose.TabIndex = 18;
            this.buttonClose.Text = "Закрити";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(100, 628);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(164, 23);
            this.buttonSave.TabIndex = 17;
            this.buttonSave.Text = "Зберегти";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Основна витрата:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Каталог для файлів:";
            // 
            // textBoxCatalogFiles
            // 
            this.textBoxCatalogFiles.Location = new System.Drawing.Point(142, 223);
            this.textBoxCatalogFiles.Name = "textBoxCatalogFiles";
            this.textBoxCatalogFiles.Size = new System.Drawing.Size(516, 20);
            this.textBoxCatalogFiles.TabIndex = 22;
            // 
            // textBoxExportFolder
            // 
            this.textBoxExportFolder.Location = new System.Drawing.Point(157, 27);
            this.textBoxExportFolder.Name = "textBoxExportFolder";
            this.textBoxExportFolder.Size = new System.Drawing.Size(486, 20);
            this.textBoxExportFolder.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Папка для вигрузки даних:";
            // 
            // textBoxImportFolder
            // 
            this.textBoxImportFolder.Location = new System.Drawing.Point(157, 53);
            this.textBoxImportFolder.Name = "textBoxImportFolder";
            this.textBoxImportFolder.Size = new System.Drawing.Size(486, 20);
            this.textBoxImportFolder.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Папка для загрузки даних:";
            // 
            // buttonExportFolder
            // 
            this.buttonExportFolder.Location = new System.Drawing.Point(649, 25);
            this.buttonExportFolder.Name = "buttonExportFolder";
            this.buttonExportFolder.Size = new System.Drawing.Size(34, 23);
            this.buttonExportFolder.TabIndex = 27;
            this.buttonExportFolder.Text = "...";
            this.buttonExportFolder.UseVisualStyleBackColor = true;
            this.buttonExportFolder.Click += new System.EventHandler(this.buttonExportFolder_Click);
            // 
            // buttonImportFolder
            // 
            this.buttonImportFolder.Location = new System.Drawing.Point(649, 51);
            this.buttonImportFolder.Name = "buttonImportFolder";
            this.buttonImportFolder.Size = new System.Drawing.Size(34, 23);
            this.buttonImportFolder.TabIndex = 28;
            this.buttonImportFolder.Text = "...";
            this.buttonImportFolder.UseVisualStyleBackColor = true;
            this.buttonImportFolder.Click += new System.EventHandler(this.buttonImportFolder_Click);
            // 
            // directoryControl2
            // 
            this.directoryControl2.CallBack = null;
            this.directoryControl2.DirectoryPointerItem = null;
            this.directoryControl2.Location = new System.Drawing.Point(127, 54);
            this.directoryControl2.Name = "directoryControl2";
            this.directoryControl2.Size = new System.Drawing.Size(556, 27);
            this.directoryControl2.TabIndex = 20;
            // 
            // directoryControl1
            // 
            this.directoryControl1.CallBack = null;
            this.directoryControl1.DirectoryPointerItem = null;
            this.directoryControl1.Location = new System.Drawing.Point(127, 21);
            this.directoryControl1.Name = "directoryControl1";
            this.directoryControl1.Size = new System.Drawing.Size(556, 27);
            this.directoryControl1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonImportFolder);
            this.groupBox1.Controls.Add(this.textBoxExportFolder);
            this.groupBox1.Controls.Add(this.buttonExportFolder);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxImportFolder);
            this.groupBox1.Location = new System.Drawing.Point(15, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(696, 90);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Вигрузка та загрузка даних";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.directoryControl2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.directoryControl1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(696, 95);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Значення по замовчуванню для заповнення форм";
            // 
            // FormConstants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 663);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBoxCatalogFiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormConstants";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Константи";
            this.Load += new System.EventHandler(this.FormConstats_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private DirectoryControl directoryControl1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSave;
        private DirectoryControl directoryControl2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCatalogFiles;
        private System.Windows.Forms.TextBox textBoxExportFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxImportFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonExportFolder;
        private System.Windows.Forms.Button buttonImportFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}