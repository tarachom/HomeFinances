/*
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

using System.Xml;
using System.Xml.XPath;
using System.IO;
using System.Threading;

using AccountingSoftware;
using Конфа = HomeFinances_1_0;
using Константи = HomeFinances_1_0.Константи;
using Довідники = HomeFinances_1_0.Довідники;
using Перелічення = HomeFinances_1_0.Перелічення;

namespace HomeFinances
{
    public partial class FormExchange : Form
    {
        public FormExchange()
        {
            InitializeComponent();
        }

		private void FormExchange_Load(object sender, EventArgs e)
        {
			
		}

        private void buttonExport_Click(object sender, EventArgs e)
        {
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "HomeFinances_Export_" + DateTime.Now.ToString("dd_MM_yyyy") + ".xml";
			saveFileDialog.Filter = "XML|*.xml";
			saveFileDialog.Title = "Файл для вигрузки даних";
			saveFileDialog.InitialDirectory =
				(!String.IsNullOrEmpty(Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляВигрузкиДаних_Const) ?
				Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляВигрузкиДаних_Const : Environment.SpecialFolder.Desktop.ToString());

			string fileExport = "";

			if (!(saveFileDialog.ShowDialog() == DialogResult.OK))
				return;
			else
			{
				fileExport = saveFileDialog.FileName;
				Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляВигрузкиДаних_Const = Path.GetDirectoryName(fileExport);

				buttonExport.Enabled = false;
				buttonImport.Enabled = false;

				Thread thread = new Thread(new ParameterizedThreadStart(Export));
				thread.Start(fileExport);
			}
		}

        private void buttonImport_Click(object sender, EventArgs e)
        {
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "XML|*.xml";
			openFileDialog.Title = "Файл для загрузки даних";
			openFileDialog.InitialDirectory =
				(!String.IsNullOrEmpty(Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляЗагрузкиДаних_Const) ?
				Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляЗагрузкиДаних_Const : Environment.SpecialFolder.Desktop.ToString());

			string fileImport = "";

			if (!(openFileDialog.ShowDialog() == DialogResult.OK))
				return;
			else
			{
				fileImport = openFileDialog.FileName;
				Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляЗагрузкиДаних_Const = Path.GetDirectoryName(fileImport);

				buttonExport.Enabled = false;
				buttonImport.Enabled = false;

				Thread thread = new Thread(new ParameterizedThreadStart(Import));
				thread.Start(fileImport);
			}
		}

		private void ApendLine(string text)
		{
			if (richTextBoxInfo.InvokeRequired)
			{
				richTextBoxInfo.Invoke(new Action<string>(ApendLine), text);
			}
			else
			{
				richTextBoxInfo.Text = "\n" + text + richTextBoxInfo.Text;
			}
		}

		#region ImportExport

		private void Export(object fileExport)
		{
			StreamWriter sw = new StreamWriter(fileExport.ToString());
			sw.AutoFlush = true;

			sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
			sw.WriteLine("<ВигрузкаДаних>");
			sw.WriteLine("<Дата>" + DateTime.Now.ToString() + "</Дата>");

			ApendLine("Довідники:");

			//1
			sw.WriteLine("<Довідник_КласифікаторВитрат>");

			ApendLine("-> КласифікаторВитрат");

			Довідники.КласифікаторВитрат_Select класифікаторВитрат_Select = new Довідники.КласифікаторВитрат_Select();
			класифікаторВитрат_Select.Select();
			while (класифікаторВитрат_Select.MoveNext())
			{
				sw.WriteLine(класифікаторВитрат_Select.Current.GetDirectoryObject().Serialize("Запис"));
				ApendLine(класифікаторВитрат_Select.Current.UnigueID.UGuid.ToString());
			}

			sw.WriteLine("</Довідник_КласифікаторВитрат>");

			//2
			sw.WriteLine("<Довідник_Записи>");

			ApendLine("-> Записи");

			Довідники.Записи_Select записи_Select = new Довідники.Записи_Select();
			записи_Select.QuerySelect.Order.Add(Довідники.Записи_Select.ДатаЗапису, SelectOrder.ASC);
			записи_Select.Select();
			while (записи_Select.MoveNext())
			{
				sw.WriteLine(записи_Select.Current.GetDirectoryObject().Serialize("Запис"));
				ApendLine(записи_Select.Current.UnigueID.UGuid.ToString());
			}

			sw.WriteLine("</Довідник_Записи>");

			//3
			sw.WriteLine("<Довідник_Контакти>");

			ApendLine("-> Контакти");

			Довідники.Контакти_Select контакти_Select = new Довідники.Контакти_Select();
			контакти_Select.QuerySelect.Order.Add(Довідники.Контакти_Select.Назва, SelectOrder.ASC);
			контакти_Select.Select();
			while (контакти_Select.MoveNext())
			{
				sw.WriteLine(контакти_Select.Current.GetDirectoryObject().Serialize("Запис"));
				ApendLine(контакти_Select.Current.UnigueID.UGuid.ToString());
			}

			sw.WriteLine("</Довідник_Контакти>");

			//4
			sw.WriteLine("<Довідник_Валюти>");

			ApendLine("-> Валюти");

			Довідники.Валюта_Select валюта_Select = new Довідники.Валюта_Select();
			валюта_Select.QuerySelect.Order.Add(Довідники.Валюта_Select.Назва, SelectOrder.ASC);
			валюта_Select.Select();
			while (валюта_Select.MoveNext())
			{
				sw.WriteLine(валюта_Select.Current.GetDirectoryObject().Serialize("Запис"));
				ApendLine(валюта_Select.Current.UnigueID.UGuid.ToString());
			}

			sw.WriteLine("</Довідник_Валюти>");

			//5
			sw.WriteLine("<Довідник_Каси>");

			ApendLine("-> Каси");

			Довідники.Каса_Select каса_Select = new Довідники.Каса_Select();
			каса_Select.QuerySelect.Order.Add(Довідники.Каса_Select.Назва, SelectOrder.ASC);
			каса_Select.Select();
			while (каса_Select.MoveNext())
			{
				sw.WriteLine(каса_Select.Current.GetDirectoryObject().Serialize("Запис"));
				ApendLine(каса_Select.Current.UnigueID.UGuid.ToString());
			}

			sw.WriteLine("</Довідник_Каси>");

			sw.WriteLine("</ВигрузкаДаних>");

			sw.Close();

			ApendLine("");
			ApendLine("ГОТОВО");
			ApendLine("Дані вигружені у файл: " + fileExport);

			buttonExport.Invoke(new Action(() => buttonExport.Enabled = true));
			buttonImport.Invoke(new Action(() => buttonImport.Enabled = true));
		}

		private void Import(object fileImport)
		{
			XPathDocument xPathDoc = new XPathDocument(fileImport.ToString());
			XPathNavigator xPathDocNavigator = xPathDoc.CreateNavigator();

			//Корінна вітка
			XPathNavigator rootNode = xPathDocNavigator.SelectSingleNode("/ВигрузкаДаних");

			ApendLine("Довідники:");
			
			ApendLine("-> КласифікаторВитрат");
			//1 - КласифікаторВитрат
			XPathNodeIterator КласифікаторВитрат_Записи = rootNode.Select("Довідник_КласифікаторВитрат/Запис");
			while (КласифікаторВитрат_Записи.MoveNext())
			{
				XPathNavigator current = КласифікаторВитрат_Записи.Current;

				string uid = current.SelectSingleNode("uid").Value;
				string Назва = current.SelectSingleNode("Назва").Value;
				string Код = current.SelectSingleNode("Код").Value;

				ApendLine(uid);

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
					класифікаторВитрат_Objest.New(класифікаторВитрат_Pointer.UnigueID);
				}

				класифікаторВитрат_Objest.Назва = Назва;
				класифікаторВитрат_Objest.Код = Код;
				класифікаторВитрат_Objest.Save();
			}

			ApendLine("-> Валюти");
			//2 - Валюти
			XPathNodeIterator Довідник_Валюти_Записи = rootNode.Select("Довідник_Валюти/Запис");
			while (Довідник_Валюти_Записи.MoveNext())
			{
				XPathNavigator current = Довідник_Валюти_Записи.Current;

				string uid = current.SelectSingleNode("uid").Value;
				string Назва = current.SelectSingleNode("Назва").Value;
				string Код = current.SelectSingleNode("Код").Value;

				ApendLine(uid);

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
					валюта_Objest.New(валюта_Pointer.UnigueID);
				}

				валюта_Objest.Назва = Назва;
				валюта_Objest.Код = Код;
				валюта_Objest.Save();
			}

			ApendLine("-> Каса");
			//3 - Каса
			XPathNodeIterator Довідник_Каси_Записи = rootNode.Select("Довідник_Каси/Запис");
			while (Довідник_Каси_Записи.MoveNext())
			{
				XPathNavigator current = Довідник_Каси_Записи.Current;

				string uid = current.SelectSingleNode("uid").Value;
				string Назва = current.SelectSingleNode("Назва").Value;
				string Валюта = current.SelectSingleNode("Валюта").Value;
				string ТипВалюти = current.SelectSingleNode("ТипВалюти").Value;

				ApendLine(uid);

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
					каса_Objest.New(каса_Pointer.UnigueID);
				}

				каса_Objest.Назва = Назва;
				каса_Objest.Валюта = new Довідники.Валюта_Pointer(new UnigueID(Валюта));
				каса_Objest.ТипВалюти = ((Перелічення.ТипВалюти)int.Parse(ТипВалюти));
				каса_Objest.Save();
			}

			ApendLine("-> Записи");
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
				string КасаПереміщення = current.SelectSingleNode("КасаПереміщення").Value;
				string СсилкаНаСайт = current.SelectSingleNode("СсилкаНаСайт").Value;
				string Проведено = current.SelectSingleNode("Проведено").Value;

				ApendLine(uid);

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
					записи_Objest.New(записи_Pointer.UnigueID);
				}

				записи_Objest.Назва = Назва;
				записи_Objest.ДатаЗапису = DateTime.Parse(ДатаЗапису);
				записи_Objest.Опис = Опис;
				записи_Objest.ТипЗапису = (Перелічення.ТипЗапису)int.Parse(ТипЗапису);
				записи_Objest.Сума = int.Parse(Сума);
				записи_Objest.Витрата = new Довідники.КласифікаторВитрат_Pointer(new UnigueID(Витрата));
				записи_Objest.Каса = new Довідники.Каса_Pointer(new UnigueID(Каса));
				записи_Objest.КасаПереміщення = new Довідники.Каса_Pointer(new UnigueID(КасаПереміщення));
				записи_Objest.СсилкаНаСайт = СсилкаНаСайт;
				записи_Objest.Проведено = Проведено == "1" ? true : false;
				записи_Objest.Save();
			}

			ApendLine("-> Контакти");
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

				ApendLine(uid);

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
					контакти_Objest.New(контакти_Pointer.UnigueID);
				}

				контакти_Objest.Назва = Назва;
				контакти_Objest.Телефон = Телефон;
				контакти_Objest.Сайт = Сайт;
				контакти_Objest.Пошта = Пошта;
				контакти_Objest.Опис = Опис;
				контакти_Objest.Скайп = Скайп;
				контакти_Objest.Save();
			}

			ApendLine("");
			ApendLine("ГОТОВО");
			ApendLine("Дані завантажені");

			buttonExport.Invoke(new Action(() => buttonExport.Enabled = true));
			buttonImport.Invoke(new Action(() => buttonImport.Enabled = true));
		}

		#endregion
	}
}
