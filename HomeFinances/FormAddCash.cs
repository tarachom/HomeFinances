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
    public partial class FormAddCash : Form
    {
        public FormAddCash()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Форма списку
		/// </summary>
        public FormCash OwnerForm { get; set; }
        
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
        private Довідники.Каса_Objest каса_Objest { get; set; }

		/// <summary>
		/// Зворотня функція для вибору із списку
		/// </summary>
		/// <param name="directoryPointerItem"></param>
		public void CallBack_DirectoryControl_Open_FormCurrency(DirectoryPointer directoryPointerItem)
        {
			FormCurrency formCurrency = new FormCurrency();
			formCurrency.DirectoryPointerItem = directoryPointerItem;
			formCurrency.DirectoryControlItem = directoryControl1;
			formCurrency.ShowDialog();
		}

		private void FormAddCash_Load(object sender, EventArgs e)
        {
			//Заповнення елементів перелічення
			foreach (ConfigurationEnumField field in Конфа.Config.Kernel.Conf.Enums["ТипВалюти"].Fields.Values)
				comboBoxTypeCurrency.Items.Add((Перелічення.ТипВалюти)field.Value);

			directoryControl1.CallBack = CallBack_DirectoryControl_Open_FormCurrency;

			if (IsNew.HasValue)
			{
				каса_Objest = new Довідники.Каса_Objest();

				if (IsNew.Value)
				{
					this.Text += " - Новий запис";

					directoryControl1.DirectoryPointerItem = new Довідники.Валюта_Pointer();
					comboBoxTypeCurrency.SelectedIndex = 0;
				}
				else
				{
					if (каса_Objest.Read(new UnigueID(Uid)))
					{
						this.Text += " - Редагування запису - " + каса_Objest.Назва;

						textBoxName.Text = каса_Objest.Назва;
						directoryControl1.DirectoryPointerItem = new Довідники.Валюта_Pointer(каса_Objest.Валюта.UnigueID);
						comboBoxTypeCurrency.SelectedItem = каса_Objest.ТипВалюти;
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
					каса_Objest.New();

				try
				{
					каса_Objest.Назва = textBoxName.Text;
					каса_Objest.Валюта = (Довідники.Валюта_Pointer)directoryControl1.DirectoryPointerItem;
					каса_Objest.ТипВалюти = (Перелічення.ТипВалюти)comboBoxTypeCurrency.SelectedItem;
					каса_Objest.Save();
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
