
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
  
 * Дата конфігурації: 11.03.2021 22:20:07
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
             new string[] { "col_a7", "col_a6", "col_a8", "col_a9", "col_b1", "col_a1" }) 
        {
            Назва = "";
            ДатаЗапису = DateTime.MinValue;
            Опис = "";
            ТипЗапису = 0;
            Сума = 0;
            Витрата = new Довідники.КласифікаторВитрат_Pointer();
            
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
    }
    
    ///<summary>
    ///Записи про витрати і надходження фінансів.
    ///</summary>
    class Записи_Select : DirectorySelect, IDisposable
    {
        public Записи_Select() : base(Config.Kernel, "tab_a02",
            new string[] { "col_a7", "col_a6", "col_a8", "col_a9", "col_b1", "col_a1" },
            new string[] { "Назва", "ДатаЗапису", "Опис", "ТипЗапису", "Сума", "Витрата" }) { }
        
        public const string Назва = "col_a7";
        public const string ДатаЗапису = "col_a6";
        public const string Опис = "col_a8";
        public const string ТипЗапису = "col_a9";
        public const string Сума = "col_b1";
        public const string Витрата = "col_a1";
        
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
  