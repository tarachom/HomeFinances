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

		private DirectoryPointer mDirectoryPointerItem;
		public DirectoryPointer DirectoryPointerItem
		{
			get
			{
				return mDirectoryPointerItem;
			}

			set
			{
				mDirectoryPointerItem = value;

				if (mDirectoryPointerItem != null)
				{
					textBoxControl.Text = mDirectoryPointerItem.GetType().InvokeMember("GetPresentation", BindingFlags.InvokeMethod, null, mDirectoryPointerItem, new object[] { }).ToString();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FormCostСlassifier formDirectoryList = new FormCostСlassifier();
			formDirectoryList.DirectoryPointerItemSelect = DirectoryPointerItem;
			formDirectoryList.DC = this;
			formDirectoryList.Show();
		}

        private void DirectoryControl_Load(object sender, EventArgs e)
        {

        }
    }
}
