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
using System.Windows.Forms;

using AccountingSoftware;
using Конфа = НоваКонфігурація_1_0;
using Константи = НоваКонфігурація_1_0.Константи;
using Довідники = НоваКонфігурація_1_0.Довідники;
using Перелічення = НоваКонфігурація_1_0.Перелічення;
using РегістриНакопичення = НоваКонфігурація_1_0.РегістриНакопичення;

namespace HomeFinances
{
	public partial class FormAddRecord : System.Windows.Forms.Form
	{
		public FormAddRecord()
		{
			InitializeComponent();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/// <summary>
		/// Форма списку
		/// </summary>
		public FormRecordFinance OwnerForm { get; set; }

		/// <summary>
		/// Чи це новий запис чи редагування існуючого
		/// </summary>
		public Nullable<bool> IsNew { get; set; }

		/// <summary>
		/// Ід запису
		/// </summary>
		public string Uid { get; set; }

		/// <summary>
		/// Обєкт запису
		/// </summary>
		private Довідники.Записи_Objest записи_Objest { get; set; }

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

		public void CallBack_DirectoryControl_Open_FormCash_Back(DirectoryPointer directoryPointerItem)
		{
			FormCash formCash = new FormCash();
			formCash.DirectoryPointerItem = directoryPointerItem;
			formCash.DirectoryControlItem = directoryControl3;
			formCash.ShowDialog();
		}

		private void FormAddRecord_Load(object sender, EventArgs e)
		{
			//Заповнення елементів перелічення
			foreach (ConfigurationEnumField field in Конфа.Config.Kernel.Conf.Enums["ТипЗапису"].Fields.Values)
				comboBoxTypeRecord.Items.Add((Перелічення.ТипЗапису)field.Value);

			directoryControl1.CallBack = CallBack_DirectoryControl_Open_FormCostСlassifier;
			directoryControl2.CallBack = CallBack_DirectoryControl_Open_FormCash;
			directoryControl3.CallBack = CallBack_DirectoryControl_Open_FormCash_Back;

			if (IsNew.HasValue)
			{
				записи_Objest = new Довідники.Записи_Objest();
				
				if (IsNew.Value)
				{
					this.Text += " - Новий запис";

					dateTimePickerRecord.Value = DateTime.Now;
					maskedTextBoxTime.Text = DateTime.Now.TimeOfDay.ToString();
					comboBoxTypeRecord.SelectedIndex = 0;
					maskedTextBoxSuma.Text = "0";
					directoryControl1.DirectoryPointerItem = new Довідники.КласифікаторВитрат_Pointer();
					directoryControl2.DirectoryPointerItem = new Довідники.Каса_Pointer();
					directoryControl3.DirectoryPointerItem = new Довідники.Каса_Pointer();

					//Константи
					directoryControl1.DirectoryPointerItem = Константи.ЗначенняПоЗамовчуванню.ОсновнаСтаттяВитрат_Const;
					directoryControl2.DirectoryPointerItem = Константи.ЗначенняПоЗамовчуванню.ОсновнаКаса_Const;
				}
				else
				{
					if (записи_Objest.Read(new UnigueID(Uid)))
					{
						this.Text += " - Редагування запису - " + записи_Objest.Назва;

						dateTimePickerRecord.Value = записи_Objest.ДатаЗапису;
						maskedTextBoxTime.Text = записи_Objest.ДатаЗапису.TimeOfDay.ToString();
						textBoxName.Text = записи_Objest.Назва;
						textBoxOpys.Text = записи_Objest.Опис;
						comboBoxTypeRecord.SelectedItem = записи_Objest.ТипЗапису;
						maskedTextBoxSuma.Text = записи_Objest.Сума.ToString();
						directoryControl1.DirectoryPointerItem = new Довідники.КласифікаторВитрат_Pointer(записи_Objest.Витрата.UnigueID);
						textBoxUrlLink.Text = записи_Objest.СсилкаНаСайт;
						directoryControl2.DirectoryPointerItem = new Довідники.Каса_Pointer(записи_Objest.Каса.UnigueID);
						directoryControl3.DirectoryPointerItem = new Довідники.Каса_Pointer(записи_Objest.КасаПереміщення.UnigueID);
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
					записи_Objest.New();

				try
				{
					TimeSpan ts = TimeSpan.Parse(maskedTextBoxTime.Text);

					записи_Objest.ДатаЗапису = new DateTime(
						dateTimePickerRecord.Value.Year, dateTimePickerRecord.Value.Month, dateTimePickerRecord.Value.Day,
						ts.Hours, ts.Minutes, ts.Seconds);

					записи_Objest.Назва = textBoxName.Text;
					записи_Objest.Опис = textBoxOpys.Text;
					записи_Objest.ТипЗапису = (Перелічення.ТипЗапису)comboBoxTypeRecord.SelectedItem;
					записи_Objest.Сума = int.Parse(maskedTextBoxSuma.Text);
					записи_Objest.Витрата = (Довідники.КласифікаторВитрат_Pointer)directoryControl1.DirectoryPointerItem;
					записи_Objest.СсилкаНаСайт = textBoxUrlLink.Text;
					записи_Objest.Каса = (Довідники.Каса_Pointer)directoryControl2.DirectoryPointerItem;
					записи_Objest.КасаПереміщення = (Довідники.Каса_Pointer)directoryControl3.DirectoryPointerItem;

					записи_Objest.Save();

					WriteRegisterAccumulation();
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

		private void WriteRegisterAccumulation()
        {
			РегістриНакопичення.ЗалишкиКоштів_RecordsSet залишкиКоштів_RecordsSet = new РегістриНакопичення.ЗалишкиКоштів_RecordsSet();

			if (записи_Objest.ТипЗапису == Перелічення.ТипЗапису.Замітка)
			{
				залишкиКоштів_RecordsSet.Delete(записи_Objest.UnigueID.UGuid);
			}
			if (записи_Objest.ТипЗапису == Перелічення.ТипЗапису.Переміщення)
            {
				РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record record1 = new РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record();
				РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record record2 = new РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record();

				record1.Income = true;
				record2.Income = false;

				record1.Owner = record2.Owner = записи_Objest.UnigueID.UGuid;

				record1.Каса = записи_Objest.Каса;
				record2.Каса = записи_Objest.КасаПереміщення;

				record1.Сума = record2.Сума = записи_Objest.Сума;

				залишкиКоштів_RecordsSet.Records.Add(record1);
				залишкиКоштів_RecordsSet.Records.Add(record2);
				залишкиКоштів_RecordsSet.Save(записи_Objest.UnigueID.UGuid);
			}
            else
            {
				РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record record = new РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record();

				if (записи_Objest.ТипЗапису == Перелічення.ТипЗапису.Витрати || записи_Objest.ТипЗапису == Перелічення.ТипЗапису.Благодійність)
					record.Income = false;
				else if (записи_Objest.ТипЗапису == Перелічення.ТипЗапису.Поступлення)
					record.Income = true;

				record.Owner = записи_Objest.UnigueID.UGuid;
				record.Каса = записи_Objest.Каса;
				record.Сума = записи_Objest.Сума;

				залишкиКоштів_RecordsSet.Records.Add(record);
				залишкиКоштів_RecordsSet.Save(записи_Objest.UnigueID.UGuid);
			}	
		}


		private void buttonOpenBrouser_Click(object sender, EventArgs e)
        {
			System.Diagnostics.Process.Start("firefox.exe", textBoxUrlLink.Text);
		}
    }
}
