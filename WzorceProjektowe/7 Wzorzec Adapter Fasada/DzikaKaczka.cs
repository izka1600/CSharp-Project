using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Wzorzec_Adapter_Fasada
{
	public class DzikaKaczka:Kaczka
	{
		public void kwacz()
		{
			Console.WriteLine("Kwacz! Kwacz!");
		}

		public void lataj()
		{
			Console.WriteLine("O rany! Latam!");
		}
	}
}
