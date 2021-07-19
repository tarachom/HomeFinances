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

		public FormRecordFinance OwnerForm { get; set; }

		public Nullable<bool> IsNew { get; set; }

		public string Uid { get; set; }

		private Довідники.Записи_Objest записи_Objest { get; set; }

		private void FormAddRecord_Load(object sender, EventArgs e)
		{
			comboBoxTypeRecord.Items.Add(Перелічення.ТипЗапису.Витрати);
			comboBoxTypeRecord.Items.Add(Перелічення.ТипЗапису.Поступлення);
			comboBoxTypeRecord.Items.Add(Перелічення.ТипЗапису.Благодійність);

			if (IsNew.HasValue)
			{
				записи_Objest = new Довідники.Записи_Objest();

				if (IsNew.Value)
				{
					dateTimePickerRecord.Value = DateTime.Now;
					maskedTextBoxTime.Text = DateTime.Now.TimeOfDay.ToString();
					comboBoxTypeRecord.SelectedIndex = 0;
					maskedTextBoxSuma.Text = "0";

					this.Text = "Новий запис";

					directoryControl1.DirectoryPointerItem = new Довідники.КласифікаторВитрат_Pointer();
				}
				else
				{
					if (записи_Objest.Read(new UnigueID(Uid)))
					{
						dateTimePickerRecord.Value = записи_Objest.ДатаЗапису;
						maskedTextBoxTime.Text = записи_Objest.ДатаЗапису.TimeOfDay.ToString();
						textBoxName.Text = записи_Objest.Назва;
						textBoxOpys.Text = записи_Objest.Опис;
						comboBoxTypeRecord.SelectedItem = записи_Objest.ТипЗапису;
						maskedTextBoxSuma.Text = записи_Objest.Сума.ToString();

						this.Text = "Редагування запису - " + записи_Objest.Назва;

						directoryControl1.DirectoryPointerItem = new Довідники.КласифікаторВитрат_Pointer(записи_Objest.Витрата.UnigueID);
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
				{
					записи_Objest.New();
				}

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
	}
}
