using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Wzorzec_Polecenie
{
	public interface IPolecenie
	{
		void wykonaj();
		void wycofaj();
	}
}
