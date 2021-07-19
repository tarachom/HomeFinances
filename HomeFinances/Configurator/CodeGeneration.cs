
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
  
 * Дата конфігурації: 19.07.2021 17:05:35
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
        
    }
}

namespace НоваКонфігурація_1_0.Константи
{
    
    static class Основний
    {
        public static void ReadAll()
        {
            
            Dictionary<string, object> fieldValue = new Dictionary<string, object>();
            bool IsSelect = Config.Kernel.DataBase.SelectAllConstants("tab_constants",
                 new string[] {  }, fieldValue);
            
            if (IsSelect)
            {
                
            }
        }
        
             
    }
    
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
             new string[] { "col_a7", "col_a6", "col_a8", "col_a9", "col_b1", "col_a1", "col_a2" }) 
        {
            Назва = "";
            ДатаЗапису = DateTime.MinValue;
            Опис = "";
            ТипЗапису = 0;
            Сума = 0;
            Витрата = new Довідники.КласифікаторВитрат_Pointer();
            Каса = new Довідники.Каса_Pointer();
            
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
            
            BaseSave();
        }

        public string Serialize()
        {
            return 
            "<Записи>" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<ДатаЗапису>" + ДатаЗапису.ToString() + "</ДатаЗапису>"  +
               "<Опис>" + "<![CDATA[" + Опис + "]]>" + "</Опис>"  +
               "<ТипЗапису>" + ((int)ТипЗапису).ToString() + "</ТипЗапису>"  +
               "<Сума>" + Сума.ToString() + "</Сума>"  +
               "<Витрата>" + Витрата.ToString() + "</Витрата>"  +
               "<Каса>" + Каса.ToString() + "</Каса>"  +
               "</Записи>";
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
    }
    
    ///<summary>
    ///Записи про витрати і надходження фінансів.
    ///</summary>
    class Записи_Select : DirectorySelect, IDisposable
    {
        public Записи_Select() : base(Config.Kernel, "tab_a02",
            new string[] { "col_a7", "col_a6", "col_a8", "col_a9", "col_b1", "col_a1", "col_a2" },
            new string[] { "Назва", "ДатаЗапису", "Опис", "ТипЗапису", "Сума", "Витрата", "Каса" }) { }
        
        public const string Назва = "col_a7";
        public const string ДатаЗапису = "col_a6";
        public const string Опис = "col_a8";
        public const string ТипЗапису = "col_a9";
        public const string Сума = "col_b1";
        public const string Витрата = "col_a1";
        public const string Каса = "col_a2";
        
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
    
      ///<summary>
    ///Список.
    ///</summary>
    class Записи_Список_View : DirectoryView
    {
        public Записи_Список_View() : base(Config.Kernel, "tab_a02", 
             new string[] { "col_a4", "col_a5" },
             new string[] { "Назва", "Код" },
             new string[] { "", "" },
             "Довідник_Записи_Список")
        {
            
        }
        
    }
      
    
    #endregion
    
    #region DIRECTORY "КласифікаторВитрат"
    
    class КласифікаторВитрат_Objest : DirectoryObject
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

        public string Serialize()
        {
            return 
            "<КласифікаторВитрат>" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "</КласифікаторВитрат>";
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
        
    }
    
    
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
			    new string[] {  }
			);
        }
    }
    
    
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
    
      ///<summary>
    ///Список.
    ///</summary>
    class КласифікаторВитрат_Список_View : DirectoryView
    {
        public КласифікаторВитрат_Список_View() : base(Config.Kernel, "tab_a01", 
             new string[] { "col_a1", "col_a2" },
             new string[] { "Назва", "Код" },
             new string[] { "string", "string" },
             "Довідник_КласифікаторВитрат_Список")
        {
            
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
             new string[] { "col_a1", "col_a4", "col_a3" }) 
        {
            Назва = "";
            Опис = "";
            Дата = DateTime.MinValue;
            
        }
        
        public bool Read(UnigueID uid)
        {
            if (BaseRead(uid))
            {
                Назва = base.FieldValue["col_a1"].ToString();
                Опис = base.FieldValue["col_a4"].ToString();
                Дата = (base.FieldValue["col_a3"] != DBNull.Value) ? DateTime.Parse(base.FieldValue["col_a3"].ToString()) : DateTime.MinValue;
                
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
            
            BaseSave();
        }

        public string Serialize()
        {
            return 
            "<Записник>" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Опис>" + "<![CDATA[" + Опис + "]]>" + "</Опис>"  +
               "<Дата>" + Дата.ToString() + "</Дата>"  +
               "</Записник>";
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
    }
    
    ///<summary>
    ///Записник інформації.
    ///</summary>
    class Записник_Select : DirectorySelect, IDisposable
    {
        public Записник_Select() : base(Config.Kernel, "tab_a03",
            new string[] { "col_a1", "col_a4", "col_a3" },
            new string[] { "Назва", "Опис", "Дата" }) { }
        
        public const string Назва = "col_a1";
        public const string Опис = "col_a4";
        public const string Дата = "col_a3";
        
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
    
      ///<summary>
    ///Список.
    ///</summary>
    class Записник_Список_View : DirectoryView
    {
        public Записник_Список_View() : base(Config.Kernel, "tab_a03", 
             new string[] { "col_a1", "col_a2" },
             new string[] { "Назва", "Код" },
             new string[] { "string", "" },
             "Довідник_Записник_Список")
        {
            
        }
        
    }
      
    
    #endregion
    
    #region DIRECTORY "Користувач"
    
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

        public string Serialize()
        {
            return 
            "<Користувач>" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "</Користувач>";
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
    }
    
    
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
      ///<summary>
    ///Список.
    ///</summary>
    class Користувач_Список_View : DirectoryView
    {
        public Користувач_Список_View() : base(Config.Kernel, "tab_a04", 
             new string[] { "col_a1", "col_a2" },
             new string[] { "Назва", "Код" },
             new string[] { "string", "string" },
             "Довідник_Користувач_Список")
        {
            
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

        public string Serialize()
        {
            return 
            "<Каса>" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Валюта>" + Валюта.ToString() + "</Валюта>"  +
               "<ТипВалюти>" + ((int)ТипВалюти).ToString() + "</ТипВалюти>"  +
               "</Каса>";
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
			    new string[] {  }
			);
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
    
      ///<summary>
    ///Список.
    ///</summary>
    class Каса_Список_View : DirectoryView
    {
        public Каса_Список_View() : base(Config.Kernel, "tab_a05", 
             new string[] { "col_a1", "col_a2" },
             new string[] { "Назва", "Код" },
             new string[] { "string", "pointer" },
             "Довідник_Каса_Список")
        {
            
        }
        
    }
      
    
    #endregion
    
    #region DIRECTORY "Валюта"
    
    class Валюта_Objest : DirectoryObject
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

        public string Serialize()
        {
            return 
            "<Валюта>" +
               "<uid>" + base.UnigueID.ToString() + "</uid>" +
               "<Назва>" + "<![CDATA[" + Назва + "]]>" + "</Назва>"  +
               "<Код>" + "<![CDATA[" + Код + "]]>" + "</Код>"  +
               "</Валюта>";
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
        
    }
    
    
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
			    new string[] {  }
			);
        }
    }
    
    
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
    
      ///<summary>
    ///Список.
    ///</summary>
    class Валюта_Список_View : DirectoryView
    {
        public Валюта_Список_View() : base(Config.Kernel, "tab_a07", 
             new string[] { "col_a3", "col_a4" },
             new string[] { "Назва", "Код" },
             new string[] { "string", "string" },
             "Довідник_Валюта_Список")
        {
            
        }
        
    }
      
    
    #endregion
    
}

namespace НоваКонфігурація_1_0.Перелічення
{
    ///<summary>
    ///Тип запису - це поступлення фінансів або витрати фінансів.
    ///</summary>
    public enum ТипЗапису
    {
         Витрати = 2,
         Поступлення = 3,
         Благодійність = 4
    }
    
    ///<summary>
    ///Нал, безнал.
    ///</summary>
    public enum ТипВалюти
    {
         Готівка = 1,
         Карточка = 2
    }
    
    
}

namespace НоваКонфігурація_1_0.Документи
{
    
}

namespace НоваКонфігурація_1_0.Журнали
{

}

namespace НоваКонфігурація_1_0.РегістриВідомостей
{
    
}

namespace НоваКонфігурація_1_0.РегістриНакопичення
{
    
}
  