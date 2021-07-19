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
    public partial class FormDirectoryList : Form
    {
        public FormDirectoryList()
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
			dataGridViewRecords.Columns["Код"].Width = 130;

			LoadRecords();
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		public void LoadRecords()
		{
			RecordsBindingList.Clear();

			Довідники.КласифікаторВитрат_Select класифікаторВитрат_Select = new Довідники.КласифікаторВитрат_Select();

			класифікаторВитрат_Select.QuerySelect.Field.Add(Довідники.КласифікаторВитрат_Select.Назва);
			класифікаторВитрат_Select.QuerySelect.Field.Add(Довідники.КласифікаторВитрат_Select.Код);

			класифікаторВитрат_Select.Select();

			while (класифікаторВитрат_Select.MoveNext())
			{
				Довідники.КласифікаторВитрат_Pointer cur = класифікаторВитрат_Select.Current;

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					cur.Fields[Довідники.КласифікаторВитрат_Select.Назва].ToString(),
					cur.Fields[Довідники.КласифікаторВитрат_Select.Код].ToString()
					));

				if (DirectoryPointerItemSelect != null)
					if (cur.UnigueID.ToString() == DirectoryPointerItemSelect.UnigueID.ToString())
					{
						dataGridViewRecords.Rows[0].Selected = false;
						dataGridViewRecords.Rows[RecordsBindingList.Count - 1].Selected = true;
					}
			}
		}

		private class Записи
		{
			public Записи(string _id, string _Назва, string _Код)
			{
				ID = _id;
				Назва = _Назва;
				Код = _Код;
			}
			public string ID { get; set; }
			public string Назва { get; set; }
			public string Код { get; set; }

		}

        private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
			string Uid = dataGridViewRecords.Rows[e.RowIndex].Cells["ID"].Value.ToString();
			DC.DirectoryPointerItem = new Довідники.КласифікаторВитрат_Pointer(new UnigueID(Uid));

			this.Hide();
		}
    }
}
