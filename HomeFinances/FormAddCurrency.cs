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
    public partial class FormAddCurrency : Form
    {
        public FormAddCurrency()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Форма списку
		/// </summary>
        public FormCurrency OwnerForm { get; set; }
        
		/// <summary>
		/// Чи це новий запис
		/// </summary>
        public Nullable<bool> IsNew { get; set; }

		/// <summary>
		/// Ід запису
		/// </summary>
        public string Uid { get; set; }

		/// <summary>
		/// Обєкт запису
		/// </summary>
        private Довідники.Валюта_Objest валюта_Objest { get; set; }

        private void FormAddCostСlassifier_Load(object sender, EventArgs e)
        {
			if (IsNew.HasValue)
			{
				валюта_Objest = new Довідники.Валюта_Objest();

				if (IsNew.Value)
				{
					this.Text += " - Новий запис";
				}
				else
				{
					if (валюта_Objest.Read(new UnigueID(Uid)))
					{
						textBoxName.Text = валюта_Objest.Назва;
						textBoxCode.Text = валюта_Objest.Код;

						this.Text += " - Редагування запису - " + валюта_Objest.Назва;
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
					валюта_Objest.New();

				try
				{
					валюта_Objest.Назва = textBoxName.Text;
					валюта_Objest.Код = textBoxCode.Text;
					валюта_Objest.Save();
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
