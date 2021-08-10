using System;

namespace HomeFinances
{
	public class ConfigurationParam
	{
		public ConfigurationParam()
		{
			DataBaseServer = "localhost";
			DataBaseLogin = "postgres";
			DataBasePort = 5432;
		}

		public string ConfigurationKey { get; set; }

		public string ConfigurationName { get; set; }

		public string DataBaseServer { get; set; }

		public int DataBasePort { get; set; }

		public string DataBaseLogin { get; set; }

		public string DataBasePassword { get; set; }

		public string DataBaseBaseName { get; set; }

		public override string ToString()
		{
			return String.IsNullOrWhiteSpace(ConfigurationName) ? "<>" : ConfigurationName;
		}

		public ConfigurationParam Clone()
        {
			ConfigurationParam configurationParam = new ConfigurationParam();
			configurationParam.ConfigurationKey = Guid.NewGuid().ToString();
			configurationParam.ConfigurationName = "Копія - " + ConfigurationName;
			configurationParam.DataBaseServer = DataBaseServer;
			configurationParam.DataBaseLogin = DataBaseLogin;
			configurationParam.DataBasePassword = DataBasePassword;
			configurationParam.DataBaseBaseName = DataBaseBaseName;
			configurationParam.DataBasePort = DataBasePort;
			
			return configurationParam;
		}
	}
}
