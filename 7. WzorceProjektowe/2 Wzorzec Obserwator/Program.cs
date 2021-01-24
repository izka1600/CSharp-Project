using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Wzorzec_Obserwator
{
	class Program
	{
		static void Main(string[] args)
		{
			DanePogodowe danePogodowe = new DanePogodowe();

			WarunkiBieżąceWyświetl warunkiBieżąceWyświetl =
			new WarunkiBieżąceWyświetl(danePogodowe);
			//StatystykaWyświetl statystykaWyświetl = new StatystykaWyświetl(danePogodowe);
			//PrognozaWyświetl prognozaWyświetl = new PrognozaWyświetl(danePogodowe);
			danePogodowe.ustawOdczyty(26, 65, 1013.1f);
			danePogodowe.ustawOdczyty(27, 70, 997.0f);
			danePogodowe.ustawOdczyty(25, 90, 997.0f);
			Console.ReadKey();
		}
	}
}
