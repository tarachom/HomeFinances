/*
Copyright (C) 2019-2020 TARAKHOMYN YURIY IVANOVYCH
All rights reserved.
Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
    http://www.apache.org/licenses/LICENSE-2.0
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

/*
Автор:    Тарахомин Юрій Іванович
Адреса:   Україна, м. Львів
Сайт:     accounting.org.ua
*/

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
using Конфа = HomeFinances_1_0;
using Константи = HomeFinances_1_0.Константи;
using Довідники = HomeFinances_1_0.Довідники;
using Перелічення = HomeFinances_1_0.Перелічення;

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

		public UnigueID DefaultParentFolderUnigueID { get; set; }

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
					directoryControl1.DirectoryPointerItem = new Довідники.Записник_Папки_Pointer(DefaultParentFolderUnigueID);
					dateTimePickerRecord.Value = DateTime.Now;
				}
				else
				{
					if (записник_Папки_Objest.Read(new UnigueID(Uid)))
					{
						this.Text += " - Редагування запису - " + записник_Папки_Objest.Назва;

						textBoxName.Text = записник_Папки_Objest.Назва;
						directoryControl1.DirectoryPointerItem = new Довідники.Записник_Папки_Pointer(записник_Папки_Objest.Родич.UnigueID);
						dateTimePickerRecord.Value = записник_Папки_Objest.Дата == DateTime.MinValue ? DateTime.Now : записник_Папки_Objest.Дата;
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
					записник_Папки_Objest.Дата = dateTimePickerRecord.Value;
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
