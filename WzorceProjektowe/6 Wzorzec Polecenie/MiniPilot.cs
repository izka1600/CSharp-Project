using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Wzorzec_Polecenie
{
	public class MiniPilot
	{
		IPolecenie slot;
		public MiniPilot() { }

		public void UstawPolecenie(IPolecenie polecenie)
		{
			slot = polecenie;
		}

		public void przyciskZostalNacisniety()
		{
			slot.wykonaj();
		}
	}
}
