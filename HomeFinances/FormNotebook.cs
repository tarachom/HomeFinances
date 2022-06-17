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
    public partial class FormNotebook : Form
    {
        public FormNotebook()
        {
            InitializeComponent();
        }

		#region DirectoryControl Open Form

		/// <summary>
		/// Ссилка на елемент довідника
		/// </summary>
		public DirectoryPointer DirectoryPointerItem { get; set; }

		/// <summary>
		/// Контрол який викликав вибір
		/// </summary>
		public DirectoryControl DirectoryControlItem { get; set; }

		#endregion

		private Довідники.Записник_Папки_Pointer ParentFolder { get; set; }

		private void FormNotebook_Load(object sender, EventArgs e)
        {
			ParentFolder = new Довідники.Записник_Папки_Pointer();

			if (DirectoryControlItem != null && DirectoryPointerItem != null)
			{
				Довідники.Записник_Папки_Pointer localParentFolder = new Довідники.Записник_Папки_Pointer(DirectoryPointerItem.UnigueID);
				if (!localParentFolder.IsEmpty())
					ParentFolder = localParentFolder.GetDirectoryObject().Родич;
			}	

			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["IsFolder"].Visible = false;
			dataGridViewRecords.Columns["IsParentFolder"].Visible = false;

			DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn();
			dataGridViewRecords.Columns["Назва"].Width = 800;
			dataGridViewRecords.Columns["Дата"].Width = 200;
			dataGridViewImageColumn.Name = "Folder";
			dataGridViewImageColumn.HeaderText = "...";
			dataGridViewImageColumn.DisplayIndex = 1;
			dataGridViewImageColumn.Width = 20;
			dataGridViewRecords.Columns.Add(dataGridViewImageColumn);

			LoadRecords();
		}

		private BindingList<Записи> RecordsBindingList { get; set; }


		public void LoadRecords()
		{
			//int selectRow = dataGridViewRecords.SelectedRows.Count > 0 ?
			//	dataGridViewRecords.SelectedRows[dataGridViewRecords.SelectedRows.Count - 1].Index : 0;

			RecordsBindingList.Clear();

			Довідники.Записник_Папки_Pointer CopyParentFolder = ParentFolder;
			int countIteration = 0;

			while (!CopyParentFolder.IsEmpty())
            {
				RecordsBindingList.Insert(0, new Записи(
					CopyParentFolder.UnigueID.ToString(),
					false,
					true,
					CopyParentFolder.GetPresentation(),
					"" //Дата
					));

				CopyParentFolder = CopyParentFolder.GetDirectoryObject().Родич;
				countIteration++;

				if (countIteration > 10)
					break;
			}

			//Групи
			Довідники.Записник_Папки_Select записник_Папки_Select = new Довідники.Записник_Папки_Select();

			записник_Папки_Select.QuerySelect.Field.Add(Довідники.Записник_Папки_Const.Назва);
			записник_Папки_Select.QuerySelect.Field.Add(Довідники.Записник_Папки_Const.Дата);
			записник_Папки_Select.QuerySelect.Where.Add(new Where(Довідники.Записник_Папки_Const.Родич, Comparison.EQ, ParentFolder.UnigueID.UGuid));

			записник_Папки_Select.QuerySelect.Order.Add(Довідники.Записник_Папки_Const.Дата, SelectOrder.DESC);

			записник_Папки_Select.Select();

			while (записник_Папки_Select.MoveNext())
			{
				Довідники.Записник_Папки_Pointer cur = записник_Папки_Select.Current;

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					true,
					false,
					cur.Fields[Довідники.Записник_Папки_Const.Назва].ToString(),
					cur.Fields[Довідники.Записник_Папки_Const.Дата].ToString()
					));

				if (DirectoryPointerItem != null) //??
					if (cur.UnigueID.ToString() == DirectoryPointerItem.UnigueID.ToString())
					{
						dataGridViewRecords.Rows[0].Selected = false;
						dataGridViewRecords.Rows[RecordsBindingList.Count - 1].Selected = true;
					}
			}

			//Елементи
			Довідники.Записник_Select записник_Select = new Довідники.Записник_Select();

			записник_Select.QuerySelect.Field.Add(Довідники.Записник_Const.Назва);
			записник_Select.QuerySelect.Field.Add(Довідники.Записник_Const.Дата);
			записник_Select.QuerySelect.Where.Add(new Where(Довідники.Записник_Const.Папка, Comparison.EQ, ParentFolder.UnigueID.UGuid));

			записник_Select.QuerySelect.Order.Add(Довідники.Записник_Const.Дата, SelectOrder.DESC);

			записник_Select.Select();

			while (записник_Select.MoveNext())
			{
				Довідники.Записник_Pointer cur = записник_Select.Current;

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					false,
					false,
					cur.Fields[Довідники.Записник_Const.Назва].ToString(),
					cur.Fields[Довідники.Записник_Const.Дата].ToString()
					));

				//if (DirectoryPointerItem != null && selectRow == 0) //??
				//	if (cur.UnigueID.ToString() == DirectoryPointerItem.UnigueID.ToString())
				//	{
				//		dataGridViewRecords.Rows[0].Selected = false;
				//		dataGridViewRecords.Rows[RecordsBindingList.Count - 1].Selected = true;
				//	}
			}

			//if (selectRow != 0 && selectRow < dataGridViewRecords.Rows.Count)
			//{
			//	dataGridViewRecords.Rows[0].Selected = false;
			//	dataGridViewRecords.Rows[selectRow].Selected = true;
			//}
		}

		private class Записи
		{
			public Записи(string _id, bool _IsFolder, bool _IsParentFolder, string _Назва, string _Дата)
			{
				ID = _id;
				Назва = _Назва;
				IsFolder = _IsFolder;
				IsParentFolder = _IsParentFolder;
				Дата = _Дата;
			}
			public string ID { get; set; }
			public bool IsFolder { get; set; }
			public bool IsParentFolder { get; set; }
			public string Назва { get; set; }
			public string Дата { get; set; }
		}

        private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.RowIndex >= 0 && e.RowIndex < dataGridViewRecords.RowCount)
			{
				string Uid = dataGridViewRecords.Rows[e.RowIndex].Cells["ID"].Value.ToString();
				bool isFolder = (bool)dataGridViewRecords.Rows[e.RowIndex].Cells["IsFolder"].Value;
				bool isParentFolder = (bool)dataGridViewRecords.Rows[e.RowIndex].Cells["IsParentFolder"].Value;

				if (DirectoryControlItem != null && dataGridViewRecords.Columns[e.ColumnIndex].Name == "Folder")
				{
					DirectoryControlItem.DirectoryPointerItem = new Довідники.Записник_Папки_Pointer(new UnigueID(Uid));
					this.Close();
				}
				else
				{
					if (isFolder)
					{
						ParentFolder = new Довідники.Записник_Папки_Pointer(new UnigueID(Uid));
						LoadRecords();
					}

					if (isParentFolder)
					{
						Довідники.Записник_Папки_Pointer записник_Папки_Pointer = new Довідники.Записник_Папки_Pointer(new UnigueID(Uid));
						ParentFolder = записник_Папки_Pointer.GetDirectoryObject().Родич;
						LoadRecords();
					}

					if (!isFolder && !isParentFolder)
                    {
						FormAddNotebookElement formAddNotebookElement = new FormAddNotebookElement();
						formAddNotebookElement.OwnerForm = this;
						formAddNotebookElement.IsNew = false;
						formAddNotebookElement.Uid = Uid;
						formAddNotebookElement.ShowDialog();
					}
				}
            }
        }

		private void toolStripButtonAddFolder_Click(object sender, EventArgs e)
		{
			FormAddNotebookFolder formAddNotebookFolder = new FormAddNotebookFolder();
			formAddNotebookFolder.IsNew = true;
			formAddNotebookFolder.OwnerForm = this;
			formAddNotebookFolder.DefaultParentFolderUnigueID = ParentFolder.UnigueID;
			formAddNotebookFolder.ShowDialog();
		}

		private void toolStripButtonAddElement_Click(object sender, EventArgs e)
		{
			FormAddNotebookElement formAddNotebookElement = new FormAddNotebookElement();
			formAddNotebookElement.IsNew = true;
			formAddNotebookElement.OwnerForm = this;
			formAddNotebookElement.DefaultParentFolderUnigueID = ParentFolder.UnigueID;
			formAddNotebookElement.ShowDialog();
		}

		private void toolStripButtonEditFolder_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				if ((bool)dataGridViewRecords.Rows[RowIndex].Cells["IsFolder"].Value == true && 
					(bool)dataGridViewRecords.Rows[RowIndex].Cells["IsParentFolder"].Value == false)
				{
					FormAddNotebookFolder formAddNotebookFolder = new FormAddNotebookFolder();
					formAddNotebookFolder.OwnerForm = this;
					formAddNotebookFolder.IsNew = false;
					formAddNotebookFolder.Uid = dataGridViewRecords.Rows[RowIndex].Cells[0].Value.ToString();
					formAddNotebookFolder.ShowDialog();
				}
            }
		}

		private void toolStripButtonEditElement_Click(object sender, EventArgs e)
		{
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				if ((bool)dataGridViewRecords.Rows[RowIndex].Cells["IsFolder"].Value == false && 
					(bool)dataGridViewRecords.Rows[RowIndex].Cells["IsParentFolder"].Value == false)
				{
					FormAddNotebookElement formAddNotebookElement = new FormAddNotebookElement();
					formAddNotebookElement.OwnerForm = this;
					formAddNotebookElement.IsNew = false;
					formAddNotebookElement.Uid = dataGridViewRecords.Rows[RowIndex].Cells[0].Value.ToString();
					formAddNotebookElement.ShowDialog();
				}
			}
		}

		private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
			LoadRecords();
		}

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count != 0 &&
				MessageBox.Show("Копіювати записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Записник_Папки_Objest записник_Папки_Objest = new Довідники.Записник_Папки_Objest();
					if (записник_Папки_Objest.Read(new UnigueID(uid)))
					{
						Довідники.Записник_Папки_Objest записник_Папки_Objest_Новий = записник_Папки_Objest.Copy();
						записник_Папки_Objest_Новий.Назва = "(Копія) - " + записник_Папки_Objest.Назва;
						записник_Папки_Objest_Новий.Save();
					}
					else
					{
						MessageBox.Show("Error read");
						break;
					}
				}

				LoadRecords();
			}
		}

		private void toolStripButtonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridViewRecords.SelectedRows.Count != 0 &&
				MessageBox.Show("Видалити папки?\nТакожу будуть видалені всі елементи і папки які знаходяться в даній папці!", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];

					string uid = row.Cells[0].Value.ToString();
					bool isFolder = (bool)row.Cells["IsFolder"].Value;
					bool isParentFolder = (bool)row.Cells["IsParentFolder"].Value;

					if (isFolder == true && isParentFolder == false)
					{
						Довідники.Записник_Папки_Objest записник_Папки_Objest = new Довідники.Записник_Папки_Objest();
						if (записник_Папки_Objest.Read(new UnigueID(uid)))
						{
							записник_Папки_Objest.Delete();
						}
						else
						{
							MessageBox.Show("Error read");
							break;
						}
					}
				}

				LoadRecords();
			}
		}

        private void dataGridViewRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
			if (dataGridViewRecords.Columns[e.ColumnIndex].Name == "Folder")
            {
				bool isFolder = (bool)dataGridViewRecords["IsFolder", e.RowIndex].Value;
				bool isParentFolder = (bool)dataGridViewRecords["IsParentFolder", e.RowIndex].Value;

				if (isFolder)
				{
					e.Value = HomeFinances.Properties.Resources.folder2;
					dataGridViewRecords.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightYellow;
				}
				else if (isParentFolder)
				{
					e.Value = HomeFinances.Properties.Resources.folder2;
					//e.CellStyle.BackColor = ;
					dataGridViewRecords.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
				}
                else
                {
					e.Value = Properties.Resources.page_white_text; 
				}
			}
        }

        private void toolStripButtonDeleteElement_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count != 0 &&
				MessageBox.Show("Видалити записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];

					string uid = row.Cells[0].Value.ToString();
					bool isFolder = (bool)row.Cells["IsFolder"].Value;
					bool isParentFolder = (bool)row.Cells["IsParentFolder"].Value;

					if (isFolder == false && isParentFolder == false)
					{
						Довідники.Записник_Objest записник_Objest = new Довідники.Записник_Objest();
						if (записник_Objest.Read(new UnigueID(uid)))
						{
							записник_Objest.Delete();
						}
						else
						{
							MessageBox.Show("Error read");
							break;
						}
					}
				}

				LoadRecords();
			}
		}
    }
}
