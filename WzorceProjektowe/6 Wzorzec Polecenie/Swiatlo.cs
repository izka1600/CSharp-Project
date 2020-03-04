using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Wzorzec_Polecenie
{
	public class Swiatlo
	{
		private string v;

		public Swiatlo(string v)
		{
			this.v = v;
		}

		public void wlacz()
		{
			Console.WriteLine("Wlaczono swiatlo");
		}

		internal void wylacz()
		{
			Console.WriteLine("Wylaczono swiatlo");
		}
	}
}
