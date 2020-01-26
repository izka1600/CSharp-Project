using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace DBClassMapper
{
	public static class DBConnection
	{
		public static string Cnn(string name)
		{
			return ConfigurationManager.ConnectionStrings[name].ConnectionString;
		}
	}
}
