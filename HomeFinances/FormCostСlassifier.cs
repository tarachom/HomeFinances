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
    public partial class FormCostСlassifier : Form
    {
        public FormCostСlassifier()
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

		private void FormCostСlassifier_Load(object sender, EventArgs e)
        {
			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns.Add(new DataGridViewImageColumn() { Name = "Image", HeaderText = "", Width = 30, DisplayIndex = 0, Image = HomeFinances.Properties.Resources.doc_text_image });
			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["Назва"].Width = 300;
			dataGridViewRecords.Columns["Код"].Width = 130;

			LoadRecords();
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		public void LoadRecords()
		{
			int selectRow = dataGridViewRecords.SelectedRows.Count > 0 ?
				dataGridViewRecords.SelectedRows[dataGridViewRecords.SelectedRows.Count - 1].Index : 0;

			RecordsBindingList.Clear();

			Довідники.КласифікаторВитрат_Select класифікаторВитрат_Select = new Довідники.КласифікаторВитрат_Select();

			класифікаторВитрат_Select.QuerySelect.Field.Add(Довідники.КласифікаторВитрат_Select.Назва);
			класифікаторВитрат_Select.QuerySelect.Field.Add(Довідники.КласифікаторВитрат_Select.Код);
			класифікаторВитрат_Select.QuerySelect.Order.Add(Довідники.КласифікаторВитрат_Select.Назва, SelectOrder.ASC);

			класифікаторВитрат_Select.Select();

			while (класифікаторВитрат_Select.MoveNext())
			{
				Довідники.КласифікаторВитрат_Pointer cur = класифікаторВитрат_Select.Current;

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					cur.Fields[Довідники.КласифікаторВитрат_Select.Назва].ToString(),
					cur.Fields[Довідники.КласифікаторВитрат_Select.Код].ToString()
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
			public Записи(string _id, string _Назва, string _Код)
			{
				ID = _id;
				Назва = _Назва;
				Код = _Код;
			}
			public string ID { get; set; }
			public string Назва { get; set; }
			public string Код { get; set; }

		}

        private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.RowIndex >= 0 && e.RowIndex < dataGridViewRecords.RowCount)
			{
				string Uid = dataGridViewRecords.Rows[e.RowIndex].Cells["ID"].Value.ToString();

				if (DirectoryControlItem != null)
				{
					DirectoryControlItem.DirectoryPointerItem = new Довідники.КласифікаторВитрат_Pointer(new UnigueID(Uid));
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
			FormAddCostСlassifier formAddCostСlassifier = new FormAddCostСlassifier();
			formAddCostСlassifier.IsNew = true;
			formAddCostСlassifier.OwnerForm = this;
			formAddCostСlassifier.ShowDialog();
		}

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				FormAddCostСlassifier formAddCostСlassifier = new FormAddCostСlassifier();
				formAddCostСlassifier.OwnerForm = this;
				formAddCostСlassifier.IsNew = false;
				formAddCostСlassifier.Uid = dataGridViewRecords.Rows[RowIndex].Cells[0].Value.ToString();
				formAddCostСlassifier.ShowDialog();
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

					Довідники.КласифікаторВитрат_Objest класифікаторВитрат_Objest = new Довідники.КласифікаторВитрат_Objest();
					if (класифікаторВитрат_Objest.Read(new UnigueID(uid)))
					{
						Довідники.КласифікаторВитрат_Objest класифікаторВитрат_Objest_Новий = new Довідники.КласифікаторВитрат_Objest();
						класифікаторВитрат_Objest_Новий.New();
						класифікаторВитрат_Objest_Новий.Назва = "(Копія) - " + класифікаторВитрат_Objest.Назва;
						класифікаторВитрат_Objest_Новий.Код = класифікаторВитрат_Objest.Код;
						класифікаторВитрат_Objest_Новий.Save();
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

					Довідники.КласифікаторВитрат_Objest класифікаторВитрат_Objest = new Довідники.КласифікаторВитрат_Objest();
					if (класифікаторВитрат_Objest.Read(new UnigueID(uid)))
					{
						класифікаторВитрат_Objest.Delete();
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
