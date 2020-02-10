using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Wzorzec_Obserwator
{
	public interface Podmiot
	{
		//Ta metoda jest wywoływana w celu powiadomienia
		//wszystkich obserwatorów o tym, że stan obiektu
		//obserwowanego zmienił się.
		void zarejestrujObserwatora(Obserwator o);
		void usuńObserwatora(Obserwator o);

		//Metody pobierają jako argument obiekt
		//typu Obserwator, czyli konkretnie obiekt,
		//który ma zostać zarejestrowany na liście
		//zarejestrowanych bądź usunięty z tej listy
		void powiadomObserwatorów();
	}
}
