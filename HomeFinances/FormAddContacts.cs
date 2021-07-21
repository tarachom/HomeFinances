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
    public partial class FormAddContacts : Form
    {
        public FormAddContacts()
        {
            InitializeComponent();
        }

        public FormContacts OwnerForm { get; set; }
        
        public Nullable<bool> IsNew { get; set; }

        public string Uid { get; set; }

        private Довідники.Контакти_Objest контакти_Objest { get; set; }

        private void FormAddContacts_Load(object sender, EventArgs e)
        {
			if (IsNew.HasValue)
			{
				контакти_Objest = new Довідники.Контакти_Objest();

				if (IsNew.Value)
				{
					this.Text = "Новий запис";
				}
				else
				{
					if (контакти_Objest.Read(new UnigueID(Uid)))
					{
						textBoxName.Text = контакти_Objest.Назва;
						

						this.Text = "Редагування запису - " + контакти_Objest.Назва;
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
					контакти_Objest.New();
				}

				try
				{
					контакти_Objest.Назва = textBoxName.Text;
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
