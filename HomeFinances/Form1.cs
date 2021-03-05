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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			string pathToConfa = @"D:\AS_Config\HomeFinances\HomeFinances\HomeFinances\Configurator\Confa.xml";

			Exception exception = null;

			Конфа.Config.Kernel = new Kernel();

			//Підключення до бази даних
			bool flag = Конфа.Config.Kernel.Open2(pathToConfa,
					"localhost",
					"postgres",
					"525491",
					5432,
					"home_finances", out exception);

			if (exception != null)
			{
				MessageBox.Show(exception.Message);
				return;
			}

			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns[0].Visible = false;
			dataGridViewRecords.Columns[1].Width = 300;
			dataGridViewRecords.Columns[2].Width = 130;
			dataGridViewRecords.Columns[3].Width = 80;
			dataGridViewRecords.Columns[4].HeaderText = "Н.Сума";
			dataGridViewRecords.Columns[4].Width = 80;

			LoadRecords();		
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		public void LoadRecords()
		{
			int selectRow = dataGridViewRecords.SelectedRows.Count > 0 ?
				dataGridViewRecords.SelectedRows[dataGridViewRecords.SelectedRows.Count - 1].Index : 0;

			RecordsBindingList.Clear();

			Довідники.Записи_Select записи_Select = new Довідники.Записи_Select();

			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.ДатаЗапису);
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.Назва);
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.Сума);
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.ТипЗапису);

			записи_Select.QuerySelect.Order.Add(Довідники.Записи_Select.ДатаЗапису, SelectOrder.DESC);

			записи_Select.Select();

			int allSuma = 0;

			while (записи_Select.MoveNext())
			{
				Довідники.Записи_Pointer cur = записи_Select.Current;

				Перелічення.ТипЗапису типЗапису = (Перелічення.ТипЗапису)cur.Fields[Довідники.Записи_Select.ТипЗапису];

				if (типЗапису == Перелічення.ТипЗапису.Витрати)
					allSuma = allSuma - int.Parse(cur.Fields[Довідники.Записи_Select.Сума].ToString());
				else
					allSuma = allSuma + int.Parse(cur.Fields[Довідники.Записи_Select.Сума].ToString());

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					cur.Fields[Довідники.Записи_Select.Назва].ToString(),
					cur.Fields[Довідники.Записи_Select.ДатаЗапису].ToString(),
					cur.Fields[Довідники.Записи_Select.Сума].ToString(),
					allSuma.ToString()
					));
			}

			if (selectRow != 0 && selectRow < dataGridViewRecords.Rows.Count)
			{
				dataGridViewRecords.Rows[0].Selected = false;
				dataGridViewRecords.Rows[selectRow].Selected = true;
			}
		}

		private void menuAddRecordToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FormAddRecord formAddRecord = new FormAddRecord();
			formAddRecord.IsNew = true;
			formAddRecord.OwnerForm = this;
			formAddRecord.Show();
		}

		private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.RowIndex < dataGridViewRecords.RowCount)
			{
				FormAddRecord formAddRecord = new FormAddRecord();
				formAddRecord.OwnerForm = this;
				formAddRecord.IsNew = false;
				formAddRecord.Uid = dataGridViewRecords.Rows[e.RowIndex].Cells[0].Value.ToString();
				formAddRecord.Show();
			}
		}

		private void toolStripButtonRefresh_Click(object sender, EventArgs e)
		{
			LoadRecords();
		}

		private void toolStripButtonAdd_Click(object sender, EventArgs e)
		{
			menuAddRecordToolStripMenuItem_Click(this, EventArgs.Empty);
		}

		private void toolStripButtonDelete_Click(object sender, EventArgs e)
		{
			if (dataGridViewRecords.SelectedRows.Count != 0 && 
				MessageBox.Show("Видалити записи?","Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Записи_Objest записи_Objest = new Довідники.Записи_Objest();
					if (записи_Objest.Read(new UnigueID(uid)))
					{
						записи_Objest.Delete();
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

		private void toolStripButtonCopy_Click(object sender, EventArgs e)
		{
			if (dataGridViewRecords.SelectedRows.Count != 0 &&
				MessageBox.Show("Копіювати записи?", "Повідомлення", MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				for (int i = 0; i < dataGridViewRecords.SelectedRows.Count; i++)
				{
					DataGridViewRow row = dataGridViewRecords.SelectedRows[i];
					string uid = row.Cells[0].Value.ToString();

					Довідники.Записи_Objest записи_Objest = new Довідники.Записи_Objest();
					if (записи_Objest.Read(new UnigueID(uid)))
					{
						Довідники.Записи_Objest записи_Objest_Новий = new Довідники.Записи_Objest();
						записи_Objest_Новий.New();
						записи_Objest_Новий.ДатаЗапису = записи_Objest.ДатаЗапису;
						записи_Objest_Новий.Назва = "(Копія) - " + записи_Objest.Назва;
						записи_Objest_Новий.Опис = записи_Objest.Опис;
						записи_Objest_Новий.Сума = записи_Objest.Сума;
						записи_Objest_Новий.ТипЗапису = записи_Objest.ТипЗапису;
						записи_Objest_Новий.Save();
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

	public class Записи
	{
		public Записи(string _id, string _Назва, string _ДатаЗапису, string _Сума, string _НаростаючаСума)
		{
			ID = _id;
			Назва = _Назва;
			ДатаЗапису = _ДатаЗапису;
			Сума = _Сума;
			НаростаючаСума = _НаростаючаСума;
		}

		public string ID { get; set; }
		public string Назва { get; set; }
		public string ДатаЗапису { get; set; }
		public string Сума { get; set; }
		public string НаростаючаСума { get; set; }
	}
}
