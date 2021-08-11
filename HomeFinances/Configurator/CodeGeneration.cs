
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
 * Конфігурації "Нова конфігурація"
 * Автор 
  
 * Дата конфігурації: 11.08.2021 17:06:15
 *
 */

using System;
using System.Collections.Generic;
using AccountingSoftware;

namespace НоваКонфігурація_1_0
{
    static class Config
    {
        public static Kernel Kernel { get; set; }
		
        public static void ReadAllConstants()
        {
            Константи.Основний.ReadAll();
            Константи.ЗначенняПоЗамовчуванню.ReadAll();
            
        }
    }
}

namespace НоваКонфігурація_1_0.Константи
{
    
	#region CONSTANTS BLOCK "Основний"
    static class Основний
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
    static class ЗначенняПоЗамовчуванню
    {
        public static void ReadAll()
        {
            
            Dictionary<string, object> fieldValue = new Dictionary<string, object>();
            bool IsSelect = Config.Kernel.DataBase.SelectAllConstants("tab_constants",
                 new string[] { "col_a1", "col_a2", "col_a4", "col_a5", "col_a6", "col_a7" }, fieldValue);
            
            if (IsSelect)
            {
                m_ОсновнаКаса_Const = new Довідники.Каса_Pointer(fieldValue["col_a1"]);
                m_ОсновнаСтаттяВитрат_Const = new Довідники.КласифікаторВитрат_Pointer(fieldValue["col_a2"]);
                m_ОсновнийСклад_Const = new Довідники.Склади_Pointer(fieldValue["col_a4"]);
                m_ОсновнийПостачальник_Const = new Довідники.Контрагенти_Pointer(fieldValue["col_a5"]);
                m_ОсновнийПокупець_Const = new Довідники.Контрагенти_Pointer(fieldValue["col_a6"]);
                m_ОсновнаОрганізація_Const = new Довідники.Організації_Pointer(fieldValue["col_a7"]);
                
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
        
        static Довідники.Склади_Pointer m_ОсновнийСклад_Const = new Довідники.Склади_Pointer();
        public static Довідники.Склади_Pointer ОсновнийСклад_Const
        {
            get { return m_ОсновнийСклад_Const; }
            set
            {
                m_ОсновнийСклад_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a4", m_ОсновнийСклад_Const.UnigueID.UGuid);
            }
        }
        
        static Довідники.Контрагенти_Pointer m_ОсновнийПостачальник_Const = new Довідники.Контрагенти_Pointer();
        public static Довідники.Контрагенти_Pointer ОсновнийПостачальник_Const
        {
            get { return m_ОсновнийПостачальник_Const; }
            set
            {
                m_ОсновнийПостачальник_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a5", m_ОсновнийПостачальник_Const.UnigueID.UGuid);
            }
        }
        
        static Довідники.Контрагенти_Pointer m_ОсновнийПокупець_Const = new Довідники.Контрагенти_Pointer();
        public static Довідники.Контрагенти_Pointer ОсновнийПокупець_Const
        {
            get { return m_ОсновнийПокупець_Const; }
            set
            {
                m_ОсновнийПокупець_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a6", m_ОсновнийПокупець_Const.UnigueID.UGuid);
            }
        }
        
        static Довідники.Організації_Pointer m_ОсновнаОрганізація_Const = new Довідники.Організації_Pointer();
        public static Довідники.Організації_Pointer ОсновнаОрганізація_Const
        {
            get { return m_ОсновнаОрганізація_Const; }
            set
            {
                m_ОсновнаОрганізація_Const = value;
                Config.Kernel.DataBase.SaveConstants("tab_constants", "col_a7", m_ОсновнаОрганізація_Const.UnigueID.UGuid);
            }
        }
             
    }
    #endregion
    
}

namespace НоваКонфігурація_1_0.Довідники
{
    
    #region DIRECTORY "Записи"
    ///<summary>
    ///Записи про витрати і надходження фінансів.
    ///</summary>
    class Записи_Objest : DirectoryObject
    {
        public Записи_Objest() : base(Config.Kernel, "tab_a02",
             new string[] { "col_a7", "col_a6", "col_a8", "col_a9", "col_b1", "col_a1", "col_a2", "col_a4" }) 
        {
            Назва = "";
            ДатаЗапису = DateTime.MinValue;
            Опис = "";
            ТипЗапису = 0;
            Сума = 0;
            Витрата = new Довідники.КласифікаторВитрат_Pointer();
            Каса = new Довідники.Каса_Pointer();
            СсилкаНаСайт = "";
            
            //Табличні частини
            ОбмінІсторія_TablePart = new Записи_ОбмінІсторія_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a7"].ToString();
                ДатаЗапису = (base.FieldValue["col_a6"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_a6"].ToString()) : DateTime.MinValue;
                Опис = base.FieldValue["col_a8"].ToString();
                ТипЗапису = (base.FieldValue["col_a9"] != DBNull.Value) ? (Перелічення.ТипЗапису)base.FieldValue["col_a9"] : 0;
                Сума = (base.FieldValue["col_b1"] != DBNull.Value) ? (int)base.FieldValue["col_b1"] : 0;
                Витрата = new Довідники.КласифікаторВитрат_Pointer(base.FieldValue["col_a1"]);
                Каса = new Довідники.Каса_Pointer(base.FieldValue["col_a2"]);
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
            base.FieldValue["col_a8"] = Опис;
            base.FieldValue["col_a9"] = (int)ТипЗапису;
            base.FieldValue["col_b1"] = Сума;
            base.FieldValue["col_a1"] = Витрата.UnigueID.UGuid;
            base.FieldValue["col_a2"] = Каса.UnigueID.UGuid;
            base.FieldValue["col_a4"] = СсилкаНаСайт;
            
            BaseSave();
        }

        public string Serialize(string root = "Записи")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<ДатаЗапису>" + ДатаЗапису.ToString() + "</ДатаЗапису>"  +
               "<Опис>" + "<![CDATA[" + Опис + "]]>" + "</Опис>"  +
               "<ТипЗапису>" + ((int)ТипЗапису).ToString() + "</ТипЗапису>"  +
               "<Сума>" + Сума.ToString() + "</Сума>"  +
               "<Витрата>" + Витрата.ToString() + "</Витрата>"  +
               "<Каса>" + Каса.ToString() + "</Каса>"  +
               "<СсилкаНаСайт>" + "<![CDATA[" + СсилкаНаСайт + "]]>" + "</СсилкаНаСайт>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Записи_Pointer GetDirectoryPointer()
        {
            Записи_Pointer directoryPointer = new Записи_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public DateTime ДатаЗапису { get; set; }
        public string Опис { get; set; }
        public Перелічення.ТипЗапису ТипЗапису { get; set; }
        public int Сума { get; set; }
        public Довідники.КласифікаторВитрат_Pointer Витрата { get; set; }
        public Довідники.Каса_Pointer Каса { get; set; }
        public string СсилкаНаСайт { get; set; }
        
        //Табличні частини
        public Записи_ОбмінІсторія_TablePart ОбмінІсторія_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Записи про витрати і надходження фінансів.
    ///</summary>
    class Записи_Pointer : DirectoryPointer
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
    class Записи_Select : DirectorySelect, IDisposable
    {
        public Записи_Select() : base(Config.Kernel, "tab_a02",
            new string[] { "col_a7", "col_a6", "col_a8", "col_a9", "col_b1", "col_a1", "col_a2", "col_a4" },
            new string[] { "Назва", "ДатаЗапису", "Опис", "ТипЗапису", "Сума", "Витрата", "Каса", "СсилкаНаСайт" }) { }
        
        public const string Назва = "col_a7";
        public const string ДатаЗапису = "col_a6";
        public const string Опис = "col_a8";
        public const string ТипЗапису = "col_a9";
        public const string Сума = "col_b1";
        public const string Витрата = "col_a1";
        public const string Каса = "col_a2";
        public const string СсилкаНаСайт = "col_a4";
        
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
    
      
    class Записи_ОбмінІсторія_TablePart : DirectoryTablePart
    {
        public Записи_ОбмінІсторія_TablePart(Записи_Objest owner) : base(Config.Kernel, "tab_a13",
             new string[] { "col_a5", "col_a6" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Записи_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Дата = (fieldValue["col_a5"] != DBNull.Value) ? DateTime.Parse(fieldValue["col_a5"].ToString()) : DateTime.MinValue;
                record.Значення = fieldValue["col_a6"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a5", record.Дата);
                    fieldValue.Add("col_a6", record.Значення);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Дата = DateTime.MinValue;
                Значення = "";
                
            }
        
            
            public Record(
                DateTime?  _Дата = null, string _Значення = "")
            {
                Дата = _Дата ?? DateTime.MinValue;
                Значення = _Значення;
                
            }
            public DateTime Дата { get; set; }
            public string Значення { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "КласифікаторВитрат"
    ///<summary>
    ///Статті витрат.
    ///</summary>
    class КласифікаторВитрат_Objest : DirectoryObject
    {
        public КласифікаторВитрат_Objest() : base(Config.Kernel, "tab_a01",
             new string[] { "col_a1", "col_a2" }) 
        {
            Назва = "";
            Код = "";
            
            //Табличні частини
            ОбмінІсторія_TablePart = new КласифікаторВитрат_ОбмінІсторія_TablePart(this);
            
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

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public КласифікаторВитрат_Pointer GetDirectoryPointer()
        {
            КласифікаторВитрат_Pointer directoryPointer = new КласифікаторВитрат_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        
        //Табличні частини
        public КласифікаторВитрат_ОбмінІсторія_TablePart ОбмінІсторія_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Статті витрат.
    ///</summary>
    class КласифікаторВитрат_Pointer : DirectoryPointer
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
    class КласифікаторВитрат_Select : DirectorySelect, IDisposable
    {
        public КласифікаторВитрат_Select() : base(Config.Kernel, "tab_a01",
            new string[] { "col_a1", "col_a2" },
            new string[] { "Назва", "Код" }) { }
        
        public const string Назва = "col_a1";
        public const string Код = "col_a2";
        
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
    
      
    class КласифікаторВитрат_ОбмінІсторія_TablePart : DirectoryTablePart
    {
        public КласифікаторВитрат_ОбмінІсторія_TablePart(КласифікаторВитрат_Objest owner) : base(Config.Kernel, "tab_a10",
             new string[] { "col_a1", "col_a2" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public КласифікаторВитрат_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Дата = (fieldValue["col_a1"] != DBNull.Value) ? DateTime.Parse(fieldValue["col_a1"].ToString()) : DateTime.MinValue;
                record.Значення = fieldValue["col_a2"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a1", record.Дата);
                    fieldValue.Add("col_a2", record.Значення);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Дата = DateTime.MinValue;
                Значення = "";
                
            }
        
            
            public Record(
                DateTime?  _Дата = null, string _Значення = "")
            {
                Дата = _Дата ?? DateTime.MinValue;
                Значення = _Значення;
                
            }
            public DateTime Дата { get; set; }
            public string Значення { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "Записник"
    ///<summary>
    ///Записник інформації.
    ///</summary>
    class Записник_Objest : DirectoryObject
    {
        public Записник_Objest() : base(Config.Kernel, "tab_a03",
             new string[] { "col_a1", "col_a4", "col_a3", "col_a2" }) 
        {
            Назва = "";
            Опис = "";
            Дата = DateTime.MinValue;
            Папка = new Довідники.Записник_Папки_Pointer();
            
            //Табличні частини
            ОбмінІсторія_TablePart = new Записник_ОбмінІсторія_TablePart(this);
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
            
            BaseSave();
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
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
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
        
        //Табличні частини
        public Записник_ОбмінІсторія_TablePart ОбмінІсторія_TablePart { get; set; }
        public Записник_Файли_TablePart Файли_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Записник інформації.
    ///</summary>
    class Записник_Pointer : DirectoryPointer
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
    class Записник_Select : DirectorySelect, IDisposable
    {
        public Записник_Select() : base(Config.Kernel, "tab_a03",
            new string[] { "col_a1", "col_a4", "col_a3", "col_a2" },
            new string[] { "Назва", "Опис", "Дата", "Папка" }) { }
        
        public const string Назва = "col_a1";
        public const string Опис = "col_a4";
        public const string Дата = "col_a3";
        public const string Папка = "col_a2";
        
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
    
      
    class Записник_ОбмінІсторія_TablePart : DirectoryTablePart
    {
        public Записник_ОбмінІсторія_TablePart(Записник_Objest owner) : base(Config.Kernel, "tab_a16",
             new string[] { "col_a3", "col_a4" }) 
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
                
                record.Дата = (fieldValue["col_a3"] != DBNull.Value) ? DateTime.Parse(fieldValue["col_a3"].ToString()) : DateTime.MinValue;
                record.Значення = fieldValue["col_a4"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a3", record.Дата);
                    fieldValue.Add("col_a4", record.Значення);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Дата = DateTime.MinValue;
                Значення = "";
                
            }
        
            
            public Record(
                DateTime?  _Дата = null, string _Значення = "")
            {
                Дата = _Дата ?? DateTime.MinValue;
                Значення = _Значення;
                
            }
            public DateTime Дата { get; set; }
            public string Значення { get; set; }
            
        }
    }
      
    class Записник_Файли_TablePart : DirectoryTablePart
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
            if (Records.Count > 0)
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
    class Користувач_Objest : DirectoryObject
    {
        public Користувач_Objest() : base(Config.Kernel, "tab_a04",
             new string[] { "col_a1", "col_a2" }) 
        {
            Назва = "";
            Код = "";
            
            //Табличні частини
            НалаштуванняФормиЗаписиФінансів_TablePart = new Користувач_НалаштуванняФормиЗаписиФінансів_TablePart(this);
            
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

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Користувач_Pointer GetDirectoryPointer()
        {
            Користувач_Pointer directoryPointer = new Користувач_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        
        //Табличні частини
        public Користувач_НалаштуванняФормиЗаписиФінансів_TablePart НалаштуванняФормиЗаписиФінансів_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Користувач програми.
    ///</summary>
    class Користувач_Pointer : DirectoryPointer
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
    class Користувач_Select : DirectorySelect, IDisposable
    {
        public Користувач_Select() : base(Config.Kernel, "tab_a04",
            new string[] { "col_a1", "col_a2" },
            new string[] { "Назва", "Код" }) { }
        
        public const string Назва = "col_a1";
        public const string Код = "col_a2";
        
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
    
      
    class Користувач_НалаштуванняФормиЗаписиФінансів_TablePart : DirectoryTablePart
    {
        public Користувач_НалаштуванняФормиЗаписиФінансів_TablePart(Користувач_Objest owner) : base(Config.Kernel, "tab_a06",
             new string[] { "col_a5", "col_a6" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Користувач_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Ключ = fieldValue["col_a5"].ToString();
                record.Значення = fieldValue["col_a6"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a5", record.Ключ);
                    fieldValue.Add("col_a6", record.Значення);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Ключ = "";
                Значення = "";
                
            }
        
            
            public Record(
                string _Ключ = "", string _Значення = "")
            {
                Ключ = _Ключ;
                Значення = _Значення;
                
            }
            public string Ключ { get; set; }
            public string Значення { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "Каса"
    ///<summary>
    ///Місце зберігання грошей.
    ///</summary>
    class Каса_Objest : DirectoryObject
    {
        public Каса_Objest() : base(Config.Kernel, "tab_a05",
             new string[] { "col_a1", "col_a2", "col_a3" }) 
        {
            Назва = "";
            Валюта = new Довідники.Валюта_Pointer();
            ТипВалюти = 0;
            
            //Табличні частини
            ОбмінІсторія_TablePart = new Каса_ОбмінІсторія_TablePart(this);
            
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

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Каса_Pointer GetDirectoryPointer()
        {
            Каса_Pointer directoryPointer = new Каса_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public Довідники.Валюта_Pointer Валюта { get; set; }
        public Перелічення.ТипВалюти ТипВалюти { get; set; }
        
        //Табличні частини
        public Каса_ОбмінІсторія_TablePart ОбмінІсторія_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Місце зберігання грошей.
    ///</summary>
    class Каса_Pointer : DirectoryPointer
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
    class Каса_Select : DirectorySelect, IDisposable
    {
        public Каса_Select() : base(Config.Kernel, "tab_a05",
            new string[] { "col_a1", "col_a2", "col_a3" },
            new string[] { "Назва", "Валюта", "ТипВалюти" }) { }
        
        public const string Назва = "col_a1";
        public const string Валюта = "col_a2";
        public const string ТипВалюти = "col_a3";
        
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
    
      
    class Каса_ОбмінІсторія_TablePart : DirectoryTablePart
    {
        public Каса_ОбмінІсторія_TablePart(Каса_Objest owner) : base(Config.Kernel, "tab_a12",
             new string[] { "col_a3", "col_a4" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Каса_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Дата = (fieldValue["col_a3"] != DBNull.Value) ? DateTime.Parse(fieldValue["col_a3"].ToString()) : DateTime.MinValue;
                record.Значення = fieldValue["col_a4"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a3", record.Дата);
                    fieldValue.Add("col_a4", record.Значення);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Дата = DateTime.MinValue;
                Значення = "";
                
            }
        
            
            public Record(
                DateTime?  _Дата = null, string _Значення = "")
            {
                Дата = _Дата ?? DateTime.MinValue;
                Значення = _Значення;
                
            }
            public DateTime Дата { get; set; }
            public string Значення { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "Валюта"
    ///<summary>
    ///Валюта.
    ///</summary>
    class Валюта_Objest : DirectoryObject
    {
        public Валюта_Objest() : base(Config.Kernel, "tab_a07",
             new string[] { "col_a3", "col_a4" }) 
        {
            Назва = "";
            Код = "";
            
            //Табличні частини
            ОбмінІсторія_TablePart = new Валюта_ОбмінІсторія_TablePart(this);
            
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

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Валюта_Pointer GetDirectoryPointer()
        {
            Валюта_Pointer directoryPointer = new Валюта_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        
        //Табличні частини
        public Валюта_ОбмінІсторія_TablePart ОбмінІсторія_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Валюта.
    ///</summary>
    class Валюта_Pointer : DirectoryPointer
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
    class Валюта_Select : DirectorySelect, IDisposable
    {
        public Валюта_Select() : base(Config.Kernel, "tab_a07",
            new string[] { "col_a3", "col_a4" },
            new string[] { "Назва", "Код" }) { }
        
        public const string Назва = "col_a3";
        public const string Код = "col_a4";
        
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
    
      
    class Валюта_ОбмінІсторія_TablePart : DirectoryTablePart
    {
        public Валюта_ОбмінІсторія_TablePart(Валюта_Objest owner) : base(Config.Kernel, "tab_a11",
             new string[] { "col_a1", "col_a2" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Валюта_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Дата = (fieldValue["col_a1"] != DBNull.Value) ? DateTime.Parse(fieldValue["col_a1"].ToString()) : DateTime.MinValue;
                record.Значення = fieldValue["col_a2"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a1", record.Дата);
                    fieldValue.Add("col_a2", record.Значення);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Дата = DateTime.MinValue;
                Значення = "";
                
            }
        
            
            public Record(
                DateTime?  _Дата = null, string _Значення = "")
            {
                Дата = _Дата ?? DateTime.MinValue;
                Значення = _Значення;
                
            }
            public DateTime Дата { get; set; }
            public string Значення { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "Контакти"
    ///<summary>
    ///Довідник для контактів.
    ///</summary>
    class Контакти_Objest : DirectoryObject
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
            
            //Табличні частини
            ОбмінІсторія_TablePart = new Контакти_ОбмінІсторія_TablePart(this);
            
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

        public void Delete()
        {
            base.BaseDelete();
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
        
        //Табличні частини
        public Контакти_ОбмінІсторія_TablePart ОбмінІсторія_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Довідник для контактів.
    ///</summary>
    class Контакти_Pointer : DirectoryPointer
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
    class Контакти_Select : DirectorySelect, IDisposable
    {
        public Контакти_Select() : base(Config.Kernel, "tab_a08",
            new string[] { "col_a4", "col_a3", "col_a5", "col_a6", "col_a7", "col_a1", "col_a2" },
            new string[] { "Телефон", "Назва", "Сайт", "Пошта", "Опис", "Скайп", "Фото" }) { }
        
        public const string Телефон = "col_a4";
        public const string Назва = "col_a3";
        public const string Сайт = "col_a5";
        public const string Пошта = "col_a6";
        public const string Опис = "col_a7";
        public const string Скайп = "col_a1";
        public const string Фото = "col_a2";
        
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
    
      
    class Контакти_ОбмінІсторія_TablePart : DirectoryTablePart
    {
        public Контакти_ОбмінІсторія_TablePart(Контакти_Objest owner) : base(Config.Kernel, "tab_a14",
             new string[] { "col_a1", "col_a2" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Контакти_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Дата = (fieldValue["col_a1"] != DBNull.Value) ? DateTime.Parse(fieldValue["col_a1"].ToString()) : DateTime.MinValue;
                record.Значення = fieldValue["col_a2"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a1", record.Дата);
                    fieldValue.Add("col_a2", record.Значення);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Дата = DateTime.MinValue;
                Значення = "";
                
            }
        
            
            public Record(
                DateTime?  _Дата = null, string _Значення = "")
            {
                Дата = _Дата ?? DateTime.MinValue;
                Значення = _Значення;
                
            }
            public DateTime Дата { get; set; }
            public string Значення { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "Записник_Папки"
    ///<summary>
    ///Іжрархія для довідника Записник.
    ///</summary>
    class Записник_Папки_Objest : DirectoryObject
    {
        public Записник_Папки_Objest() : base(Config.Kernel, "tab_a09",
             new string[] { "col_a1", "col_a3" }) 
        {
            Назва = "";
            Родич = new Довідники.Записник_Папки_Pointer();
            
            //Табличні частини
            ОбмінІсторія_TablePart = new Записник_Папки_ОбмінІсторія_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                Родич = new Довідники.Записник_Папки_Pointer(base.FieldValue["col_a3"]);
                
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
            
            BaseSave();
        }

        public string Serialize(string root = "Записник_Папки")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Родич>" + Родич.ToString() + "</Родич>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Записник_Папки_Pointer GetDirectoryPointer()
        {
            Записник_Папки_Pointer directoryPointer = new Записник_Папки_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public Довідники.Записник_Папки_Pointer Родич { get; set; }
        
        //Табличні частини
        public Записник_Папки_ОбмінІсторія_TablePart ОбмінІсторія_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Іжрархія для довідника Записник.
    ///</summary>
    class Записник_Папки_Pointer : DirectoryPointer
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
    ///Іжрархія для довідника Записник.
    ///</summary>
    class Записник_Папки_Select : DirectorySelect, IDisposable
    {
        public Записник_Папки_Select() : base(Config.Kernel, "tab_a09",
            new string[] { "col_a1", "col_a3" },
            new string[] { "Назва", "Родич" }) { }
        
        public const string Назва = "col_a1";
        public const string Родич = "col_a3";
        
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
    
      
    class Записник_Папки_ОбмінІсторія_TablePart : DirectoryTablePart
    {
        public Записник_Папки_ОбмінІсторія_TablePart(Записник_Папки_Objest owner) : base(Config.Kernel, "tab_a15",
             new string[] { "col_a1", "col_a2" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Записник_Папки_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Дата = (fieldValue["col_a1"] != DBNull.Value) ? DateTime.Parse(fieldValue["col_a1"].ToString()) : DateTime.MinValue;
                record.Значення = fieldValue["col_a2"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a1", record.Дата);
                    fieldValue.Add("col_a2", record.Значення);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Дата = DateTime.MinValue;
                Значення = "";
                
            }
        
            
            public Record(
                DateTime?  _Дата = null, string _Значення = "")
            {
                Дата = _Дата ?? DateTime.MinValue;
                Значення = _Значення;
                
            }
            public DateTime Дата { get; set; }
            public string Значення { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "Склади"
    ///<summary>
    ///Список складів.
    ///</summary>
    class Склади_Objest : DirectoryObject
    {
        public Склади_Objest() : base(Config.Kernel, "tab_a20",
             new string[] { "col_a7", "col_a8", "col_a1" }) 
        {
            Назва = "";
            Код = "";
            Папка = new Довідники.Склади_Папки_Pointer();
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a7"].ToString();
                Код = base.FieldValue["col_a8"].ToString();
                Папка = new Довідники.Склади_Папки_Pointer(base.FieldValue["col_a1"]);
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a7"] = Назва;
            base.FieldValue["col_a8"] = Код;
            base.FieldValue["col_a1"] = Папка.UnigueID.UGuid;
            
            BaseSave();
        }

        public string Serialize(string root = "Склади")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "<Папка>" + Папка.ToString() + "</Папка>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Склади_Pointer GetDirectoryPointer()
        {
            Склади_Pointer directoryPointer = new Склади_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        public Довідники.Склади_Папки_Pointer Папка { get; set; }
        
    }
    
    ///<summary>
    ///Список складів.
    ///</summary>
    class Склади_Pointer : DirectoryPointer
    {
        public Склади_Pointer(object uid = null) : base(Config.Kernel, "tab_a20")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Склади_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a20")
        {
            base.Init(uid, fields);
        }
        
        public Склади_Objest GetDirectoryObject()
        {
            Склади_Objest СкладиObjestItem = new Склади_Objest();
            return СкладиObjestItem.Read(base.UnigueID) ? СкладиObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public Склади_Pointer GetEmptyPointer()
        {
            return new Склади_Pointer();
        }
    }
    
    ///<summary>
    ///Список складів.
    ///</summary>
    class Склади_Select : DirectorySelect, IDisposable
    {
        public Склади_Select() : base(Config.Kernel, "tab_a20",
            new string[] { "col_a7", "col_a8", "col_a1" },
            new string[] { "Назва", "Код", "Папка" }) { }
        
        public const string Назва = "col_a7";
        public const string Код = "col_a8";
        public const string Папка = "col_a1";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Склади_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Склади_Pointer Current { get; private set; }
        
        public Склади_Pointer FindByField(string name, object value)
        {
            Склади_Pointer itemPointer = new Склади_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Склади_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Склади_Pointer> directoryPointerList = new List<Склади_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Склади_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "Номенклатура"
    ///<summary>
    ///Список номенклатури.
    ///</summary>
    class Номенклатура_Objest : DirectoryObject
    {
        public Номенклатура_Objest() : base(Config.Kernel, "tab_a21",
             new string[] { "col_a9", "col_b1", "col_a1", "col_a2", "col_a3", "col_a4", "col_a5", "col_a6", "col_a7", "col_a8" }) 
        {
            Назва = "";
            Код = "";
            Папка = new Довідники.Номенклатура_Папки_Pointer();
            ТипНоменклатури = 0;
            Артикул = "";
            ВидНоменклатури = new Довідники.ВидиНоменклатури_Pointer();
            ОдиницяВиміру = new Довідники.ПакуванняОдиниціВиміру_Pointer();
            ПовнаНазва = "";
            Опис = "";
            Виробник = new Довідники.Виробники_Pointer();
            
            //Табличні частини
            Фотографії_TablePart = new Номенклатура_Фотографії_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a9"].ToString();
                Код = base.FieldValue["col_b1"].ToString();
                Папка = new Довідники.Номенклатура_Папки_Pointer(base.FieldValue["col_a1"]);
                ТипНоменклатури = (base.FieldValue["col_a2"] != DBNull.Value) ? (Перелічення.ТипНоменклатури)base.FieldValue["col_a2"] : 0;
                Артикул = base.FieldValue["col_a3"].ToString();
                ВидНоменклатури = new Довідники.ВидиНоменклатури_Pointer(base.FieldValue["col_a4"]);
                ОдиницяВиміру = new Довідники.ПакуванняОдиниціВиміру_Pointer(base.FieldValue["col_a5"]);
                ПовнаНазва = base.FieldValue["col_a6"].ToString();
                Опис = base.FieldValue["col_a7"].ToString();
                Виробник = new Довідники.Виробники_Pointer(base.FieldValue["col_a8"]);
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a9"] = Назва;
            base.FieldValue["col_b1"] = Код;
            base.FieldValue["col_a1"] = Папка.UnigueID.UGuid;
            base.FieldValue["col_a2"] = (int)ТипНоменклатури;
            base.FieldValue["col_a3"] = Артикул;
            base.FieldValue["col_a4"] = ВидНоменклатури.UnigueID.UGuid;
            base.FieldValue["col_a5"] = ОдиницяВиміру.UnigueID.UGuid;
            base.FieldValue["col_a6"] = ПовнаНазва;
            base.FieldValue["col_a7"] = Опис;
            base.FieldValue["col_a8"] = Виробник.UnigueID.UGuid;
            
            BaseSave();
        }

        public string Serialize(string root = "Номенклатура")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "<Папка>" + Папка.ToString() + "</Папка>"  +
               "<ТипНоменклатури>" + ((int)ТипНоменклатури).ToString() + "</ТипНоменклатури>"  +
               "<Артикул>" + "<![CDATA[" + Артикул + "]]>" + "</Артикул>"  +
               "<ВидНоменклатури>" + ВидНоменклатури.ToString() + "</ВидНоменклатури>"  +
               "<ОдиницяВиміру>" + ОдиницяВиміру.ToString() + "</ОдиницяВиміру>"  +
               "<ПовнаНазва>" + "<![CDATA[" + ПовнаНазва + "]]>" + "</ПовнаНазва>"  +
               "<Опис>" + "<![CDATA[" + Опис + "]]>" + "</Опис>"  +
               "<Виробник>" + Виробник.ToString() + "</Виробник>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Номенклатура_Pointer GetDirectoryPointer()
        {
            Номенклатура_Pointer directoryPointer = new Номенклатура_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        public Довідники.Номенклатура_Папки_Pointer Папка { get; set; }
        public Перелічення.ТипНоменклатури ТипНоменклатури { get; set; }
        public string Артикул { get; set; }
        public Довідники.ВидиНоменклатури_Pointer ВидНоменклатури { get; set; }
        public Довідники.ПакуванняОдиниціВиміру_Pointer ОдиницяВиміру { get; set; }
        public string ПовнаНазва { get; set; }
        public string Опис { get; set; }
        public Довідники.Виробники_Pointer Виробник { get; set; }
        
        //Табличні частини
        public Номенклатура_Фотографії_TablePart Фотографії_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Список номенклатури.
    ///</summary>
    class Номенклатура_Pointer : DirectoryPointer
    {
        public Номенклатура_Pointer(object uid = null) : base(Config.Kernel, "tab_a21")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Номенклатура_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a21")
        {
            base.Init(uid, fields);
        }
        
        public Номенклатура_Objest GetDirectoryObject()
        {
            Номенклатура_Objest НоменклатураObjestItem = new Номенклатура_Objest();
            return НоменклатураObjestItem.Read(base.UnigueID) ? НоменклатураObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public Номенклатура_Pointer GetEmptyPointer()
        {
            return new Номенклатура_Pointer();
        }
    }
    
    ///<summary>
    ///Список номенклатури.
    ///</summary>
    class Номенклатура_Select : DirectorySelect, IDisposable
    {
        public Номенклатура_Select() : base(Config.Kernel, "tab_a21",
            new string[] { "col_a9", "col_b1", "col_a1", "col_a2", "col_a3", "col_a4", "col_a5", "col_a6", "col_a7", "col_a8" },
            new string[] { "Назва", "Код", "Папка", "ТипНоменклатури", "Артикул", "ВидНоменклатури", "ОдиницяВиміру", "ПовнаНазва", "Опис", "Виробник" }) { }
        
        public const string Назва = "col_a9";
        public const string Код = "col_b1";
        public const string Папка = "col_a1";
        public const string ТипНоменклатури = "col_a2";
        public const string Артикул = "col_a3";
        public const string ВидНоменклатури = "col_a4";
        public const string ОдиницяВиміру = "col_a5";
        public const string ПовнаНазва = "col_a6";
        public const string Опис = "col_a7";
        public const string Виробник = "col_a8";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Номенклатура_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Номенклатура_Pointer Current { get; private set; }
        
        public Номенклатура_Pointer FindByField(string name, object value)
        {
            Номенклатура_Pointer itemPointer = new Номенклатура_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Номенклатура_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Номенклатура_Pointer> directoryPointerList = new List<Номенклатура_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Номенклатура_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
    class Номенклатура_Фотографії_TablePart : DirectoryTablePart
    {
        public Номенклатура_Фотографії_TablePart(Номенклатура_Objest owner) : base(Config.Kernel, "tab_a54",
             new string[] { "col_a5", "col_a1" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Номенклатура_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Фото = fieldValue["col_a5"].ToString();
                record.Опис = fieldValue["col_a1"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a5", record.Фото);
                    fieldValue.Add("col_a1", record.Опис);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Фото = "";
                Опис = "";
                
            }
        
            
            public Record(
                string _Фото = "", string _Опис = "")
            {
                Фото = _Фото;
                Опис = _Опис;
                
            }
            public string Фото { get; set; }
            public string Опис { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "Контрагенти"
    ///<summary>
    ///Список контрагентів.
    ///</summary>
    class Контрагенти_Objest : DirectoryObject
    {
        public Контрагенти_Objest() : base(Config.Kernel, "tab_a24",
             new string[] { "col_b9", "col_c1", "col_a1" }) 
        {
            Назва = "";
            Код = "";
            Папка = new Довідники.Контрагенти_Папки_Pointer();
            
            //Табличні частини
            Контакти_TablePart = new Контрагенти_Контакти_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_b9"].ToString();
                Код = base.FieldValue["col_c1"].ToString();
                Папка = new Довідники.Контрагенти_Папки_Pointer(base.FieldValue["col_a1"]);
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_b9"] = Назва;
            base.FieldValue["col_c1"] = Код;
            base.FieldValue["col_a1"] = Папка.UnigueID.UGuid;
            
            BaseSave();
        }

        public string Serialize(string root = "Контрагенти")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "<Папка>" + Папка.ToString() + "</Папка>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Контрагенти_Pointer GetDirectoryPointer()
        {
            Контрагенти_Pointer directoryPointer = new Контрагенти_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        public Довідники.Контрагенти_Папки_Pointer Папка { get; set; }
        
        //Табличні частини
        public Контрагенти_Контакти_TablePart Контакти_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Список контрагентів.
    ///</summary>
    class Контрагенти_Pointer : DirectoryPointer
    {
        public Контрагенти_Pointer(object uid = null) : base(Config.Kernel, "tab_a24")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Контрагенти_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a24")
        {
            base.Init(uid, fields);
        }
        
        public Контрагенти_Objest GetDirectoryObject()
        {
            Контрагенти_Objest КонтрагентиObjestItem = new Контрагенти_Objest();
            return КонтрагентиObjestItem.Read(base.UnigueID) ? КонтрагентиObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public Контрагенти_Pointer GetEmptyPointer()
        {
            return new Контрагенти_Pointer();
        }
    }
    
    ///<summary>
    ///Список контрагентів.
    ///</summary>
    class Контрагенти_Select : DirectorySelect, IDisposable
    {
        public Контрагенти_Select() : base(Config.Kernel, "tab_a24",
            new string[] { "col_b9", "col_c1", "col_a1" },
            new string[] { "Назва", "Код", "Папка" }) { }
        
        public const string Назва = "col_b9";
        public const string Код = "col_c1";
        public const string Папка = "col_a1";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Контрагенти_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Контрагенти_Pointer Current { get; private set; }
        
        public Контрагенти_Pointer FindByField(string name, object value)
        {
            Контрагенти_Pointer itemPointer = new Контрагенти_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Контрагенти_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Контрагенти_Pointer> directoryPointerList = new List<Контрагенти_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Контрагенти_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
    class Контрагенти_Контакти_TablePart : DirectoryTablePart
    {
        public Контрагенти_Контакти_TablePart(Контрагенти_Objest owner) : base(Config.Kernel, "tab_a55",
             new string[] { "col_a6", "col_a7", "col_a8", "col_a9" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Контрагенти_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Адреса = fieldValue["col_a6"].ToString();
                record.Телефон = fieldValue["col_a7"].ToString();
                record.Емайл = fieldValue["col_a8"].ToString();
                record.Опис = fieldValue["col_a9"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a6", record.Адреса);
                    fieldValue.Add("col_a7", record.Телефон);
                    fieldValue.Add("col_a8", record.Емайл);
                    fieldValue.Add("col_a9", record.Опис);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Адреса = "";
                Телефон = "";
                Емайл = "";
                Опис = "";
                
            }
        
            
            public Record(
                string _Адреса = "", string _Телефон = "", string _Емайл = "", string _Опис = "")
            {
                Адреса = _Адреса;
                Телефон = _Телефон;
                Емайл = _Емайл;
                Опис = _Опис;
                
            }
            public string Адреса { get; set; }
            public string Телефон { get; set; }
            public string Емайл { get; set; }
            public string Опис { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "Номенклатура_Папки"
    
    class Номенклатура_Папки_Objest : DirectoryObject
    {
        public Номенклатура_Папки_Objest() : base(Config.Kernel, "tab_a27",
             new string[] { "col_c2", "col_c4" }) 
        {
            Назва = "";
            Родич = new Довідники.Номенклатура_Папки_Pointer();
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_c2"].ToString();
                Родич = new Довідники.Номенклатура_Папки_Pointer(base.FieldValue["col_c4"]);
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_c2"] = Назва;
            base.FieldValue["col_c4"] = Родич.UnigueID.UGuid;
            
            BaseSave();
        }

        public string Serialize(string root = "Номенклатура_Папки")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Родич>" + Родич.ToString() + "</Родич>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Номенклатура_Папки_Pointer GetDirectoryPointer()
        {
            Номенклатура_Папки_Pointer directoryPointer = new Номенклатура_Папки_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public Довідники.Номенклатура_Папки_Pointer Родич { get; set; }
        
    }
    
    
    class Номенклатура_Папки_Pointer : DirectoryPointer
    {
        public Номенклатура_Папки_Pointer(object uid = null) : base(Config.Kernel, "tab_a27")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Номенклатура_Папки_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a27")
        {
            base.Init(uid, fields);
        }
        
        public Номенклатура_Папки_Objest GetDirectoryObject()
        {
            Номенклатура_Папки_Objest Номенклатура_ПапкиObjestItem = new Номенклатура_Папки_Objest();
            return Номенклатура_ПапкиObjestItem.Read(base.UnigueID) ? Номенклатура_ПапкиObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public Номенклатура_Папки_Pointer GetEmptyPointer()
        {
            return new Номенклатура_Папки_Pointer();
        }
    }
    
    
    class Номенклатура_Папки_Select : DirectorySelect, IDisposable
    {
        public Номенклатура_Папки_Select() : base(Config.Kernel, "tab_a27",
            new string[] { "col_c2", "col_c4" },
            new string[] { "Назва", "Родич" }) { }
        
        public const string Назва = "col_c2";
        public const string Родич = "col_c4";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Номенклатура_Папки_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Номенклатура_Папки_Pointer Current { get; private set; }
        
        public Номенклатура_Папки_Pointer FindByField(string name, object value)
        {
            Номенклатура_Папки_Pointer itemPointer = new Номенклатура_Папки_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Номенклатура_Папки_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Номенклатура_Папки_Pointer> directoryPointerList = new List<Номенклатура_Папки_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Номенклатура_Папки_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "Контрагенти_Папки"
    ///<summary>
    ///Ієрарахія для довідника Контрагенти.
    ///</summary>
    class Контрагенти_Папки_Objest : DirectoryObject
    {
        public Контрагенти_Папки_Objest() : base(Config.Kernel, "tab_a28",
             new string[] { "col_c5", "col_c7" }) 
        {
            Назва = "";
            Родич = new Довідники.Контрагенти_Папки_Pointer();
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_c5"].ToString();
                Родич = new Довідники.Контрагенти_Папки_Pointer(base.FieldValue["col_c7"]);
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_c5"] = Назва;
            base.FieldValue["col_c7"] = Родич.UnigueID.UGuid;
            
            BaseSave();
        }

        public string Serialize(string root = "Контрагенти_Папки")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Родич>" + Родич.ToString() + "</Родич>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Контрагенти_Папки_Pointer GetDirectoryPointer()
        {
            Контрагенти_Папки_Pointer directoryPointer = new Контрагенти_Папки_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public Довідники.Контрагенти_Папки_Pointer Родич { get; set; }
        
    }
    
    ///<summary>
    ///Ієрарахія для довідника Контрагенти.
    ///</summary>
    class Контрагенти_Папки_Pointer : DirectoryPointer
    {
        public Контрагенти_Папки_Pointer(object uid = null) : base(Config.Kernel, "tab_a28")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Контрагенти_Папки_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a28")
        {
            base.Init(uid, fields);
        }
        
        public Контрагенти_Папки_Objest GetDirectoryObject()
        {
            Контрагенти_Папки_Objest Контрагенти_ПапкиObjestItem = new Контрагенти_Папки_Objest();
            return Контрагенти_ПапкиObjestItem.Read(base.UnigueID) ? Контрагенти_ПапкиObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public Контрагенти_Папки_Pointer GetEmptyPointer()
        {
            return new Контрагенти_Папки_Pointer();
        }
    }
    
    ///<summary>
    ///Ієрарахія для довідника Контрагенти.
    ///</summary>
    class Контрагенти_Папки_Select : DirectorySelect, IDisposable
    {
        public Контрагенти_Папки_Select() : base(Config.Kernel, "tab_a28",
            new string[] { "col_c5", "col_c7" },
            new string[] { "Назва", "Родич" }) { }
        
        public const string Назва = "col_c5";
        public const string Родич = "col_c7";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Контрагенти_Папки_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Контрагенти_Папки_Pointer Current { get; private set; }
        
        public Контрагенти_Папки_Pointer FindByField(string name, object value)
        {
            Контрагенти_Папки_Pointer itemPointer = new Контрагенти_Папки_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Контрагенти_Папки_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Контрагенти_Папки_Pointer> directoryPointerList = new List<Контрагенти_Папки_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Контрагенти_Папки_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "Склади_Папки"
    ///<summary>
    ///Ієрархія для довідника Склади.
    ///</summary>
    class Склади_Папки_Objest : DirectoryObject
    {
        public Склади_Папки_Objest() : base(Config.Kernel, "tab_a36",
             new string[] { "col_d5", "col_d7" }) 
        {
            Назва = "";
            Родич = new Довідники.Склади_Папки_Pointer();
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_d5"].ToString();
                Родич = new Довідники.Склади_Папки_Pointer(base.FieldValue["col_d7"]);
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_d5"] = Назва;
            base.FieldValue["col_d7"] = Родич.UnigueID.UGuid;
            
            BaseSave();
        }

        public string Serialize(string root = "Склади_Папки")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Родич>" + Родич.ToString() + "</Родич>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Склади_Папки_Pointer GetDirectoryPointer()
        {
            Склади_Папки_Pointer directoryPointer = new Склади_Папки_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public Довідники.Склади_Папки_Pointer Родич { get; set; }
        
    }
    
    ///<summary>
    ///Ієрархія для довідника Склади.
    ///</summary>
    class Склади_Папки_Pointer : DirectoryPointer
    {
        public Склади_Папки_Pointer(object uid = null) : base(Config.Kernel, "tab_a36")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Склади_Папки_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a36")
        {
            base.Init(uid, fields);
        }
        
        public Склади_Папки_Objest GetDirectoryObject()
        {
            Склади_Папки_Objest Склади_ПапкиObjestItem = new Склади_Папки_Objest();
            return Склади_ПапкиObjestItem.Read(base.UnigueID) ? Склади_ПапкиObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public Склади_Папки_Pointer GetEmptyPointer()
        {
            return new Склади_Папки_Pointer();
        }
    }
    
    ///<summary>
    ///Ієрархія для довідника Склади.
    ///</summary>
    class Склади_Папки_Select : DirectorySelect, IDisposable
    {
        public Склади_Папки_Select() : base(Config.Kernel, "tab_a36",
            new string[] { "col_d5", "col_d7" },
            new string[] { "Назва", "Родич" }) { }
        
        public const string Назва = "col_d5";
        public const string Родич = "col_d7";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Склади_Папки_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Склади_Папки_Pointer Current { get; private set; }
        
        public Склади_Папки_Pointer FindByField(string name, object value)
        {
            Склади_Папки_Pointer itemPointer = new Склади_Папки_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Склади_Папки_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Склади_Папки_Pointer> directoryPointerList = new List<Склади_Папки_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Склади_Папки_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "Організації"
    ///<summary>
    ///Список Організацій.
    ///</summary>
    class Організації_Objest : DirectoryObject
    {
        public Організації_Objest() : base(Config.Kernel, "tab_a29",
             new string[] { "col_a1" }) 
        {
            Назва = "";
            
            //Табличні частини
            Контакти_TablePart = new Організації_Контакти_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = Назва;
            
            BaseSave();
        }

        public string Serialize(string root = "Організації")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Організації_Pointer GetDirectoryPointer()
        {
            Організації_Pointer directoryPointer = new Організації_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        
        //Табличні частини
        public Організації_Контакти_TablePart Контакти_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Список Організацій.
    ///</summary>
    class Організації_Pointer : DirectoryPointer
    {
        public Організації_Pointer(object uid = null) : base(Config.Kernel, "tab_a29")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Організації_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a29")
        {
            base.Init(uid, fields);
        }
        
        public Організації_Objest GetDirectoryObject()
        {
            Організації_Objest ОрганізаціїObjestItem = new Організації_Objest();
            return ОрганізаціїObjestItem.Read(base.UnigueID) ? ОрганізаціїObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public Організації_Pointer GetEmptyPointer()
        {
            return new Організації_Pointer();
        }
    }
    
    ///<summary>
    ///Список Організацій.
    ///</summary>
    class Організації_Select : DirectorySelect, IDisposable
    {
        public Організації_Select() : base(Config.Kernel, "tab_a29",
            new string[] { "col_a1" },
            new string[] { "Назва" }) { }
        
        public const string Назва = "col_a1";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Організації_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Організації_Pointer Current { get; private set; }
        
        public Організації_Pointer FindByField(string name, object value)
        {
            Організації_Pointer itemPointer = new Організації_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Організації_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Організації_Pointer> directoryPointerList = new List<Організації_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Організації_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
    class Організації_Контакти_TablePart : DirectoryTablePart
    {
        public Організації_Контакти_TablePart(Організації_Objest owner) : base(Config.Kernel, "tab_a32",
             new string[] { "col_a1", "col_a2", "col_a3" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Організації_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Адреса = fieldValue["col_a1"].ToString();
                record.Телефон = fieldValue["col_a2"].ToString();
                record.Емайл = fieldValue["col_a3"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a1", record.Адреса);
                    fieldValue.Add("col_a2", record.Телефон);
                    fieldValue.Add("col_a3", record.Емайл);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
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
                Адреса = "";
                Телефон = "";
                Емайл = "";
                
            }
        
            
            public Record(
                string _Адреса = "", string _Телефон = "", string _Емайл = "")
            {
                Адреса = _Адреса;
                Телефон = _Телефон;
                Емайл = _Емайл;
                
            }
            public string Адреса { get; set; }
            public string Телефон { get; set; }
            public string Емайл { get; set; }
            
        }
    }
      
   
    #endregion
    
    #region DIRECTORY "ВидиЦін"
    ///<summary>
    ///Види цін номенклатури.
    ///</summary>
    class ВидиЦін_Objest : DirectoryObject
    {
        public ВидиЦін_Objest() : base(Config.Kernel, "tab_a31",
             new string[] { "col_a1", "col_a3" }) 
        {
            Назва = "";
            Валюта = new Довідники.Валюта_Pointer();
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                Валюта = new Довідники.Валюта_Pointer(base.FieldValue["col_a3"]);
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = Назва;
            base.FieldValue["col_a3"] = Валюта.UnigueID.UGuid;
            
            BaseSave();
        }

        public string Serialize(string root = "ВидиЦін")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Валюта>" + Валюта.ToString() + "</Валюта>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ВидиЦін_Pointer GetDirectoryPointer()
        {
            ВидиЦін_Pointer directoryPointer = new ВидиЦін_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public Довідники.Валюта_Pointer Валюта { get; set; }
        
    }
    
    ///<summary>
    ///Види цін номенклатури.
    ///</summary>
    class ВидиЦін_Pointer : DirectoryPointer
    {
        public ВидиЦін_Pointer(object uid = null) : base(Config.Kernel, "tab_a31")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ВидиЦін_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a31")
        {
            base.Init(uid, fields);
        }
        
        public ВидиЦін_Objest GetDirectoryObject()
        {
            ВидиЦін_Objest ВидиЦінObjestItem = new ВидиЦін_Objest();
            return ВидиЦінObjestItem.Read(base.UnigueID) ? ВидиЦінObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public ВидиЦін_Pointer GetEmptyPointer()
        {
            return new ВидиЦін_Pointer();
        }
    }
    
    ///<summary>
    ///Види цін номенклатури.
    ///</summary>
    class ВидиЦін_Select : DirectorySelect, IDisposable
    {
        public ВидиЦін_Select() : base(Config.Kernel, "tab_a31",
            new string[] { "col_a1", "col_a3" },
            new string[] { "Назва", "Валюта" }) { }
        
        public const string Назва = "col_a1";
        public const string Валюта = "col_a3";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ВидиЦін_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public ВидиЦін_Pointer Current { get; private set; }
        
        public ВидиЦін_Pointer FindByField(string name, object value)
        {
            ВидиЦін_Pointer itemPointer = new ВидиЦін_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<ВидиЦін_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<ВидиЦін_Pointer> directoryPointerList = new List<ВидиЦін_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new ВидиЦін_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "ВидиНоменклатури"
    ///<summary>
    ///Види Номенклатури.
    ///</summary>
    class ВидиНоменклатури_Objest : DirectoryObject
    {
        public ВидиНоменклатури_Objest() : base(Config.Kernel, "tab_a50",
             new string[] { "col_a7", "col_a8", "col_a9", "col_b1" }) 
        {
            Назва = "";
            Код = "";
            ТипНоменклатури = 0;
            Опис = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a7"].ToString();
                Код = base.FieldValue["col_a8"].ToString();
                ТипНоменклатури = (base.FieldValue["col_a9"] != DBNull.Value) ? (Перелічення.ТипНоменклатури)base.FieldValue["col_a9"] : 0;
                Опис = base.FieldValue["col_b1"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a7"] = Назва;
            base.FieldValue["col_a8"] = Код;
            base.FieldValue["col_a9"] = (int)ТипНоменклатури;
            base.FieldValue["col_b1"] = Опис;
            
            BaseSave();
        }

        public string Serialize(string root = "ВидиНоменклатури")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "<ТипНоменклатури>" + ((int)ТипНоменклатури).ToString() + "</ТипНоменклатури>"  +
               "<Опис>" + "<![CDATA[" + Опис + "]]>" + "</Опис>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ВидиНоменклатури_Pointer GetDirectoryPointer()
        {
            ВидиНоменклатури_Pointer directoryPointer = new ВидиНоменклатури_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public string Код { get; set; }
        public Перелічення.ТипНоменклатури ТипНоменклатури { get; set; }
        public string Опис { get; set; }
        
    }
    
    ///<summary>
    ///Види Номенклатури.
    ///</summary>
    class ВидиНоменклатури_Pointer : DirectoryPointer
    {
        public ВидиНоменклатури_Pointer(object uid = null) : base(Config.Kernel, "tab_a50")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ВидиНоменклатури_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a50")
        {
            base.Init(uid, fields);
        }
        
        public ВидиНоменклатури_Objest GetDirectoryObject()
        {
            ВидиНоменклатури_Objest ВидиНоменклатуриObjestItem = new ВидиНоменклатури_Objest();
            return ВидиНоменклатуриObjestItem.Read(base.UnigueID) ? ВидиНоменклатуриObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public ВидиНоменклатури_Pointer GetEmptyPointer()
        {
            return new ВидиНоменклатури_Pointer();
        }
    }
    
    ///<summary>
    ///Види Номенклатури.
    ///</summary>
    class ВидиНоменклатури_Select : DirectorySelect, IDisposable
    {
        public ВидиНоменклатури_Select() : base(Config.Kernel, "tab_a50",
            new string[] { "col_a7", "col_a8", "col_a9", "col_b1" },
            new string[] { "Назва", "Код", "ТипНоменклатури", "Опис" }) { }
        
        public const string Назва = "col_a7";
        public const string Код = "col_a8";
        public const string ТипНоменклатури = "col_a9";
        public const string Опис = "col_b1";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ВидиНоменклатури_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public ВидиНоменклатури_Pointer Current { get; private set; }
        
        public ВидиНоменклатури_Pointer FindByField(string name, object value)
        {
            ВидиНоменклатури_Pointer itemPointer = new ВидиНоменклатури_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<ВидиНоменклатури_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<ВидиНоменклатури_Pointer> directoryPointerList = new List<ВидиНоменклатури_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new ВидиНоменклатури_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "ПакуванняОдиниціВиміру"
    ///<summary>
    ///Одиниці виміру.
    ///</summary>
    class ПакуванняОдиниціВиміру_Objest : DirectoryObject
    {
        public ПакуванняОдиниціВиміру_Objest() : base(Config.Kernel, "tab_a51",
             new string[] { "col_b2" }) 
        {
            Назва = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_b2"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_b2"] = Назва;
            
            BaseSave();
        }

        public string Serialize(string root = "ПакуванняОдиниціВиміру")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ПакуванняОдиниціВиміру_Pointer GetDirectoryPointer()
        {
            ПакуванняОдиниціВиміру_Pointer directoryPointer = new ПакуванняОдиниціВиміру_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        
    }
    
    ///<summary>
    ///Одиниці виміру.
    ///</summary>
    class ПакуванняОдиниціВиміру_Pointer : DirectoryPointer
    {
        public ПакуванняОдиниціВиміру_Pointer(object uid = null) : base(Config.Kernel, "tab_a51")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ПакуванняОдиниціВиміру_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a51")
        {
            base.Init(uid, fields);
        }
        
        public ПакуванняОдиниціВиміру_Objest GetDirectoryObject()
        {
            ПакуванняОдиниціВиміру_Objest ПакуванняОдиниціВиміруObjestItem = new ПакуванняОдиниціВиміру_Objest();
            return ПакуванняОдиниціВиміруObjestItem.Read(base.UnigueID) ? ПакуванняОдиниціВиміруObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public ПакуванняОдиниціВиміру_Pointer GetEmptyPointer()
        {
            return new ПакуванняОдиниціВиміру_Pointer();
        }
    }
    
    ///<summary>
    ///Одиниці виміру.
    ///</summary>
    class ПакуванняОдиниціВиміру_Select : DirectorySelect, IDisposable
    {
        public ПакуванняОдиниціВиміру_Select() : base(Config.Kernel, "tab_a51",
            new string[] { "col_b2" },
            new string[] { "Назва" }) { }
        
        public const string Назва = "col_b2";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ПакуванняОдиниціВиміру_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public ПакуванняОдиниціВиміру_Pointer Current { get; private set; }
        
        public ПакуванняОдиниціВиміру_Pointer FindByField(string name, object value)
        {
            ПакуванняОдиниціВиміру_Pointer itemPointer = new ПакуванняОдиниціВиміру_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<ПакуванняОдиниціВиміру_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<ПакуванняОдиниціВиміру_Pointer> directoryPointerList = new List<ПакуванняОдиниціВиміру_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new ПакуванняОдиниціВиміру_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "Виробники"
    ///<summary>
    ///Список Виробників.
    ///</summary>
    class Виробники_Objest : DirectoryObject
    {
        public Виробники_Objest() : base(Config.Kernel, "tab_a52",
             new string[] { "col_b4" }) 
        {
            Назва = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_b4"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_b4"] = Назва;
            
            BaseSave();
        }

        public string Serialize(string root = "Виробники")
        {
            return 
            "<" + root + ">" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Виробники_Pointer GetDirectoryPointer()
        {
            Виробники_Pointer directoryPointer = new Виробники_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        
    }
    
    ///<summary>
    ///Список Виробників.
    ///</summary>
    class Виробники_Pointer : DirectoryPointer
    {
        public Виробники_Pointer(object uid = null) : base(Config.Kernel, "tab_a52")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Виробники_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a52")
        {
            base.Init(uid, fields);
        }
        
        public Виробники_Objest GetDirectoryObject()
        {
            Виробники_Objest ВиробникиObjestItem = new Виробники_Objest();
            return ВиробникиObjestItem.Read(base.UnigueID) ? ВиробникиObjestItem : null;
        }
		
		public string GetPresentation()
        {
		    return base.BasePresentation(
			    new string[] {  }
			);
        }
		
        public Виробники_Pointer GetEmptyPointer()
        {
            return new Виробники_Pointer();
        }
    }
    
    ///<summary>
    ///Список Виробників.
    ///</summary>
    class Виробники_Select : DirectorySelect, IDisposable
    {
        public Виробники_Select() : base(Config.Kernel, "tab_a52",
            new string[] { "col_b4" },
            new string[] { "Назва" }) { }
        
        public const string Назва = "col_b4";
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Виробники_Pointer(base.DirectoryPointerPosition.UnigueID, base.DirectoryPointerPosition.Fields); return true; } else { Current = null; return false; } }

        public Виробники_Pointer Current { get; private set; }
        
        public Виробники_Pointer FindByField(string name, object value)
        {
            Виробники_Pointer itemPointer = new Виробники_Pointer();
            DirectoryPointer directoryPointer = base.BaseFindByField(name, value);
            if (!directoryPointer.IsEmpty()) itemPointer.Init(directoryPointer.UnigueID);
            return itemPointer;
        }
        
        public List<Виробники_Pointer> FindListByField(string name, object value, int limit = 0, int offset = 0)
        {
            List<Виробники_Pointer> directoryPointerList = new List<Виробники_Pointer>();
            foreach (DirectoryPointer directoryPointer in base.BaseFindListByField(name, value, limit, offset)) 
                directoryPointerList.Add(new Виробники_Pointer(directoryPointer.UnigueID));
            return directoryPointerList;
        }
    }
    
      
   
    #endregion
    
    #region DIRECTORY "КалендарПеріодичнихЗавдань"
    ///<summary>
    ///Список періодичних завдань. Наприклад: подати покази лічильників води, світла і т.д з періодичністю раз на місяць..
    ///</summary>
    class КалендарПеріодичнихЗавдань_Objest : DirectoryObject
    {
        public КалендарПеріодичнихЗавдань_Objest() : base(Config.Kernel, "tab_a53",
             new string[] { "col_a1", "col_a3", "col_a4" }) 
        {
            Назва = "";
            ПеріодВиконання = 0;
            Опис = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                ПеріодВиконання = (base.FieldValue["col_a3"] != DBNull.Value) ? (Перелічення.ПеріодиВиконанняЗавдань)base.FieldValue["col_a3"] : 0;
                Опис = base.FieldValue["col_a4"].ToString();
                
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
               "</" + root + ">";
        }

        public void Delete()
        {
            base.BaseDelete();
        }
        
        public КалендарПеріодичнихЗавдань_Pointer GetDirectoryPointer()
        {
            КалендарПеріодичнихЗавдань_Pointer directoryPointer = new КалендарПеріодичнихЗавдань_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public string Назва { get; set; }
        public Перелічення.ПеріодиВиконанняЗавдань ПеріодВиконання { get; set; }
        public string Опис { get; set; }
        
    }
    
    ///<summary>
    ///Список періодичних завдань. Наприклад: подати покази лічильників води, світла і т.д з періодичністю раз на місяць..
    ///</summary>
    class КалендарПеріодичнихЗавдань_Pointer : DirectoryPointer
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
    class КалендарПеріодичнихЗавдань_Select : DirectorySelect, IDisposable
    {
        public КалендарПеріодичнихЗавдань_Select() : base(Config.Kernel, "tab_a53",
            new string[] { "col_a1", "col_a3", "col_a4" },
            new string[] { "Назва", "ПеріодВиконання", "Опис" }) { }
        
        public const string Назва = "col_a1";
        public const string ПеріодВиконання = "col_a3";
        public const string Опис = "col_a4";
        
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

namespace НоваКонфігурація_1_0.Перелічення
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
         Замітка = 5
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
    
    #region ENUM "ТипНоменклатури"
    
    public enum ТипНоменклатури
    {
         Товар = 1,
         Послуга = 2,
         Робота = 3
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
    
}

namespace НоваКонфігурація_1_0.Документи
{
    
    #region DOCUMENT "Інвентаризація"
    
    ///<summary>
    ///Перелік оварів на складі.
    ///</summary>
    class Інвентаризація_Objest : DocumentObject
    {
        public Інвентаризація_Objest() : base(Config.Kernel, "tab_a18",
             new string[] { "col_a1", "col_a2", "col_a6", "col_a3", "col_a4" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            Склад = new Довідники.Склади_Pointer();
            Організація = new Довідники.Організації_Pointer();
            Коментар = "";
            
            //Табличні частини
            Товари_TablePart = new Інвентаризація_Товари_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_a1"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_a1"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_a2"] != DBNull.Value) ? (int)base.FieldValue["col_a2"] : 0;
                Склад = new Довідники.Склади_Pointer(base.FieldValue["col_a6"]);
                Організація = new Довідники.Організації_Pointer(base.FieldValue["col_a3"]);
                Коментар = base.FieldValue["col_a4"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = ДатаДок;
            base.FieldValue["col_a2"] = НомерДок;
            base.FieldValue["col_a6"] = Склад.ToString();
            base.FieldValue["col_a3"] = Організація.ToString();
            base.FieldValue["col_a4"] = Коментар;
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public Інвентаризація_Pointer GetDocumentPointer()
        {
            Інвентаризація_Pointer directoryPointer = new Інвентаризація_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public Довідники.Склади_Pointer Склад { get; set; }
        public Довідники.Організації_Pointer Організація { get; set; }
        public string Коментар { get; set; }
        
        //Табличні частини
        public Інвентаризація_Товари_TablePart Товари_TablePart { get; set; }
        
    }
    
    ///<summary>
    ///Перелік оварів на складі.
    ///</summary>
    class Інвентаризація_Pointer : DocumentPointer
    {
        public Інвентаризація_Pointer(object uid = null) : base(Config.Kernel, "tab_a18")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public Інвентаризація_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a18")
        {
            base.Init(uid, fields);
        } 
        
        public Інвентаризація_Objest GetDocumentObject()
        {
            Інвентаризація_Objest ІнвентаризаціяObjestItem = new Інвентаризація_Objest();
            ІнвентаризаціяObjestItem.Read(base.UnigueID);
            return ІнвентаризаціяObjestItem;
        }
    }
    
    ///<summary>
    ///Перелік оварів на складі.
    ///</summary>
    class Інвентаризація_Select : DocumentSelect, IDisposable
    {
        public Інвентаризація_Select() : base(Config.Kernel, "tab_a18") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new Інвентаризація_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public Інвентаризація_Pointer Current { get; private set; }
    }
    
      
    class Інвентаризація_Товари_TablePart : DocumentTablePart
    {
        public Інвентаризація_Товари_TablePart(Інвентаризація_Objest owner) : base(Config.Kernel, "tab_a19",
             new string[] { "col_a3", "col_a4", "col_a5" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public Інвентаризація_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Товар = new Довідники.Номенклатура_Pointer(fieldValue["col_a3"]);
                record.Кількість = (fieldValue["col_a4"] != DBNull.Value) ? (int)fieldValue["col_a4"] : 0;
                record.Коментар = fieldValue["col_a5"].ToString();
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a3", record.Товар.UnigueID.UGuid);
                    fieldValue.Add("col_a4", record.Кількість);
                    fieldValue.Add("col_a5", record.Коментар);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete(Owner.UnigueID);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Товар = new Довідники.Номенклатура_Pointer();
                Кількість = 0;
                Коментар = "";
                
            }
        
            
            public Record(
                Довідники.Номенклатура_Pointer _Товар = null, int _Кількість = 0, string _Коментар = "")
            {
                Товар = _Товар ?? new Довідники.Номенклатура_Pointer();
                Кількість = _Кількість;
                Коментар = _Коментар;
                
            }
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public int Кількість { get; set; }
            public string Коментар { get; set; }
            
        }
    }
      
    
    #endregion
    
    #region DOCUMENT "ПоступленняТоварівПослуг"
    
    
    class ПоступленняТоварівПослуг_Objest : DocumentObject
    {
        public ПоступленняТоварівПослуг_Objest() : base(Config.Kernel, "tab_a22",
             new string[] { "col_b2", "col_b3", "col_b7", "col_b8", "col_a1", "col_a2", "col_a3" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            Склад = new Довідники.Склади_Pointer();
            Контрагент = new Довідники.Контрагенти_Pointer();
            Організація = new Довідники.Організації_Pointer();
            Коментар = "";
            СумаДокументу = 0;
            
            //Табличні частини
            Товари_TablePart = new ПоступленняТоварівПослуг_Товари_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_b2"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_b2"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_b3"] != DBNull.Value) ? (int)base.FieldValue["col_b3"] : 0;
                Склад = new Довідники.Склади_Pointer(base.FieldValue["col_b7"]);
                Контрагент = new Довідники.Контрагенти_Pointer(base.FieldValue["col_b8"]);
                Організація = new Довідники.Організації_Pointer(base.FieldValue["col_a1"]);
                Коментар = base.FieldValue["col_a2"].ToString();
                СумаДокументу = (base.FieldValue["col_a3"] != DBNull.Value) ? (decimal)base.FieldValue["col_a3"] : 0;
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_b2"] = ДатаДок;
            base.FieldValue["col_b3"] = НомерДок;
            base.FieldValue["col_b7"] = Склад.ToString();
            base.FieldValue["col_b8"] = Контрагент.ToString();
            base.FieldValue["col_a1"] = Організація.ToString();
            base.FieldValue["col_a2"] = Коментар;
            base.FieldValue["col_a3"] = СумаДокументу;
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ПоступленняТоварівПослуг_Pointer GetDocumentPointer()
        {
            ПоступленняТоварівПослуг_Pointer directoryPointer = new ПоступленняТоварівПослуг_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public Довідники.Склади_Pointer Склад { get; set; }
        public Довідники.Контрагенти_Pointer Контрагент { get; set; }
        public Довідники.Організації_Pointer Організація { get; set; }
        public string Коментар { get; set; }
        public decimal СумаДокументу { get; set; }
        
        //Табличні частини
        public ПоступленняТоварівПослуг_Товари_TablePart Товари_TablePart { get; set; }
        
    }
    
    
    class ПоступленняТоварівПослуг_Pointer : DocumentPointer
    {
        public ПоступленняТоварівПослуг_Pointer(object uid = null) : base(Config.Kernel, "tab_a22")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ПоступленняТоварівПослуг_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a22")
        {
            base.Init(uid, fields);
        } 
        
        public ПоступленняТоварівПослуг_Objest GetDocumentObject()
        {
            ПоступленняТоварівПослуг_Objest ПоступленняТоварівПослугObjestItem = new ПоступленняТоварівПослуг_Objest();
            ПоступленняТоварівПослугObjestItem.Read(base.UnigueID);
            return ПоступленняТоварівПослугObjestItem;
        }
    }
    
    
    class ПоступленняТоварівПослуг_Select : DocumentSelect, IDisposable
    {
        public ПоступленняТоварівПослуг_Select() : base(Config.Kernel, "tab_a22") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ПоступленняТоварівПослуг_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public ПоступленняТоварівПослуг_Pointer Current { get; private set; }
    }
    
      
    class ПоступленняТоварівПослуг_Товари_TablePart : DocumentTablePart
    {
        public ПоступленняТоварівПослуг_Товари_TablePart(ПоступленняТоварівПослуг_Objest owner) : base(Config.Kernel, "tab_a23",
             new string[] { "col_b4", "col_b5", "col_b6", "col_a1" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public ПоступленняТоварівПослуг_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Товар = new Довідники.Номенклатура_Pointer(fieldValue["col_b4"]);
                record.Кількість = (fieldValue["col_b5"] != DBNull.Value) ? (int)fieldValue["col_b5"] : 0;
                record.Сума = (fieldValue["col_b6"] != DBNull.Value) ? (decimal)fieldValue["col_b6"] : 0;
                record.Разом = (fieldValue["col_a1"] != DBNull.Value) ? (decimal)fieldValue["col_a1"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_b4", record.Товар.UnigueID.UGuid);
                    fieldValue.Add("col_b5", record.Кількість);
                    fieldValue.Add("col_b6", record.Сума);
                    fieldValue.Add("col_a1", record.Разом);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete(Owner.UnigueID);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Товар = new Довідники.Номенклатура_Pointer();
                Кількість = 0;
                Сума = 0;
                Разом = 0;
                
            }
        
            
            public Record(
                Довідники.Номенклатура_Pointer _Товар = null, int _Кількість = 0, decimal _Сума = 0, decimal _Разом = 0)
            {
                Товар = _Товар ?? new Довідники.Номенклатура_Pointer();
                Кількість = _Кількість;
                Сума = _Сума;
                Разом = _Разом;
                
            }
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public int Кількість { get; set; }
            public decimal Сума { get; set; }
            public decimal Разом { get; set; }
            
        }
    }
      
    
    #endregion
    
    #region DOCUMENT "РеалізаціяТоварівПослуг"
    
    
    class РеалізаціяТоварівПослуг_Objest : DocumentObject
    {
        public РеалізаціяТоварівПослуг_Objest() : base(Config.Kernel, "tab_a25",
             new string[] { "col_b2", "col_b3", "col_b7", "col_b8", "col_a1", "col_a2", "col_a3" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            Склад = new Довідники.Склади_Pointer();
            Контрагент = new Довідники.Контрагенти_Pointer();
            Організація = new Довідники.Організації_Pointer();
            Коментар = "";
            СумаДокументу = 0;
            
            //Табличні частини
            Товари_TablePart = new РеалізаціяТоварівПослуг_Товари_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_b2"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_b2"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_b3"] != DBNull.Value) ? (int)base.FieldValue["col_b3"] : 0;
                Склад = new Довідники.Склади_Pointer(base.FieldValue["col_b7"]);
                Контрагент = new Довідники.Контрагенти_Pointer(base.FieldValue["col_b8"]);
                Організація = new Довідники.Організації_Pointer(base.FieldValue["col_a1"]);
                Коментар = base.FieldValue["col_a2"].ToString();
                СумаДокументу = (base.FieldValue["col_a3"] != DBNull.Value) ? (decimal)base.FieldValue["col_a3"] : 0;
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_b2"] = ДатаДок;
            base.FieldValue["col_b3"] = НомерДок;
            base.FieldValue["col_b7"] = Склад.ToString();
            base.FieldValue["col_b8"] = Контрагент.ToString();
            base.FieldValue["col_a1"] = Організація.ToString();
            base.FieldValue["col_a2"] = Коментар;
            base.FieldValue["col_a3"] = СумаДокументу;
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public РеалізаціяТоварівПослуг_Pointer GetDocumentPointer()
        {
            РеалізаціяТоварівПослуг_Pointer directoryPointer = new РеалізаціяТоварівПослуг_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public Довідники.Склади_Pointer Склад { get; set; }
        public Довідники.Контрагенти_Pointer Контрагент { get; set; }
        public Довідники.Організації_Pointer Організація { get; set; }
        public string Коментар { get; set; }
        public decimal СумаДокументу { get; set; }
        
        //Табличні частини
        public РеалізаціяТоварівПослуг_Товари_TablePart Товари_TablePart { get; set; }
        
    }
    
    
    class РеалізаціяТоварівПослуг_Pointer : DocumentPointer
    {
        public РеалізаціяТоварівПослуг_Pointer(object uid = null) : base(Config.Kernel, "tab_a25")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public РеалізаціяТоварівПослуг_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a25")
        {
            base.Init(uid, fields);
        } 
        
        public РеалізаціяТоварівПослуг_Objest GetDocumentObject()
        {
            РеалізаціяТоварівПослуг_Objest РеалізаціяТоварівПослугObjestItem = new РеалізаціяТоварівПослуг_Objest();
            РеалізаціяТоварівПослугObjestItem.Read(base.UnigueID);
            return РеалізаціяТоварівПослугObjestItem;
        }
    }
    
    
    class РеалізаціяТоварівПослуг_Select : DocumentSelect, IDisposable
    {
        public РеалізаціяТоварівПослуг_Select() : base(Config.Kernel, "tab_a25") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new РеалізаціяТоварівПослуг_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public РеалізаціяТоварівПослуг_Pointer Current { get; private set; }
    }
    
      
    class РеалізаціяТоварівПослуг_Товари_TablePart : DocumentTablePart
    {
        public РеалізаціяТоварівПослуг_Товари_TablePart(РеалізаціяТоварівПослуг_Objest owner) : base(Config.Kernel, "tab_a26",
             new string[] { "col_b4", "col_b5", "col_b6", "col_a1" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public РеалізаціяТоварівПослуг_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Товар = new Довідники.Номенклатура_Pointer(fieldValue["col_b4"]);
                record.Кількість = (fieldValue["col_b5"] != DBNull.Value) ? (int)fieldValue["col_b5"] : 0;
                record.Сума = (fieldValue["col_b6"] != DBNull.Value) ? (decimal)fieldValue["col_b6"] : 0;
                record.Разом = (fieldValue["col_a1"] != DBNull.Value) ? (decimal)fieldValue["col_a1"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_b4", record.Товар.UnigueID.UGuid);
                    fieldValue.Add("col_b5", record.Кількість);
                    fieldValue.Add("col_b6", record.Сума);
                    fieldValue.Add("col_a1", record.Разом);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete(Owner.UnigueID);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Товар = new Довідники.Номенклатура_Pointer();
                Кількість = 0;
                Сума = 0;
                Разом = 0;
                
            }
        
            
            public Record(
                Довідники.Номенклатура_Pointer _Товар = null, int _Кількість = 0, decimal _Сума = 0, decimal _Разом = 0)
            {
                Товар = _Товар ?? new Довідники.Номенклатура_Pointer();
                Кількість = _Кількість;
                Сума = _Сума;
                Разом = _Разом;
                
            }
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public int Кількість { get; set; }
            public decimal Сума { get; set; }
            public decimal Разом { get; set; }
            
        }
    }
      
    
    #endregion
    
    #region DOCUMENT "ПрихіднийКасовийОрдер"
    
    
    class ПрихіднийКасовийОрдер_Objest : DocumentObject
    {
        public ПрихіднийКасовийОрдер_Objest() : base(Config.Kernel, "tab_a37",
             new string[] { "col_d8", "col_d9", "col_e1", "col_e2", "col_e3", "col_a1", "col_a2" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            Каса = new Довідники.Каса_Pointer();
            Сума = 0;
            Контрагент = new Довідники.Контрагенти_Pointer();
            Організація = new Довідники.Організації_Pointer();
            Коментар = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_d8"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_d8"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_d9"] != DBNull.Value) ? (int)base.FieldValue["col_d9"] : 0;
                Каса = new Довідники.Каса_Pointer(base.FieldValue["col_e1"]);
                Сума = (base.FieldValue["col_e2"] != DBNull.Value) ? (decimal)base.FieldValue["col_e2"] : 0;
                Контрагент = new Довідники.Контрагенти_Pointer(base.FieldValue["col_e3"]);
                Організація = new Довідники.Організації_Pointer(base.FieldValue["col_a1"]);
                Коментар = base.FieldValue["col_a2"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_d8"] = ДатаДок;
            base.FieldValue["col_d9"] = НомерДок;
            base.FieldValue["col_e1"] = Каса.ToString();
            base.FieldValue["col_e2"] = Сума;
            base.FieldValue["col_e3"] = Контрагент.ToString();
            base.FieldValue["col_a1"] = Організація.ToString();
            base.FieldValue["col_a2"] = Коментар;
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ПрихіднийКасовийОрдер_Pointer GetDocumentPointer()
        {
            ПрихіднийКасовийОрдер_Pointer directoryPointer = new ПрихіднийКасовийОрдер_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public Довідники.Каса_Pointer Каса { get; set; }
        public decimal Сума { get; set; }
        public Довідники.Контрагенти_Pointer Контрагент { get; set; }
        public Довідники.Організації_Pointer Організація { get; set; }
        public string Коментар { get; set; }
        
    }
    
    
    class ПрихіднийКасовийОрдер_Pointer : DocumentPointer
    {
        public ПрихіднийКасовийОрдер_Pointer(object uid = null) : base(Config.Kernel, "tab_a37")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ПрихіднийКасовийОрдер_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a37")
        {
            base.Init(uid, fields);
        } 
        
        public ПрихіднийКасовийОрдер_Objest GetDocumentObject()
        {
            ПрихіднийКасовийОрдер_Objest ПрихіднийКасовийОрдерObjestItem = new ПрихіднийКасовийОрдер_Objest();
            ПрихіднийКасовийОрдерObjestItem.Read(base.UnigueID);
            return ПрихіднийКасовийОрдерObjestItem;
        }
    }
    
    
    class ПрихіднийКасовийОрдер_Select : DocumentSelect, IDisposable
    {
        public ПрихіднийКасовийОрдер_Select() : base(Config.Kernel, "tab_a37") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ПрихіднийКасовийОрдер_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public ПрихіднийКасовийОрдер_Pointer Current { get; private set; }
    }
    
      
    
    #endregion
    
    #region DOCUMENT "РозхіднийКасовийОрдер"
    
    
    class РозхіднийКасовийОрдер_Objest : DocumentObject
    {
        public РозхіднийКасовийОрдер_Objest() : base(Config.Kernel, "tab_a38",
             new string[] { "col_d8", "col_d9", "col_e1", "col_e2", "col_e3", "col_a1", "col_a2" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            Каса = new Довідники.Каса_Pointer();
            Сума = 0;
            Контрагент = new Довідники.Контрагенти_Pointer();
            Організація = new Довідники.Організації_Pointer();
            Коментар = "";
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_d8"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_d8"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_d9"] != DBNull.Value) ? (int)base.FieldValue["col_d9"] : 0;
                Каса = new Довідники.Каса_Pointer(base.FieldValue["col_e1"]);
                Сума = (base.FieldValue["col_e2"] != DBNull.Value) ? (decimal)base.FieldValue["col_e2"] : 0;
                Контрагент = new Довідники.Контрагенти_Pointer(base.FieldValue["col_e3"]);
                Організація = new Довідники.Організації_Pointer(base.FieldValue["col_a1"]);
                Коментар = base.FieldValue["col_a2"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_d8"] = ДатаДок;
            base.FieldValue["col_d9"] = НомерДок;
            base.FieldValue["col_e1"] = Каса.ToString();
            base.FieldValue["col_e2"] = Сума;
            base.FieldValue["col_e3"] = Контрагент.ToString();
            base.FieldValue["col_a1"] = Організація.ToString();
            base.FieldValue["col_a2"] = Коментар;
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public РозхіднийКасовийОрдер_Pointer GetDocumentPointer()
        {
            РозхіднийКасовийОрдер_Pointer directoryPointer = new РозхіднийКасовийОрдер_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public Довідники.Каса_Pointer Каса { get; set; }
        public decimal Сума { get; set; }
        public Довідники.Контрагенти_Pointer Контрагент { get; set; }
        public Довідники.Організації_Pointer Організація { get; set; }
        public string Коментар { get; set; }
        
    }
    
    
    class РозхіднийКасовийОрдер_Pointer : DocumentPointer
    {
        public РозхіднийКасовийОрдер_Pointer(object uid = null) : base(Config.Kernel, "tab_a38")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public РозхіднийКасовийОрдер_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a38")
        {
            base.Init(uid, fields);
        } 
        
        public РозхіднийКасовийОрдер_Objest GetDocumentObject()
        {
            РозхіднийКасовийОрдер_Objest РозхіднийКасовийОрдерObjestItem = new РозхіднийКасовийОрдер_Objest();
            РозхіднийКасовийОрдерObjestItem.Read(base.UnigueID);
            return РозхіднийКасовийОрдерObjestItem;
        }
    }
    
    
    class РозхіднийКасовийОрдер_Select : DocumentSelect, IDisposable
    {
        public РозхіднийКасовийОрдер_Select() : base(Config.Kernel, "tab_a38") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new РозхіднийКасовийОрдер_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public РозхіднийКасовийОрдер_Pointer Current { get; private set; }
    }
    
      
    
    #endregion
    
    #region DOCUMENT "ПереміщенняТоварів"
    
    
    class ПереміщенняТоварів_Objest : DocumentObject
    {
        public ПереміщенняТоварів_Objest() : base(Config.Kernel, "tab_a40",
             new string[] { "col_a7", "col_a8", "col_a9", "col_b1", "col_b2", "col_b3" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            СкладВідправник = new Довідники.Склади_Pointer();
            СкладОтримувач = new Довідники.Склади_Pointer();
            Коментар = "";
            Організація = new Довідники.Організації_Pointer();
            
            //Табличні частини
            Товари_TablePart = new ПереміщенняТоварів_Товари_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_a7"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_a7"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_a8"] != DBNull.Value) ? (int)base.FieldValue["col_a8"] : 0;
                СкладВідправник = new Довідники.Склади_Pointer(base.FieldValue["col_a9"]);
                СкладОтримувач = new Довідники.Склади_Pointer(base.FieldValue["col_b1"]);
                Коментар = base.FieldValue["col_b2"].ToString();
                Організація = new Довідники.Організації_Pointer(base.FieldValue["col_b3"]);
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a7"] = ДатаДок;
            base.FieldValue["col_a8"] = НомерДок;
            base.FieldValue["col_a9"] = СкладВідправник.ToString();
            base.FieldValue["col_b1"] = СкладОтримувач.ToString();
            base.FieldValue["col_b2"] = Коментар;
            base.FieldValue["col_b3"] = Організація.ToString();
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ПереміщенняТоварів_Pointer GetDocumentPointer()
        {
            ПереміщенняТоварів_Pointer directoryPointer = new ПереміщенняТоварів_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public Довідники.Склади_Pointer СкладВідправник { get; set; }
        public Довідники.Склади_Pointer СкладОтримувач { get; set; }
        public string Коментар { get; set; }
        public Довідники.Організації_Pointer Організація { get; set; }
        
        //Табличні частини
        public ПереміщенняТоварів_Товари_TablePart Товари_TablePart { get; set; }
        
    }
    
    
    class ПереміщенняТоварів_Pointer : DocumentPointer
    {
        public ПереміщенняТоварів_Pointer(object uid = null) : base(Config.Kernel, "tab_a40")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ПереміщенняТоварів_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a40")
        {
            base.Init(uid, fields);
        } 
        
        public ПереміщенняТоварів_Objest GetDocumentObject()
        {
            ПереміщенняТоварів_Objest ПереміщенняТоварівObjestItem = new ПереміщенняТоварів_Objest();
            ПереміщенняТоварівObjestItem.Read(base.UnigueID);
            return ПереміщенняТоварівObjestItem;
        }
    }
    
    
    class ПереміщенняТоварів_Select : DocumentSelect, IDisposable
    {
        public ПереміщенняТоварів_Select() : base(Config.Kernel, "tab_a40") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ПереміщенняТоварів_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public ПереміщенняТоварів_Pointer Current { get; private set; }
    }
    
      
    class ПереміщенняТоварів_Товари_TablePart : DocumentTablePart
    {
        public ПереміщенняТоварів_Товари_TablePart(ПереміщенняТоварів_Objest owner) : base(Config.Kernel, "tab_a41",
             new string[] { "col_b4", "col_b5" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public ПереміщенняТоварів_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Товар = new Довідники.Номенклатура_Pointer(fieldValue["col_b4"]);
                record.Кількість = (fieldValue["col_b5"] != DBNull.Value) ? (int)fieldValue["col_b5"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_b4", record.Товар.UnigueID.UGuid);
                    fieldValue.Add("col_b5", record.Кількість);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete(Owner.UnigueID);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Товар = new Довідники.Номенклатура_Pointer();
                Кількість = 0;
                
            }
        
            
            public Record(
                Довідники.Номенклатура_Pointer _Товар = null, int _Кількість = 0)
            {
                Товар = _Товар ?? new Довідники.Номенклатура_Pointer();
                Кількість = _Кількість;
                
            }
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public int Кількість { get; set; }
            
        }
    }
      
    
    #endregion
    
    #region DOCUMENT "ПоверненняТоварівВідКлієнта"
    
    
    class ПоверненняТоварівВідКлієнта_Objest : DocumentObject
    {
        public ПоверненняТоварівВідКлієнта_Objest() : base(Config.Kernel, "tab_a42",
             new string[] { "col_b2", "col_b3", "col_b7", "col_b8", "col_a1", "col_a2", "col_a3" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            Склад = new Довідники.Склади_Pointer();
            Контрагент = new Довідники.Контрагенти_Pointer();
            Організація = new Довідники.Організації_Pointer();
            Коментар = "";
            СумаДокументу = 0;
            
            //Табличні частини
            Товари_TablePart = new ПоверненняТоварівВідКлієнта_Товари_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_b2"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_b2"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_b3"] != DBNull.Value) ? (int)base.FieldValue["col_b3"] : 0;
                Склад = new Довідники.Склади_Pointer(base.FieldValue["col_b7"]);
                Контрагент = new Довідники.Контрагенти_Pointer(base.FieldValue["col_b8"]);
                Організація = new Довідники.Організації_Pointer(base.FieldValue["col_a1"]);
                Коментар = base.FieldValue["col_a2"].ToString();
                СумаДокументу = (base.FieldValue["col_a3"] != DBNull.Value) ? (decimal)base.FieldValue["col_a3"] : 0;
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_b2"] = ДатаДок;
            base.FieldValue["col_b3"] = НомерДок;
            base.FieldValue["col_b7"] = Склад.ToString();
            base.FieldValue["col_b8"] = Контрагент.ToString();
            base.FieldValue["col_a1"] = Організація.ToString();
            base.FieldValue["col_a2"] = Коментар;
            base.FieldValue["col_a3"] = СумаДокументу;
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ПоверненняТоварівВідКлієнта_Pointer GetDocumentPointer()
        {
            ПоверненняТоварівВідКлієнта_Pointer directoryPointer = new ПоверненняТоварівВідКлієнта_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public Довідники.Склади_Pointer Склад { get; set; }
        public Довідники.Контрагенти_Pointer Контрагент { get; set; }
        public Довідники.Організації_Pointer Організація { get; set; }
        public string Коментар { get; set; }
        public decimal СумаДокументу { get; set; }
        
        //Табличні частини
        public ПоверненняТоварівВідКлієнта_Товари_TablePart Товари_TablePart { get; set; }
        
    }
    
    
    class ПоверненняТоварівВідКлієнта_Pointer : DocumentPointer
    {
        public ПоверненняТоварівВідКлієнта_Pointer(object uid = null) : base(Config.Kernel, "tab_a42")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ПоверненняТоварівВідКлієнта_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a42")
        {
            base.Init(uid, fields);
        } 
        
        public ПоверненняТоварівВідКлієнта_Objest GetDocumentObject()
        {
            ПоверненняТоварівВідКлієнта_Objest ПоверненняТоварівВідКлієнтаObjestItem = new ПоверненняТоварівВідКлієнта_Objest();
            ПоверненняТоварівВідКлієнтаObjestItem.Read(base.UnigueID);
            return ПоверненняТоварівВідКлієнтаObjestItem;
        }
    }
    
    
    class ПоверненняТоварівВідКлієнта_Select : DocumentSelect, IDisposable
    {
        public ПоверненняТоварівВідКлієнта_Select() : base(Config.Kernel, "tab_a42") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ПоверненняТоварівВідКлієнта_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public ПоверненняТоварівВідКлієнта_Pointer Current { get; private set; }
    }
    
      
    class ПоверненняТоварівВідКлієнта_Товари_TablePart : DocumentTablePart
    {
        public ПоверненняТоварівВідКлієнта_Товари_TablePart(ПоверненняТоварівВідКлієнта_Objest owner) : base(Config.Kernel, "tab_a43",
             new string[] { "col_b4", "col_b5", "col_b6", "col_a1" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public ПоверненняТоварівВідКлієнта_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Товар = new Довідники.Номенклатура_Pointer(fieldValue["col_b4"]);
                record.Кількість = (fieldValue["col_b5"] != DBNull.Value) ? (int)fieldValue["col_b5"] : 0;
                record.Сума = (fieldValue["col_b6"] != DBNull.Value) ? (decimal)fieldValue["col_b6"] : 0;
                record.Разом = (fieldValue["col_a1"] != DBNull.Value) ? (decimal)fieldValue["col_a1"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_b4", record.Товар.UnigueID.UGuid);
                    fieldValue.Add("col_b5", record.Кількість);
                    fieldValue.Add("col_b6", record.Сума);
                    fieldValue.Add("col_a1", record.Разом);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete(Owner.UnigueID);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Товар = new Довідники.Номенклатура_Pointer();
                Кількість = 0;
                Сума = 0;
                Разом = 0;
                
            }
        
            
            public Record(
                Довідники.Номенклатура_Pointer _Товар = null, int _Кількість = 0, decimal _Сума = 0, decimal _Разом = 0)
            {
                Товар = _Товар ?? new Довідники.Номенклатура_Pointer();
                Кількість = _Кількість;
                Сума = _Сума;
                Разом = _Разом;
                
            }
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public int Кількість { get; set; }
            public decimal Сума { get; set; }
            public decimal Разом { get; set; }
            
        }
    }
      
    
    #endregion
    
    #region DOCUMENT "ПоверненняТоварівПостачальнику"
    
    
    class ПоверненняТоварівПостачальнику_Objest : DocumentObject
    {
        public ПоверненняТоварівПостачальнику_Objest() : base(Config.Kernel, "tab_a44",
             new string[] { "col_b2", "col_b3", "col_b7", "col_b8", "col_a1", "col_a2", "col_a3" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            Склад = new Довідники.Склади_Pointer();
            Контрагент = new Довідники.Контрагенти_Pointer();
            Організація = new Довідники.Організації_Pointer();
            Коментар = "";
            СумаДокументу = 0;
            
            //Табличні частини
            Товари_TablePart = new ПоверненняТоварівПостачальнику_Товари_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_b2"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_b2"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_b3"] != DBNull.Value) ? (int)base.FieldValue["col_b3"] : 0;
                Склад = new Довідники.Склади_Pointer(base.FieldValue["col_b7"]);
                Контрагент = new Довідники.Контрагенти_Pointer(base.FieldValue["col_b8"]);
                Організація = new Довідники.Організації_Pointer(base.FieldValue["col_a1"]);
                Коментар = base.FieldValue["col_a2"].ToString();
                СумаДокументу = (base.FieldValue["col_a3"] != DBNull.Value) ? (decimal)base.FieldValue["col_a3"] : 0;
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_b2"] = ДатаДок;
            base.FieldValue["col_b3"] = НомерДок;
            base.FieldValue["col_b7"] = Склад.ToString();
            base.FieldValue["col_b8"] = Контрагент.ToString();
            base.FieldValue["col_a1"] = Організація.ToString();
            base.FieldValue["col_a2"] = Коментар;
            base.FieldValue["col_a3"] = СумаДокументу;
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ПоверненняТоварівПостачальнику_Pointer GetDocumentPointer()
        {
            ПоверненняТоварівПостачальнику_Pointer directoryPointer = new ПоверненняТоварівПостачальнику_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public Довідники.Склади_Pointer Склад { get; set; }
        public Довідники.Контрагенти_Pointer Контрагент { get; set; }
        public Довідники.Організації_Pointer Організація { get; set; }
        public string Коментар { get; set; }
        public decimal СумаДокументу { get; set; }
        
        //Табличні частини
        public ПоверненняТоварівПостачальнику_Товари_TablePart Товари_TablePart { get; set; }
        
    }
    
    
    class ПоверненняТоварівПостачальнику_Pointer : DocumentPointer
    {
        public ПоверненняТоварівПостачальнику_Pointer(object uid = null) : base(Config.Kernel, "tab_a44")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ПоверненняТоварівПостачальнику_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a44")
        {
            base.Init(uid, fields);
        } 
        
        public ПоверненняТоварівПостачальнику_Objest GetDocumentObject()
        {
            ПоверненняТоварівПостачальнику_Objest ПоверненняТоварівПостачальникуObjestItem = new ПоверненняТоварівПостачальнику_Objest();
            ПоверненняТоварівПостачальникуObjestItem.Read(base.UnigueID);
            return ПоверненняТоварівПостачальникуObjestItem;
        }
    }
    
    
    class ПоверненняТоварівПостачальнику_Select : DocumentSelect, IDisposable
    {
        public ПоверненняТоварівПостачальнику_Select() : base(Config.Kernel, "tab_a44") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ПоверненняТоварівПостачальнику_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public ПоверненняТоварівПостачальнику_Pointer Current { get; private set; }
    }
    
      
    class ПоверненняТоварівПостачальнику_Товари_TablePart : DocumentTablePart
    {
        public ПоверненняТоварівПостачальнику_Товари_TablePart(ПоверненняТоварівПостачальнику_Objest owner) : base(Config.Kernel, "tab_a45",
             new string[] { "col_b4", "col_b5", "col_b6", "col_a1" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public ПоверненняТоварівПостачальнику_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Товар = new Довідники.Номенклатура_Pointer(fieldValue["col_b4"]);
                record.Кількість = (fieldValue["col_b5"] != DBNull.Value) ? (int)fieldValue["col_b5"] : 0;
                record.Сума = (fieldValue["col_b6"] != DBNull.Value) ? (decimal)fieldValue["col_b6"] : 0;
                record.Разом = (fieldValue["col_a1"] != DBNull.Value) ? (decimal)fieldValue["col_a1"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_b4", record.Товар.UnigueID.UGuid);
                    fieldValue.Add("col_b5", record.Кількість);
                    fieldValue.Add("col_b6", record.Сума);
                    fieldValue.Add("col_a1", record.Разом);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete(Owner.UnigueID);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Товар = new Довідники.Номенклатура_Pointer();
                Кількість = 0;
                Сума = 0;
                Разом = 0;
                
            }
        
            
            public Record(
                Довідники.Номенклатура_Pointer _Товар = null, int _Кількість = 0, decimal _Сума = 0, decimal _Разом = 0)
            {
                Товар = _Товар ?? new Довідники.Номенклатура_Pointer();
                Кількість = _Кількість;
                Сума = _Сума;
                Разом = _Разом;
                
            }
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public int Кількість { get; set; }
            public decimal Сума { get; set; }
            public decimal Разом { get; set; }
            
        }
    }
      
    
    #endregion
    
    #region DOCUMENT "ЗамовленняПостачальнику"
    
    
    class ЗамовленняПостачальнику_Objest : DocumentObject
    {
        public ЗамовленняПостачальнику_Objest() : base(Config.Kernel, "tab_a46",
             new string[] { "col_b2", "col_b3", "col_b7", "col_b8", "col_a1", "col_a2", "col_a3" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            Склад = new Довідники.Склади_Pointer();
            Контрагент = new Довідники.Контрагенти_Pointer();
            Організація = new Довідники.Організації_Pointer();
            Коментар = "";
            СумаДокументу = 0;
            
            //Табличні частини
            Товари_TablePart = new ЗамовленняПостачальнику_Товари_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_b2"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_b2"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_b3"] != DBNull.Value) ? (int)base.FieldValue["col_b3"] : 0;
                Склад = new Довідники.Склади_Pointer(base.FieldValue["col_b7"]);
                Контрагент = new Довідники.Контрагенти_Pointer(base.FieldValue["col_b8"]);
                Організація = new Довідники.Організації_Pointer(base.FieldValue["col_a1"]);
                Коментар = base.FieldValue["col_a2"].ToString();
                СумаДокументу = (base.FieldValue["col_a3"] != DBNull.Value) ? (decimal)base.FieldValue["col_a3"] : 0;
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_b2"] = ДатаДок;
            base.FieldValue["col_b3"] = НомерДок;
            base.FieldValue["col_b7"] = Склад.ToString();
            base.FieldValue["col_b8"] = Контрагент.ToString();
            base.FieldValue["col_a1"] = Організація.ToString();
            base.FieldValue["col_a2"] = Коментар;
            base.FieldValue["col_a3"] = СумаДокументу;
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ЗамовленняПостачальнику_Pointer GetDocumentPointer()
        {
            ЗамовленняПостачальнику_Pointer directoryPointer = new ЗамовленняПостачальнику_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public Довідники.Склади_Pointer Склад { get; set; }
        public Довідники.Контрагенти_Pointer Контрагент { get; set; }
        public Довідники.Організації_Pointer Організація { get; set; }
        public string Коментар { get; set; }
        public decimal СумаДокументу { get; set; }
        
        //Табличні частини
        public ЗамовленняПостачальнику_Товари_TablePart Товари_TablePart { get; set; }
        
    }
    
    
    class ЗамовленняПостачальнику_Pointer : DocumentPointer
    {
        public ЗамовленняПостачальнику_Pointer(object uid = null) : base(Config.Kernel, "tab_a46")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ЗамовленняПостачальнику_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a46")
        {
            base.Init(uid, fields);
        } 
        
        public ЗамовленняПостачальнику_Objest GetDocumentObject()
        {
            ЗамовленняПостачальнику_Objest ЗамовленняПостачальникуObjestItem = new ЗамовленняПостачальнику_Objest();
            ЗамовленняПостачальникуObjestItem.Read(base.UnigueID);
            return ЗамовленняПостачальникуObjestItem;
        }
    }
    
    
    class ЗамовленняПостачальнику_Select : DocumentSelect, IDisposable
    {
        public ЗамовленняПостачальнику_Select() : base(Config.Kernel, "tab_a46") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ЗамовленняПостачальнику_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public ЗамовленняПостачальнику_Pointer Current { get; private set; }
    }
    
      
    class ЗамовленняПостачальнику_Товари_TablePart : DocumentTablePart
    {
        public ЗамовленняПостачальнику_Товари_TablePart(ЗамовленняПостачальнику_Objest owner) : base(Config.Kernel, "tab_a47",
             new string[] { "col_b4", "col_b5", "col_b6", "col_a1" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public ЗамовленняПостачальнику_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Товар = new Довідники.Номенклатура_Pointer(fieldValue["col_b4"]);
                record.Кількість = (fieldValue["col_b5"] != DBNull.Value) ? (int)fieldValue["col_b5"] : 0;
                record.Сума = (fieldValue["col_b6"] != DBNull.Value) ? (decimal)fieldValue["col_b6"] : 0;
                record.Разом = (fieldValue["col_a1"] != DBNull.Value) ? (decimal)fieldValue["col_a1"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_b4", record.Товар.UnigueID.UGuid);
                    fieldValue.Add("col_b5", record.Кількість);
                    fieldValue.Add("col_b6", record.Сума);
                    fieldValue.Add("col_a1", record.Разом);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete(Owner.UnigueID);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Товар = new Довідники.Номенклатура_Pointer();
                Кількість = 0;
                Сума = 0;
                Разом = 0;
                
            }
        
            
            public Record(
                Довідники.Номенклатура_Pointer _Товар = null, int _Кількість = 0, decimal _Сума = 0, decimal _Разом = 0)
            {
                Товар = _Товар ?? new Довідники.Номенклатура_Pointer();
                Кількість = _Кількість;
                Сума = _Сума;
                Разом = _Разом;
                
            }
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public int Кількість { get; set; }
            public decimal Сума { get; set; }
            public decimal Разом { get; set; }
            
        }
    }
      
    
    #endregion
    
    #region DOCUMENT "ЗамовленняКлієнта"
    
    
    class ЗамовленняКлієнта_Objest : DocumentObject
    {
        public ЗамовленняКлієнта_Objest() : base(Config.Kernel, "tab_a48",
             new string[] { "col_b2", "col_b3", "col_b7", "col_b8", "col_a1", "col_a2", "col_a3" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            Склад = new Довідники.Склади_Pointer();
            Контрагент = new Довідники.Контрагенти_Pointer();
            Організація = new Довідники.Організації_Pointer();
            Коментар = "";
            СумаДокументу = 0;
            
            //Табличні частини
            Товари_TablePart = new ЗамовленняКлієнта_Товари_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_b2"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_b2"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_b3"] != DBNull.Value) ? (int)base.FieldValue["col_b3"] : 0;
                Склад = new Довідники.Склади_Pointer(base.FieldValue["col_b7"]);
                Контрагент = new Довідники.Контрагенти_Pointer(base.FieldValue["col_b8"]);
                Організація = new Довідники.Організації_Pointer(base.FieldValue["col_a1"]);
                Коментар = base.FieldValue["col_a2"].ToString();
                СумаДокументу = (base.FieldValue["col_a3"] != DBNull.Value) ? (decimal)base.FieldValue["col_a3"] : 0;
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_b2"] = ДатаДок;
            base.FieldValue["col_b3"] = НомерДок;
            base.FieldValue["col_b7"] = Склад.ToString();
            base.FieldValue["col_b8"] = Контрагент.ToString();
            base.FieldValue["col_a1"] = Організація.ToString();
            base.FieldValue["col_a2"] = Коментар;
            base.FieldValue["col_a3"] = СумаДокументу;
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ЗамовленняКлієнта_Pointer GetDocumentPointer()
        {
            ЗамовленняКлієнта_Pointer directoryPointer = new ЗамовленняКлієнта_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public Довідники.Склади_Pointer Склад { get; set; }
        public Довідники.Контрагенти_Pointer Контрагент { get; set; }
        public Довідники.Організації_Pointer Організація { get; set; }
        public string Коментар { get; set; }
        public decimal СумаДокументу { get; set; }
        
        //Табличні частини
        public ЗамовленняКлієнта_Товари_TablePart Товари_TablePart { get; set; }
        
    }
    
    
    class ЗамовленняКлієнта_Pointer : DocumentPointer
    {
        public ЗамовленняКлієнта_Pointer(object uid = null) : base(Config.Kernel, "tab_a48")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ЗамовленняКлієнта_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a48")
        {
            base.Init(uid, fields);
        } 
        
        public ЗамовленняКлієнта_Objest GetDocumentObject()
        {
            ЗамовленняКлієнта_Objest ЗамовленняКлієнтаObjestItem = new ЗамовленняКлієнта_Objest();
            ЗамовленняКлієнтаObjestItem.Read(base.UnigueID);
            return ЗамовленняКлієнтаObjestItem;
        }
    }
    
    
    class ЗамовленняКлієнта_Select : DocumentSelect, IDisposable
    {
        public ЗамовленняКлієнта_Select() : base(Config.Kernel, "tab_a48") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ЗамовленняКлієнта_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public ЗамовленняКлієнта_Pointer Current { get; private set; }
    }
    
      
    class ЗамовленняКлієнта_Товари_TablePart : DocumentTablePart
    {
        public ЗамовленняКлієнта_Товари_TablePart(ЗамовленняКлієнта_Objest owner) : base(Config.Kernel, "tab_a49",
             new string[] { "col_b4", "col_b5", "col_b6", "col_a1" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public ЗамовленняКлієнта_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Товар = new Довідники.Номенклатура_Pointer(fieldValue["col_b4"]);
                record.Кількість = (fieldValue["col_b5"] != DBNull.Value) ? (int)fieldValue["col_b5"] : 0;
                record.Сума = (fieldValue["col_b6"] != DBNull.Value) ? (decimal)fieldValue["col_b6"] : 0;
                record.Разом = (fieldValue["col_a1"] != DBNull.Value) ? (decimal)fieldValue["col_a1"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_b4", record.Товар.UnigueID.UGuid);
                    fieldValue.Add("col_b5", record.Кількість);
                    fieldValue.Add("col_b6", record.Сума);
                    fieldValue.Add("col_a1", record.Разом);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete(Owner.UnigueID);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Товар = new Довідники.Номенклатура_Pointer();
                Кількість = 0;
                Сума = 0;
                Разом = 0;
                
            }
        
            
            public Record(
                Довідники.Номенклатура_Pointer _Товар = null, int _Кількість = 0, decimal _Сума = 0, decimal _Разом = 0)
            {
                Товар = _Товар ?? new Довідники.Номенклатура_Pointer();
                Кількість = _Кількість;
                Сума = _Сума;
                Разом = _Разом;
                
            }
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public int Кількість { get; set; }
            public decimal Сума { get; set; }
            public decimal Разом { get; set; }
            
        }
    }
      
    
    #endregion
    
    #region DOCUMENT "ВстановленняЦінНоменклатури"
    
    
    class ВстановленняЦінНоменклатури_Objest : DocumentObject
    {
        public ВстановленняЦінНоменклатури_Objest() : base(Config.Kernel, "tab_a34",
             new string[] { "col_a1", "col_a2", "col_a6" }) 
        {
            ДатаДок = DateTime.MinValue;
            НомерДок = 0;
            Коментар = "";
            
            //Табличні частини
            Товари_TablePart = new ВстановленняЦінНоменклатури_Товари_TablePart(this);
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                ДатаДок = (base.FieldValue["col_a1"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_a1"].ToString()) : DateTime.MinValue;
                НомерДок = (base.FieldValue["col_a2"] != DBNull.Value) ? (int)base.FieldValue["col_a2"] : 0;
                Коментар = base.FieldValue["col_a6"].ToString();
                
                BaseClear();
                return true;
            }
            else
                return false;
        }
        
        public void Save()
        {
            base.FieldValue["col_a1"] = ДатаДок;
            base.FieldValue["col_a2"] = НомерДок;
            base.FieldValue["col_a6"] = Коментар;
            
            BaseSave();
        }
        
        public void Delete()
        {
            base.BaseDelete();
        }
        
        public ВстановленняЦінНоменклатури_Pointer GetDocumentPointer()
        {
            ВстановленняЦінНоменклатури_Pointer directoryPointer = new ВстановленняЦінНоменклатури_Pointer(UnigueID.UGuid);
            return directoryPointer;
        }
        
        public DateTime ДатаДок { get; set; }
        public int НомерДок { get; set; }
        public string Коментар { get; set; }
        
        //Табличні частини
        public ВстановленняЦінНоменклатури_Товари_TablePart Товари_TablePart { get; set; }
        
    }
    
    
    class ВстановленняЦінНоменклатури_Pointer : DocumentPointer
    {
        public ВстановленняЦінНоменклатури_Pointer(object uid = null) : base(Config.Kernel, "tab_a34")
        {
            base.Init(new UnigueID(uid), null);
        }
        
        public ВстановленняЦінНоменклатури_Pointer(UnigueID uid, Dictionary<string, object> fields = null) : base(Config.Kernel, "tab_a34")
        {
            base.Init(uid, fields);
        } 
        
        public ВстановленняЦінНоменклатури_Objest GetDocumentObject()
        {
            ВстановленняЦінНоменклатури_Objest ВстановленняЦінНоменклатуриObjestItem = new ВстановленняЦінНоменклатури_Objest();
            ВстановленняЦінНоменклатуриObjestItem.Read(base.UnigueID);
            return ВстановленняЦінНоменклатуриObjestItem;
        }
    }
    
    
    class ВстановленняЦінНоменклатури_Select : DocumentSelect, IDisposable
    {
        public ВстановленняЦінНоменклатури_Select() : base(Config.Kernel, "tab_a34") { }
        
        public bool Select() { return base.BaseSelect(); }
        
        public bool SelectSingle() { if (base.BaseSelectSingle()) { MoveNext(); return true; } else { Current = null; return false; } }
        
        public bool MoveNext() { if (MoveToPosition()) { Current = new ВстановленняЦінНоменклатури_Pointer(base.DocumentPointerPosition.UnigueID, base.DocumentPointerPosition.Fields); return true; } else { Current = null; return false; } }
        
        public ВстановленняЦінНоменклатури_Pointer Current { get; private set; }
    }
    
      
    class ВстановленняЦінНоменклатури_Товари_TablePart : DocumentTablePart
    {
        public ВстановленняЦінНоменклатури_Товари_TablePart(ВстановленняЦінНоменклатури_Objest owner) : base(Config.Kernel, "tab_a35",
             new string[] { "col_a3", "col_a4", "col_a5" }) 
        {
            if (owner == null) throw new Exception("owner null");
            
            Owner = owner;
            Records = new List<Record>();
        }
        
        public ВстановленняЦінНоменклатури_Objest Owner { get; private set; }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            base.BaseRead(Owner.UnigueID);

            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                record.UID = (Guid)fieldValue["uid"];
                
                record.Товар = new Довідники.Номенклатура_Pointer(fieldValue["col_a3"]);
                record.ВидЦіни = new Довідники.ВидиЦін_Pointer(fieldValue["col_a4"]);
                record.Ціна = (fieldValue["col_a5"] != DBNull.Value) ? (decimal)fieldValue["col_a5"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save /*= true*/) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete(Owner.UnigueID);

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a3", record.Товар.UnigueID.UGuid);
                    fieldValue.Add("col_a4", record.ВидЦіни.UnigueID.UGuid);
                    fieldValue.Add("col_a5", record.Ціна);
                    
                    base.BaseSave(record.UID, Owner.UnigueID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete(Owner.UnigueID);
            base.BaseCommitTransaction();
        }
        
        
        public class Record : DocumentTablePartRecord
        {
            public Record()
            {
                Товар = new Довідники.Номенклатура_Pointer();
                ВидЦіни = new Довідники.ВидиЦін_Pointer();
                Ціна = 0;
                
            }
        
            
            public Record(
                Довідники.Номенклатура_Pointer _Товар = null, Довідники.ВидиЦін_Pointer _ВидЦіни = null, decimal _Ціна = 0)
            {
                Товар = _Товар ?? new Довідники.Номенклатура_Pointer();
                ВидЦіни = _ВидЦіни ?? new Довідники.ВидиЦін_Pointer();
                Ціна = _Ціна;
                
            }
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public Довідники.ВидиЦін_Pointer ВидЦіни { get; set; }
            public decimal Ціна { get; set; }
            
        }
    }
      
    
    #endregion
    
}

namespace НоваКонфігурація_1_0.Журнали
{

}

namespace НоваКонфігурація_1_0.РегістриВідомостей
{
    
    #region REGISTER "ЦіниНоменклатури"
    
    
    class ЦіниНоменклатури_RecordsSet : RegisterInformationRecordsSet
    {
        public ЦіниНоменклатури_RecordsSet() : base(Config.Kernel, "tab_a33",
             new string[] { "col_a4", "col_a5", "col_a6", "col_a7" }) 
        {
            Records = new List<Record>();
            Filter = new SelectFilter();
        }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            
            bool isExistPreceding = false;
            if (Filter.Номенклатура != null)
            {
                base.BaseFilter.Add(new Where("col_a4", Comparison.EQ, Filter.Номенклатура.ToString(), false));
                
                isExistPreceding = true;
                
            }
            
            if (Filter.ВидЦіни != null)
            {
                if (isExistPreceding)
                    base.BaseFilter.Add(new Where(Comparison.AND, "col_a5", Comparison.EQ, Filter.ВидЦіни.ToString(), false));
                else
                {
                    base.BaseFilter.Add(new Where("col_a5", Comparison.EQ, Filter.ВидЦіни.ToString(), false));
                    isExistPreceding = true; 
                }
            }
            

            base.BaseRead();
            
            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                
                record.UID = (Guid)fieldValue["uid"];
                  
                record.Номенклатура = new Довідники.Номенклатура_Pointer(fieldValue["col_a4"]);
                record.ВидЦіни = new Довідники.ВидиЦін_Pointer(fieldValue["col_a5"]);
                record.Ціна = fieldValue["col_a6"].ToString();
                record.Валюта = new Довідники.Валюта_Pointer(fieldValue["col_a7"]);
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save = true) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete();

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_a4", record.Номенклатура.ToString());
                    fieldValue.Add("col_a5", record.ВидЦіни.ToString());
                    fieldValue.Add("col_a6", record.Ціна);
                    fieldValue.Add("col_a7", record.Валюта.ToString());
                    
                    base.BaseSave(record.UID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete();
            base.BaseCommitTransaction();
        }
        
        public SelectFilter Filter { get; set; }
        
        
        public class Record : RegisterRecord
        {
            public Record()
            {
                Номенклатура = new Довідники.Номенклатура_Pointer();
                ВидЦіни = new Довідники.ВидиЦін_Pointer();
                Ціна = "";
                Валюта = new Довідники.Валюта_Pointer();
                
            }
        
            public Довідники.Номенклатура_Pointer Номенклатура { get; set; }
            public Довідники.ВидиЦін_Pointer ВидЦіни { get; set; }
            public string Ціна { get; set; }
            public Довідники.Валюта_Pointer Валюта { get; set; }
            
        }
    
        public class SelectFilter
        {
            public SelectFilter()
            {
                 Номенклатура = null;
                 ВидЦіни = null;
                 
            }
        
            public Довідники.Номенклатура_Pointer Номенклатура { get; set; }
            public Довідники.ВидиЦін_Pointer ВидЦіни { get; set; }
            
        }
    }
    
    #endregion
  
}

namespace НоваКонфігурація_1_0.РегістриНакопичення
{
    
    #region REGISTER "ЗалишкиТоварів"
    
    
    class ЗалишкиТоварів_RecordsSet : RegisterAccumulationRecordsSet
    {
        public ЗалишкиТоварів_RecordsSet() : base(Config.Kernel, "tab_a30",
             new string[] { "col_d2", "col_d3", "col_d4" }) 
        {
            Records = new List<Record>();
            Filter = new SelectFilter();
        }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            
            bool isExistPreceding = false;
            if (Filter.Товар != null)
            {
                base.BaseFilter.Add(new Where("col_d2", Comparison.EQ, Filter.Товар.ToString(), false));
                
                isExistPreceding = true;
                
            }
            
            if (Filter.Склад != null)
            {
                if (isExistPreceding)
                    base.BaseFilter.Add(new Where(Comparison.AND, "col_d3", Comparison.EQ, Filter.Склад.ToString(), false));
                else
                {
                    base.BaseFilter.Add(new Where("col_d3", Comparison.EQ, Filter.Склад.ToString(), false));
                    isExistPreceding = true; 
                }
            }
            

            base.BaseRead();
            
            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                
                record.UID = (Guid)fieldValue["uid"];
                  
                record.Товар = new Довідники.Номенклатура_Pointer(fieldValue["col_d2"]);
                record.Склад = new Довідники.Склади_Pointer(fieldValue["col_d3"]);
                record.Кількість = (fieldValue["col_d4"] != DBNull.Value) ? (int)fieldValue["col_d4"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save = true) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete();

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_d2", record.Товар.ToString());
                    fieldValue.Add("col_d3", record.Склад.ToString());
                    fieldValue.Add("col_d4", record.Кількість);
                    
                    base.BaseSave(record.UID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete();
            base.BaseCommitTransaction();
        }
        
        public SelectFilter Filter { get; set; }
        
        
        public class Record : RegisterRecord
        {
            public Record()
            {
                Товар = new Довідники.Номенклатура_Pointer();
                Склад = new Довідники.Склади_Pointer();
                Кількість = 0;
                
            }
        
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public Довідники.Склади_Pointer Склад { get; set; }
            public int Кількість { get; set; }
            
        }
    
        public class SelectFilter
        {
            public SelectFilter()
            {
                 Товар = null;
                 Склад = null;
                 
            }
        
            public Довідники.Номенклатура_Pointer Товар { get; set; }
            public Довідники.Склади_Pointer Склад { get; set; }
            
        }
    }
    
    #endregion
  
    #region REGISTER "ЗалишкиГрошей"
    
    
    class ЗалишкиГрошей_RecordsSet : RegisterAccumulationRecordsSet
    {
        public ЗалишкиГрошей_RecordsSet() : base(Config.Kernel, "tab_a39",
             new string[] { "col_e4", "col_e6" }) 
        {
            Records = new List<Record>();
            Filter = new SelectFilter();
        }
        
        public List<Record> Records { get; set; }
        
        public void Read()
        {
            Records.Clear();
            
            
            if (Filter.Каса != null)
            {
                base.BaseFilter.Add(new Where("col_e4", Comparison.EQ, Filter.Каса.ToString(), false));
                
            }
            

            base.BaseRead();
            
            foreach (Dictionary<string, object> fieldValue in base.FieldValueList) 
            {
                Record record = new Record();
                
                record.UID = (Guid)fieldValue["uid"];
                  
                record.Каса = new Довідники.Каса_Pointer(fieldValue["col_e4"]);
                record.Сума = (fieldValue["col_e6"] != DBNull.Value) ? (decimal)fieldValue["col_e6"] : 0;
                
                Records.Add(record);
            }
            
            base.BaseClear();
        }
        
        public void Save(bool clear_all_before_save = true) 
        {
            if (Records.Count > 0)
            {
                base.BaseBeginTransaction();
                
                if (clear_all_before_save)
                    base.BaseDelete();

                foreach (Record record in Records)
                {
                    Dictionary<string, object> fieldValue = new Dictionary<string, object>();

                    fieldValue.Add("col_e4", record.Каса.ToString());
                    fieldValue.Add("col_e6", record.Сума);
                    
                    base.BaseSave(record.UID, fieldValue);
                }
                
                base.BaseCommitTransaction();
            }
        }
        
        public void Delete()
        {
            base.BaseBeginTransaction();
            base.BaseDelete();
            base.BaseCommitTransaction();
        }
        
        public SelectFilter Filter { get; set; }
        
        
        public class Record : RegisterRecord
        {
            public Record()
            {
                Каса = new Довідники.Каса_Pointer();
                Сума = 0;
                
            }
        
            public Довідники.Каса_Pointer Каса { get; set; }
            public decimal Сума { get; set; }
            
        }
    
        public class SelectFilter
        {
            public SelectFilter()
            {
                 Каса = null;
                 
            }
        
            public Довідники.Каса_Pointer Каса { get; set; }
            
        }
    }
    
    #endregion
  
}
  