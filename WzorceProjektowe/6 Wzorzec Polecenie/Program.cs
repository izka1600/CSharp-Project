using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Wzorzec_Polecenie
{
	class Program
	{
		static void Main(string[] args)
		{
			//MiniPilot pilot = new MiniPilot();
			//Swiatlo swiatlo = new Swiatlo();
			//PolecenieWlaczSwiatlo wlaczSwiatlo = new PolecenieWlaczSwiatlo(swiatlo);
			//pilot.UstawPolecenie(wlaczSwiatlo);
			//pilot.przyciskZostalNacisniety();

			SuperPilot pilot = new SuperPilot();

			Swiatlo jadalniaSwiatlo = new Swiatlo("Jadalnia");
			Swiatlo kuchniaSwiatlo = new Swiatlo("Kuchnia");
			WiezaStereo wiezaStereo = new WiezaStereo("Jadalnia");

			PolecenieWlaczSwiatlo jadalniaWlaczSwiatlo = new PolecenieWlaczSwiatlo(jadalniaSwiatlo);
			PolecenieWylaczSwiatlo jadalniaWylaczSwiatlo = new PolecenieWylaczSwiatlo(jadalniaSwiatlo);


			PolecenieWiezaStereoWlaczCD wiezaStereoWlaczCD = new PolecenieWiezaStereoWlaczCD(wiezaStereo);

			pilot.UstawPolecenie(0, jadalniaWlaczSwiatlo, jadalniaWylaczSwiatlo);
			Console.WriteLine(pilot);
			pilot.wcisnietoPrzyciskWlacz(0);
			pilot.wcisnietoPrzyciskWylacz(0);
			Console.WriteLine(pilot);
			pilot.wcisnietoPrzyciskWycofaj();
			pilot.wcisnietoPrzyciskWylacz(0);
			pilot.wcisnietoPrzyciskWlacz(0);
			Console.WriteLine(pilot);
			pilot.wcisnietoPrzyciskWycofaj();


			Console.ReadKey();
		}
	}
}
