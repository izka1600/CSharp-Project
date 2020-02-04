using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WzorceProjektowe
{
    public class DzikaKaczka: Kaczka
    {
        public DzikaKaczka()
        {
            kwakanieInterfejs = new Kwacz();
            latanieInterfejs = new LatamBoMamSkrzydła();
        }

        public override void wyświetl()
        {
            Console.WriteLine("Jestem prawdziwą Dziką Kaczką");
        }
    }
}
