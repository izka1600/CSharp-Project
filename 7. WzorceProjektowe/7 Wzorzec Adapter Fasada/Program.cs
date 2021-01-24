using System;
using System.Collections.Generic;
using System.Linq;
 using System.Threading.Tasks;

namespace _7_Wzorzec_Adapter_Fasada
{
	class Program
	{
		static void Main(string[] args)
		{
			DzikaKaczka kaczka = new DzikaKaczka();
			DzikiIndyk indyk = new DzikiIndyk();
			Kaczka indykAdapter = new IndykAdapter(indyk);

			Console.WriteLine("Indyk powiada tak: ");
			indyk.gulgocz();
			indyk.lataj();
			Console.WriteLine();

			Console.WriteLine("Kaczka powiada tak: ");
			testujKaczke(kaczka);

			Console.WriteLine("A Indyk powiada tak...");
			testujKaczke(indykAdapter);
			Console.ReadKey();


		}

		static void testujKaczke(Kaczka kaczka)
		{
			kaczka.kwacz();
			kaczka.lataj();
		}
	}
}
