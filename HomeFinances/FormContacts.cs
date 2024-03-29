﻿/*
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
    public partial class FormContacts : Form
    {
        public FormContacts()
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

		private void FormContacts_Load(object sender, EventArgs e)
        {
			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns.Add(new DataGridViewImageColumn() { Name = "Image", HeaderText = "", Width = 30, DisplayIndex = 0, Image = HomeFinances.Properties.Resources.doc_text_image });
			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["Назва"].Width = 350;
			dataGridViewRecords.Columns["Телефон"].Width = 250;
			//dataGridViewRecords.Columns["Пошта"].Width = 200;
			//dataGridViewRecords.Columns["Скайп"].Width = 200;
			//dataGridViewRecords.Columns["Сайт"].Width = 200;

			LoadRecords();
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		public void LoadRecords()
		{
			int selectRow = dataGridViewRecords.SelectedRows.Count > 0 ?
				dataGridViewRecords.SelectedRows[dataGridViewRecords.SelectedRows.Count - 1].Index : 0;

			RecordsBindingList.Clear();

			Довідники.Контакти_Select контакти_Select = new Довідники.Контакти_Select();

			контакти_Select.QuerySelect.Field.Add(Довідники.Контакти_Const.Назва);
			контакти_Select.QuerySelect.Field.Add(Довідники.Контакти_Const.Телефон);
			контакти_Select.QuerySelect.Field.Add(Довідники.Контакти_Const.Пошта);
			контакти_Select.QuerySelect.Field.Add(Довідники.Контакти_Const.Скайп);
			контакти_Select.QuerySelect.Field.Add(Довідники.Контакти_Const.Сайт);

			контакти_Select.QuerySelect.Order.Add(Довідники.Контакти_Const.Назва, SelectOrder.ASC);

			контакти_Select.Select();

			while (контакти_Select.MoveNext())
			{
				Довідники.Контакти_Pointer cur = контакти_Select.Current;

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					cur.Fields[Довідники.Контакти_Const.Назва].ToString(),
					cur.Fields[Довідники.Контакти_Const.Телефон].ToString()/*,
					cur.Fields[Довідники.Контакти_Select.Пошта].ToString(),
					cur.Fields[Довідники.Контакти_Select.Скайп].ToString(),
					cur.Fields[Довідники.Контакти_Select.Сайт].ToString()*/
					));

                if (DirectoryPointerItem != null && selectRow == 0) //??
                    if (cur.UnigueID.ToString() == DirectoryPointerItem.UnigueID.ToString())
                    {
                        dataGridViewRecords.Rows[0].Selected = false;
                        dataGridViewRecords.Rows[RecordsBindingList.Count - 1].Selected = true;
                    }
            }

			if (selectRow != 0 && selectRow < dataGridViewRecords.Rows.Count)
			{
				dataGridViewRecords.Rows[0].Selected = false;
				dataGridViewRecords.Rows[selectRow].Selected = true;
			}
		}

		private class Записи
		{
			public Записи(string _id, string _Назва, string _Телефон/*, string _Пошта, string _Скайп, string _Сайт*/)
			{
				ID = _id;
				Назва = _Назва;
				Телефон = _Телефон;
				/*Пошта = _Пошта;
				Скайп = _Скайп;
				Сайт = _Сайт;*/
			}
			public string ID { get; set; }
			public string Назва { get; set; }
			public string Телефон { get; set; }
			//public string Пошта { get; set; }
			//public string Скайп { get; set; }
			//public string Сайт { get; set; }
		}

        private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.RowIndex >= 0 && e.RowIndex < dataGridViewRecords.RowCount)
			{
				string Uid = dataGridViewRecords.Rows[e.RowIndex].Cells["ID"].Value.ToString();

				if (DirectoryControlItem != null)
				{
					DirectoryControlItem.DirectoryPointerItem = new Довідники.Контакти_Pointer(new UnigueID(Uid));
					this.Close();
				}
				else
				{
					toolStripButtonEdit_Click(this, null);
				}
			}
		}

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
			FormAddContacts formAddContacts = new FormAddContacts();
			formAddContacts.IsNew = true;
			formAddContacts.OwnerForm = this;
			formAddContacts.ShowDialog();
		}

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				FormAddContacts formAddContacts = new FormAddContacts();
				formAddContacts.OwnerForm = this;
				formAddContacts.IsNew = false;
				formAddContacts.Uid = dataGridViewRecords.Rows[RowIndex].Cells[0].Value.ToString();
				formAddContacts.ShowDialog();
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

					Довідники.Контакти_Objest контакти_Objest = new Довідники.Контакти_Objest();
					if (контакти_Objest.Read(new UnigueID(uid)))
					{
						Довідники.Контакти_Objest контакти_Objest_Новий = контакти_Objest.Copy();
						контакти_Objest_Новий.Назва = "(Копія) - " + контакти_Objest.Назва;
						контакти_Objest_Новий.Save();
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
				MessageBox.Show("Видалити записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Контакти_Objest контакти_Objest_Новий = new Довідники.Контакти_Objest();
					if (контакти_Objest_Новий.Read(new UnigueID(uid)))
					{
						контакти_Objest_Новий.Delete();
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
    }
}
