using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Wzorzec_Obserwator
{
	public class DanePogodowe : Podmiot
	{
		private List<Obserwator> obserwatorzy;
		private float temperatura;
		private float wilgotność;
		private float ciśnienie;
		public DanePogodowe()
		{
			obserwatorzy = new List<Obserwator>();
		}

		//Kiedy dany obserwator się rejestruje, dopisujemy go po prostu na końcu listy
		public void zarejestrujObserwatora(Obserwator o)
		{
			obserwatorzy.Add(o);
		}

		public void usuńObserwatora(Obserwator o)
		{
			//Analogicznie, jeżeli dany obserwator chce się wyrejestrować, po prostu usuwamy go z listy.

			int i = obserwatorzy.IndexOf(o);
			if (i >= 0)
			{
				obserwatorzy.RemoveAt(i);
			}
		}


		//	A tutaj mamy coś fajnego: to jest właśnie miejsce, w którym mówimy obiektom obserwującym
	    //	(obserwatorom), że zmienił się stan obiektu obserwowanego.Ponieważ wszystkie obiekty
		//	obserwujące posiadają interfejs Obserwator, wiemy, że posiadają także zaimplementowaną
		//	metodę aktualizacja() i w związku z tym wiemy, jak możemy je powiadomić.
		public void powiadomObserwatorów()
		{
			for (int i = 0; i < obserwatorzy.Count(); i++)
			{
				Obserwator Obs = (Obserwator)obserwatorzy[i];
				Obs.aktualizacja(temperatura, wilgotność, ciśnienie);
			}
		}

		//		Obserwatorów będziemy powiadamiali po otrzymaniu nowych wartości
		//		pomiarów ze stacji meteorologicznej
		public void odczytyZmiana()
		{
			powiadomObserwatorów();
		}

		public void ustawOdczyty(float temperatura, float wilgotność, float ciśnienie)
		{
			this.temperatura = temperatura;
			this.wilgotność = wilgotność;
			this.ciśnienie = ciśnienie;
			odczytyZmiana();
		}

		// tutaj zamieść inne metody klasy DanePogodowe

	}
}
