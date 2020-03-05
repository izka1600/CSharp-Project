using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_Wzorzec_Polecenie
{
	public class SuperPilot
	{
		IPolecenie[] poleceniaWlacz;
		IPolecenie[] poleceniaWylacz;
		IPolecenie polecenieWycofaj;


		public SuperPilot()
		{
			poleceniaWlacz = new IPolecenie[7];
			poleceniaWylacz = new IPolecenie[7];

			IPolecenie brakPolecenia = new BrakPolecenia();

			for (int i = 0; i < 7; i++)
			{
				poleceniaWylacz[i] = brakPolecenia;
				poleceniaWlacz[i] = brakPolecenia;
			}
			polecenieWycofaj = brakPolecenia;

		}

		public void UstawPolecenie(int slot, IPolecenie polecenieWlacz, IPolecenie polecenieWylacz)
		{
			poleceniaWlacz[slot] = polecenieWlacz;
			poleceniaWylacz[slot] = polecenieWylacz;

		}

		public void wcisnietoPrzyciskWlacz(int slot)
		{
			poleceniaWlacz[slot].wykonaj();
			polecenieWycofaj = poleceniaWlacz[slot];
		}

		public void wcisnietoPrzyciskWylacz(int slot)
		{
			poleceniaWylacz[slot].wykonaj();
			polecenieWycofaj = poleceniaWylacz[slot];
		}

		public void wcisnietoPrzyciskWycofaj()
		{
			polecenieWycofaj.wycofaj();
		}
		public override String ToString()
		{
			string x = "";
			for (int i = 0; i < poleceniaWlacz.Length; i++)
			{
				x = $"[slot {i} {poleceniaWlacz[i].ToString()} {poleceniaWylacz[i].ToString()}";
			}
			Console.WriteLine(x);
			return x;
		}
	}
}
