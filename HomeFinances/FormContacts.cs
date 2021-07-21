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
    public partial class FormContacts : Form
    {
        public FormContacts()
        {
            InitializeComponent();
        }

		private DirectoryPointer mDirectoryPointerItemSelect;
		public DirectoryPointer DirectoryPointerItemSelect
		{
			get
			{
				return mDirectoryPointerItemSelect;
			}

			set
			{
				mDirectoryPointerItemSelect = value;

				if (mDirectoryPointerItemSelect != null)
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

			Довідники.Контакти_Select контакти_Select = new Довідники.Контакти_Select();

			контакти_Select.QuerySelect.Field.Add(Довідники.Контакти_Select.Назва);
			контакти_Select.QuerySelect.Order.Add(Довідники.Контакти_Select.Назва, SelectOrder.ASC);

			контакти_Select.Select();

			while (контакти_Select.MoveNext())
			{
				Довідники.Контакти_Pointer cur = контакти_Select.Current;

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					cur.Fields[Довідники.Контакти_Select.Назва].ToString()
					));

				//if (DirectoryPointerItemSelect != null && selectRow == 0) //??
				//	if (cur.UnigueID.ToString() == DirectoryPointerItemSelect.UnigueID.ToString())
				//	{
				//		dataGridViewRecords.Rows[0].Selected = false;
				//		dataGridViewRecords.Rows[RecordsBindingList.Count - 1].Selected = true;
				//	}
			}

			if (selectRow != 0 && selectRow < dataGridViewRecords.Rows.Count)
			{
				dataGridViewRecords.Rows[0].Selected = false;
				dataGridViewRecords.Rows[selectRow].Selected = true;
			}
		}

		private class Записи
		{
			public Записи(string _id, string _Назва)
			{
				ID = _id;
				Назва = _Назва;
			}
			public string ID { get; set; }
			public string Назва { get; set; }
		}

        private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			string Uid = dataGridViewRecords.Rows[e.RowIndex].Cells["ID"].Value.ToString();

			if (DC != null)
            {
				DC.DirectoryPointerItem = new Довідники.Контакти_Pointer(new UnigueID(Uid));
				this.Close();
			}
            else
            {
				toolStripButtonEdit_Click(this, null);
			}
		}

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
			FormAddContacts formAddContacts = new FormAddContacts();
			formAddContacts.IsNew = true;
			formAddContacts.OwnerForm = this;
			formAddContacts.ShowDialog();
		}

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				FormAddContacts formAddContacts = new FormAddContacts();
				formAddContacts.OwnerForm = this;
				formAddContacts.IsNew = false;
				formAddContacts.Uid = dataGridViewRecords.Rows[RowIndex].Cells[0].Value.ToString();
				formAddContacts.ShowDialog();
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

					Довідники.Контакти_Objest контакти_Objest = new Довідники.Контакти_Objest();
					if (контакти_Objest.Read(new UnigueID(uid)))
					{
						Довідники.Контакти_Objest контакти_Objest_Новий = new Довідники.Контакти_Objest();
						контакти_Objest_Новий.New();
						контакти_Objest_Новий.Назва = "(Копія) - " + контакти_Objest.Назва;
						контакти_Objest_Новий.Save();
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

					Довідники.Контакти_Objest контакти_Objest_Новий = new Довідники.Контакти_Objest();
					if (контакти_Objest_Новий.Read(new UnigueID(uid)))
					{
						контакти_Objest_Новий.Delete();
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
