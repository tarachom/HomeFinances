using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Xml;
using System.Xml.XPath;

using System.IO;

using AccountingSoftware;
using Конфа = НоваКонфігурація_1_0;
using Константи = НоваКонфігурація_1_0.Константи;
using Довідники = НоваКонфігурація_1_0.Довідники;
using Перелічення = НоваКонфігурація_1_0.Перелічення;

namespace HomeFinances
{
	public partial class FormRecordFinance : System.Windows.Forms.Form
	{
		public FormRecordFinance()
		{
			InitializeComponent();
		}

		private void FormRecordFinance_Load(object sender, EventArgs e)
		{
			string pathToConfa = @"E:\Project\HomeFinaces\HomeFinances\Configurator\Confa.xml";

			Exception exception = null;

			Конфа.Config.Kernel = new Kernel();

			//Підключення до бази даних
			bool flag = Конфа.Config.Kernel.Open2(pathToConfa,
					"localhost",
					"postgres",
					"1",
					5433,
					"home_finances", out exception);

			if (exception != null)
			{
				MessageBox.Show(exception.Message);
				return;
			}

			Конфа.Config.ReadAllConstants();


			dataGridViewRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			RecordsBindingList = new BindingList<Записи>();
			dataGridViewRecords.DataSource = RecordsBindingList;

			dataGridViewRecords.Columns["ID"].Visible = false;
			dataGridViewRecords.Columns["Назва"].Width = 500;

			dataGridViewRecords.Columns["ДатаЗапису"].Width = 120;
			dataGridViewRecords.Columns["ДатаЗапису"].DisplayIndex = 1;

			dataGridViewRecords.Columns["Сума"].Width = 80;
			dataGridViewRecords.Columns["Сума"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			dataGridViewRecords.Columns["Сума"].DisplayIndex = 5;

			dataGridViewRecords.Columns["ТипЗапису"].HeaderText = "Тип";
			dataGridViewRecords.Columns["ТипЗапису"].Width = 80;
			dataGridViewRecords.Columns["ТипЗапису"].DisplayIndex = 0;
			//dataGridViewRecords.Columns["ТипЗапису"].CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
			//dataGridViewRecords.Columns["ТипЗапису"].CellTemplate.Style.Font = new Font("Arial", 11);

			dataGridViewRecords.Columns["Витрата"].Width = 200;

			//Користувач
			//Записи налаштувань користувача

			/*
			Довідники.Користувач_Select користувач = new Довідники.Користувач_Select();
			Довідники.Користувач_Pointer користувач_Ссилка = користувач.FindByField(Довідники.Користувач_Select.Код, "1");
			
			if (користувач_Ссилка.IsEmpty())
            {
				Довідники.Користувач_Objest користувач_НовийЗапис = new Довідники.Користувач_Objest();
				користувач_НовийЗапис.New();
				користувач_НовийЗапис.Код = "1";
				користувач_НовийЗапис.Назва = "Основний";
				користувач_НовийЗапис.Save();

				користувач_Ссилка = користувач_НовийЗапис.GetDirectoryPointer();
			}

			Довідники.Користувач_Objest користувач_Обєкт = користувач_Ссилка.GetDirectoryObject();
			користувач_Обєкт.НалаштуванняФормиЗаписиФінансів_TablePart.Read();

			if (користувач_Обєкт.НалаштуванняФормиЗаписиФінансів_TablePart.Records.Count > 0)
			{
				foreach (Довідники.Користувач_НалаштуванняФормиЗаписиФінансів_TablePart.Record record in
					користувач_Обєкт.НалаштуванняФормиЗаписиФінансів_TablePart.Records)
				{
					if (record.Ключ == "НазваФорми")
					{

					}
				}
			}
			else
			{
				користувач_Обєкт.НалаштуванняФормиЗаписиФінансів_TablePart.Records.Add(
					new Довідники.Користувач_НалаштуванняФормиЗаписиФінансів_TablePart.Record("НазваФорми", "Назва форми"));
				користувач_Обєкт.НалаштуванняФормиЗаписиФінансів_TablePart.Save(true);
			}
			*/

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
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.Витрата);

			записи_Select.QuerySelect.Order.Add(Довідники.Записи_Select.ДатаЗапису, SelectOrder.DESC);

			//Створення тимчасової таблиці
			записи_Select.QuerySelect.CreateTempTable = true;
			записи_Select.Select();

			Dictionary<string, string> dictionaryCostСlassifier = new Dictionary<string, string>();

			Довідники.КласифікаторВитрат_Select класифікаторВитрат_Select = new Довідники.КласифікаторВитрат_Select();
			класифікаторВитрат_Select.QuerySelect.Field.Add(Довідники.КласифікаторВитрат_Select.Назва);
			класифікаторВитрат_Select.QuerySelect.Where.Add(new Where("uid", Comparison.IN, "SELECT DISTINCT " + Довідники.Записи_Select.Витрата + " FROM " + записи_Select.QuerySelect.TempTable, true));
			класифікаторВитрат_Select.Select();

			while (класифікаторВитрат_Select.MoveNext())
			{
				Довідники.КласифікаторВитрат_Pointer cur = класифікаторВитрат_Select.Current;
				dictionaryCostСlassifier.Add(cur.UnigueID.ToString(), cur.Fields[Довідники.КласифікаторВитрат_Select.Назва].ToString());
			}

			//Видалення тимчасової таблиці
			записи_Select.DeleteTempTable();

			//Нормальна вибірка даних
			записи_Select.Select();

			while (записи_Select.MoveNext())
			{
				Довідники.Записи_Pointer cur = записи_Select.Current;

				Перелічення.ТипЗапису типЗапису = (Перелічення.ТипЗапису)cur.Fields[Довідники.Записи_Select.ТипЗапису];
				string типЗаписуПредставлення = типЗапису.ToString(); 
				/*(
					типЗапису == Перелічення.ТипЗапису.Поступлення ? "+" :
					типЗапису == Перелічення.ТипЗапису.Витрати ? "-" :
					типЗапису == Перелічення.ТипЗапису.Замітка ? "*" :
					типЗапису == Перелічення.ТипЗапису.Благодійність ? "." : "");*/

				Довідники.КласифікаторВитрат_Pointer Витрата = new Довідники.КласифікаторВитрат_Pointer(new UnigueID(cur.Fields[Довідники.Записи_Select.Витрата].ToString()));
				string ВитратаПредставлення = (!Витрата.IsEmpty() && dictionaryCostСlassifier.ContainsKey(Витрата.UnigueID.ToString())) ? dictionaryCostСlassifier[Витрата.UnigueID.ToString()] : "";

				RecordsBindingList.Add(new Записи(
					cur.UnigueID.ToString(),
					cur.Fields[Довідники.Записи_Select.Назва].ToString(),
					cur.Fields[Довідники.Записи_Select.ДатаЗапису].ToString(),
					cur.Fields[Довідники.Записи_Select.Сума].ToString(),
					типЗаписуПредставлення,
					ВитратаПредставлення
					));
			}

			if (selectRow != 0 && selectRow < dataGridViewRecords.Rows.Count)
			{
				dataGridViewRecords.Rows[0].Selected = false;
				dataGridViewRecords.Rows[selectRow].Selected = true;
			}
		}

		private void dataGridViewRecords_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.RowIndex < dataGridViewRecords.RowCount)
			{
				FormAddRecord formAddRecord = new FormAddRecord();
				formAddRecord.OwnerForm = this;
				formAddRecord.IsNew = false;
				formAddRecord.Uid = dataGridViewRecords.Rows[e.RowIndex].Cells[0].Value.ToString();
				formAddRecord.ShowDialog();
			}
		}

		private void toolStripButtonRefresh_Click(object sender, EventArgs e)
		{
			LoadRecords();
		}

		private void toolStripButtonAdd_Click(object sender, EventArgs e)
		{
			FormAddRecord formAddRecord = new FormAddRecord();
			formAddRecord.IsNew = true;
			formAddRecord.OwnerForm = this;
			formAddRecord.ShowDialog();
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
						записи_Objest_Новий.Витрата = записи_Objest.Витрата;
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

		private void Export()
		{
			StreamWriter sw = new StreamWriter("E:\\Вигрузка.xml");
			sw.AutoFlush = true;

			sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
			sw.WriteLine("<ВигрузкаДаних>");
			sw.WriteLine("<Дата>" + DateTime.Now.ToString() + "</Дата>");

			//1
			sw.WriteLine("<Довідник_КласифікаторВитрат>");

			Довідники.КласифікаторВитрат_Select класифікаторВитрат_Select = new Довідники.КласифікаторВитрат_Select();
			класифікаторВитрат_Select.Select();
			while (класифікаторВитрат_Select.MoveNext())
			{
				sw.WriteLine(класифікаторВитрат_Select.Current.GetDirectoryObject().Serialize("Запис"));
			}

			sw.WriteLine("</Довідник_КласифікаторВитрат>");

			//2
			sw.WriteLine("<Довідник_Записи>");

			Довідники.Записи_Select записи_Select = new Довідники.Записи_Select();
			записи_Select.QuerySelect.Order.Add(Довідники.Записи_Select.ДатаЗапису, SelectOrder.ASC);
			записи_Select.Select();
			while (записи_Select.MoveNext())
			{
				sw.WriteLine(записи_Select.Current.GetDirectoryObject().Serialize("Запис"));
			}

			sw.WriteLine("</Довідник_Записи>");

			//3
			sw.WriteLine("<Довідник_Контакти>");

			Довідники.Контакти_Select контакти_Select = new Довідники.Контакти_Select();
			контакти_Select.QuerySelect.Order.Add(Довідники.Контакти_Select.Назва, SelectOrder.ASC);
			контакти_Select.Select();
			while (контакти_Select.MoveNext())
			{
				sw.WriteLine(контакти_Select.Current.GetDirectoryObject().Serialize("Запис"));
			}

			sw.WriteLine("</Довідник_Контакти>");

			//4
			sw.WriteLine("<Довідник_Валюти>");

			Довідники.Валюта_Select валюта_Select = new Довідники.Валюта_Select();
			валюта_Select.QuerySelect.Order.Add(Довідники.Валюта_Select.Назва, SelectOrder.ASC);
			валюта_Select.Select();
			while (валюта_Select.MoveNext())
			{
				sw.WriteLine(валюта_Select.Current.GetDirectoryObject().Serialize("Запис"));
			}

			sw.WriteLine("</Довідник_Валюти>");

			//5
			sw.WriteLine("<Довідник_Каси>");

			Довідники.Каса_Select каса_Select = new Довідники.Каса_Select();
			каса_Select.QuerySelect.Order.Add(Довідники.Каса_Select.Назва, SelectOrder.ASC);
			каса_Select.Select();
			while (каса_Select.MoveNext())
			{
				sw.WriteLine(каса_Select.Current.GetDirectoryObject().Serialize("Запис"));
			}

			sw.WriteLine("</Довідник_Каси>");

			sw.WriteLine("</ВигрузкаДаних>");

			sw.Close();
		}

		private void Import()
		{
			XPathDocument xPathDoc = new XPathDocument("E:\\Вигрузка.xml");
			XPathNavigator xPathDocNavigator = xPathDoc.CreateNavigator();

			//Корінна вітка
			XPathNavigator rootNode = xPathDocNavigator.SelectSingleNode("/ВигрузкаДаних");

			//1 - КласифікаторВитрат
			XPathNodeIterator КласифікаторВитрат_Записи = rootNode.Select("Довідник_КласифікаторВитрат/Запис");
			while (КласифікаторВитрат_Записи.MoveNext())
			{
				XPathNavigator current = КласифікаторВитрат_Записи.Current;

				string uid = current.SelectSingleNode("uid").Value;
				string Назва = current.SelectSingleNode("Назва").Value;
				string Код = current.SelectSingleNode("Код").Value;

				Довідники.КласифікаторВитрат_Pointer класифікаторВитрат_Pointer = new Довідники.КласифікаторВитрат_Pointer(new UnigueID(uid));
				Довідники.КласифікаторВитрат_Objest класифікаторВитрат_Objest = класифікаторВитрат_Pointer.GetDirectoryObject();
				if (класифікаторВитрат_Objest != null)
				{
					//Збереження попередніх значень
					класифікаторВитрат_Objest.ОбмінІсторія_TablePart.Records.Add(
						new Довідники.КласифікаторВитрат_ОбмінІсторія_TablePart.Record(DateTime.Now, класифікаторВитрат_Objest.Serialize("Запис")));
					класифікаторВитрат_Objest.ОбмінІсторія_TablePart.Save(true);
				}
				else
				{
					класифікаторВитрат_Objest = new Довідники.КласифікаторВитрат_Objest();
					класифікаторВитрат_Objest.New();
				}

				класифікаторВитрат_Objest.Назва = Назва;
				класифікаторВитрат_Objest.Код = Код;
				класифікаторВитрат_Objest.Save();
			}

			//2 - Валюти
			XPathNodeIterator Довідник_Валюти_Записи = rootNode.Select("Довідник_Валюти/Запис");
			while (Довідник_Валюти_Записи.MoveNext())
			{
				XPathNavigator current = Довідник_Валюти_Записи.Current;

				string uid = current.SelectSingleNode("uid").Value;
				string Назва = current.SelectSingleNode("Назва").Value;
				string Код = current.SelectSingleNode("Код").Value;

				Довідники.Валюта_Pointer валюта_Pointer = new Довідники.Валюта_Pointer(new UnigueID(uid));
				Довідники.Валюта_Objest валюта_Objest = валюта_Pointer.GetDirectoryObject();
				if (валюта_Objest != null)
				{
					//Збереження попередніх значень
					валюта_Objest.ОбмінІсторія_TablePart.Records.Add(
						new Довідники.Валюта_ОбмінІсторія_TablePart.Record(DateTime.Now, валюта_Objest.Serialize("Запис")));
					валюта_Objest.ОбмінІсторія_TablePart.Save(true);
				}
				else
				{
					валюта_Objest = new Довідники.Валюта_Objest();
					валюта_Objest.New();
				}

				валюта_Objest.Назва = Назва;
				валюта_Objest.Код = Код;
				валюта_Objest.Save();
			}

			//3 - Каса
			XPathNodeIterator Довідник_Каси_Записи = rootNode.Select("Довідник_Каси/Запис");
			while (Довідник_Каси_Записи.MoveNext())
			{
				XPathNavigator current = Довідник_Каси_Записи.Current;

				string uid = current.SelectSingleNode("uid").Value;
				string Назва = current.SelectSingleNode("Назва").Value;
				string Валюта = current.SelectSingleNode("Валюта").Value;
				string ТипВалюти = current.SelectSingleNode("ТипВалюти").Value;

				Довідники.Каса_Pointer каса_Pointer = new Довідники.Каса_Pointer(new UnigueID(uid));
				Довідники.Каса_Objest каса_Objest = каса_Pointer.GetDirectoryObject();
				if (каса_Objest != null)
				{
					//Збереження попередніх значень
					каса_Objest.ОбмінІсторія_TablePart.Records.Add(
						new Довідники.Каса_ОбмінІсторія_TablePart.Record(DateTime.Now, каса_Objest.Serialize("Запис")));
					каса_Objest.ОбмінІсторія_TablePart.Save(true);
				}
				else
				{
					каса_Objest = new Довідники.Каса_Objest();
					каса_Objest.New();
				}

				каса_Objest.Назва = Назва;
				каса_Objest.Валюта = new Довідники.Валюта_Pointer(new UnigueID(Валюта));
				каса_Objest.ТипВалюти = ((Перелічення.ТипВалюти)int.Parse(ТипВалюти));
				каса_Objest.Save();
			}

			//4 - Записи
			XPathNodeIterator Довідник_Записи_Записи = rootNode.Select("Довідник_Записи/Запис");
			while (Довідник_Записи_Записи.MoveNext())
			{
				XPathNavigator current = Довідник_Записи_Записи.Current;

				string uid = current.SelectSingleNode("uid").Value;
				string Назва = current.SelectSingleNode("Назва").Value;
				string ДатаЗапису = current.SelectSingleNode("ДатаЗапису").Value;
				string Опис = current.SelectSingleNode("Опис").Value;
				string ТипЗапису = current.SelectSingleNode("ТипЗапису").Value;
				string Сума = current.SelectSingleNode("Сума").Value;
				string Витрата = current.SelectSingleNode("Витрата").Value;
				string Каса = current.SelectSingleNode("Каса").Value;
				string СсилкаНаСайт = current.SelectSingleNode("СсилкаНаСайт").Value;

				Довідники.Записи_Pointer записи_Pointer = new Довідники.Записи_Pointer(new UnigueID(uid));
				Довідники.Записи_Objest записи_Objest = записи_Pointer.GetDirectoryObject();
				if (записи_Objest != null)
				{
					//Збереження попередніх значень
					записи_Objest.ОбмінІсторія_TablePart.Records.Add(
						new Довідники.Записи_ОбмінІсторія_TablePart.Record(DateTime.Now, записи_Objest.Serialize("Запис")));
					записи_Objest.ОбмінІсторія_TablePart.Save(true);
				}
				else
				{
					записи_Objest = new Довідники.Записи_Objest();
					записи_Objest.New();
				}

				записи_Objest.Назва = Назва;
				записи_Objest.ДатаЗапису = DateTime.Parse(ДатаЗапису);
				записи_Objest.Опис = Опис;
				записи_Objest.ТипЗапису = (Перелічення.ТипЗапису)int.Parse(ТипЗапису);
				записи_Objest.Сума = int.Parse(Сума);
				записи_Objest.Витрата = new Довідники.КласифікаторВитрат_Pointer(new UnigueID(Витрата));
				записи_Objest.Каса = new Довідники.Каса_Pointer(new UnigueID(Каса));
				записи_Objest.СсилкаНаСайт = СсилкаНаСайт;
				записи_Objest.Save();
			}

			//5 - Контакти
			XPathNodeIterator Довідник_Контакти_Записи = rootNode.Select("Довідник_Контакти/Запис");
			while (Довідник_Контакти_Записи.MoveNext())
			{
				XPathNavigator current = Довідник_Контакти_Записи.Current;

				string uid = current.SelectSingleNode("uid").Value;
				string Назва = current.SelectSingleNode("Назва").Value;
				string Телефон = current.SelectSingleNode("Телефон").Value;
				string Сайт = current.SelectSingleNode("Сайт").Value;
				string Пошта = current.SelectSingleNode("Пошта").Value;
				string Опис = current.SelectSingleNode("Опис").Value;
				string Скайп = current.SelectSingleNode("Скайп").Value;

				Довідники.Контакти_Pointer контакти_Pointer = new Довідники.Контакти_Pointer(new UnigueID(uid));
				Довідники.Контакти_Objest контакти_Objest = контакти_Pointer.GetDirectoryObject();
				if (контакти_Objest != null)
				{
					//Збереження попередніх значень
					контакти_Objest.ОбмінІсторія_TablePart.Records.Add(
						new Довідники.Контакти_ОбмінІсторія_TablePart.Record(DateTime.Now, контакти_Objest.Serialize("Запис")));
					контакти_Objest.ОбмінІсторія_TablePart.Save(true);
				}
				else
				{
					контакти_Objest = new Довідники.Контакти_Objest();
					контакти_Objest.New();
				}

				контакти_Objest.Назва = Назва;
				контакти_Objest.Телефон = Телефон;
				контакти_Objest.Сайт = Сайт;
				контакти_Objest.Пошта = Пошта;
				контакти_Objest.Опис = Опис;
				контакти_Objest.Скайп = Скайп;
				контакти_Objest.Save();
			}


		}

		private void toolStripMenuItemExport_Click(object sender, EventArgs e)
        {
			Export();

			/*
			XmlDocument xmlConfDocument = new XmlDocument();
			xmlConfDocument.AppendChild(xmlConfDocument.CreateXmlDeclaration("1.0", "utf-8", ""));

			XmlElement rootNode = xmlConfDocument.CreateElement("Exchange");
			xmlConfDocument.AppendChild(rootNode);

			XmlElement nodeDateTime = xmlConfDocument.CreateElement("DateTime");
			nodeDateTime.InnerText = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
			rootNode.AppendChild(nodeDateTime);

			XmlElement nodeRecords = xmlConfDocument.CreateElement("Records");
			rootNode.AppendChild(nodeRecords);

			Довідники.Записи_Select записи_Select = new Довідники.Записи_Select();

			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.Назва);
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.ДатаЗапису);
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.Опис);
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.ТипЗапису);
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.Сума);
			записи_Select.QuerySelect.Field.Add(Довідники.Записи_Select.Витрата);

			записи_Select.Select();

			while (записи_Select.MoveNext())
			{
				Довідники.Записи_Pointer cur = записи_Select.Current;

				XmlElement nodeRecord = xmlConfDocument.CreateElement("Record");
				nodeRecords.AppendChild(nodeRecord);

				XmlElement nodeID = xmlConfDocument.CreateElement("ID");
				nodeID.InnerText = cur.UnigueID.ToString();
				nodeRecord.AppendChild(nodeID);

				XmlElement nodeName = xmlConfDocument.CreateElement("Назва");
				nodeName.InnerText = cur.Fields[Довідники.Записи_Select.Назва].ToString();
				nodeRecord.AppendChild(nodeName);

				XmlElement nodeDataSave = xmlConfDocument.CreateElement("ДатаЗапису");
				nodeDataSave.InnerText = cur.Fields[Довідники.Записи_Select.ДатаЗапису].ToString();
				nodeRecord.AppendChild(nodeDataSave);

				XmlElement nodeDesc = xmlConfDocument.CreateElement("Опис");
				nodeDesc.InnerText = cur.Fields[Довідники.Записи_Select.Опис].ToString();
				nodeRecord.AppendChild(nodeDesc);

				XmlElement nodeTypeRecord = xmlConfDocument.CreateElement("ТипЗапису");
				nodeTypeRecord.InnerText = cur.Fields[Довідники.Записи_Select.ТипЗапису].ToString();
				nodeRecord.AppendChild(nodeTypeRecord);

				XmlElement nodeSumma = xmlConfDocument.CreateElement("Сума");
				nodeSumma.InnerText = cur.Fields[Довідники.Записи_Select.Сума].ToString();
				nodeRecord.AppendChild(nodeSumma);

				XmlElement nodeStation = xmlConfDocument.CreateElement("Витрата");
				nodeStation.InnerText = cur.Fields[Довідники.Записи_Select.Витрата].ToString();
				nodeRecord.AppendChild(nodeStation);
			}

			xmlConfDocument.Save("E:\\export.xml");
			*/
		}

        private void toolStripMenuItemImport_Click(object sender, EventArgs e)
        {
			Import();
		}

		private class Записи
		{
			public Записи(string _id, string _Назва, string _ДатаЗапису, string _Сума, string _ТипЗапису, string _Витрата)
			{
				ID = _id;
				Назва = _Назва;
				ДатаЗапису = _ДатаЗапису;
				Сума = _Сума;
				ТипЗапису = _ТипЗапису;
				Витрата = _Витрата;
			}
			public string ID { get; set; }
			public string Назва { get; set; }
			public string ДатаЗапису { get; set; }
			public string Сума { get; set; }
			public string ТипЗапису { get; set; }
			public string Витрата { get; set; }
		}

        private void класифікаторВитратToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormCostСlassifier formCostСlassifier = new FormCostСlassifier();
			formCostСlassifier.Show();
		}

        private void контактиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormContacts formContacts = new FormContacts();
			formContacts.Show();
		}

        private void валютиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormCurrency formCurrency = new FormCurrency();
			formCurrency.Show();
		}

        private void касиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormCash formCash = new FormCash();
			formCash.Show();
		}

        private void записникToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormNotebook formNotebook = new FormNotebook();
			formNotebook.Show();
		}

        private void константиToolStripMenuItem_Click(object sender, EventArgs e)
        {
			FormConstants formConstats = new FormConstants();
			formConstats.Show();
		}
    }
}
