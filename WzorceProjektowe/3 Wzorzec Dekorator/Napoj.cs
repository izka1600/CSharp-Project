using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Wzorzec_Dekorator
{
    public abstract class Napoj
    {
        public string opis = "Napój nieznany";

        public string pobierzOpis() { return opis; }

        public abstract double koszt();
    }
}
