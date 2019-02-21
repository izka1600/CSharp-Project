//using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domowe_Wydatki
{
    public class AutorzyModel
    {
        public List<List<string>>  PodajWszystkichAutorow()
        {
            PolaczenieZBaza polaczenie = new PolaczenieZBaza();
            var wynik = polaczenie.PobierzDane("select * from Autorzy");
            return wynik;
        }
    }
}
