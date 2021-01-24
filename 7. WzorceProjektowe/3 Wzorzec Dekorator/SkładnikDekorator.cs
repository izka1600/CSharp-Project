using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Wzorzec_Dekorator
{
    public abstract class SkładnikDekorator :Napoj
    {
        public abstract string pobierzOpis();
    }

}
