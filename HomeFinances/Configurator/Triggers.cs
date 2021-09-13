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

/*
 *
 * Конфігурації "Домашні фінанси 1.0"
 * Автор Тарахомин Юрій Іванович, Україна, м. Львів, accounting.org.ua, tarachom@gmail.com
 * Дата конфігурації: 03.09.2021 16:50:57
 *
 */

using System;
using System.Collections.Generic;
using AccountingSoftware;

namespace HomeFinances_1_0.Довідники
{
	class Записник_Triggers
    {
		public static void Записник_AfterRecording(Записник_Objest записник_Objest)
        {
			//Для папки встановлюється сьогоднішня дата
			if (записник_Objest.Папка != null)
			{
				Довідники.Записник_Папки_Objest записник_Папки_Objest = записник_Objest.Папка.GetDirectoryObject();
				if (записник_Папки_Objest != null)
				{
					записник_Папки_Objest.Дата = DateTime.Now;
					записник_Папки_Objest.Save();
				}
			}
		}
	}

	class Записник_Папки_Triggers
	{
		public static void Записник_Папки_AfterRecording(Записник_Папки_Objest записник_Папки_Objest)
		{
			//Для папки Родич встановлюється сьогоднішня дата
			if (записник_Папки_Objest.Родич != null)
			{
				Довідники.Записник_Папки_Objest записник_Папки_Родич_Objest = записник_Папки_Objest.Родич.GetDirectoryObject();
				if (записник_Папки_Родич_Objest != null)
                {
					записник_Папки_Родич_Objest.Дата = DateTime.Now;
					записник_Папки_Родич_Objest.Save();
				}
			}
		}

		public static void Записник_Папки_BeforeDelete(Записник_Папки_Objest записник_Папки_Objest)
        {
			//
			//Вибірка елементів папки
			//
			Довідники.Записник_Select записник_Select = new Записник_Select();
			записник_Select.QuerySelect.Where.Add(new Where(Довідники.Записник_Select.Папка, Comparison.EQ, записник_Папки_Objest.UnigueID.UGuid));

			записник_Select.Select();
			while(записник_Select.MoveNext())
            {
				Довідники.Записник_Objest записник_Objest = записник_Select.Current.GetDirectoryObject();
				if (записник_Objest != null)
                {
					//Console.WriteLine("Delete element: " + записник_Objest.Назва);
					записник_Objest.Delete();
				}
			}

			//
			//Вибірка папок у папці
			//
			Довідники.Записник_Папки_Select записник_Папки_Select = new Записник_Папки_Select();
			записник_Папки_Select.QuerySelect.Where.Add(new Where(Довідники.Записник_Папки_Select.Родич, Comparison.EQ, записник_Папки_Objest.UnigueID.UGuid));

			записник_Папки_Select.Select();
			while (записник_Папки_Select.MoveNext())
            {
				Довідники.Записник_Папки_Objest записник_Папки_Objest_List = записник_Папки_Select.Current.GetDirectoryObject();
				if (записник_Папки_Objest_List != null)
                {
					//Console.WriteLine("Delete folder: " + записник_Папки_Objest_List.Назва);
					записник_Папки_Objest_List.Delete();
				}
			}
		}

	}

	class Записи_Triggers
	{
        public static void Записи_BeforeRecording(Записи_Objest запис)
        {
            //Console.WriteLine("BeforeRecording: " + запис.Назва);
		}

        public static void Записи_AfterRecording(Записи_Objest запис)
        {
            //Console.WriteLine("AfterRecording: " + запис.Назва);

			//Обов'язкове очищення регістру від попередніх записів
			РегістриНакопичення.ЗалишкиКоштів_RecordsSet залишкиКоштів_RecordsSet = new РегістриНакопичення.ЗалишкиКоштів_RecordsSet();
			залишкиКоштів_RecordsSet.Delete(запис.UnigueID.UGuid);

			if (запис.Проведено)
			{
				if ((запис.ТипЗапису == Перелічення.ТипЗапису.Витрати) ||
					(запис.ТипЗапису == Перелічення.ТипЗапису.Благодійність) ||
					(запис.ТипЗапису == Перелічення.ТипЗапису.Поступлення))
				{
					РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record record = new РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record();

					if (запис.ТипЗапису == Перелічення.ТипЗапису.Витрати || запис.ТипЗапису == Перелічення.ТипЗапису.Благодійність)
						record.Income = false;
					else if (запис.ТипЗапису == Перелічення.ТипЗапису.Поступлення)
						record.Income = true;

					record.Owner = запис.UnigueID.UGuid;
					record.Каса = запис.Каса;
					record.Сума = запис.Сума;

					залишкиКоштів_RecordsSet.Records.Add(record);
					залишкиКоштів_RecordsSet.Save(запис.ДатаЗапису, запис.UnigueID.UGuid);
				}

				if (запис.ТипЗапису == Перелічення.ТипЗапису.Переміщення)
				{
					РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record record1 = new РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record();
					РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record record2 = new РегістриНакопичення.ЗалишкиКоштів_RecordsSet.Record();

					record1.Income = false;
					record2.Income = true;

					record1.Owner = record2.Owner = запис.UnigueID.UGuid;

					record1.Каса = запис.Каса;
					record2.Каса = запис.КасаПереміщення;

					record1.Сума = record2.Сума = запис.Сума;

					залишкиКоштів_RecordsSet.Records.Add(record1);
					залишкиКоштів_RecordsSet.Records.Add(record2);
					залишкиКоштів_RecordsSet.Save(запис.ДатаЗапису, запис.UnigueID.UGuid);
				}
			}
		}

		public static void Записи_BeforeDelete(Записи_Objest запис)
		{
			//Console.WriteLine("BeforeDelete: " + запис.Назва);

			РегістриНакопичення.ЗалишкиКоштів_RecordsSet залишкиКоштів_RecordsSet = new РегістриНакопичення.ЗалишкиКоштів_RecordsSet();
			залишкиКоштів_RecordsSet.Delete(запис.UnigueID.UGuid);
		}
	}
}
