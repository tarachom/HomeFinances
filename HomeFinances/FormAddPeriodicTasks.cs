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
