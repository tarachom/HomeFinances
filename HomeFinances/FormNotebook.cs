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
			ParentFolder = new Довідники.Записник_Папки_Pointer();

			if (DirectoryControlItem != null && DirectoryPointerItem != null)
			{
				Довідники.Записник_Папки_Pointer localParentFolder = new Довідники.Записник_Папки_Pointer(DirectoryPointerItem.UnigueID);
				if (!localParentFolder.IsEmpty())
					ParentFolder = localParentFolder.GetDirectoryObject().Родич;
			}	

			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["IsFolder"].Visible = false;
			dataGridViewRecords.Columns["IsParentFolder"].Visible = false;
			dataGridViewRecords.Columns["Назва"].Width = 500;
			dataGridViewRecords.Columns["Дата"].Width = 120;

			DataGridViewImageColumn dataGridViewImageColumn = new DataGridViewImageColumn();
			dataGridViewImageColumn.Name = "Folder";
			dataGridViewImageColumn.HeaderText = "...";
			dataGridViewImageColumn.DisplayIndex = 1;
			dataGridViewImageColumn.Width = 20;
			dataGridViewRecords.Columns.Add(dataGridViewImageColumn);

			LoadRecords();
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		private Довідники.Записник_Папки_Pointer ParentFolder { get; set; }

		public void LoadRecords()
		{
			//int selectRow = dataGridViewRecords.SelectedRows.Count > 0 ?
			//	dataGridViewRecords.SelectedRows[dataGridViewRecords.SelectedRows.Count - 1].Index : 0;

			RecordsBindingList.Clear();

			Довідники.Записник_Папки_Pointer CopyParentFolder = ParentFolder;
			int countIteration = 0;

			while (!CopyParentFolder.IsEmpty())
            {
				RecordsBindingList.Insert(0, new Записи(
					CopyParentFolder.UnigueID.ToString(),
					false,
					true,
					CopyParentFolder.GetPresentation(),
					"" //Дата
					));

				CopyParentFolder = CopyParentFolder.GetDirectoryObject().Родич;
				countIteration++;

				if (countIteration > 10)
					break;
			}

			//Групи
			Довідники.Записник_Папки_Select записник_Папки_Select = new Довідники.Записник_Папки_Select();

			записник_Папки_Select.QuerySelect.Field.Add(Довідники.Записник_Папки_Select.Назва);
			записник_Папки_Select.QuerySelect.Where.Add(new Where(Довідники.Записник_Папки_Select.Родич, Comparison.EQ, ParentFolder.UnigueID.UGuid));

			записник_Папки_Select.QuerySelect.Order.Add(Довідники.Записник_Папки_Select.Назва, SelectOrder.ASC);

			записник_Папки_Select.Select();

			while (записник_Папки_Select.MoveNext())
			{
				Довідники.Записник_Папки_Pointer cur = записник_Папки_Select.Current;

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					true,
					false,
					cur.Fields[Довідники.Записник_Папки_Select.Назва].ToString(),
					"" //Дата
					));

				if (DirectoryPointerItem != null) //??
					if (cur.UnigueID.ToString() == DirectoryPointerItem.UnigueID.ToString())
					{
						dataGridViewRecords.Rows[0].Selected = false;
						dataGridViewRecords.Rows[RecordsBindingList.Count - 1].Selected = true;
					}
			}

			//Елементи
			Довідники.Записник_Select записник_Select = new Довідники.Записник_Select();

			записник_Select.QuerySelect.Field.Add(Довідники.Записник_Select.Назва);
			записник_Select.QuerySelect.Field.Add(Довідники.Записник_Select.Дата);
			записник_Select.QuerySelect.Where.Add(new Where(Довідники.Записник_Select.Папка, Comparison.EQ, ParentFolder.UnigueID.UGuid));

			записник_Select.QuerySelect.Order.Add(Довідники.Записник_Select.Назва, SelectOrder.ASC);

			записник_Select.Select();

			while (записник_Select.MoveNext())
			{
				Довідники.Записник_Pointer cur = записник_Select.Current;

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					false,
					false,
					cur.Fields[Довідники.Записник_Select.Назва].ToString(),
					cur.Fields[Довідники.Записник_Select.Дата].ToString()
					));

				//if (DirectoryPointerItem != null && selectRow == 0) //??
				//	if (cur.UnigueID.ToString() == DirectoryPointerItem.UnigueID.ToString())
				//	{
				//		dataGridViewRecords.Rows[0].Selected = false;
				//		dataGridViewRecords.Rows[RecordsBindingList.Count - 1].Selected = true;
				//	}
			}

			//if (selectRow != 0 && selectRow < dataGridViewRecords.Rows.Count)
			//{
			//	dataGridViewRecords.Rows[0].Selected = false;
			//	dataGridViewRecords.Rows[selectRow].Selected = true;
			//}
		}

		private class Записи
		{
			public Записи(string _id, bool _IsFolder, bool _IsParentFolder, string _Назва, string _Дата)
			{
				ID = _id;
				Назва = _Назва;
				IsFolder = _IsFolder;
				IsParentFolder = _IsParentFolder;
				Дата = _Дата;
			}
			public string ID { get; set; }
			public bool IsFolder { get; set; }
			public bool IsParentFolder { get; set; }
			public string Назва { get; set; }
			public string Дата { get; set; }
		}

        private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			if (e.RowIndex >= 0 && e.RowIndex < dataGridViewRecords.RowCount)
			{
				string Uid = dataGridViewRecords.Rows[e.RowIndex].Cells["ID"].Value.ToString();
				bool isFolder = (bool)dataGridViewRecords.Rows[e.RowIndex].Cells["IsFolder"].Value;
				bool isParentFolder = (bool)dataGridViewRecords.Rows[e.RowIndex].Cells["IsParentFolder"].Value;

				if (DirectoryControlItem != null && dataGridViewRecords.Columns[e.ColumnIndex].Name == "Folder")
				{
					DirectoryControlItem.DirectoryPointerItem = new Довідники.Записник_Папки_Pointer(new UnigueID(Uid));
					this.Close();
				}
				else
				{
					if (isFolder)
					{
						ParentFolder = new Довідники.Записник_Папки_Pointer(new UnigueID(Uid));
						LoadRecords();
					}

					if (isParentFolder)
					{
						Довідники.Записник_Папки_Pointer записник_Папки_Pointer = new Довідники.Записник_Папки_Pointer(new UnigueID(Uid));
						ParentFolder = записник_Папки_Pointer.GetDirectoryObject().Родич;
						LoadRecords();
					}
				}
            }
        }

		private void toolStripButtonAddFolder_Click(object sender, EventArgs e)
		{
			FormAddNotebookFolder formAddNotebookFolder = new FormAddNotebookFolder();
			formAddNotebookFolder.IsNew = true;
			formAddNotebookFolder.OwnerForm = this;
			formAddNotebookFolder.ShowDialog();
		}

		private void toolStripButtonAddElement_Click(object sender, EventArgs e)
		{
			FormAddNotebookElement formAddNotebookElement = new FormAddNotebookElement();
			formAddNotebookElement.IsNew = true;
			formAddNotebookElement.OwnerForm = this;
			formAddNotebookElement.ShowDialog();
		}

		private void toolStripButtonEditFolder_Click(object sender, EventArgs e)
        {
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				if ((bool)dataGridViewRecords.Rows[RowIndex].Cells["IsFolder"].Value == true && 
					(bool)dataGridViewRecords.Rows[RowIndex].Cells["IsParentFolder"].Value == false)
				{
					FormAddNotebookFolder formAddNotebookFolder = new FormAddNotebookFolder();
					formAddNotebookFolder.OwnerForm = this;
					formAddNotebookFolder.IsNew = false;
					formAddNotebookFolder.Uid = dataGridViewRecords.Rows[RowIndex].Cells[0].Value.ToString();
					formAddNotebookFolder.ShowDialog();
				}
            }
		}

		private void toolStripButtonEditElement_Click(object sender, EventArgs e)
		{
			if (dataGridViewRecords.SelectedRows.Count > 0)
			{
				int RowIndex = dataGridViewRecords.SelectedRows[0].Index;

				if ((bool)dataGridViewRecords.Rows[RowIndex].Cells["IsFolder"].Value == false && 
					(bool)dataGridViewRecords.Rows[RowIndex].Cells["IsParentFolder"].Value == false)
				{
					FormAddNotebookElement formAddNotebookElement = new FormAddNotebookElement();
					formAddNotebookElement.OwnerForm = this;
					formAddNotebookElement.IsNew = false;
					formAddNotebookElement.Uid = dataGridViewRecords.Rows[RowIndex].Cells[0].Value.ToString();
					formAddNotebookElement.ShowDialog();
				}
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
			if (dataGridViewRecords.Columns[e.ColumnIndex].Name == "Folder")
            {
				bool isFolder = (bool)dataGridViewRecords["IsFolder", e.RowIndex].Value;
				bool isParentFolder = (bool)dataGridViewRecords["IsParentFolder", e.RowIndex].Value;

				if (isFolder)
				{
					e.Value = Image.FromFile(@"C:\Users\Administrator\Desktop\2\folder.png");
				}
				else if (isParentFolder)
				{
					e.Value = Image.FromFile(@"C:\Users\Administrator\Desktop\2\layers.png");
				}
                else
                {
					e.Value = Image.FromFile(@"C:\Users\Administrator\Desktop\2\application_form.png"); 
				}
			}
        }

        
    }
}
