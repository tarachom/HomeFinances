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
using Перелічення = НоваКонфігурація_1_0.Перелічення;

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
            //Конфа.Config.ReadAllConstants();

            directoryControl1.DirectoryPointerItem = new Довідники.Каса_Pointer(Константи.ЗначенняПоЗамовчуванню.ОсновнаКаса_Const.UnigueID);
            directoryControl1.CallBack = CallBack_DirectoryControl_Open_FormCash;

            directoryControl2.DirectoryPointerItem = new Довідники.КласифікаторВитрат_Pointer(Константи.ЗначенняПоЗамовчуванню.ОсновнаСтаттяВитрат_Const.UnigueID);
            directoryControl2.CallBack = CallBack_DirectoryControl_Open_FormCostСlassifier;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            Константи.ЗначенняПоЗамовчуванню.ОсновнаКаса_Const = (Довідники.Каса_Pointer)directoryControl1.DirectoryPointerItem;
            Константи.ЗначенняПоЗамовчуванню.ОсновнаСтаттяВитрат_Const = (Довідники.КласифікаторВитрат_Pointer)directoryControl2.DirectoryPointerItem;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
