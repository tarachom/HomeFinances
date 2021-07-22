using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AccountingSoftware;
using Конфа = НоваКонфігурація_1_0;
using Константи = НоваКонфігурація_1_0.Константи;
using Довідники = НоваКонфігурація_1_0.Довідники;
using Перелічення = НоваКонфігурація_1_0.Перелічення;

namespace HomeFinances
{
    public partial class FormAddNotebookFolder : Form
    {
        public FormAddNotebookFolder()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Форма списку
		/// </summary>
        public FormNotebook OwnerForm { get; set; }
        
		/// <summary>
		/// Чи це новий
		/// </summary>
        public Nullable<bool> IsNew { get; set; }

		/// <summary>
		/// Ід запису
		/// </summary>
        public string Uid { get; set; }

		/// <summary>
		/// Обєкт запису
		/// </summary>
        private Довідники.Записник_Папки_Objest записник_Папки_Objest { get; set; }

		/// <summary>
		/// Зворотня функція для вибору із списку
		/// </summary>
		/// <param name="directoryPointerItem"></param>
		public void CallBack_DirectoryControl_Open_FormNotebook(DirectoryPointer directoryPointerItem)
        {
			FormNotebook formNotebook = new FormNotebook();
			formNotebook.DirectoryPointerItem = directoryPointerItem;
			formNotebook.DirectoryControlItem = directoryControl1;
			formNotebook.ShowDialog();
		}

		private void FormAddNotebookFolder_Load(object sender, EventArgs e)
        {
			directoryControl1.CallBack = CallBack_DirectoryControl_Open_FormNotebook;

			if (IsNew.HasValue)
			{
				записник_Папки_Objest = new Довідники.Записник_Папки_Objest();

				if (IsNew.Value)
				{
					this.Text += " - Новий запис";

					directoryControl1.DirectoryPointerItem = new Довідники.Записник_Папки_Pointer();
				}
				else
				{
					if (записник_Папки_Objest.Read(new UnigueID(Uid)))
					{
						this.Text += " - Редагування запису - " + записник_Папки_Objest.Назва;

						textBoxName.Text = записник_Папки_Objest.Назва;
						directoryControl1.DirectoryPointerItem = new Довідники.Записник_Папки_Pointer(записник_Папки_Objest.Родич.UnigueID);
					}
					else
						MessageBox.Show("Error read");
				}
			}
		}

        private void buttonSave_Click(object sender, EventArgs e)
        {
			if (IsNew.HasValue)
			{
				if (IsNew.Value)
					записник_Папки_Objest.New();

				try
				{
					записник_Папки_Objest.Назва = textBoxName.Text;
					записник_Папки_Objest.Родич = directoryControl1.DirectoryPointerItem != null ? (Довідники.Записник_Папки_Pointer)directoryControl1.DirectoryPointerItem : new Довідники.Записник_Папки_Pointer();
					записник_Папки_Objest.Save();
				}
				catch (Exception exp)
				{
					MessageBox.Show(exp.Message);
					return;
				}

				if (OwnerForm != null)
					OwnerForm.LoadRecords();

				this.Close();
			}
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
