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
    public partial class FormCash : Form
    {
        public FormCash()
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

        private void FormCash_Load(object sender, EventArgs e)
        {
			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns.Add(new DataGridViewImageColumn() { Name = "Image", HeaderText = "", Width = 30, DisplayIndex = 0, Image = HomeFinances.Properties.Resources.doc_text_image });
			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["Назва"].Width = 300;

			LoadRecords();
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		public void LoadRecords()
		{
			int selectRow = dataGridViewRecords.SelectedRows.Count > 0 ?
				dataGridViewRecords.SelectedRows[dataGridViewRecords.SelectedRows.Count - 1].Index : 0;

			RecordsBindingList.Clear();

			Довідники.Каса_Select каса_Select = new Довідники.Каса_Select();
			каса_Select.QuerySelect.Field.Add(Довідники.Каса_Const.Назва);
			каса_Select.QuerySelect.Field.Add(Довідники.Каса_Const.Валюта);
			каса_Select.QuerySelect.Field.Add(Довідники.Каса_Const.ТипВалюти);

			//JOIN
			каса_Select.QuerySelect.FieldAndAlias.Add(
				new NameValue<string>(Довідники.Валюта_Const.TABLE + "." + Довідники.Валюта_Const.Назва, "field2"));
			каса_Select.QuerySelect.Joins.Add(
				new Join(Довідники.Валюта_Const.TABLE, Довідники.Каса_Const.Валюта, Довідники.Каса_Const.TABLE));

			//ORDER
			каса_Select.QuerySelect.Order.Add(Довідники.Каса_Const.Назва, SelectOrder.ASC);

			каса_Select.Select();

			while (каса_Select.MoveNext())
			{
				Довідники.Каса_Pointer cur = каса_Select.Current;

				string ТипВалютиПредставлення = ((Перелічення.ТипВалюти)cur.Fields[Довідники.Каса_Const.ТипВалюти]).ToString();

				RecordsBindingList.Add(new Записи(){
					ID = cur.UnigueID.ToString(),
					Назва = cur.Fields[Довідники.Каса_Const.Назва].ToString(),
					Валюта = cur.Fields["field2"].ToString(),
					ТипВалюти = ТипВалютиПредставлення
				});

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
			public string ID { get; set; }
			public string Назва { get; set; }
			public string Валюта { get; set; }
			public string ТипВалюти { get; set; }
		}

        private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.RowIndex >= 0 && e.RowIndex < dataGridViewRecords.RowCount)
			{
				string Uid = dataGridViewRecords.Rows[e.RowIndex].Cells["ID"].Value.ToString();

				if (DirectoryControlItem != null)
				{
					DirectoryControlItem.DirectoryPointerItem = new Довідники.Каса_Pointer(new UnigueID(Uid));
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
			FormAddCash formAddCash = new FormAddCash();
			formAddCash.IsNew = true;
			formAddCash.OwnerForm = this;
			formAddCash.ShowDialog();
		}

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				FormAddCash formAddCash = new FormAddCash();
				formAddCash.OwnerForm = this;
				formAddCash.IsNew = false;
				formAddCash.Uid = dataGridViewRecords.Rows[RowIndex].Cells[0].Value.ToString();
				formAddCash.ShowDialog();
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

					Довідники.Каса_Objest каса_Objest = new Довідники.Каса_Objest();
					if (каса_Objest.Read(new UnigueID(uid)))
					{
						Довідники.Каса_Objest каса_Objest_Новий = каса_Objest.Copy();
						каса_Objest_Новий.Назва = "(Копія) - " + каса_Objest.Назва;
						каса_Objest_Новий.Save();
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

					Довідники.Каса_Objest каса_Objest = new Довідники.Каса_Objest();
					if (каса_Objest.Read(new UnigueID(uid)))
					{
						каса_Objest.Delete();
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
