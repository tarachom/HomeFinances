using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

using AccountingSoftware;

namespace HomeFinances
{
	public partial class DirectoryControl : UserControl
	{
		public DirectoryControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Зворотня функція для вибору із списку
		/// </summary>
		public Action<DirectoryPointer> CallBack { get; set; }

		private DirectoryPointer mDirectoryPointerItem;

		/// <summary>
		/// Ссилка на елемент довідника
		/// </summary>
		public DirectoryPointer DirectoryPointerItem
		{
			get { return mDirectoryPointerItem; }

			set
			{
				mDirectoryPointerItem = value;

				if (mDirectoryPointerItem != null)
					ReadPresentation();
			}
		}

		private void ReadPresentation()
        {
			textBoxControl.Text = mDirectoryPointerItem.GetType().InvokeMember(
				"GetPresentation", BindingFlags.InvokeMethod, null, mDirectoryPointerItem, new object[] { }).ToString();
		}

		private void buttonOpen_Click(object sender, EventArgs e)
		{
			if (CallBack != null)
				CallBack.Invoke(DirectoryPointerItem);
		}

        private void buttonClear_Click(object sender, EventArgs e)
        {
			DirectoryPointerItem.UnigueID.SetEmpty();
			ReadPresentation();
		}
    }
}
