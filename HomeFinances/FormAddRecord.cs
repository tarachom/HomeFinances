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

		private void FormAddRecord_Load(object sender, EventArgs e)
		{
			//Заповнення елементів перелічення
			foreach (ConfigurationEnumField field in Конфа.Config.Kernel.Conf.Enums["ТипЗапису"].Fields.Values)
				comboBoxTypeRecord.Items.Add((Перелічення.ТипЗапису)field.Value);

			directoryControl1.CallBack = CallBack_DirectoryControl_Open_FormCostСlassifier;
			directoryControl2.CallBack = CallBack_DirectoryControl_Open_FormCash;

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

					записи_Objest.Save();
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

        private void buttonOpenBrouser_Click(object sender, EventArgs e)
        {
			System.Diagnostics.Process.Start("firefox.exe", textBoxUrlLink.Text);
		}
    }
}
