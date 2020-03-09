using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Wzorzec_Polecenie
{
	public class PolecenieWiezaStereoWlaczCD: IPolecenie
	{
		WiezaStereo wiezaStereo;

		public PolecenieWiezaStereoWlaczCD(WiezaStereo wiezaStereo)
		{
			this.wiezaStereo = wiezaStereo;
		}

		public void wykonaj()
		{
			wiezaStereo.wlacz();
			wiezaStereo.ustawCD();
			wiezaStereo.UstawGlosnosc(11);
		}
		public void wycofaj()
		{ }

	}
}
