using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_Wzorzec_Dekorator
{
    public class Czekolada : SkładnikDekorator
    {
        Napoj napoj;

        public Czekolada(Napoj napoj) { this.napoj = napoj; opis = napoj.pobierzOpis(); }

        public override string pobierzOpis()
        {
            return opis + ", Czekolada";
        }

        public override double koszt()
        {
            return napoj.koszt() + 0.20;
        }
    }
}


//Mamy zamiar utworzyć obiekt klasy Czekolada, który będzie się odwoływał do obiektu klasy Napój, 
//wykorzystując: 
//    (1) Zmienną obiektową przechowującą dekorowany obiekt. 
//    (2) Specyficzny sposób ustawiania tej zmiennej obiektowej na dekorowany obiekt.
//    Tutaj mamy zamiar przekazywać obiekt reprezentujący dekorowany napój do konstruktora dekoratora.

//Chcemy, aby opis obejmował nie tylko nazwę napoju — przykładowo „Mocno Palona” — 
//ale również nazwy każdego dodatku użytego do dekorowania, przykładowo „Mocno Palona, Czekolada”. 
//Z tego względu najpierw delegujemy wykonanie metody pobierzOpis() do dekorowanego obiektu(co pozwala 
//na pobranie jego opisu), a następnie dołączamy opis naszego dekoratora, „Czekolada”, do uzyskanego wyniku.


