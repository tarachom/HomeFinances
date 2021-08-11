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
    public partial class FormAddPeriodicTasks : Form
    {
        public FormAddPeriodicTasks()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Форма списку
		/// </summary>
        public FormPeriodicTasks OwnerForm { get; set; }
        
		/// <summary>
		/// Чи це новий
		/// </summary>
        public Nullable<bool> IsNew { get; set; }

		/// <summary>
		/// Ід запису
		/// </summary>
        public string Uid { get; set; }

		/// <summary>
		/// Обєкт запису
		/// </summary>
        private Довідники.КалендарПеріодичнихЗавдань_Objest календарПеріодичнихЗавдань_Objest { get; set; }

		private void FormAddCash_Load(object sender, EventArgs e)
        {
			//Заповнення елементів перелічення
			foreach (ConfigurationEnumField field in Конфа.Config.Kernel.Conf.Enums["ПеріодиВиконанняЗавдань"].Fields.Values)
				comboBoxTypeCurrency.Items.Add((Перелічення.ПеріодиВиконанняЗавдань)field.Value);

			if (IsNew.HasValue)
			{
				календарПеріодичнихЗавдань_Objest = new Довідники.КалендарПеріодичнихЗавдань_Objest();

				if (IsNew.Value)
				{
					this.Text += " - Новий запис";

					comboBoxTypeCurrency.SelectedIndex = 0;
				}
				else
				{
					if (календарПеріодичнихЗавдань_Objest.Read(new UnigueID(Uid)))
					{
						this.Text += " - Редагування запису - " + календарПеріодичнихЗавдань_Objest.Назва;

						textBoxName.Text = календарПеріодичнихЗавдань_Objest.Назва;
						comboBoxTypeCurrency.SelectedItem = календарПеріодичнихЗавдань_Objest.ПеріодВиконання;
						textBoxDesc.Text = календарПеріодичнихЗавдань_Objest.Опис;
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
					календарПеріодичнихЗавдань_Objest.New();

				try
				{
					календарПеріодичнихЗавдань_Objest.Назва = textBoxName.Text;
					календарПеріодичнихЗавдань_Objest.ПеріодВиконання = (Перелічення.ПеріодиВиконанняЗавдань)comboBoxTypeCurrency.SelectedItem;
					календарПеріодичнихЗавдань_Objest.Опис = textBoxDesc.Text;
					календарПеріодичнихЗавдань_Objest.Save();
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

		private void buttonClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
