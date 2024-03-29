﻿/*
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
    public partial class FormAddContacts : Form
    {
        public FormAddContacts()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Форма списку
		/// </summary>
        public FormContacts OwnerForm { get; set; }
        
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
        private Довідники.Контакти_Objest контакти_Objest { get; set; }

        private void FormAddContacts_Load(object sender, EventArgs e)
        {
			if (IsNew.HasValue)
			{
				контакти_Objest = new Довідники.Контакти_Objest();

				if (IsNew.Value)
				{
					this.Text += " - Новий запис";
				}
				else
				{
					if (контакти_Objest.Read(new UnigueID(Uid)))
					{
						this.Text += " - Редагування запису - " + контакти_Objest.Назва;

						textBoxName.Text = контакти_Objest.Назва;
						textBoxPhone.Text = контакти_Objest.Телефон;
						textBoxEmail.Text = контакти_Objest.Пошта;
						textBoxSkype.Text = контакти_Objest.Скайп;
						textBoxSite.Text = контакти_Objest.Сайт;
						textBoxDesc.Text = контакти_Objest.Опис;
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
					контакти_Objest.New();

				try
				{
					контакти_Objest.Назва = textBoxName.Text;
					контакти_Objest.Телефон = textBoxPhone.Text;
					контакти_Objest.Пошта = textBoxEmail.Text;
					контакти_Objest.Сайт = textBoxSite.Text;
					контакти_Objest.Опис = textBoxDesc.Text;
					контакти_Objest.Скайп = textBoxSkype.Text;

					контакти_Objest.Save();
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
