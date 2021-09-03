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

using System.IO;

using AccountingSoftware;
using Конфа = HomeFinances_1_0;
using Константи = HomeFinances_1_0.Константи;
using Довідники = HomeFinances_1_0.Довідники;
using Перелічення = HomeFinances_1_0.Перелічення;

namespace HomeFinances
{
    public partial class FormConstants : Form
    {
        public FormConstants()
        {
            InitializeComponent();
        }

        /// <summary>
		/// Зворотня функція для вибору із списку
		/// </summary>
		/// <param name="directoryPointerItem"></param>
		public void CallBack_DirectoryControl_Open_FormCash(DirectoryPointer directoryPointerItem)
        {
            FormCash formCash = new FormCash();
            formCash.DirectoryPointerItem = directoryPointerItem;
            formCash.DirectoryControlItem = directoryControl1;
            formCash.ShowDialog();
        }

        public void CallBack_DirectoryControl_Open_FormCostСlassifier(DirectoryPointer directoryPointerItem)
        {
            FormCostСlassifier formCostСlassifier = new FormCostСlassifier();
            formCostСlassifier.DirectoryPointerItem = directoryPointerItem;
            formCostСlassifier.DirectoryControlItem = directoryControl2;
            formCostСlassifier.ShowDialog();
        }

        private void FormConstats_Load(object sender, EventArgs e)
        {
            directoryControl1.DirectoryPointerItem = new Довідники.Каса_Pointer(Константи.ЗначенняПоЗамовчуванню.ОсновнаКаса_Const.UnigueID);
            directoryControl1.CallBack = CallBack_DirectoryControl_Open_FormCash;

            directoryControl2.DirectoryPointerItem = new Довідники.КласифікаторВитрат_Pointer(Константи.ЗначенняПоЗамовчуванню.ОсновнаСтаттяВитрат_Const.UnigueID);
            directoryControl2.CallBack = CallBack_DirectoryControl_Open_FormCostСlassifier;

            textBoxCatalogFiles.Text = Константи.Основний.КаталогДляФайлів_Const;
            textBoxExportFolder.Text = Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляВигрузкиДаних_Const;
            textBoxImportFolder.Text = Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляЗагрузкиДаних_Const;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Константи.ЗначенняПоЗамовчуванню.ОсновнаКаса_Const = (Довідники.Каса_Pointer)directoryControl1.DirectoryPointerItem;
            Константи.ЗначенняПоЗамовчуванню.ОсновнаСтаттяВитрат_Const = (Довідники.КласифікаторВитрат_Pointer)directoryControl2.DirectoryPointerItem;
            Константи.Основний.КаталогДляФайлів_Const = textBoxCatalogFiles.Text;
            Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляВигрузкиДаних_Const = textBoxExportFolder.Text;
            Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляЗагрузкиДаних_Const = textBoxImportFolder.Text;

            this.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonExportFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляВигрузкиДаних_Const;
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;
            
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                textBoxExportFolder.Text = folderBrowserDialog.SelectedPath;
            }

        }

        private void buttonImportFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.SelectedPath = Константи.ВигрузкаТаЗагрузкаДаних.ПапкаДляЗагрузкиДаних_Const;
            folderBrowserDialog.ShowNewFolderButton = true;
            folderBrowserDialog.RootFolder = Environment.SpecialFolder.Desktop;

            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                textBoxImportFolder.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }
}
