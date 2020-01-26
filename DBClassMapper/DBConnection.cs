using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

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
