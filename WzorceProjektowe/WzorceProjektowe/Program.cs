using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WzorceProjektowe
{
    class Program
    {
        static void Main(string[] args)
        {
            Kaczka dzika = new DzikaKaczka();
            dzika.WykonajKwacz();
            dzika.wykonajLeć();

            Kaczka model = new ModelKaczki();
            model.wykonajLeć();
            model.ustawLatanieInterfejs(new LotzNapędemRakietowym());
            model.wykonajLeć();

            Console.ReadKey();
        }
    }
}
