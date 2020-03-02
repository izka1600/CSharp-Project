using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Wzorzec_Dekorator
{
    public class StarCafeSpecial : Napoj
    {
        public StarCafeSpecial() { opis = "Kawa Star Cafe Special"; }
        public override double koszt() { return 0.89; }

    }
}
