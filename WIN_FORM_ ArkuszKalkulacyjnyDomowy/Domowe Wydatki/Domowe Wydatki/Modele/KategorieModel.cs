using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domowe_Wydatki
{
    public class KategorieModel
    {
        public List<List<string>>  PodajWszystkieKategorie()
        {
            PolaczenieZBaza polaczenie = new PolaczenieZBaza();
            var wynik = polaczenie.PobierzDane("select * from Kategorie");
            return wynik;
        }
    }
}
