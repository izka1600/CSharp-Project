using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WzorceProjektowe
{
    public abstract class Kaczka
    {

        public LatanieInterfejs latanieInterfejs;
        public KwakanieInterfejs kwakanieInterfejs;

        public Kaczka()
        {
        }
        public void ustawLatanieInterfejs(LatanieInterfejs li) { latanieInterfejs = li; }
        public void ustawKwakanieInterfejs(KwakanieInterfejs ki) { kwakanieInterfejs = ki; }


        public abstract void wyświetl();

        public void wykonajLeć()
        {
            latanieInterfejs.leć();
        }

        public void WykonajKwacz()
        {
            kwakanieInterfejs.kwacz();
        }

        public void pływaj()
        {
            Console.WriteLine("Wszystkie kaczki pływają, nawet te sztuczne!");
        }

    }
}
