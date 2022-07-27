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
using System.IO;

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

		public ConfigurationParam OpenConfigurationParam { get; set; }

		//Признак процесу завантаження форми
		private bool FormLoadProcessedFlag { get; set; }

		private void FormRecordFinance_Load(object sender, EventArgs e)
		{
			FormLoadProcessedFlag = true;

			this.splitContainer1.SplitterDistance = 430;

			if (OpenConfigurationParam != null)
				this.Text += " (" + OpenConfigurationParam.ConfigurationName + ")";

			//this.записникToolStripMenuItem.Visible = false;
			//this.періодичніЗавданняToolStripMenuItem.Visible = false;

			//Параметри в лівій панелі
			DateTime start = DateTime.Today;

			//Початок періоду в залежності від значення константи
			switch (Константи.Інтерфейс.ДатаПочаткуПеріоду_Const)
			{
				case Перелічення.ВаріантиПочаткуПеріоду.Тиждень:
					{
						dateTimePickerStart.Value = start.AddDays(-7);
						break;
					}
				case Перелічення.ВаріантиПочаткуПеріоду.Місяць:
					{
						dateTimePickerStart.Value = start.AddDays(-30);
						break;
					}
				case Перелічення.ВаріантиПочаткуПеріоду.Квартал:
					{
						dateTimePickerStart.Value = start.AddDays(-90);
						break;
					}
				case Перелічення.ВаріантиПочаткуПеріоду.ПівРоку:
					{
						dateTimePickerStart.Value = start.AddDays(-180);
						break;
					}
				case Перелічення.ВаріантиПочаткуПеріоду.Рік:
					{
						dateTimePickerStart.Value = start.AddDays(-365);
						break;
					}
				case Перелічення.ВаріантиПочаткуПеріоду.ЗПочаткуМісяця:
					{
						dateTimePickerStart.Value = start.AddDays(-(start.Day - 1));
						break;
					}
				default:
					{
						dateTimePickerStart.Value = start.AddDays(-7);
						break;
					}
			}

			dateTimePickerStop.Value = new DateTime(start.Year, start.Month, start.Day, 23, 59, 59);

			//Заповнення елементів перелічення
			comboBoxTypeRecord.Items.Add(new NameValue<int>("- Всі -", 0));
			comboBoxTypeRecord.SelectedIndex = 0;

			foreach (ConfigurationEnumField field in Конфа.Config.Kernel.Conf.Enums["ТипЗапису"].Fields.Values)
				comboBoxTypeRecord.Items.Add(new NameValue<int>(field.Name, field.Value));

			//Стаття витрат, Каса
			directoryControl1.CallBack = CallBack_DirectoryControl_Open_FormCostСlassifier;
			directoryControl2.CallBack = CallBack_DirectoryControl_Open_FormCash;
			directoryControl3.CallBack = CallBack_DirectoryControl_Open_FormCashMove;

			//Обчислення залишків по касах
			labelCalculateBalance.Text = "";

			//GRID
			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns.Add(new DataGridViewImageColumn() { Name = "Image", HeaderText = "", Width = 30, DisplayIndex = 0, Image = HomeFinances.Properties.Resources.doc_text_image });

			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["Назва"].Width = Константи.СписокГоловнаФорма.СтовпчикНазваШирина_Const != 0 ? Константи.СписокГоловнаФорма.СтовпчикНазваШирина_Const : 300;

			dataGridViewRecords.Columns["ДатаЗапису"].Width = Константи.СписокГоловнаФорма.СтовпчикДатаЗаписуШирина_Const != 0 ? Константи.СписокГоловнаФорма.СтовпчикДатаЗаписуШирина_Const : 120;
			dataGridViewRecords.Columns["ДатаЗапису"].DisplayIndex = 1;

			dataGridViewRecords.Columns["Сума"].Width = Константи.СписокГоловнаФорма.СтовпчикСумаШирина_Const != 0 ? Константи.СписокГоловнаФорма.СтовпчикСумаШирина_Const : 60;
			dataGridViewRecords.Columns["Сума"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewRecords.Columns["Сума"].DisplayIndex = 5;

			dataGridViewRecords.Columns["ТипЗапису"].HeaderText = "Тип";
			dataGridViewRecords.Columns["ТипЗапису"].Width = 80;
			dataGridViewRecords.Columns["ТипЗапису"].DisplayIndex = 2;

			dataGridViewRecords.Columns["Витрата"].Width = Константи.СписокГоловнаФорма.СтовпчикВитратаШирина_Const != 0 ? Константи.СписокГоловнаФорма.СтовпчикВитратаШирина_Const : 150;
			dataGridViewRecords.Columns["Витрата"].HeaderText = "Стаття витрат";

			dataGridViewRecords.Columns["Каса"].Width = Константи.СписокГоловнаФорма.СтовпчикКасаШирина_Const != 0 ? Константи.СписокГоловнаФорма.СтовпчикКасаШирина_Const : 100;

			dataGridViewRecords.Columns["Проведено"].Width = 70;

			LoadRecords();

			CalculateBalance();

			FormLoadProcessedFlag = false;
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		private class Записи
		{
			public string ID { get; set; }
			public string Назва { get; set; }
			public string ДатаЗапису { get; set; }
			public string Сума { get; set; }
			public string ТипЗапису { get; set; }
			public string Витрата { get; set; }
			public string Каса { get; set; }
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

		/// <summary>
		/// Зворотня функція для вибору із списку
		/// </summary>
		/// <param name="directoryPointerItem">Ссилка на елемент довідника</param>
		public void CallBack_DirectoryControl_Open_FormCashMove(DirectoryPointer directoryPointerItem)
		{
			FormCash formCash = new FormCash();
			formCash.DirectoryPointerItem = directoryPointerItem;
			formCash.DirectoryControlItem = directoryControl3;
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
				Довідники.Записи_Const.ДатаЗапису,
				Довідники.Записи_Const.Назва,
				Довідники.Записи_Const.Сума,
				Довідники.Записи_Const.ТипЗапису,
				Довідники.Записи_Const.Проведено
			});

			//JOIN
			записи_Select.QuerySelect.FieldAndAlias.Add(
				new NameValue<string>(Довідники.КласифікаторВитрат_Const.TABLE + "." + Довідники.КласифікаторВитрат_Const.Назва, "statya_name"));
			записи_Select.QuerySelect.Joins.Add(
				new Join(Довідники.КласифікаторВитрат_Const.TABLE, Довідники.Записи_Const.Витрата, Довідники.Записи_Const.TABLE));

			//JOIN2
			записи_Select.QuerySelect.FieldAndAlias.Add(
				new NameValue<string>(Довідники.Каса_Const.TABLE + "." + Довідники.Каса_Const.Назва, "casa_name"));
			записи_Select.QuerySelect.Joins.Add(
				new Join(Довідники.Каса_Const.TABLE, Довідники.Записи_Const.Каса, Довідники.Записи_Const.TABLE));

			//WHERE
			записи_Select.QuerySelect.Where.Add(new Where(Довідники.Записи_Const.ДатаЗапису, Comparison.QT_EQ, dateTimePickerStart.Value, false, Comparison.AND));
			записи_Select.QuerySelect.Where.Add(new Where(Довідники.Записи_Const.ДатаЗапису, Comparison.LT_EQ, dateTimePickerStop.Value));

			//записи_Select.QuerySelect.Where.Add(
			//    new Where(Довідники.Записи_Select.ДатаЗапису, Comparison.BETWEEN,
			//    "'" + dateTimePickerStart.Value.ToString("dd.MM.yyyy") + "' AND '" + dateTimePickerStop.Value.ToString("dd.MM.yyyy") + "'", true));

			NameValue<int> типЗаписуФільтер = (NameValue<int>)comboBoxTypeRecord.SelectedItem;

			if (!(типЗаписуФільтер.Value == 0))
				записи_Select.QuerySelect.Where.Add(new Where(Comparison.AND, Довідники.Записи_Const.ТипЗапису, Comparison.EQ, типЗаписуФільтер.Value));

			//Стаття
			if (directoryControl1.DirectoryPointerItem != null && !directoryControl1.DirectoryPointerItem.IsEmpty())
				записи_Select.QuerySelect.Where.Add(new Where(Comparison.AND, Довідники.Записи_Const.Витрата, Comparison.EQ, directoryControl1.DirectoryPointerItem.UnigueID.UGuid));

			//Каса
			if (directoryControl2.DirectoryPointerItem != null && !directoryControl2.DirectoryPointerItem.IsEmpty())
				записи_Select.QuerySelect.Where.Add(new Where(Comparison.AND, Довідники.Записи_Const.Каса, Comparison.EQ, directoryControl2.DirectoryPointerItem.UnigueID.UGuid));

			//Каса переміщення
			if (directoryControl3.DirectoryPointerItem != null && !directoryControl3.DirectoryPointerItem.IsEmpty())
				записи_Select.QuerySelect.Where.Add(new Where(Comparison.AND, Довідники.Записи_Const.КасаПереміщення, Comparison.EQ, directoryControl3.DirectoryPointerItem.UnigueID.UGuid));

			//OREDER
			записи_Select.QuerySelect.Order.Add(Довідники.Записи_Const.ДатаЗапису, SelectOrder.ASC);

			записи_Select.Select();

			while (записи_Select.MoveNext())
			{
				Довідники.Записи_Pointer cur = записи_Select.Current;

				Перелічення.ТипЗапису типЗапису = (Перелічення.ТипЗапису)cur.Fields[Довідники.Записи_Const.ТипЗапису];
				string типЗаписуПредставлення = типЗапису.ToString();

				RecordsBindingList.Add(new Записи()
				{
					ID = cur.UnigueID.ToString(),
					Назва = cur.Fields[Довідники.Записи_Const.Назва].ToString(),
					ДатаЗапису = cur.Fields[Довідники.Записи_Const.ДатаЗапису].ToString(),
					Сума = Math.Round((decimal)cur.Fields[Довідники.Записи_Const.Сума], 2).ToString(),
					ТипЗапису = типЗаписуПредставлення,
					Витрата = cur.Fields["statya_name"].ToString(),
					Каса = cur.Fields["casa_name"].ToString(),
					Проведено = cur.Fields[Довідники.Записи_Const.Проведено] != DBNull.Value ? (bool)cur.Fields[Довідники.Записи_Const.Проведено] : false
				});
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
				MessageBox.Show("Видалити виділені записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
				CalculateBalance();
			}
		}

		private void toolStripButtonCopy_Click(object sender, EventArgs e)
		{
			if (dataGridViewRecords.SelectedRows.Count != 0 &&
				MessageBox.Show("Копіювати виділені записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Записи_Objest записи_Objest = new Довідники.Записи_Objest();
					if (записи_Objest.Read(new UnigueID(uid)))
					{
						Довідники.Записи_Objest записи_Objest_Новий = записи_Objest.Copy();
						записи_Objest_Новий.Назва = "(Копія) - " + записи_Objest.Назва;
						записи_Objest_Новий.ДатаЗапису = DateTime.Now;
						записи_Objest_Новий.Проведено = false;
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

		/// <summary>
		/// Встановлює флажок Проведено і записує Обєкт.
		/// Відповідно при запису викликаються трігери, тому записуються значення в регістр, або стираються
		/// </summary>
		/// <param name="SpendFlag"></param>
		private void SaveSpendFlag(string messageBoxText, bool SpendFlag)
		{
			if (dataGridViewRecords.SelectedRows.Count != 0 &&
				MessageBox.Show(messageBoxText, "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Записи_Objest записи_Objest = new Довідники.Записи_Objest();
					if (записи_Objest.Read(new UnigueID(uid)))
					{
						записи_Objest.Проведено = SpendFlag;
						записи_Objest.Save();
					}
					else
					{
						MessageBox.Show("Error read");
						break;
					}
				}

				LoadRecords();
				CalculateBalance();
			}
		}

		private void toolStripButtonSpend_Click(object sender, EventArgs e)
		{
			SaveSpendFlag("Провести виділені записи?", true);
		}

		private void toolStripButtonClearSpend_Click(object sender, EventArgs e)
		{
			SaveSpendFlag("Відмінити проведення виділених записів?", false);
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			LoadRecords();
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

		private void періодичніЗавданняToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormPeriodicTasks formPeriodicTasks = new FormPeriodicTasks();
			formPeriodicTasks.Show();
		}

		private void калькуляторToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("calc.exe");
		}

		#endregion

		private void FormRecordFinance_FormClosing(object sender, FormClosingEventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// Обчислення залишків по касах
		/// </summary>
		public void CalculateBalance()
		{
			string query = $@"
SELECT 
    ЗалишкиКоштів.{РегістриНакопичення.ЗалишкиКоштів_Const.Каса} AS КасаІд, 
    КасаТаб.{Довідники.Каса_Const.Назва} AS КасаНазва,
	SUM(CASE WHEN ЗалишкиКоштів.income = true THEN 
        ЗалишкиКоштів.{РегістриНакопичення.ЗалишкиКоштів_Const.Сума} ELSE 
        -ЗалишкиКоштів.{РегістриНакопичення.ЗалишкиКоштів_Const.Сума} END) AS Сума,
    ВалютаТаб.{Довідники.Валюта_Const.Код} AS ВалютаКод
FROM 
    {РегістриНакопичення.ЗалишкиКоштів_Const.TABLE} AS ЗалишкиКоштів
    LEFT JOIN {Довідники.Каса_Const.TABLE} AS КасаТаб ON КасаТаб.uid = ЗалишкиКоштів.{РегістриНакопичення.ЗалишкиКоштів_Const.Каса}
    LEFT JOIN {Довідники.Валюта_Const.TABLE} AS ВалютаТаб ON ВалютаТаб.uid = КасаТаб.{Довідники.Каса_Const.Валюта}
GROUP BY КасаІд, КасаНазва, ВалютаКод
HAVING SUM(CASE WHEN ЗалишкиКоштів.income = true THEN 
       ЗалишкиКоштів.{РегістриНакопичення.ЗалишкиКоштів_Const.Сума} ELSE 
       -ЗалишкиКоштів.{РегістриНакопичення.ЗалишкиКоштів_Const.Сума} END) != 0
ORDER BY КасаНазва ASC";

			//Console.WriteLine(query);

			string[] columnsName;
			List<object[]> listRow;

			Конфа.Config.Kernel.DataBase.SelectRequest(query, null, out columnsName, out listRow);

			string result = "";

			foreach (object[] o in listRow)
			{
				result += (String.IsNullOrEmpty(o[1].ToString()) ? "<каса не вказана>" : o[1].ToString()) + ": " +
					Math.Round((decimal)o[2], 2).ToString() + " " + o[3].ToString() + "\n\r";
			}

			labelCalculateBalance.Text = result;
		}

		private void buttonCalculateBalance_Click(object sender, EventArgs e)
		{
			CalculateBalance();
		}

		private void dataGridViewRecords_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
		{
			if (!FormLoadProcessedFlag)
			{
				if (e.Column.Name == "Назва")
					Константи.СписокГоловнаФорма.СтовпчикНазваШирина_Const = e.Column.Width;

				if (e.Column.Name == "ДатаЗапису")
					Константи.СписокГоловнаФорма.СтовпчикДатаЗаписуШирина_Const = e.Column.Width;

				if (e.Column.Name == "Сума")
					Константи.СписокГоловнаФорма.СтовпчикСумаШирина_Const = e.Column.Width;

				if (e.Column.Name == "Витрата")
					Константи.СписокГоловнаФорма.СтовпчикВитратаШирина_Const = e.Column.Width;

				if (e.Column.Name == "Каса")
					Константи.СписокГоловнаФорма.СтовпчикКасаШирина_Const = e.Column.Width;
			}
		}

        #region ОБМІН

        private void вигрузкаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "Finances_Export_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xml";
			saveFileDialog.Filter = "XML|*.xml";
			saveFileDialog.Title = "Файл для вигрузки даних";
			saveFileDialog.InitialDirectory =
				Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляВигрузкиДаних_Const.Trim() != "" ?
				Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляВигрузкиДаних_Const : Environment.SpecialFolder.Desktop.ToString();

			if (!(saveFileDialog.ShowDialog() == DialogResult.OK))
				return;
			else
			{
				string fileExport = saveFileDialog.FileName;
				Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляВигрузкиДаних_Const = Path.GetDirectoryName(fileExport);

				System.Diagnostics.Process.Start("Configurator.exe",
					OpenConfigurationParam.ConfigurationKey + " " +
					"unloadingdata" + " " +
					fileExport);
			}
		}

		private void загрузкаToolStripMenuItem_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "XML|*.xml";
			openFileDialog.Title = "Файл для загрузки даних";

			openFileDialog.InitialDirectory =
				Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляЗагрузкиДаних_Const.Trim() != "" ?
				Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляЗагрузкиДаних_Const : Environment.SpecialFolder.Desktop.ToString();

			if (!(openFileDialog.ShowDialog() == DialogResult.OK))
				return;
			else
			{
				string fileImport = openFileDialog.FileName;
				Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляЗагрузкиДаних_Const = Path.GetDirectoryName(fileImport);

				System.Diagnostics.Process.Start("Configurator.exe",
					OpenConfigurationParam.ConfigurationKey + " " +
					"loadingdata" + " " +
					fileImport);
			}
		}

        private void ВідкритиКонфігураторToolStripMenuItem_Click(object sender, EventArgs e)
        {
			System.Diagnostics.Process.Start("Configurator.exe",
					OpenConfigurationParam.ConfigurationKey);
		}

        #endregion

        private void проПрограмуToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormAbout formAbout = new FormAbout();
			formAbout.OpenConfigurationParam = OpenConfigurationParam;
			formAbout.ShowDialog();
		}
    }
}
