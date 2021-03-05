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

			LoadRecords();		
		}

		private BindingList<Записи> RecordsBindingList { get; set; }

		public void LoadRecords()
		{
			RecordsBindingList.Clear();

			Довідники.Записи_Select записи_Select = new Довідники.Записи_Select();

			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.ДатаЗапису);
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.Назва);
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.Сума);

			записи_Select.QuerySelect.Order.Add(Довідники.Записи_Select.ДатаЗапису, SelectOrder.ASC);

			записи_Select.Select();

			while (записи_Select.MoveNext())
			{
				Довідники.Записи_Pointer cur = записи_Select.Current;

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					cur.Fields[Довідники.Записи_Select.Назва].ToString(),
					cur.Fields[Довідники.Записи_Select.ДатаЗапису].ToString(),
					cur.Fields[Довідники.Записи_Select.Сума].ToString()
					));
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

		
	}

	public class Записи
	{
		public Записи(string _id, string _Назва, string _ДатаЗапису, string _Сума)
		{
			ID = _id;
			Назва = _Назва;
			ДатаЗапису = _ДатаЗапису;
			Сума = _Сума;
		}

		public string ID { get; set; }
		public string Назва { get; set; }
		public string ДатаЗапису { get; set; }
		public string Сума { get; set; }
	}
}
