using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domowe_Wydatki
{
    public class PodkategorieModel
    {
        public List<List<string>>  PodajWszystkiePodkategorie(int id)
        {
            PolaczenieZBaza polaczenie = new PolaczenieZBaza();
            string query = string.Format("select * from Podkategorie where IdKategorii={0}", id);
            var wynik = polaczenie.PobierzDane(query);
            return wynik;
        }
    }
}
