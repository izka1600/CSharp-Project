using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Wzorzec_Polecenie
{
	public class PolecenieWylaczSwiatlo:IPolecenie
	{
		Swiatlo swiatlo;

		public PolecenieWylaczSwiatlo(Swiatlo swiatlo)
		{
			this.swiatlo = swiatlo;
		}

		public void wykonaj()
		{
			swiatlo.wylacz();
		}
	}
}
