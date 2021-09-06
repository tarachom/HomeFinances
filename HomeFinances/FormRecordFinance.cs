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
using РегістриНакопичення = HomeFinances_1_0.РегістриНакопичення;

namespace HomeFinances
{
	public partial class FormRecordFinance : System.Windows.Forms.Form
	{
		public FormRecordFinance()
		{
			InitializeComponent();
		}

		public string OpenDataBaseName { get; set; }

		private void FormRecordFinance_Load(object sender, EventArgs e)
		{
			this.splitContainer1.SplitterDistance = 400;
			this.Text += OpenDataBaseName;

			//this.записникToolStripMenuItem.Visible = false;
			//this.періодичніЗавданняToolStripMenuItem.Visible = false;

			//Параметри в лівій панелі
			DateTime start = DateTime.Today;

			dateTimePickerStart.Value = start.AddDays(-7);
			dateTimePickerStop.Value = new DateTime(start.Year, start.Month, start.Day, 23, 59, 59);

			//Заповнення елементів перелічення
			comboBoxTypeRecord.Items.Add(new NameValue<int>("- Всі -", 0));
			comboBoxTypeRecord.SelectedIndex = 0;

			foreach (ConfigurationEnumField field in Конфа.Config.Kernel.Conf.Enums["ТипЗапису"].Fields.Values)
				comboBoxTypeRecord.Items.Add(new NameValue<int>(field.Name, field.Value));

			//Стаття витрат, Каса
			directoryControl1.CallBack = CallBack_DirectoryControl_Open_FormCostСlassifier;
			directoryControl2.CallBack = CallBack_DirectoryControl_Open_FormCash;

			//Обчислення залишків по касах
			labelCalculateBalance.Text = "";

			//GRID
			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns.Add(new DataGridViewImageColumn() {Name = "Image", HeaderText = "", Width = 30, DisplayIndex = 0, Image = HomeFinances.Properties.Resources.doc_text_image });

			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["Назва"].Width = 500;

			dataGridViewRecords.Columns["ДатаЗапису"].Width = 120;
			dataGridViewRecords.Columns["ДатаЗапису"].DisplayIndex = 1;

			dataGridViewRecords.Columns["Сума"].Width = 80;
			dataGridViewRecords.Columns["Сума"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewRecords.Columns["Сума"].DisplayIndex = 5;

			dataGridViewRecords.Columns["ТипЗапису"].HeaderText = "Тип";
			dataGridViewRecords.Columns["ТипЗапису"].Width = 80;
			dataGridViewRecords.Columns["ТипЗапису"].DisplayIndex = 2;
			//dataGridViewRecords.Columns["ТипЗапису"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//dataGridViewRecords.Columns["ТипЗапису"].CellTemplate.Style.Font = new Font("Arial", 11);

			dataGridViewRecords.Columns["Витрата"].Width = 200;
			dataGridViewRecords.Columns["Витрата"].HeaderText = "Стаття витрат";

			dataGridViewRecords.Columns["Проведено"].Width = 65;

			

			LoadRecords();		
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		private class Записи
		{
			public Записи(string _id, string _Назва, string _ДатаЗапису, string _Сума, string _ТипЗапису, string _Витрата, bool _Проведено)
			{
				ID = _id;
				Назва = _Назва;
				ДатаЗапису = _ДатаЗапису;
				Сума = _Сума;
				ТипЗапису = _ТипЗапису;
				Витрата = _Витрата;
				Проведено = _Проведено;
			}
			public string ID { get; set; }
			public string Назва { get; set; }
			public string ДатаЗапису { get; set; }
			public string Сума { get; set; }
			public string ТипЗапису { get; set; }
			public string Витрата { get; set; }
			public bool Проведено { get; set; }
		}

        #region Call_Back

        /// <summary>
        /// Зворотня функція для вибору із списку
        /// </summary>
        /// <param name="directoryPointerItem">Ссилка на елемент довідника</param>
        public void CallBack_DirectoryControl_Open_FormCostСlassifier(DirectoryPointer directoryPointerItem)
		{
			FormCostСlassifier formCostСlassifier = new FormCostСlassifier();
			formCostСlassifier.DirectoryPointerItem = directoryPointerItem;
			formCostСlassifier.DirectoryControlItem = directoryControl1;
			formCostСlassifier.ShowDialog();
		}

		/// <summary>
		/// Зворотня функція для вибору із списку
		/// </summary>
		/// <param name="directoryPointerItem">Ссилка на елемент довідника</param>
		public void CallBack_DirectoryControl_Open_FormCash(DirectoryPointer directoryPointerItem)
		{
			FormCash formCash = new FormCash();
			formCash.DirectoryPointerItem = directoryPointerItem;
			formCash.DirectoryControlItem = directoryControl2;
			formCash.ShowDialog();
		}

        #endregion

        public void LoadRecords()
		{
			int selectRow = dataGridViewRecords.SelectedRows.Count > 0 ?
				dataGridViewRecords.SelectedRows[dataGridViewRecords.SelectedRows.Count - 1].Index : 0;

			RecordsBindingList.Clear();

			Довідники.Записи_Select записи_Select = new Довідники.Записи_Select();
			записи_Select.QuerySelect.Field.AddRange(new string[] {
				Довідники.Записи_Select.ДатаЗапису,
				Довідники.Записи_Select.Назва,
				Довідники.Записи_Select.Сума,
				Довідники.Записи_Select.ТипЗапису,
				Довідники.Записи_Select.Витрата,
				Довідники.Записи_Select.Проведено
			});

			записи_Select.QuerySelect.Where.Add(new Where(Довідники.Записи_Select.ДатаЗапису, Comparison.QT_EQ, dateTimePickerStart.Value, false, Comparison.AND));
            записи_Select.QuerySelect.Where.Add(new Where(Довідники.Записи_Select.ДатаЗапису, Comparison.LT_EQ, dateTimePickerStop.Value));

			//записи_Select.QuerySelect.Where.Add(
			//    new Where(Довідники.Записи_Select.ДатаЗапису, Comparison.BETWEEN,
			//    "'" + dateTimePickerStart.Value.ToString("dd.MM.yyyy") + "' AND '" + dateTimePickerStop.Value.ToString("dd.MM.yyyy") + "'", true));

			NameValue<int> типЗаписуФільтер = (NameValue<int>)comboBoxTypeRecord.SelectedItem;

			if (!(типЗаписуФільтер.Value == 0))
				записи_Select.QuerySelect.Where.Add(new Where(Comparison.AND, Довідники.Записи_Select.ТипЗапису, Comparison.EQ, типЗаписуФільтер.Value));

			if (directoryControl1.DirectoryPointerItem != null && !directoryControl1.DirectoryPointerItem.IsEmpty())
				записи_Select.QuerySelect.Where.Add(new Where(Comparison.AND, Довідники.Записи_Select.Витрата, Comparison.EQ, directoryControl1.DirectoryPointerItem.UnigueID.UGuid));

			if (directoryControl2.DirectoryPointerItem != null && !directoryControl2.DirectoryPointerItem.IsEmpty())
				записи_Select.QuerySelect.Where.Add(new Where(Comparison.AND, Довідники.Записи_Select.Каса, Comparison.EQ, directoryControl2.DirectoryPointerItem.UnigueID.UGuid));

			записи_Select.QuerySelect.Order.Add(Довідники.Записи_Select.ДатаЗапису, SelectOrder.DESC);

			//Створення тимчасової таблиці
			записи_Select.QuerySelect.CreateTempTable = true;
			записи_Select.Select();

			Dictionary<string, string> dictionaryCostСlassifier = new Dictionary<string, string>();

			Довідники.КласифікаторВитрат_Select класифікаторВитрат_Select = new Довідники.КласифікаторВитрат_Select();
			класифікаторВитрат_Select.QuerySelect.Field.Add(Довідники.КласифікаторВитрат_Select.Назва);
			класифікаторВитрат_Select.QuerySelect.Where.Add(new Where("uid", Comparison.IN, "SELECT DISTINCT " + Довідники.Записи_Select.Витрата + " FROM " + записи_Select.QuerySelect.TempTable, true));
			класифікаторВитрат_Select.Select();

			while (класифікаторВитрат_Select.MoveNext())
			{
				Довідники.КласифікаторВитрат_Pointer cur = класифікаторВитрат_Select.Current;
				dictionaryCostСlassifier.Add(cur.UnigueID.ToString(), cur.Fields[Довідники.КласифікаторВитрат_Select.Назва].ToString());
			}

			//Видалення тимчасової таблиці
			записи_Select.DeleteTempTable();

			//Нормальна вибірка даних
			записи_Select.Select();

			while (записи_Select.MoveNext())
			{
				Довідники.Записи_Pointer cur = записи_Select.Current;

				Перелічення.ТипЗапису типЗапису = (Перелічення.ТипЗапису)cur.Fields[Довідники.Записи_Select.ТипЗапису];
				string типЗаписуПредставлення = типЗапису.ToString();

				Довідники.КласифікаторВитрат_Pointer Витрата = new Довідники.КласифікаторВитрат_Pointer(new UnigueID(cur.Fields[Довідники.Записи_Select.Витрата].ToString()));
				string ВитратаПредставлення = (!Витрата.IsEmpty() && dictionaryCostСlassifier.ContainsKey(Витрата.UnigueID.ToString())) ? dictionaryCostСlassifier[Витрата.UnigueID.ToString()] : "";

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					cur.Fields[Довідники.Записи_Select.Назва].ToString(),
					cur.Fields[Довідники.Записи_Select.ДатаЗапису].ToString(),
					cur.Fields[Довідники.Записи_Select.Сума].ToString(),
					типЗаписуПредставлення,
					ВитратаПредставлення,
					cur.Fields[Довідники.Записи_Select.Проведено] != DBNull.Value ? (bool)cur.Fields[Довідники.Записи_Select.Проведено] : false
					));
			}

			if (selectRow != 0 && selectRow < dataGridViewRecords.Rows.Count)
			{
				dataGridViewRecords.Rows[0].Selected = false;
				dataGridViewRecords.Rows[selectRow].Selected = true;
			}
		}

		private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.RowIndex < dataGridViewRecords.RowCount)
			{
				FormAddRecord formAddRecord = new FormAddRecord();
				formAddRecord.OwnerForm = this;
				formAddRecord.IsNew = false;
				formAddRecord.Uid = dataGridViewRecords.Rows[e.RowIndex].Cells[0].Value.ToString();
				formAddRecord.ShowDialog();
			}
		}

        #region ToolStrip Menu

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
		{
			LoadRecords();
		}

		private void toolStripButtonAdd_Click(object sender, EventArgs e)
		{
			FormAddRecord formAddRecord = new FormAddRecord();
			formAddRecord.IsNew = true;
			formAddRecord.OwnerForm = this;
			formAddRecord.ShowDialog();
		}

		private void toolStripButtonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridViewRecords.SelectedRows.Count != 0 && 
				MessageBox.Show("Видалити записи?","Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Записи_Objest записи_Objest = new Довідники.Записи_Objest();
					if (записи_Objest.Read(new UnigueID(uid)))
					{
						записи_Objest.Delete();
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

		private void toolStripButtonCopy_Click(object sender, EventArgs e)
		{
			if (dataGridViewRecords.SelectedRows.Count != 0 &&
				MessageBox.Show("Копіювати записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Записи_Objest записи_Objest = new Довідники.Записи_Objest();
					if (записи_Objest.Read(new UnigueID(uid)))
					{
						Довідники.Записи_Objest записи_Objest_Новий = new Довідники.Записи_Objest();
						записи_Objest_Новий.New();
						записи_Objest_Новий.ДатаЗапису = записи_Objest.ДатаЗапису;
						записи_Objest_Новий.Назва = "(Копія) - " + записи_Objest.Назва;
						записи_Objest_Новий.Опис = записи_Objest.Опис;
						записи_Objest_Новий.Сума = записи_Objest.Сума;
						записи_Objest_Новий.ТипЗапису = записи_Objest.ТипЗапису;
						записи_Objest_Новий.Каса = записи_Objest.Каса;
						записи_Objest_Новий.КасаПереміщення = записи_Objest.КасаПереміщення;
						записи_Objest_Новий.Витрата = записи_Objest.Витрата;
						записи_Objest_Новий.СсилкаНаСайт = записи_Objest.СсилкаНаСайт;
						записи_Objest_Новий.Save();
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

		private void toolStripButtonSpend_Click(object sender, EventArgs e)
		{
			if (dataGridViewRecords.SelectedRows.Count != 0 &&
				MessageBox.Show("Провести записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Записи_Objest записи_Objest = new Довідники.Записи_Objest();
					if (записи_Objest.Read(new UnigueID(uid)))
					{
						записи_Objest.Проведено = true;
						записи_Objest.Save();
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

		#endregion

		

        #region MENU

        private void класифікаторВитратToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormCostСlassifier formCostСlassifier = new FormCostСlassifier();
			formCostСlassifier.Show();
		}

        private void контактиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormContacts formContacts = new FormContacts();
			formContacts.Show();
		}

        private void валютиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormCurrency formCurrency = new FormCurrency();
			formCurrency.Show();
		}

        private void касиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormCash formCash = new FormCash();
			formCash.Show();
		}

        private void записникToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormNotebook formNotebook = new FormNotebook();
			formNotebook.Show();
		}

        private void константиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormConstants formConstats = new FormConstants();
			formConstats.Show();
		}

		private void toolStripDropDownButton1_Click(object sender, EventArgs e)
		{
			FormExchange formExchange = new FormExchange();
			formExchange.ShowDialog();
		}

		private void періодичніЗавданняToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormPeriodicTasks formPeriodicTasks = new FormPeriodicTasks();
			formPeriodicTasks.Show();
		}

		#endregion

		private void buttonRefresh_Click(object sender, EventArgs e)
        {
			LoadRecords();
		}

        private void FormRecordFinance_FormClosing(object sender, FormClosingEventArgs e)
        {
			Application.Exit();
        }

        private void buttonCalculateBalance_Click(object sender, EventArgs e)
        {
			Configuration Conf = Конфа.Config.Kernel.Conf;

			string КасаІд = Conf.RegistersAccumulation["ЗалишкиКоштів"].DimensionFields["Каса"].NameInTable;
			string КасаНазва = Conf.Directories["Каса"].Fields["Назва"].NameInTable;
			string Сума = Conf.RegistersAccumulation["ЗалишкиКоштів"].ResourcesFields["Сума"].NameInTable;
			string ВалютаКод = Conf.Directories["Валюта"].Fields["Код"].NameInTable;
			string Регістр_ЗалишкиКоштів = Conf.RegistersAccumulation["ЗалишкиКоштів"].Table;
			string КасаТаб = Conf.Directories["Каса"].Table;
			string ВалютаТаб = Conf.Directories["Валюта"].Table;
			string КасаТаб_Валюта = Conf.Directories["Каса"].Fields["Валюта"].NameInTable;

			string query = $@"
				SELECT 
                    ЗалишкиКоштів.{КасаІд} AS КасаІд, 
                    КасаТаб.{КасаНазва} AS КасаНазва,
				    sum(CASE WHEN ЗалишкиКоштів.income = true THEN ЗалишкиКоштів.{Сума} ELSE -ЗалишкиКоштів.{Сума} END) AS Сума,
                    ВалютаТаб.{ВалютаКод} AS ВалютаКод
				FROM 
                    {Регістр_ЗалишкиКоштів} AS ЗалишкиКоштів
                    LEFT JOIN {КасаТаб} AS КасаТаб ON ЗалишкиКоштів.{КасаІд} = КасаТаб.uid
                    LEFT JOIN {ВалютаТаб} AS ВалютаТаб ON КасаТаб.{КасаТаб_Валюта} = ВалютаТаб.uid 
			    GROUP BY КасаІд, КасаНазва, ВалютаКод
                ORDER BY КасаНазва";

			string[] columnsName;
			List<object[]> listRow;

			Конфа.Config.Kernel.DataBase.SelectRequest(query, null, out columnsName, out listRow);

			string result = "";

			foreach(object[] o in listRow)
            {
				result += (String.IsNullOrEmpty(o[1].ToString()) ? "<каса не вказана>" : o[1].ToString()) + ": " + o[2].ToString() + " " + o[3].ToString() + "\n\r";
			}

			labelCalculateBalance.Text = result;
		}

        
    }
}
