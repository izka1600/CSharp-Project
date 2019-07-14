using System;
using System.Collections.Generic;

namespace ArkuszDataBase.Models
{
    public partial class Uzytkownik
    {
        public Uzytkownik()
        {
            Plan = new HashSet<Plan>();
            Transakcje = new HashSet<Transakcje>();
        }

        public int UzytId { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Nick { get; set; }
        public string EMail { get; set; }
        public DateTime? DataDodania { get; set; }
        public DateTime? OstatnieLogowanie { get; set; }
		public DateTime? DataUsuniecia { get; set; }
		public virtual ICollection<Plan> Plan { get; set; }
        public virtual ICollection<Transakcje> Transakcje { get; set; }
    }
}
