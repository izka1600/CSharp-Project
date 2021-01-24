using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_Wzorzec_Adapter_Fasada
{
	public class IndykAdapter:Kaczka
	{
		Indyk indyk;
		public IndykAdapter(Indyk indyk)
		{
			this.indyk = indyk;
		}
		public void kwacz()
		{
			indyk.gulgocz();
		}
		public void lataj()
		{
			for (int i = 0; i < 5; i++)
			{
				indyk.lataj();
			}
		}
	}
}
