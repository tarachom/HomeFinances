﻿using System;
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
    public partial class FormCash : Form
    {
        public FormCash()
        {
            InitializeComponent();
        }

		private DirectoryPointer mDirectoryPointerItem;
		public DirectoryPointer DirectoryPointerItem
		{
			get
			{
				return mDirectoryPointerItem;
			}

			set
			{
				mDirectoryPointerItem = value;

				if (mDirectoryPointerItem != null)
				{

				}
			}
		}

		public DirectoryControl DC { get; set; }

		private void FormDirectoryList_Load(object sender, EventArgs e)
        {
			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["Назва"].Width = 300;

			LoadRecords();
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		public void LoadRecords()
		{
			int selectRow = dataGridViewRecords.SelectedRows.Count > 0 ?
				dataGridViewRecords.SelectedRows[dataGridViewRecords.SelectedRows.Count - 1].Index : 0;

			RecordsBindingList.Clear();

			Довідники.Каса_Select каса_Select = new Довідники.Каса_Select();

			каса_Select.QuerySelect.Field.Add(Довідники.Каса_Select.Назва);
			каса_Select.QuerySelect.Field.Add(Довідники.Каса_Select.Валюта);
			каса_Select.QuerySelect.Field.Add(Довідники.Каса_Select.ТипВалюти);
			каса_Select.QuerySelect.Order.Add(Довідники.Каса_Select.Назва, SelectOrder.ASC);

			//Створення тимчасової таблиці
			каса_Select.QuerySelect.CreateTempTable = true;
			каса_Select.Select();

			Dictionary<string, string> dictionaryCurrency = new Dictionary<string, string>();

			Довідники.Валюта_Select валюта_Select = new Довідники.Валюта_Select();
			валюта_Select.QuerySelect.Field.Add(Довідники.Валюта_Select.Назва);
			валюта_Select.QuerySelect.Where.Add(new Where("uid", Comparison.IN, "SELECT DISTINCT " + Довідники.Каса_Select.Валюта + " FROM " + каса_Select.QuerySelect.TempTable, true));
			валюта_Select.Select();

			while (валюта_Select.MoveNext())
			{
				Довідники.Валюта_Pointer cur = валюта_Select.Current;
				dictionaryCurrency.Add(cur.UnigueID.ToString(), cur.Fields[Довідники.Валюта_Select.Назва].ToString());
			}

			//Видалення тимчасової таблиці
			каса_Select.DeleteTempTable();

			//Нормальна вибірка даних
			каса_Select.Select();

			while (каса_Select.MoveNext())
			{
				Довідники.Каса_Pointer cur = каса_Select.Current;

				string ТипВалютиПредставлення = ((Перелічення.ТипВалюти)cur.Fields[Довідники.Каса_Select.ТипВалюти]).ToString();

				Довідники.Валюта_Pointer Валюта = new Довідники.Валюта_Pointer(new UnigueID(cur.Fields[Довідники.Каса_Select.Валюта].ToString()));
				string ВалютаПредставлення = (!Валюта.IsEmpty() && dictionaryCurrency.ContainsKey(Валюта.UnigueID.ToString())) ? dictionaryCurrency[Валюта.UnigueID.ToString()] : "";

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					cur.Fields[Довідники.Каса_Select.Назва].ToString(),
					ВалютаПредставлення,
					ТипВалютиПредставлення
					));

				if (DirectoryPointerItem != null && selectRow == 0) //??
					if (cur.UnigueID.ToString() == DirectoryPointerItem.UnigueID.ToString())
					{
						dataGridViewRecords.Rows[0].Selected = false;
						dataGridViewRecords.Rows[RecordsBindingList.Count - 1].Selected = true;
					}
			}

			if (selectRow != 0 && selectRow < dataGridViewRecords.Rows.Count)
			{
				dataGridViewRecords.Rows[0].Selected = false;
				dataGridViewRecords.Rows[selectRow].Selected = true;
			}
		}

		private class Записи
		{
			public Записи(string _id, string _Назва, string _Валюта, string _ТипВалюти)
			{
				ID = _id;
				Назва = _Назва;
				Валюта = _Валюта;
				ТипВалюти = _ТипВалюти;
			}
			public string ID { get; set; }
			public string Назва { get; set; }
			public string Валюта { get; set; }
			public string ТипВалюти { get; set; }
		}

        private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			string Uid = dataGridViewRecords.Rows[e.RowIndex].Cells["ID"].Value.ToString();

			if (DC != null)
            {
				DC.DirectoryPointerItem = new Довідники.Каса_Pointer(new UnigueID(Uid));
				this.Close();
			}
            else
            {
				toolStripButtonEdit_Click(this, null);
			}
		}

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
			FormAddCash formAddCash = new FormAddCash();
			formAddCash.IsNew = true;
			formAddCash.OwnerForm = this;
			formAddCash.ShowDialog();
		}

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				FormAddCash formAddCash = new FormAddCash();
				formAddCash.OwnerForm = this;
				formAddCash.IsNew = false;
				formAddCash.Uid = dataGridViewRecords.Rows[RowIndex].Cells[0].Value.ToString();
				formAddCash.ShowDialog();
			}			
		}

        private void toolStripButtonRefresh_Click(object sender, EventArgs e)
        {
			LoadRecords();
		}

        private void toolStripButtonCopy_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count != 0 &&
				MessageBox.Show("Копіювати записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Каса_Objest каса_Objest = new Довідники.Каса_Objest();
					if (каса_Objest.Read(new UnigueID(uid)))
					{
						Довідники.Каса_Objest каса_Objest_Новий = new Довідники.Каса_Objest();
						каса_Objest_Новий.New();
						каса_Objest_Новий.Назва = "(Копія) - " + каса_Objest.Назва;
						каса_Objest_Новий.Save();
					}
					else
					{
						MessageBox.Show("Error read");
						break;
					}
				}

				LoadRecords();
			}
		}

        private void toolStripButtonDelete_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count != 0 &&
				MessageBox.Show("Видалити записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Каса_Objest каса_Objest = new Довідники.Каса_Objest();
					if (каса_Objest.Read(new UnigueID(uid)))
					{
						каса_Objest.Delete();
					}
					else
					{
						MessageBox.Show("Error read");
						break;
					}
				}

				LoadRecords();
			}
		}
    }
}