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

		public Nullable<bool> IsNew { get; set; }

		public string Uid { get; set; }

		private Довідники.Записи_Objest записи_Objest { get; set; }

		private void FormAddRecord_Load(object sender, EventArgs e)
		{
			comboBoxTypeRecord.Items.Add(Перелічення.ТипЗапису.Витрати);
			comboBoxTypeRecord.Items.Add(Перелічення.ТипЗапису.Поступлення);
			comboBoxTypeRecord.Items.Add(Перелічення.ТипЗапису.Благодійність);

			if (IsNew.HasValue)
				if (IsNew.Value)
				{
					dateTimePickerRecord.Value = DateTime.Now;
					comboBoxTypeRecord.SelectedIndex = 0;
					maskedTextBoxSuma.Text = "0";

					this.Text = "Новий запис";

					directoryControl1.DP = new Довідники.КласифікаторВитрат_Pointer();
				}
				else
				{
					записи_Objest = new Довідники.Записи_Objest();
					if (записи_Objest.Read(new UnigueID(Uid)))
					{
						dateTimePickerRecord.Value = записи_Objest.ДатаЗапису;
						textBoxName.Text = записи_Objest.Назва;
						textBoxOpys.Text = записи_Objest.Опис;
						comboBoxTypeRecord.SelectedItem = записи_Objest.ТипЗапису;
						maskedTextBoxSuma.Text = записи_Objest.Сума.ToString();

						this.Text = "Редагування запису - " + записи_Objest.Назва;

						directoryControl1.DP = new Довідники.КласифікаторВитрат_Pointer(записи_Objest.Витрата.UnigueID);
					}
					else
						MessageBox.Show("Error read");
				}
		}

		private void buttonSave_Click(object sender, EventArgs e)
		{
			if (IsNew.HasValue)
				if (IsNew.Value)
				{
					try
					{
						записи_Objest = new Довідники.Записи_Objest();
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
				else
				{
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
		}
	}
}
