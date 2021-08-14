
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
            this.directoryControl2 = new HomeFinances.DirectoryControl();
            this.directoryControl1 = new HomeFinances.DirectoryControl();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxCatalogFiles = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Основна каса:";
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(410, 246);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(164, 23);
            this.buttonClose.TabIndex = 18;
            this.buttonClose.Text = "Закрити";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(113, 246);
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
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Основна витрата:";
            // 
            // directoryControl2
            // 
            this.directoryControl2.CallBack = null;
            this.directoryControl2.DirectoryPointerItem = null;
            this.directoryControl2.Location = new System.Drawing.Point(127, 45);
            this.directoryControl2.Name = "directoryControl2";
            this.directoryControl2.Size = new System.Drawing.Size(584, 27);
            this.directoryControl2.TabIndex = 20;
            // 
            // directoryControl1
            // 
            this.directoryControl1.CallBack = null;
            this.directoryControl1.DirectoryPointerItem = null;
            this.directoryControl1.Location = new System.Drawing.Point(127, 12);
            this.directoryControl1.Name = "directoryControl1";
            this.directoryControl1.Size = new System.Drawing.Size(584, 27);
            this.directoryControl1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Каталог для файлів:";
            this.label3.Visible = false;
            // 
            // textBoxCatalogFiles
            // 
            this.textBoxCatalogFiles.Location = new System.Drawing.Point(127, 82);
            this.textBoxCatalogFiles.Name = "textBoxCatalogFiles";
            this.textBoxCatalogFiles.Size = new System.Drawing.Size(584, 20);
            this.textBoxCatalogFiles.TabIndex = 22;
            this.textBoxCatalogFiles.Visible = false;
            // 
            // FormConstants
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 281);
            this.Controls.Add(this.textBoxCatalogFiles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.directoryControl2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.directoryControl1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormConstants";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Константи";
            this.Load += new System.EventHandler(this.FormConstats_Load);
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
    }
}