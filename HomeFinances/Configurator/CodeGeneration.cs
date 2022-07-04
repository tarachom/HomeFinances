
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
 * Дата конфігурації: 04.07.2022 23:37:42
 *
 */

using System;
using System.Collections.Generic;
using AccountingSoftware;

namespace HomeFinances_1_0
{
    public static class Config
    {
        public static Kernel Kernel { get; set; }
		
        public static void ReadAllConstants()
        {
            Константи.Основний.ReadAll();
            Константи.ЗначенняПоЗамовчуванню.ReadAll();
            Константи.ВигрузкаТаЗагрузкаДаних.ReadAll();
            Константи.Інтерфейс.ReadAll();
            Константи.СписокГоловнаФорма.ReadAll();
            
        }
    }
}

namespace HomeFinances_1_0.Константи
{
    
	#region CONSTANTS BLOCK "Основний"
    public static class Основний
    {
        public static void ReadAll()
        {
            
            Dictionary<string, object> fieldValue = new Dictionary<string, object>();
            bool IsSelect = Config.Kernel.DataBase.SelectAllConstants("tab_constants",
                 new string[] { "col_a3" }, fieldValue);
            
            if (IsSelect)
            {
                m_КаталогДляФайлів_Const = fieldValue["col_a3"].ToString();
                
            }
			
        }
        
        
        static string m_КаталогДляФайлів_Const = "";
        public static string КаталогДляФайлів_Const
        {
            get { return m_КаталогДляФайлів_Const; }
            set
            {
                m_КаталогДляФайлів_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a3", m_КаталогДляФайлів_Const);
            }
        }
             
    }
    #endregion
    
	#region CONSTANTS BLOCK "ЗначенняПоЗамовчуванню"
    public static class ЗначенняПоЗамовчуванню
    {
        public static void ReadAll()
        {
            
            Dictionary<string, object> fieldValue = new Dictionary<string, object>();
            bool IsSelect = Config.Kernel.DataBase.SelectAllConstants("tab_constants",
                 new string[] { "col_a1", "col_a2" }, fieldValue);
            
            if (IsSelect)
            {
                m_ОсновнаКаса_Const = new Довідники.Каса_Pointer(fieldValue["col_a1"]);
                m_ОсновнаСтаттяВитрат_Const = new Довідники.КласифікаторВитрат_Pointer(fieldValue["col_a2"]);
                
            }
			
        }
        
        
        static Довідники.Каса_Pointer m_ОсновнаКаса_Const = new Довідники.Каса_Pointer();
        public static Довідники.Каса_Pointer ОсновнаКаса_Const
        {
            get { return m_ОсновнаКаса_Const; }
            set
            {
                m_ОсновнаКаса_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a1", m_ОсновнаКаса_Const.UnigueID.UGuid);
            }
        }
        
        static Довідники.КласифікаторВитрат_Pointer m_ОсновнаСтаттяВитрат_Const = new Довідники.КласифікаторВитрат_Pointer();
        public static Довідники.КласифікаторВитрат_Pointer ОсновнаСтаттяВитрат_Const
        {
            get { return m_ОсновнаСтаттяВитрат_Const; }
            set
            {
                m_ОсновнаСтаттяВитрат_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a2", m_ОсновнаСтаттяВитрат_Const.UnigueID.UGuid);
            }
        }
             
    }
    #endregion
    
	#region CONSTANTS BLOCK "ВигрузкаТаЗагрузкаДаних"
    public static class ВигрузкаТаЗагрузкаДаних
    {
        public static void ReadAll()
        {
            
            Dictionary<string, object> fieldValue = new Dictionary<string, object>();
            bool IsSelect = Config.Kernel.DataBase.SelectAllConstants("tab_constants",
                 new string[] { "col_a4", "col_a5" }, fieldValue);
            
            if (IsSelect)
            {
                m_ПапкаДляВигрузкиДаних_Const = fieldValue["col_a4"].ToString();
                m_ПапкаДляЗагрузкиДаних_Const = fieldValue["col_a5"].ToString();
                
            }
			
        }
        
        
        static string m_ПапкаДляВигрузкиДаних_Const = "";
        public static string ПапкаДляВигрузкиДаних_Const
        {
            get { return m_ПапкаДляВигрузкиДаних_Const; }
            set
            {
                m_ПапкаДляВигрузкиДаних_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a4", m_ПапкаДляВигрузкиДаних_Const);
            }
        }
        
        static string m_ПапкаДляЗагрузкиДаних_Const = "";
        public static string ПапкаДляЗагрузкиДаних_Const
        {
            get { return m_ПапкаДляЗагрузкиДаних_Const; }
            set
            {
                m_ПапкаДляЗагрузкиДаних_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a5", m_ПапкаДляЗагрузкиДаних_Const);
            }
        }
             
    }
    #endregion
    
	#region CONSTANTS BLOCK "Інтерфейс"
    public static class Інтерфейс
    {
        public static void ReadAll()
        {
            
            Dictionary<string, object> fieldValue = new Dictionary<string, object>();
            bool IsSelect = Config.Kernel.DataBase.SelectAllConstants("tab_constants",
                 new string[] { "col_a6" }, fieldValue);
            
            if (IsSelect)
            {
                m_ДатаПочаткуПеріоду_Const = (fieldValue["col_a6"] != DBNull.Value) ? (Перелічення.ВаріантиПочаткуПеріоду)fieldValue["col_a6"] : 0;
                
            }
			
        }
        
        
        static Перелічення.ВаріантиПочаткуПеріоду m_ДатаПочаткуПеріоду_Const = 0;
        public static Перелічення.ВаріантиПочаткуПеріоду ДатаПочаткуПеріоду_Const
        {
            get { return m_ДатаПочаткуПеріоду_Const; }
            set
            {
                m_ДатаПочаткуПеріоду_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a6", (int)m_ДатаПочаткуПеріоду_Const);
            }
        }
             
    }
    #endregion
    
	#region CONSTANTS BLOCK "СписокГоловнаФорма"
    public static class СписокГоловнаФорма
    {
        public static void ReadAll()
        {
            
            Dictionary<string, object> fieldValue = new Dictionary<string, object>();
            bool IsSelect = Config.Kernel.DataBase.SelectAllConstants("tab_constants",
                 new string[] { "col_a7", "col_a8", "col_a9", "col_b1", "col_b2" }, fieldValue);
            
            if (IsSelect)
            {
                m_СтовпчикНазваШирина_Const = (fieldValue["col_a7"] != DBNull.Value) ? (int)fieldValue["col_a7"] : 0;
                m_СтовпчикДатаЗаписуШирина_Const = (fieldValue["col_a8"] != DBNull.Value) ? (int)fieldValue["col_a8"] : 0;
                m_СтовпчикСумаШирина_Const = (fieldValue["col_a9"] != DBNull.Value) ? (int)fieldValue["col_a9"] : 0;
                m_СтовпчикВитратаШирина_Const = (fieldValue["col_b1"] != DBNull.Value) ? (int)fieldValue["col_b1"] : 0;
                m_СтовпчикКасаШирина_Const = (fieldValue["col_b2"] != DBNull.Value) ? (int)fieldValue["col_b2"] : 0;
                
            }
			
        }
        
        
        static int m_СтовпчикНазваШирина_Const = 0;
        public static int СтовпчикНазваШирина_Const
        {
            get { return m_СтовпчикНазваШирина_Const; }
            set
            {
                m_СтовпчикНазваШирина_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a7", m_СтовпчикНазваШирина_Const);
            }
        }
        
        static int m_СтовпчикДатаЗаписуШирина_Const = 0;
        public static int СтовпчикДатаЗаписуШирина_Const
        {
            get { return m_СтовпчикДатаЗаписуШирина_Const; }
            set
            {
                m_СтовпчикДатаЗаписуШирина_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a8", m_СтовпчикДатаЗаписуШирина_Const);
            }
        }
        
        static int m_СтовпчикСумаШирина_Const = 0;
        public static int СтовпчикСумаШирина_Const
        {
            get { return m_СтовпчикСумаШирина_Const; }
            set
            {
                m_СтовпчикСумаШирина_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a9", m_СтовпчикСумаШирина_Const);
            }
        }
        
        static int m_СтовпчикВитратаШирина_Const = 0;
        public static int СтовпчикВитратаШирина_Const
        {
            get { return m_СтовпчикВитратаШирина_Const; }
            set
            {
                m_СтовпчикВитратаШирина_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_b1", m_СтовпчикВитратаШирина_Const);
            }
        }
        
        static int m_СтовпчикКасаШирина_Const = 0;
        public static int СтовпчикКасаШирина_Const
        {
            get { return m_СтовпчикКасаШирина_Const; }
            set
            {
                m_СтовпчикКасаШирина_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_b2", m_СтовпчикКасаШирина_Const);
            }
        }
             
    }
    #endregion
    
}

namespace HomeFinances_1_0.Довідники
{
    
    #region DIRECTORY "Записи"
    ///<summary>
    ///Записи про витрати і надходження фінансів.
    ///</summary>
    public static class Записи_Const
    {
        public const string TABLE = "tab_a02";
        
        public const string Назва = "col_a7";
        public const string ДатаЗапису = "col_a6";
        public const string ТипЗапису = "col_a9";
        public const string Сума = "col_b1";
        public const string Витрата = "col_a1";
        public const string Каса = "col_a2";
        public const string КасаПереміщення = "col_a3";
        public const string СумаОбміну = "col_b2";
        public const string КурсОбміну = "col_b3";
        public const string Проведено = "col_a5";
        public const string Опис = "col_a8";
        public const string СсилкаНаСайт = "col_a4";
    }
	
    ///<summary>
    ///Записи про витрати і надходження фінансів.
    ///</summary>
    public class Записи_Objest : DirectoryObject
    {
        public Записи_Objest() : base(Config.Kernel, "tab_a02",
             new string[] { "col_a7", "col_a6", "col_a9", "col_b1", "col_a1", "col_a2", "col_a3", "col_b2", "col_b3", "col_a5", "col_a8", "col_a4" }) 
        {
            Назва = "";
            ДатаЗапису = DateTime.MinValue;
            ТипЗапису = 0;
            Сума = 0;
            Витрата = new Довідники.КласифікаторВитрат_Pointer();
            Каса = new Довідники.Каса_Pointer();
            КасаПереміщення = new Довідники.Каса_Pointer();
            СумаОбміну = 0;
            КурсОбміну = 0;
            Проведено = false;
            Опис = "";
            СсилкаНаСайт = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a7"].ToString();
                ДатаЗапису = (base.FieldValue["col_a6"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_a6"].ToString()) : DateTime.MinValue;
                ТипЗапису = (base.FieldValue["col_a9"] != DBNull.Value) ? (Перелічення.ТипЗапису)base.FieldValue["col_a9"] : 0;
                Сума = (base.FieldValue["col_b1"] != DBNull.Value) ? (decimal)base.FieldValue["col_b1"] : 0;
                Витрата = new Довідники.КласифікаторВитрат_Pointer(base.FieldValue["col_a1"]);
                Каса = new Довідники.Каса_Pointer(base.FieldValue["col_a2"]);
                КасаПереміщення = new Довідники.Каса_Pointer(base.FieldValue["col_a3"]);
                СумаОбміну = (base.FieldValue["col_b2"] != DBNull.Value) ? (decimal)base.FieldValue["col_b2"] : 0;
                КурсОбміну = (base.FieldValue["col_b3"] != DBNull.Value) ? (decimal)base.FieldValue["col_b3"] : 0;
                Проведено = (base.FieldValue["col_a5"] != DBNull.Value) ? bool.Parse(base.FieldValue["col_a5"].ToString()) : false;
                Опис = base.FieldValue["col_a8"].ToString();
                СсилкаНаСайт = base.FieldValue["col_a4"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a7"] = Назва;
            base.FieldValue["col_a6"] = ДатаЗапису;
            base.FieldValue["col_a9"] = (int)ТипЗапису;
            base.FieldValue["col_b1"] = Сума;
            base.FieldValue["col_a1"] = Витрата.UnigueID.UGuid;
            base.FieldValue["col_a2"] = Каса.UnigueID.UGuid;
            base.FieldValue["col_a3"] = КасаПереміщення.UnigueID.UGuid;
            base.FieldValue["col_b2"] = СумаОбміну;
            base.FieldValue["col_b3"] = КурсОбміну;
            base.FieldValue["col_a5"] = Проведено;
            base.FieldValue["col_a8"] = Опис;
            base.FieldValue["col_a4"] = СсилкаНаСайт;
            Записи_Triggers.Записи_BeforeRecording(this);
            BaseSave();
			Записи_Triggers.Записи_AfterRecording(this);
        }

        public string Serialize(string root = "Записи")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<ДатаЗапису>" + ДатаЗапису.ToString() + "</ДатаЗапису>"  +
               "<ТипЗапису>" + ((int)ТипЗапису).ToString() + "</ТипЗапису>"  +
               "<Сума>" + Сума.ToString() + "</Сума>"  +
               "<Витрата>" + Витрата.ToString() + "</Витрата>"  +
               "<Каса>" + Каса.ToString() + "</Каса>"  +
               "<КасаПереміщення>" + КасаПереміщення.ToString() + "</КасаПереміщення>"  +
               "<СумаОбміну>" + СумаОбміну.ToString() + "</СумаОбміну>"  +
               "<КурсОбміну>" + КурсОбміну.ToString() + "</КурсОбміну>"  +
               "<Проведено>" + (Проведено == true ? "1" : "0") + "</Проведено>"  +
               "<Опис>" + "<![CDATA[" + Опис + "]]>" + "</Опис>"  +
               "<СсилкаНаСайт>" + "<![CDATA[" + СсилкаНаСайт + "]]>" + "</СсилкаНаСайт>"  +
               "</" + root + ">";
        }

        public Записи_Objest Copy()
        {
            Записи_Objest copy = new Записи_Objest();
			copy.New();
            copy.Назва = Назва;
			copy.ДатаЗапису = ДатаЗапису;
			copy.ТипЗапису = ТипЗапису;
			copy.Сума = Сума;
			copy.Витрата = Витрата;
			copy.Каса = Каса;
			copy.КасаПереміщення = КасаПереміщення;
			copy.СумаОбміну = СумаОбміну;
			copy.КурсОбміну = КурсОбміну;
			copy.Проведено = Проведено;
			copy.Опис = Опис;
			copy.СсилкаНаСайт = СсилкаНаСайт;
			
			return copy;
        }

        public void Delete()
        {
            Записи_Triggers.Записи_BeforeDelete(this);
			base.BaseDelete(new string[] {  });
        }
        
        public Записи_Pointer GetDirectoryPointer()
        {
            Записи_Pointer directoryPointer = new Записи_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public DateTime ДатаЗапису { get; set; }
        public Перелічення.ТипЗапису ТипЗапису { get; set; }
        public decimal Сума { get; set; }
        public Довідники.КласифікаторВитрат_Pointer Витрата { get; set; }
        public Довідники.Каса_Pointer Каса { get; set; }
        public Довідники.Каса_Pointer КасаПереміщення { get; set; }
        public decimal СумаОбміну { get; set; }
        public decimal КурсОбміну { get; set; }
        public bool Проведено { get; set; }
        public string Опис { get; set; }
        public string СсилкаНаСайт { get; set; }
        
    }
    
    ///<summary>
    ///Записи про витрати і надходження фінансів.
    ///</summary>
    public class Записи_Pointer : DirectoryPointer
    {
        public Записи_Pointer(object uid = null) : base(Config.Kernel, "tab_a02")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Записи_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a02")
        {
            base.Init(uid, fields);
        }
        
        public Записи_Objest GetDirectoryObject()
        {
            if (this.IsEmpty()) return null;
            Записи_Objest ЗаписиObjestItem = new Записи_Objest();
            return ЗаписиObjestItem.Read(base.UnigueID) ? ЗаписиObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] { "col_a7", "col_a6" }
			);
        }
		
        public Записи_Pointer GetEmptyPointer()
        {
            return new Записи_Pointer();
        }
    }
    
    ///<summary>
    ///Записи про витрати і надходження фінансів.
    ///</summary>
    public class Записи_Select : DirectorySelect, IDisposable
    {
        public Записи_Select() : base(Config.Kernel, "tab_a02") { }        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Записи_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Записи_Pointer Current { get; private set; }
        
        public Записи_Pointer FindByField(string name, object value)
        {
            Записи_Pointer itemPointer = new Записи_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Записи_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Записи_Pointer> directoryPointerList = new List<Записи_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Записи_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "КласифікаторВитрат"
    ///<summary>
    ///Статті витрат.
    ///</summary>
    public static class КласифікаторВитрат_Const
    {
        public const string TABLE = "tab_a01";
        
        public const string Назва = "col_a1";
        public const string Код = "col_a2";
    }
	
    ///<summary>
    ///Статті витрат.
    ///</summary>
    public class КласифікаторВитрат_Objest : DirectoryObject
    {
        public КласифікаторВитрат_Objest() : base(Config.Kernel, "tab_a01",
             new string[] { "col_a1", "col_a2" }) 
        {
            Назва = "";
            Код = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                Код = base.FieldValue["col_a2"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = Назва;
            base.FieldValue["col_a2"] = Код;
            
            BaseSave();
			
        }

        public string Serialize(string root = "КласифікаторВитрат")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "</" + root + ">";
        }

        public КласифікаторВитрат_Objest Copy()
        {
            КласифікаторВитрат_Objest copy = new КласифікаторВитрат_Objest();
			copy.New();
            copy.Назва = Назва;
			copy.Код = Код;
			
			return copy;
        }

        public void Delete()
        {
            
			base.BaseDelete(new string[] {  });
        }
        
        public КласифікаторВитрат_Pointer GetDirectoryPointer()
        {
            КласифікаторВитрат_Pointer directoryPointer = new КласифікаторВитрат_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        
    }
    
    ///<summary>
    ///Статті витрат.
    ///</summary>
    public class КласифікаторВитрат_Pointer : DirectoryPointer
    {
        public КласифікаторВитрат_Pointer(object uid = null) : base(Config.Kernel, "tab_a01")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public КласифікаторВитрат_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a01")
        {
            base.Init(uid, fields);
        }
        
        public КласифікаторВитрат_Objest GetDirectoryObject()
        {
            if (this.IsEmpty()) return null;
            КласифікаторВитрат_Objest КласифікаторВитратObjestItem = new КласифікаторВитрат_Objest();
            return КласифікаторВитратObjestItem.Read(base.UnigueID) ? КласифікаторВитратObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] { "col_a1" }
			);
        }
		
        public КласифікаторВитрат_Pointer GetEmptyPointer()
        {
            return new КласифікаторВитрат_Pointer();
        }
    }
    
    ///<summary>
    ///Статті витрат.
    ///</summary>
    public class КласифікаторВитрат_Select : DirectorySelect, IDisposable
    {
        public КласифікаторВитрат_Select() : base(Config.Kernel, "tab_a01") { }        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new КласифікаторВитрат_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public КласифікаторВитрат_Pointer Current { get; private set; }
        
        public КласифікаторВитрат_Pointer FindByField(string name, object value)
        {
            КласифікаторВитрат_Pointer itemPointer = new КласифікаторВитрат_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<КласифікаторВитрат_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<КласифікаторВитрат_Pointer> directoryPointerList = new List<КласифікаторВитрат_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new КласифікаторВитрат_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "Записник"
    ///<summary>
    ///Записник інформації.
    ///</summary>
    public static class Записник_Const
    {
        public const string TABLE = "tab_a03";
        
        public const string Назва = "col_a1";
        public const string Опис = "col_a4";
        public const string Дата = "col_a3";
        public const string Папка = "col_a2";
        public const string Сайт = "col_a5";
    }
	
    ///<summary>
    ///Записник інформації.
    ///</summary>
    public class Записник_Objest : DirectoryObject
    {
        public Записник_Objest() : base(Config.Kernel, "tab_a03",
             new string[] { "col_a1", "col_a4", "col_a3", "col_a2", "col_a5" }) 
        {
            Назва = "";
            Опис = "";
            Дата = DateTime.MinValue;
            Папка = new Довідники.Записник_Папки_Pointer();
            Сайт = "";
            
            //Табличні частини
            Файли_TablePart = new Записник_Файли_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                Опис = base.FieldValue["col_a4"].ToString();
                Дата = (base.FieldValue["col_a3"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_a3"].ToString()) : DateTime.MinValue;
                Папка = new Довідники.Записник_Папки_Pointer(base.FieldValue["col_a2"]);
                Сайт = base.FieldValue["col_a5"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = Назва;
            base.FieldValue["col_a4"] = Опис;
            base.FieldValue["col_a3"] = Дата;
            base.FieldValue["col_a2"] = Папка.UnigueID.UGuid;
            base.FieldValue["col_a5"] = Сайт;
            
            BaseSave();
			Записник_Triggers.Записник_AfterRecording(this);
        }

        public string Serialize(string root = "Записник")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Опис>" + "<![CDATA[" + Опис + "]]>" + "</Опис>"  +
               "<Дата>" + Дата.ToString() + "</Дата>"  +
               "<Папка>" + Папка.ToString() + "</Папка>"  +
               "<Сайт>" + "<![CDATA[" + Сайт + "]]>" + "</Сайт>"  +
               "</" + root + ">";
        }

        public Записник_Objest Copy()
        {
            Записник_Objest copy = new Записник_Objest();
			copy.New();
            copy.Назва = Назва;
			copy.Опис = Опис;
			copy.Дата = Дата;
			copy.Папка = Папка;
			copy.Сайт = Сайт;
			
			return copy;
        }

        public void Delete()
        {
            
			base.BaseDelete(new string[] { "tab_a17" });
        }
        
        public Записник_Pointer GetDirectoryPointer()
        {
            Записник_Pointer directoryPointer = new Записник_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Опис { get; set; }
        public DateTime Дата { get; set; }
        public Довідники.Записник_Папки_Pointer Папка { get; set; }
        public string Сайт { get; set; }
        
        //Табличні частини
        public Записник_Файли_TablePart Файли_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Записник інформації.
    ///</summary>
    public class Записник_Pointer : DirectoryPointer
    {
        public Записник_Pointer(object uid = null) : base(Config.Kernel, "tab_a03")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Записник_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a03")
        {
            base.Init(uid, fields);
        }
        
        public Записник_Objest GetDirectoryObject()
        {
            if (this.IsEmpty()) return null;
            Записник_Objest ЗаписникObjestItem = new Записник_Objest();
            return ЗаписникObjestItem.Read(base.UnigueID) ? ЗаписникObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public Записник_Pointer GetEmptyPointer()
        {
            return new Записник_Pointer();
        }
    }
    
    ///<summary>
    ///Записник інформації.
    ///</summary>
    public class Записник_Select : DirectorySelect, IDisposable
    {
        public Записник_Select() : base(Config.Kernel, "tab_a03") { }        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Записник_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Записник_Pointer Current { get; private set; }
        
        public Записник_Pointer FindByField(string name, object value)
        {
            Записник_Pointer itemPointer = new Записник_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Записник_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Записник_Pointer> directoryPointerList = new List<Записник_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Записник_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
    public class Записник_Файли_TablePart : DirectoryTablePart
    {
        public Записник_Файли_TablePart(Записник_Objest owner) : base(Config.Kernel, "tab_a17",
             new string[] { "col_a1", "col_a2" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Записник_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Назва = fieldValue["col_a1"].ToString();
                record.НазваФайлуНаДиску = fieldValue["col_a2"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            base.BaseBeginTransaction();
                
            if (clear_all_before_save)
                base.BaseDelete(Owner.UnigueID);

            foreach (Record record in Records)
            {
                Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                fieldValue.Add("col_a1", record.Назва);
                fieldValue.Add("col_a2", record.НазваФайлуНаДиску);
                
                base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
            }
                
            base.BaseCommitTransaction();
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete(Owner.UnigueID);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : DirectoryTablePartRecord
        {
            public Record()
            {
                Назва = "";
                НазваФайлуНаДиску = "";
                
            }
        
            
            public Record(
                string _Назва = "", string _НазваФайлуНаДиску = "")
            {
                Назва = _Назва;
                НазваФайлуНаДиску = _НазваФайлуНаДиску;
                
            }
            public string Назва { get; set; }
            public string НазваФайлуНаДиску { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "Користувач"
    ///<summary>
    ///Користувач програми.
    ///</summary>
    public static class Користувач_Const
    {
        public const string TABLE = "tab_a04";
        
        public const string Назва = "col_a1";
        public const string Код = "col_a2";
    }
	
    ///<summary>
    ///Користувач програми.
    ///</summary>
    public class Користувач_Objest : DirectoryObject
    {
        public Користувач_Objest() : base(Config.Kernel, "tab_a04",
             new string[] { "col_a1", "col_a2" }) 
        {
            Назва = "";
            Код = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                Код = base.FieldValue["col_a2"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = Назва;
            base.FieldValue["col_a2"] = Код;
            
            BaseSave();
			
        }

        public string Serialize(string root = "Користувач")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "</" + root + ">";
        }

        public Користувач_Objest Copy()
        {
            Користувач_Objest copy = new Користувач_Objest();
			copy.New();
            copy.Назва = Назва;
			copy.Код = Код;
			
			return copy;
        }

        public void Delete()
        {
            
			base.BaseDelete(new string[] {  });
        }
        
        public Користувач_Pointer GetDirectoryPointer()
        {
            Користувач_Pointer directoryPointer = new Користувач_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        
    }
    
    ///<summary>
    ///Користувач програми.
    ///</summary>
    public class Користувач_Pointer : DirectoryPointer
    {
        public Користувач_Pointer(object uid = null) : base(Config.Kernel, "tab_a04")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Користувач_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a04")
        {
            base.Init(uid, fields);
        }
        
        public Користувач_Objest GetDirectoryObject()
        {
            if (this.IsEmpty()) return null;
            Користувач_Objest КористувачObjestItem = new Користувач_Objest();
            return КористувачObjestItem.Read(base.UnigueID) ? КористувачObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public Користувач_Pointer GetEmptyPointer()
        {
            return new Користувач_Pointer();
        }
    }
    
    ///<summary>
    ///Користувач програми.
    ///</summary>
    public class Користувач_Select : DirectorySelect, IDisposable
    {
        public Користувач_Select() : base(Config.Kernel, "tab_a04") { }        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Користувач_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Користувач_Pointer Current { get; private set; }
        
        public Користувач_Pointer FindByField(string name, object value)
        {
            Користувач_Pointer itemPointer = new Користувач_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Користувач_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Користувач_Pointer> directoryPointerList = new List<Користувач_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Користувач_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "Каса"
    ///<summary>
    ///Місце зберігання грошей.
    ///</summary>
    public static class Каса_Const
    {
        public const string TABLE = "tab_a05";
        
        public const string Назва = "col_a1";
        public const string Валюта = "col_a2";
        public const string ТипВалюти = "col_a3";
    }
	
    ///<summary>
    ///Місце зберігання грошей.
    ///</summary>
    public class Каса_Objest : DirectoryObject
    {
        public Каса_Objest() : base(Config.Kernel, "tab_a05",
             new string[] { "col_a1", "col_a2", "col_a3" }) 
        {
            Назва = "";
            Валюта = new Довідники.Валюта_Pointer();
            ТипВалюти = 0;
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                Валюта = new Довідники.Валюта_Pointer(base.FieldValue["col_a2"]);
                ТипВалюти = (base.FieldValue["col_a3"] != DBNull.Value) ? (Перелічення.ТипВалюти)base.FieldValue["col_a3"] : 0;
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = Назва;
            base.FieldValue["col_a2"] = Валюта.UnigueID.UGuid;
            base.FieldValue["col_a3"] = (int)ТипВалюти;
            
            BaseSave();
			
        }

        public string Serialize(string root = "Каса")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Валюта>" + Валюта.ToString() + "</Валюта>"  +
               "<ТипВалюти>" + ((int)ТипВалюти).ToString() + "</ТипВалюти>"  +
               "</" + root + ">";
        }

        public Каса_Objest Copy()
        {
            Каса_Objest copy = new Каса_Objest();
			copy.New();
            copy.Назва = Назва;
			copy.Валюта = Валюта;
			copy.ТипВалюти = ТипВалюти;
			
			return copy;
        }

        public void Delete()
        {
            
			base.BaseDelete(new string[] {  });
        }
        
        public Каса_Pointer GetDirectoryPointer()
        {
            Каса_Pointer directoryPointer = new Каса_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public Довідники.Валюта_Pointer Валюта { get; set; }
        public Перелічення.ТипВалюти ТипВалюти { get; set; }
        
    }
    
    ///<summary>
    ///Місце зберігання грошей.
    ///</summary>
    public class Каса_Pointer : DirectoryPointer
    {
        public Каса_Pointer(object uid = null) : base(Config.Kernel, "tab_a05")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Каса_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a05")
        {
            base.Init(uid, fields);
        }
        
        public Каса_Objest GetDirectoryObject()
        {
            if (this.IsEmpty()) return null;
            Каса_Objest КасаObjestItem = new Каса_Objest();
            return КасаObjestItem.Read(base.UnigueID) ? КасаObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] { "col_a1" }
			);
        }
		
        public Каса_Pointer GetEmptyPointer()
        {
            return new Каса_Pointer();
        }
    }
    
    ///<summary>
    ///Місце зберігання грошей.
    ///</summary>
    public class Каса_Select : DirectorySelect, IDisposable
    {
        public Каса_Select() : base(Config.Kernel, "tab_a05") { }        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Каса_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Каса_Pointer Current { get; private set; }
        
        public Каса_Pointer FindByField(string name, object value)
        {
            Каса_Pointer itemPointer = new Каса_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Каса_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Каса_Pointer> directoryPointerList = new List<Каса_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Каса_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "Валюта"
    ///<summary>
    ///Валюта.
    ///</summary>
    public static class Валюта_Const
    {
        public const string TABLE = "tab_a07";
        
        public const string Назва = "col_a3";
        public const string Код = "col_a4";
    }
	
    ///<summary>
    ///Валюта.
    ///</summary>
    public class Валюта_Objest : DirectoryObject
    {
        public Валюта_Objest() : base(Config.Kernel, "tab_a07",
             new string[] { "col_a3", "col_a4" }) 
        {
            Назва = "";
            Код = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a3"].ToString();
                Код = base.FieldValue["col_a4"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a3"] = Назва;
            base.FieldValue["col_a4"] = Код;
            
            BaseSave();
			
        }

        public string Serialize(string root = "Валюта")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "</" + root + ">";
        }

        public Валюта_Objest Copy()
        {
            Валюта_Objest copy = new Валюта_Objest();
			copy.New();
            copy.Назва = Назва;
			copy.Код = Код;
			
			return copy;
        }

        public void Delete()
        {
            
			base.BaseDelete(new string[] {  });
        }
        
        public Валюта_Pointer GetDirectoryPointer()
        {
            Валюта_Pointer directoryPointer = new Валюта_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        
    }
    
    ///<summary>
    ///Валюта.
    ///</summary>
    public class Валюта_Pointer : DirectoryPointer
    {
        public Валюта_Pointer(object uid = null) : base(Config.Kernel, "tab_a07")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Валюта_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a07")
        {
            base.Init(uid, fields);
        }
        
        public Валюта_Objest GetDirectoryObject()
        {
            if (this.IsEmpty()) return null;
            Валюта_Objest ВалютаObjestItem = new Валюта_Objest();
            return ВалютаObjestItem.Read(base.UnigueID) ? ВалютаObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] { "col_a3" }
			);
        }
		
        public Валюта_Pointer GetEmptyPointer()
        {
            return new Валюта_Pointer();
        }
    }
    
    ///<summary>
    ///Валюта.
    ///</summary>
    public class Валюта_Select : DirectorySelect, IDisposable
    {
        public Валюта_Select() : base(Config.Kernel, "tab_a07") { }        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Валюта_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Валюта_Pointer Current { get; private set; }
        
        public Валюта_Pointer FindByField(string name, object value)
        {
            Валюта_Pointer itemPointer = new Валюта_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Валюта_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Валюта_Pointer> directoryPointerList = new List<Валюта_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Валюта_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "Контакти"
    ///<summary>
    ///Довідник для контактів.
    ///</summary>
    public static class Контакти_Const
    {
        public const string TABLE = "tab_a08";
        
        public const string Телефон = "col_a4";
        public const string Назва = "col_a3";
        public const string Сайт = "col_a5";
        public const string Пошта = "col_a6";
        public const string Опис = "col_a7";
        public const string Скайп = "col_a1";
        public const string Фото = "col_a2";
    }
	
    ///<summary>
    ///Довідник для контактів.
    ///</summary>
    public class Контакти_Objest : DirectoryObject
    {
        public Контакти_Objest() : base(Config.Kernel, "tab_a08",
             new string[] { "col_a4", "col_a3", "col_a5", "col_a6", "col_a7", "col_a1", "col_a2" }) 
        {
            Телефон = "";
            Назва = "";
            Сайт = "";
            Пошта = "";
            Опис = "";
            Скайп = "";
            Фото = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Телефон = base.FieldValue["col_a4"].ToString();
                Назва = base.FieldValue["col_a3"].ToString();
                Сайт = base.FieldValue["col_a5"].ToString();
                Пошта = base.FieldValue["col_a6"].ToString();
                Опис = base.FieldValue["col_a7"].ToString();
                Скайп = base.FieldValue["col_a1"].ToString();
                Фото = base.FieldValue["col_a2"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a4"] = Телефон;
            base.FieldValue["col_a3"] = Назва;
            base.FieldValue["col_a5"] = Сайт;
            base.FieldValue["col_a6"] = Пошта;
            base.FieldValue["col_a7"] = Опис;
            base.FieldValue["col_a1"] = Скайп;
            base.FieldValue["col_a2"] = Фото;
            
            BaseSave();
			
        }

        public string Serialize(string root = "Контакти")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Телефон>" + "<![CDATA[" + Телефон + "]]>" + "</Телефон>"  +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Сайт>" + "<![CDATA[" + Сайт + "]]>" + "</Сайт>"  +
               "<Пошта>" + "<![CDATA[" + Пошта + "]]>" + "</Пошта>"  +
               "<Опис>" + "<![CDATA[" + Опис + "]]>" + "</Опис>"  +
               "<Скайп>" + "<![CDATA[" + Скайп + "]]>" + "</Скайп>"  +
               "<Фото>" + "<![CDATA[" + Фото + "]]>" + "</Фото>"  +
               "</" + root + ">";
        }

        public Контакти_Objest Copy()
        {
            Контакти_Objest copy = new Контакти_Objest();
			copy.New();
            copy.Телефон = Телефон;
			copy.Назва = Назва;
			copy.Сайт = Сайт;
			copy.Пошта = Пошта;
			copy.Опис = Опис;
			copy.Скайп = Скайп;
			copy.Фото = Фото;
			
			return copy;
        }

        public void Delete()
        {
            
			base.BaseDelete(new string[] {  });
        }
        
        public Контакти_Pointer GetDirectoryPointer()
        {
            Контакти_Pointer directoryPointer = new Контакти_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Телефон { get; set; }
        public string Назва { get; set; }
        public string Сайт { get; set; }
        public string Пошта { get; set; }
        public string Опис { get; set; }
        public string Скайп { get; set; }
        public string Фото { get; set; }
        
    }
    
    ///<summary>
    ///Довідник для контактів.
    ///</summary>
    public class Контакти_Pointer : DirectoryPointer
    {
        public Контакти_Pointer(object uid = null) : base(Config.Kernel, "tab_a08")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Контакти_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a08")
        {
            base.Init(uid, fields);
        }
        
        public Контакти_Objest GetDirectoryObject()
        {
            if (this.IsEmpty()) return null;
            Контакти_Objest КонтактиObjestItem = new Контакти_Objest();
            return КонтактиObjestItem.Read(base.UnigueID) ? КонтактиObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] { "col_a3" }
			);
        }
		
        public Контакти_Pointer GetEmptyPointer()
        {
            return new Контакти_Pointer();
        }
    }
    
    ///<summary>
    ///Довідник для контактів.
    ///</summary>
    public class Контакти_Select : DirectorySelect, IDisposable
    {
        public Контакти_Select() : base(Config.Kernel, "tab_a08") { }        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Контакти_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Контакти_Pointer Current { get; private set; }
        
        public Контакти_Pointer FindByField(string name, object value)
        {
            Контакти_Pointer itemPointer = new Контакти_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Контакти_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Контакти_Pointer> directoryPointerList = new List<Контакти_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Контакти_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "Записник_Папки"
    ///<summary>
    ///Ієрархія для довідника Записник.
    ///</summary>
    public static class Записник_Папки_Const
    {
        public const string TABLE = "tab_a09";
        
        public const string Назва = "col_a1";
        public const string Родич = "col_a3";
        public const string Дата = "col_a2";
    }
	
    ///<summary>
    ///Ієрархія для довідника Записник.
    ///</summary>
    public class Записник_Папки_Objest : DirectoryObject
    {
        public Записник_Папки_Objest() : base(Config.Kernel, "tab_a09",
             new string[] { "col_a1", "col_a3", "col_a2" }) 
        {
            Назва = "";
            Родич = new Довідники.Записник_Папки_Pointer();
            Дата = DateTime.MinValue;
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                Родич = new Довідники.Записник_Папки_Pointer(base.FieldValue["col_a3"]);
                Дата = (base.FieldValue["col_a2"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_a2"].ToString()) : DateTime.MinValue;
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = Назва;
            base.FieldValue["col_a3"] = Родич.UnigueID.UGuid;
            base.FieldValue["col_a2"] = Дата;
            
            BaseSave();
			Записник_Папки_Triggers.Записник_Папки_AfterRecording(this);
        }

        public string Serialize(string root = "Записник_Папки")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Родич>" + Родич.ToString() + "</Родич>"  +
               "<Дата>" + Дата.ToString() + "</Дата>"  +
               "</" + root + ">";
        }

        public Записник_Папки_Objest Copy()
        {
            Записник_Папки_Objest copy = new Записник_Папки_Objest();
			copy.New();
            copy.Назва = Назва;
			copy.Родич = Родич;
			copy.Дата = Дата;
			
			return copy;
        }

        public void Delete()
        {
            Записник_Папки_Triggers.Записник_Папки_BeforeDelete(this);
			base.BaseDelete(new string[] {  });
        }
        
        public Записник_Папки_Pointer GetDirectoryPointer()
        {
            Записник_Папки_Pointer directoryPointer = new Записник_Папки_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public Довідники.Записник_Папки_Pointer Родич { get; set; }
        public DateTime Дата { get; set; }
        
    }
    
    ///<summary>
    ///Ієрархія для довідника Записник.
    ///</summary>
    public class Записник_Папки_Pointer : DirectoryPointer
    {
        public Записник_Папки_Pointer(object uid = null) : base(Config.Kernel, "tab_a09")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Записник_Папки_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a09")
        {
            base.Init(uid, fields);
        }
        
        public Записник_Папки_Objest GetDirectoryObject()
        {
            if (this.IsEmpty()) return null;
            Записник_Папки_Objest Записник_ПапкиObjestItem = new Записник_Папки_Objest();
            return Записник_ПапкиObjestItem.Read(base.UnigueID) ? Записник_ПапкиObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] { "col_a1" }
			);
        }
		
        public Записник_Папки_Pointer GetEmptyPointer()
        {
            return new Записник_Папки_Pointer();
        }
    }
    
    ///<summary>
    ///Ієрархія для довідника Записник.
    ///</summary>
    public class Записник_Папки_Select : DirectorySelect, IDisposable
    {
        public Записник_Папки_Select() : base(Config.Kernel, "tab_a09") { }        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Записник_Папки_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Записник_Папки_Pointer Current { get; private set; }
        
        public Записник_Папки_Pointer FindByField(string name, object value)
        {
            Записник_Папки_Pointer itemPointer = new Записник_Папки_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Записник_Папки_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Записник_Папки_Pointer> directoryPointerList = new List<Записник_Папки_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Записник_Папки_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "КалендарПеріодичнихЗавдань"
    ///<summary>
    ///Список періодичних завдань. Наприклад: подати покази лічильників води, світла і т.д з періодичністю раз на місяць..
    ///</summary>
    public static class КалендарПеріодичнихЗавдань_Const
    {
        public const string TABLE = "tab_a53";
        
        public const string Назва = "col_a1";
        public const string ПеріодВиконання = "col_a3";
        public const string Опис = "col_a4";
        public const string Старт = "col_a2";
    }
	
    ///<summary>
    ///Список періодичних завдань. Наприклад: подати покази лічильників води, світла і т.д з періодичністю раз на місяць..
    ///</summary>
    public class КалендарПеріодичнихЗавдань_Objest : DirectoryObject
    {
        public КалендарПеріодичнихЗавдань_Objest() : base(Config.Kernel, "tab_a53",
             new string[] { "col_a1", "col_a3", "col_a4", "col_a2" }) 
        {
            Назва = "";
            ПеріодВиконання = 0;
            Опис = "";
            Старт = DateTime.MinValue;
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                ПеріодВиконання = (base.FieldValue["col_a3"] != DBNull.Value) ? (Перелічення.ПеріодиВиконанняЗавдань)base.FieldValue["col_a3"] : 0;
                Опис = base.FieldValue["col_a4"].ToString();
                Старт = (base.FieldValue["col_a2"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_a2"].ToString()) : DateTime.MinValue;
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = Назва;
            base.FieldValue["col_a3"] = (int)ПеріодВиконання;
            base.FieldValue["col_a4"] = Опис;
            base.FieldValue["col_a2"] = Старт;
            
            BaseSave();
			
        }

        public string Serialize(string root = "КалендарПеріодичнихЗавдань")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<ПеріодВиконання>" + ((int)ПеріодВиконання).ToString() + "</ПеріодВиконання>"  +
               "<Опис>" + "<![CDATA[" + Опис + "]]>" + "</Опис>"  +
               "<Старт>" + Старт.ToString() + "</Старт>"  +
               "</" + root + ">";
        }

        public КалендарПеріодичнихЗавдань_Objest Copy()
        {
            КалендарПеріодичнихЗавдань_Objest copy = new КалендарПеріодичнихЗавдань_Objest();
			copy.New();
            copy.Назва = Назва;
			copy.ПеріодВиконання = ПеріодВиконання;
			copy.Опис = Опис;
			copy.Старт = Старт;
			
			return copy;
        }

        public void Delete()
        {
            
			base.BaseDelete(new string[] {  });
        }
        
        public КалендарПеріодичнихЗавдань_Pointer GetDirectoryPointer()
        {
            КалендарПеріодичнихЗавдань_Pointer directoryPointer = new КалендарПеріодичнихЗавдань_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public Перелічення.ПеріодиВиконанняЗавдань ПеріодВиконання { get; set; }
        public string Опис { get; set; }
        public DateTime Старт { get; set; }
        
    }
    
    ///<summary>
    ///Список періодичних завдань. Наприклад: подати покази лічильників води, світла і т.д з періодичністю раз на місяць..
    ///</summary>
    public class КалендарПеріодичнихЗавдань_Pointer : DirectoryPointer
    {
        public КалендарПеріодичнихЗавдань_Pointer(object uid = null) : base(Config.Kernel, "tab_a53")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public КалендарПеріодичнихЗавдань_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a53")
        {
            base.Init(uid, fields);
        }
        
        public КалендарПеріодичнихЗавдань_Objest GetDirectoryObject()
        {
            if (this.IsEmpty()) return null;
            КалендарПеріодичнихЗавдань_Objest КалендарПеріодичнихЗавданьObjestItem = new КалендарПеріодичнихЗавдань_Objest();
            return КалендарПеріодичнихЗавданьObjestItem.Read(base.UnigueID) ? КалендарПеріодичнихЗавданьObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] { "col_a1" }
			);
        }
		
        public КалендарПеріодичнихЗавдань_Pointer GetEmptyPointer()
        {
            return new КалендарПеріодичнихЗавдань_Pointer();
        }
    }
    
    ///<summary>
    ///Список періодичних завдань. Наприклад: подати покази лічильників води, світла і т.д з періодичністю раз на місяць..
    ///</summary>
    public class КалендарПеріодичнихЗавдань_Select : DirectorySelect, IDisposable
    {
        public КалендарПеріодичнихЗавдань_Select() : base(Config.Kernel, "tab_a53") { }        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new КалендарПеріодичнихЗавдань_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public КалендарПеріодичнихЗавдань_Pointer Current { get; private set; }
        
        public КалендарПеріодичнихЗавдань_Pointer FindByField(string name, object value)
        {
            КалендарПеріодичнихЗавдань_Pointer itemPointer = new КалендарПеріодичнихЗавдань_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<КалендарПеріодичнихЗавдань_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<КалендарПеріодичнихЗавдань_Pointer> directoryPointerList = new List<КалендарПеріодичнихЗавдань_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new КалендарПеріодичнихЗавдань_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
}

namespace HomeFinances_1_0.Перелічення
{
    
    #region ENUM "ТипЗапису"
    ///<summary>
    ///Тип запису - це поступлення фінансів або витрати фінансів.
    ///</summary>
    public enum ТипЗапису
    {
         Витрати = 2,
         Поступлення = 3,
         Благодійність = 4,
         Замітка = 5,
         Переміщення = 7,
         Обмін = 8,
         Корегування = 9
    }
    #endregion
    
    #region ENUM "ТипВалюти"
    ///<summary>
    ///Нал, безнал.
    ///</summary>
    public enum ТипВалюти
    {
         Готівка = 1,
         Карточка = 2
    }
    #endregion
    
    #region ENUM "ПеріодиВиконанняЗавдань"
    ///<summary>
    ///Для довідника КалендарПеріодичнихЗавдань.
    ///</summary>
    public enum ПеріодиВиконанняЗавдань
    {
         День = 2,
         Тиждень = 3,
         Місяць = 4,
         Квартал = 5,
         Півроку = 6,
         Рік = 7
    }
    #endregion
    
    #region ENUM "ВаріантиПочаткуПеріоду"
    ///<summary>
    ///Для константи ДатаПочаткуПеріоду..
    ///</summary>
    public enum ВаріантиПочаткуПеріоду
    {
         ЗПочаткуМісяця = 1,
         Тиждень = 2,
         Місяць = 6,
         Квартал = 3,
         ПівРоку = 4,
         Рік = 5
    }
    #endregion
    
}

namespace HomeFinances_1_0.Документи
{
    
}

namespace HomeFinances_1_0.РегістриВідомостей
{
    
}

namespace HomeFinances_1_0.РегістриНакопичення
{
    
    #region REGISTER "ЗалишкиКоштів"
    
    public static class ЗалишкиКоштів_Const
    {
        public const string TABLE = "tab_a19";
        
        public const string Каса = "col_a1";
        public const string Сума = "col_a2";
    }
	
    
    public class ЗалишкиКоштів_RecordsSet : RegisterAccumulationRecordsSet
    {
        public ЗалишкиКоштів_RecordsSet() : base(Config.Kernel, "tab_a19",
             new string[] { "col_a1", "col_a2" }) 
        {
            Records = new List<Record>();
        }
		
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            
            base.BaseRead();
            
            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
				record.Period = DateTime.Parse(fieldValue["period"].ToString());
                record.Income = (bool)fieldValue["income"];
                record.Owner = (Guid)fieldValue["owner"];
                record.Каса = new Довідники.Каса_Pointer(fieldValue["col_a1"]);
                record.Сума = (fieldValue["col_a2"] != DBNull.Value) ? (decimal)fieldValue["col_a2"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(DateTime period, Guid owner) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                base.BaseDelete(owner);
                foreach (Record record in Records)
                {
                    record.Period = period;
                    record.Owner = owner;
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();
                    fieldValue.Add("col_a1", record.Каса.UnigueID.UGuid);
                    fieldValue.Add("col_a2", record.Сума);
                    
                    base.BaseSave(record.UID, period, record.Income, owner, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }

        public void Delete(Guid owner)
        {
            base.BaseBeginTransaction();
            base.BaseDelete(owner);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : RegisterAccumulationRecord
        {
            public Record()
            {
                Каса = new Довідники.Каса_Pointer();
                Сума = 0;
                
            }
            public Довідники.Каса_Pointer Каса { get; set; }
            public decimal Сума { get; set; }
            
        }
    }
    
    #endregion
  
}
  