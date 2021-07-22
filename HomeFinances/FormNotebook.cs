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
    public partial class FormNotebook : Form
    {
        public FormNotebook()
        {
            InitializeComponent();
        }

		#region DirectoryControl Open Form

		/// <summary>
		/// Ссилка на елемент довідника
		/// </summary>
		public DirectoryPointer DirectoryPointerItem { get; set; }

		/// <summary>
		/// Контрол який викликав вибір
		/// </summary>
		public DirectoryControl DirectoryControlItem { get; set; }

		#endregion

		private void FormNotebook_Load(object sender, EventArgs e)
        {
			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["Назва"].Width = 300;

			//dataGridViewRecords.Columns["Назва"].CellType = DataGridViewImageCell;

			LoadRecords();
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		public void LoadRecords()
		{
			int selectRow = dataGridViewRecords.SelectedRows.Count > 0 ?
				dataGridViewRecords.SelectedRows[dataGridViewRecords.SelectedRows.Count - 1].Index : 0;

			RecordsBindingList.Clear();

			Довідники.Записник_Папки_Select записник_Папки_Select = new Довідники.Записник_Папки_Select();

			записник_Папки_Select.QuerySelect.Field.Add(Довідники.Записник_Папки_Select.Назва);
			записник_Папки_Select.QuerySelect.Order.Add(Довідники.Записник_Папки_Select.Назва, SelectOrder.ASC);

			записник_Папки_Select.Select();

			while (записник_Папки_Select.MoveNext())
			{
				Довідники.Записник_Папки_Pointer cur = записник_Папки_Select.Current;

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					true,
					cur.Fields[Довідники.Записник_Папки_Select.Назва].ToString()
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
			public Записи(string _id, bool _IsGroup, string _Назва)
			{
				ID = _id;
				Назва = _Назва;
				IsGroup = _IsGroup;
			}
			public string ID { get; set; }
			public bool IsGroup { get; set; }
			public string Назва { get; set; }

		}

        private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.RowIndex >= 0 && e.RowIndex < dataGridViewRecords.RowCount)
			{
				string Uid = dataGridViewRecords.Rows[e.RowIndex].Cells["ID"].Value.ToString();

				if (DirectoryControlItem != null)
				{
					DirectoryControlItem.DirectoryPointerItem = new Довідники.Записник_Папки_Pointer(new UnigueID(Uid));
					this.Close();
				}
				else
				{
					toolStripButtonEdit_Click(this, null);
				}
			}
		}

        private void toolStripButtonAdd_Click(object sender, EventArgs e)
        {
            FormAddNotebookFolder formAddNotebookFolder = new FormAddNotebookFolder();
			formAddNotebookFolder.IsNew = true;
			formAddNotebookFolder.OwnerForm = this;
			formAddNotebookFolder.ShowDialog();
        }

        private void toolStripButtonEdit_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				FormAddNotebookFolder formAddNotebookFolder = new FormAddNotebookFolder();
				formAddNotebookFolder.OwnerForm = this;
				formAddNotebookFolder.IsNew = false;
				formAddNotebookFolder.Uid = dataGridViewRecords.Rows[RowIndex].Cells[0].Value.ToString();
				formAddNotebookFolder.ShowDialog();
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

					Довідники.Записник_Папки_Objest записник_Папки_Objest = new Довідники.Записник_Папки_Objest();
					if (записник_Папки_Objest.Read(new UnigueID(uid)))
					{
						Довідники.Записник_Папки_Objest записник_Папки_Objest_Новий = new Довідники.Записник_Папки_Objest();
						записник_Папки_Objest_Новий.New();
						записник_Папки_Objest_Новий.Назва = "(Копія) - " + записник_Папки_Objest.Назва;
						записник_Папки_Objest_Новий.Save();
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

					Довідники.Записник_Папки_Objest записник_Папки_Objest = new Довідники.Записник_Папки_Objest();
					if (записник_Папки_Objest.Read(new UnigueID(uid)))
					{
						записник_Папки_Objest.Delete();
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

        private void dataGridViewRecords_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
			if (dataGridViewRecords.Columns[e.ColumnIndex].Name == "Назва")
            {
				e.CellStyle.BackColor = Color.Azure;
            }
        }
    }
}
