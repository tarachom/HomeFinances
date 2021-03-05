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
	public partial class FormAddRecord : Form
	{
		public FormAddRecord()
		{
			InitializeComponent();
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		public Form1 OwnerForm { get; set; }

		private void FormAddRecord_Load(object sender, EventArgs e)
		{
			dateTimePickerRecord.Value = DateTime.Now;

			comboBoxTypeRecord.Items.Add(Перелічення.ТипЗапису.Витрати);
			comboBoxTypeRecord.Items.Add(Перелічення.ТипЗапису.Поступлення);

			comboBoxTypeRecord.SelectedIndex = 0;

			maskedTextBoxSuma.Text = "0";
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			try
			{
				Довідники.Записи_Objest записи_Objest = new Довідники.Записи_Objest();
				записи_Objest.New();
				записи_Objest.ДатаЗапису = dateTimePickerRecord.Value;
				записи_Objest.Назва = textBoxName.Text;
				записи_Objest.Опис = textBoxOpys.Text;
				записи_Objest.ТипЗапису = (Перелічення.ТипЗапису)comboBoxTypeRecord.SelectedItem;
				записи_Objest.Сума = int.Parse(maskedTextBoxSuma.Text);
				записи_Objest.Save();

				if (OwnerForm != null)
					OwnerForm.LoadRecords();

				this.Close();
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message);
			}
		}
	}
}
