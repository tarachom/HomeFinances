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
    public partial class FormAddCostСlassifier : Form
    {
        public FormAddCostСlassifier()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Форма списку
		/// </summary>
        public FormCostСlassifier OwnerForm { get; set; }
        
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
        private Довідники.КласифікаторВитрат_Objest класифікаторВитрат_Objest { get; set; }

        private void FormAddCostСlassifier_Load(object sender, EventArgs e)
        {
			if (IsNew.HasValue)
			{
				класифікаторВитрат_Objest = new Довідники.КласифікаторВитрат_Objest();

				if (IsNew.Value)
				{
					this.Text += " - Новий запис";
				}
				else
				{
					if (класифікаторВитрат_Objest.Read(new UnigueID(Uid)))
					{
						textBoxName.Text = класифікаторВитрат_Objest.Назва;
						textBoxCode.Text = класифікаторВитрат_Objest.Код;

						this.Text += " - Редагування запису - " + класифікаторВитрат_Objest.Назва;
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
					класифікаторВитрат_Objest.New();

				try
				{
					класифікаторВитрат_Objest.Назва = textBoxName.Text;
					класифікаторВитрат_Objest.Код = textBoxCode.Text;
					класифікаторВитрат_Objest.Save();
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
