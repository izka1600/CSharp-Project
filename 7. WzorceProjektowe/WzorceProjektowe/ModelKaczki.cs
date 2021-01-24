using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WzorceProjektowe
{
    public class ModelKaczki:Kaczka
    {
        public ModelKaczki()
        {
            latanieInterfejs = new NieLatam();
            kwakanieInterfejs = new Kwacz();
        }

        public override void wyświetl()
        {
            Console.WriteLine("Jestem modelem kaczki");
        }
    }
}
