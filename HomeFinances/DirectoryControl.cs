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

		private DirectoryPointer mDP;
		public DirectoryPointer DP 
		{
			get
			{
				return mDP;
			}

			set
			{
				mDP = value;

				if (mDP != null)
				{
					textBoxControl.Text = mDP.GetType().InvokeMember("GetPresentation", BindingFlags.InvokeMethod, null, mDP, new object[] { }).ToString();
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			
		}
	}
}
