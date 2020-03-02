using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Wzorzec_Dekorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Napoj napoj = new Espresso();
            Console.WriteLine(napoj.pobierzOpis() + " " + napoj.koszt() + " zł.");

            Napoj napoj2 = new StarCafeSpecial();
            napoj2 = new Czekolada(napoj2);
            napoj2 = new Czekolada(napoj2);
            Console.WriteLine(napoj2.pobierzOpis() + " " + napoj2.koszt() + " zł.");
            Console.ReadKey();
        }
    }
}
