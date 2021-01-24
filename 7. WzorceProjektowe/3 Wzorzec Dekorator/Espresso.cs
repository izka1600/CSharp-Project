using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Wzorzec_Dekorator
{
    public class Espresso : Napoj
    {
    public Espresso()
        {
            opis = "Kawa Espresso";
        }
    public override double koszt()
        {
            return 1.99;
        }
    }

}
