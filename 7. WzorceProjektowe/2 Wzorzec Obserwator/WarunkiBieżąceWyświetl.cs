using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Wzorzec_Obserwator
{
	//	Ta klasa, odpowiadająca za wyświetlanie warunków bieżących, posiada zaimplementowany interfejs Obserwator, dzięki czemu
	//	może otrzymywać informacje o zmieniających się danych od obiektu klasy DanePogodowe.
	//	Posiada również zaimplementowany interfejs WyświetlElement, ponieważ nasze API będzie wymagało, aby
	//  każdy element odpowiedzialny za wyświetlanie informacji na ekranie posiadał taki interfejs.
	public class WarunkiBieżąceWyświetl: Obserwator, WyswietlElements
	{
		private float temperatura;
		private float wilgotność;
		private Podmiot DanePogodowe;


//		Konstruktor obiektów klasy WarunkiBieżąceWyświetl otrzymuje jako argument wywołania obiekt DanePogodowe
//		(czyli obiekt obserwowany, Podmiot), a następnie wykorzystuje go do zarejestrowania swojego obiektu jako obserwatora
		public WarunkiBieżąceWyświetl(Podmiot DanePogodowe)
		{
			this.DanePogodowe = DanePogodowe;
			DanePogodowe.zarejestrujObserwatora(this);
		}

	//		Kiedy wywoływana jest metoda aktualizacja(), zachowujemy wartości temperatury otoczenia oraz
	//		wilgotności, a następnie wywołujemy metodę wyświetl()
		public void aktualizacja(float temperatura, float wilgotność, float ciśnienie)
		{
			this.temperatura = temperatura;
			this.wilgotność = wilgotność;
			wyświetl();
		}


		//Metoda wyświetl() powoduje po prostu wyświetlenie najbardziej aktualnych odczytów temperatury i wilgotności.
		public void wyświetl()
		{
			Console.WriteLine("Warunki bieżące " + temperatura
			+ " stopni C oraz " + wilgotność + "% wilgotność");
		}


	}
}
