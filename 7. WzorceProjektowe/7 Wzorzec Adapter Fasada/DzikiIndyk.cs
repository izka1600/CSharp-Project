using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Wzorzec_Adapter_Fasada
{
	public class DzikiIndyk:Indyk
	{
		public void gulgocz()
		{
			Console.WriteLine("Gulgulgul!");
		}

		public void lataj()
		{
			Console.WriteLine("O rany! Latam, ale tylko na krótkich dystansach");
		}
	}
}
