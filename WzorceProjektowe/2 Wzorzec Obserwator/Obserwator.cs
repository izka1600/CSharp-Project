using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Wzorzec_Obserwator
{
	public interface Obserwator
	{
		void aktualizacja(float temp, float wilgotność, float ciśnienie);
		//Te zmienne odpowiadają wartościom stanu, jakie obiekty obserwujące otrzymują
		//od obiektu obserwowanego, kiedy zmieniają się odczyty parametrów pogody
	}
}
