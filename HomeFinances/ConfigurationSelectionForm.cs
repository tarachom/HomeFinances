﻿/*
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
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using AccountingSoftware;
using Конфа = НоваКонфігурація_1_0;

namespace HomeFinances
{
	public partial class ConfigurationSelectionForm : Form
	{
		public ConfigurationSelectionForm()
		{
			InitializeComponent();

			ListConfigurationParam = new List<ConfigurationParam>();
		}

		private string PathToXML { get; set; }

		private string PathToConfXML { get; set; }

		private List<ConfigurationParam> ListConfigurationParam { get; set; }

		private void ConfigurationSelectionForm_Load(object sender, EventArgs e)
		{
			string assemblyLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;

			PathToXML = Path.GetDirectoryName(assemblyLocation) + "\\ConfigurationParam.xml";

#if DEBUG
			//Конфігурація береться із папки Configurator
			PathToConfXML = Path.GetFullPath(Path.GetDirectoryName(assemblyLocation) + "\\..\\..\\Configurator\\Confa.xml");
#else
			//Конфігурація знаходиться в тому самому каталозі що і програма
			PathToConfXML = Path.GetDirectoryName(assemblyLocation) + "\\Confa.xml";
#endif

			LoadConfigurationParamFromXML();

			Fill_listBoxConfiguration();
		}

		private void LoadConfigurationParamFromXML()
		{
			ListConfigurationParam.Clear();

			if (File.Exists(PathToXML))
			{
				XPathDocument xPathDoc = new XPathDocument(PathToXML);
				XPathNavigator xPathDocNavigator = xPathDoc.CreateNavigator();

				XPathNodeIterator ConfigurationParamNodes = xPathDocNavigator.Select("/root/Configuration");
				while (ConfigurationParamNodes.MoveNext())
				{
					ConfigurationParam ItemConfigurationParam = new ConfigurationParam();

					XPathNavigator currentNode = ConfigurationParamNodes.Current;

					ItemConfigurationParam.ConfigurationKey = currentNode.SelectSingleNode("Key").Value;
					ItemConfigurationParam.ConfigurationName = currentNode.SelectSingleNode("Name").Value;
					ItemConfigurationParam.DataBaseServer = currentNode.SelectSingleNode("Server").Value;
					ItemConfigurationParam.DataBasePort = int.Parse(currentNode.SelectSingleNode("Port").Value);
					ItemConfigurationParam.DataBaseLogin = currentNode.SelectSingleNode("Login").Value;
					ItemConfigurationParam.DataBasePassword = currentNode.SelectSingleNode("Password").Value;
					ItemConfigurationParam.DataBaseBaseName = currentNode.SelectSingleNode("BaseName").Value;

					ListConfigurationParam.Add(ItemConfigurationParam);
				}
			}
		}

		private void SaveConfigurationParamFromXML()
		{
			XmlDocument xmlConfParamDocument = new XmlDocument();
			xmlConfParamDocument.AppendChild(xmlConfParamDocument.CreateXmlDeclaration("1.0", "utf-8", ""));

			XmlElement rootNode = xmlConfParamDocument.CreateElement("root");
			xmlConfParamDocument.AppendChild(rootNode);

			foreach (ConfigurationParam ItemConfigurationParam in ListConfigurationParam)
			{
				XmlElement configurationNode = xmlConfParamDocument.CreateElement("Configuration");
				rootNode.AppendChild(configurationNode);

				XmlElement nodeKey = xmlConfParamDocument.CreateElement("Key");
				nodeKey.InnerText = ItemConfigurationParam.ConfigurationKey;
				configurationNode.AppendChild(nodeKey);

				XmlElement nodeName = xmlConfParamDocument.CreateElement("Name");
				nodeName.InnerText = ItemConfigurationParam.ConfigurationName;
				configurationNode.AppendChild(nodeName);

				XmlElement nodeServer = xmlConfParamDocument.CreateElement("Server");
				nodeServer.InnerText = ItemConfigurationParam.DataBaseServer;
				configurationNode.AppendChild(nodeServer);

				XmlElement nodePort = xmlConfParamDocument.CreateElement("Port");
				nodePort.InnerText = ItemConfigurationParam.DataBasePort.ToString();
				configurationNode.AppendChild(nodePort);

				XmlElement nodeLogin = xmlConfParamDocument.CreateElement("Login");
				nodeLogin.InnerText = ItemConfigurationParam.DataBaseLogin;
				configurationNode.AppendChild(nodeLogin);

				XmlElement nodePassword = xmlConfParamDocument.CreateElement("Password");
				nodePassword.InnerText = ItemConfigurationParam.DataBasePassword;
				configurationNode.AppendChild(nodePassword);

				XmlElement nodeBaseName = xmlConfParamDocument.CreateElement("BaseName");
				nodeBaseName.InnerText = ItemConfigurationParam.DataBaseBaseName;
				configurationNode.AppendChild(nodeBaseName);
			}

			xmlConfParamDocument.Save(PathToXML);
		}

		private void Fill_listBoxConfiguration()
		{
			listBoxConfiguration.Items.Clear();

			foreach (ConfigurationParam ItemConfigurationParam in ListConfigurationParam)
				listBoxConfiguration.Items.Add(ItemConfigurationParam);

			if (listBoxConfiguration.Items.Count > 0)
				listBoxConfiguration.SelectedIndex = 0;
		}

		#region CallBack

		void CallBack_Update(ConfigurationParam itemConfigurationParam, bool isNew)
		{
			if (isNew)
			{
				ListConfigurationParam.Add(itemConfigurationParam);
				SaveConfigurationParamFromXML();
			}
			else
			{
				foreach (ConfigurationParam ItemConfigurationParam in ListConfigurationParam)
				{
					if (ItemConfigurationParam.ConfigurationKey == itemConfigurationParam.ConfigurationKey)
					{
						ItemConfigurationParam.ConfigurationName = itemConfigurationParam.ConfigurationName;
						ItemConfigurationParam.DataBaseServer = itemConfigurationParam.DataBaseServer;
						ItemConfigurationParam.DataBaseLogin = itemConfigurationParam.DataBaseLogin;
						ItemConfigurationParam.DataBasePassword = itemConfigurationParam.DataBasePassword;
						ItemConfigurationParam.DataBaseBaseName = itemConfigurationParam.DataBaseBaseName;
						ItemConfigurationParam.DataBasePort = itemConfigurationParam.DataBasePort;

						SaveConfigurationParamFromXML();
						break;
					}
				}
			}

			LoadConfigurationParamFromXML();
			Fill_listBoxConfiguration();
		}

		#endregion

		private void listBoxConfiguration_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			if (listBoxConfiguration.SelectedItem != null)
			{
				ConfigurationParam itemConfigurationParam = (ConfigurationParam)listBoxConfiguration.SelectedItem;

				ConfigurationSelectionParam configurationSelectionParamForm = new ConfigurationSelectionParam();
				configurationSelectionParamForm.IsNew = false;
				configurationSelectionParamForm.ItemConfigurationParam = itemConfigurationParam;
				configurationSelectionParamForm.CallBack_Update = CallBack_Update;
				configurationSelectionParamForm.ShowDialog();
			}
		}

		private void buttonAddConf_Click(object sender, EventArgs e)
		{
			ConfigurationSelectionParam configurationSelectionParamForm = new ConfigurationSelectionParam();
			configurationSelectionParamForm.IsNew = true;
			configurationSelectionParamForm.CallBack_Update = CallBack_Update;
			configurationSelectionParamForm.ShowDialog();
		}

		private void buttonDelete_Click(object sender, EventArgs e)
		{
			if (listBoxConfiguration.SelectedItem != null)
			{
				if (MessageBox.Show("Видалити?", "Видалити?", MessageBoxButtons.YesNo) == DialogResult.Yes)
				{
					ConfigurationParam itemConfigurationParam = (ConfigurationParam)listBoxConfiguration.SelectedItem;

					foreach (ConfigurationParam ItemConfigurationParam in ListConfigurationParam)
					{
						if (ItemConfigurationParam.ConfigurationKey == itemConfigurationParam.ConfigurationKey)
						{
							ListConfigurationParam.Remove(ItemConfigurationParam);

							SaveConfigurationParamFromXML();
							Fill_listBoxConfiguration();

							break;
						}
					}
				}
			}
		}

		private void buttonOpenConf_Click(object sender, EventArgs e)
		{
			if (listBoxConfiguration.SelectedItem != null)
			{
				ConfigurationParam itemConfigurationParam = (ConfigurationParam)listBoxConfiguration.SelectedItem;

				Exception exception = null;

				Конфа.Config.Kernel = new Kernel();

				//Підключення до бази даних
				bool flag = Конфа.Config.Kernel.Open2(
						PathToConfXML,
						itemConfigurationParam.DataBaseServer,
						itemConfigurationParam.DataBaseLogin,
						itemConfigurationParam.DataBasePassword,
						itemConfigurationParam.DataBasePort,
						itemConfigurationParam.DataBaseBaseName, out exception);

				if (exception != null)
				{
					MessageBox.Show(exception.Message);
					return;
				}

				Конфа.Config.ReadAllConstants();

				FormRecordFinance formRecordFinance = new FormRecordFinance();
				formRecordFinance.Show();

				this.DialogResult = DialogResult.OK;
				this.Hide();
			}
		}

		private void buttonCopy_Click(object sender, EventArgs e)
		{
			if (listBoxConfiguration.SelectedItem != null)
			{
				ConfigurationParam itemConfigurationParam = (ConfigurationParam)listBoxConfiguration.SelectedItem;

				ListConfigurationParam.Add(itemConfigurationParam.Clone());

				SaveConfigurationParamFromXML();
				Fill_listBoxConfiguration();
			}
		}
	}
}
