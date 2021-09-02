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
    public partial class FormPeriodicTasks : Form
    {
        public FormPeriodicTasks()
        {
            InitializeComponent();
        }

        private void FormPeriodicTasks_Load(object sender, EventArgs e)
        {
			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns.Add(new DataGridViewImageColumn() { Name = "Image", HeaderText = "", Width = 30, DisplayIndex = 0, Image = HomeFinances.Properties.Resources.doc_text_image });
			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["Назва"].Width = 300;

			dataGridViewRecords.Columns["ПеріодВиконання"].Width = 200;
			dataGridViewRecords.Columns["ПеріодВиконання"].HeaderText = "Періодичність виконання";

			LoadRecords();
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		public void LoadRecords()
		{
			int selectRow = dataGridViewRecords.SelectedRows.Count > 0 ?
				dataGridViewRecords.SelectedRows[dataGridViewRecords.SelectedRows.Count - 1].Index : 0;

			RecordsBindingList.Clear();

			Довідники.КалендарПеріодичнихЗавдань_Select календарПеріодичнихЗавдань = new Довідники.КалендарПеріодичнихЗавдань_Select();

			календарПеріодичнихЗавдань.QuerySelect.Field.Add(Довідники.КалендарПеріодичнихЗавдань_Select.Назва);
			календарПеріодичнихЗавдань.QuerySelect.Field.Add(Довідники.КалендарПеріодичнихЗавдань_Select.ПеріодВиконання);
			календарПеріодичнихЗавдань.QuerySelect.Order.Add(Довідники.КалендарПеріодичнихЗавдань_Select.Назва, SelectOrder.ASC);

			//Нормальна вибірка даних
			календарПеріодичнихЗавдань.Select();

			while (календарПеріодичнихЗавдань.MoveNext())
			{
				Довідники.КалендарПеріодичнихЗавдань_Pointer cur = календарПеріодичнихЗавдань.Current;

				string періодВиконання = ((Перелічення.ПеріодиВиконанняЗавдань)cur.Fields[Довідники.КалендарПеріодичнихЗавдань_Select.ПеріодВиконання]).ToString();

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					cur.Fields[Довідники.КалендарПеріодичнихЗавдань_Select.Назва].ToString(),
					періодВиконання
					));
			}

			if (selectRow != 0 && selectRow < dataGridViewRecords.Rows.Count)
			{
				dataGridViewRecords.Rows[0].Selected = false;
				dataGridViewRecords.Rows[selectRow].Selected = true;
			}
		}

		private class Записи
		{
			public Записи(string _id, string _Назва, string _ПеріодВиконання)
			{
				ID = _id;
				Назва = _Назва;
				ПеріодВиконання = _ПеріодВиконання;
			}
			public string ID { get; set; }
			public string Назва { get; set; }
			public string ПеріодВиконання { get; set; }
		}

        private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.RowIndex >= 0 && e.RowIndex < dataGridViewRecords.RowCount)
			{
				string Uid = dataGridViewRecords.Rows[e.RowIndex].Cells["ID"].Value.ToString();

				toolStripButtonEdit_Click(this, null);
			}
		}

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
			FormAddPeriodicTasks formAddCash = new FormAddPeriodicTasks();
			formAddCash.IsNew = true;
			formAddCash.OwnerForm = this;
			formAddCash.ShowDialog();
		}

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				FormAddPeriodicTasks formAddCash = new FormAddPeriodicTasks();
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

					Довідники.КалендарПеріодичнихЗавдань_Objest календарПеріодичнихЗавдань_Objest = new Довідники.КалендарПеріодичнихЗавдань_Objest();
					if (календарПеріодичнихЗавдань_Objest.Read(new UnigueID(uid)))
					{
						Довідники.КалендарПеріодичнихЗавдань_Objest КалендарПеріодичнихЗавдань_Objest_Новий = new Довідники.КалендарПеріодичнихЗавдань_Objest();
						КалендарПеріодичнихЗавдань_Objest_Новий.New();
						КалендарПеріодичнихЗавдань_Objest_Новий.Назва = "(Копія) - " + календарПеріодичнихЗавдань_Objest.Назва;
						КалендарПеріодичнихЗавдань_Objest_Новий.ПеріодВиконання = календарПеріодичнихЗавдань_Objest.ПеріодВиконання;
						КалендарПеріодичнихЗавдань_Objest_Новий.Опис = календарПеріодичнихЗавдань_Objest.Опис;
						КалендарПеріодичнихЗавдань_Objest_Новий.Save();
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

					Довідники.КалендарПеріодичнихЗавдань_Objest календарПеріодичнихЗавдань_Objest = new Довідники.КалендарПеріодичнихЗавдань_Objest();
					if (календарПеріодичнихЗавдань_Objest.Read(new UnigueID(uid)))
					{
						календарПеріодичнихЗавдань_Objest.Delete();
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
