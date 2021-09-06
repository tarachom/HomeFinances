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
    
    class Triggers
    {
        public static void Записи_BeforeRecording(Записи_Objest записи)
        {
            Console.WriteLine("BeforeRecording: " + записи.Назва);
        }

        public static void Записи_AfterRecording(Записи_Objest запис)
        {
            Console.WriteLine("AfterRecording: " + запис.Назва);

			//Обов'язкове очищення регістру від попередніх записів
			РегістриНакопичення.ЗалишкиКоштів_RecordsSet залишкиКоштів_RecordsSet = new РегістриНакопичення.ЗалишкиКоштів_RecordsSet();
			залишкиКоштів_RecordsSet.Delete(запис.UnigueID.UGuid);

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
		}
    }
}
