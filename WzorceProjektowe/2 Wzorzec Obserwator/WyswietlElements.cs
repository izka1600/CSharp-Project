using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Wzorzec_Obserwator
{
	public interface WyswietlElements
	{
//		Interfejs WyświetlElement posiada tylko jedną metodę,
//		wyświetl(), którą będziemy wywoływać w sytuacji,
//		kiedy niezbędne będzie wyświetlanie danego elementu
//		na ekranie.
		void wyświetl();
	}
}
