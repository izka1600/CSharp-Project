using System;
using System.Collections.Generic;

namespace ArkuszDataBase.Models
{
    public partial class Transakcje
    {
        public Transakcje()
        {
            Plan = new HashSet<Plan>();
        }

        public int TransId { get; set; }
        public DateTime? Data { get; set; }
        public int IdUzytkownika { get; set; }
        public int IdKategorii { get; set; }
        public int IdPodkategorii { get; set; }
        public double? Kwota { get; set; }

        public virtual Kategorie IdKategoriiNavigation { get; set; }
        public virtual Podkategorie IdPodkategoriiNavigation { get; set; }
        public virtual Uzytkownik IdUzytkownikaNavigation { get; set; }
        public virtual ICollection<Plan> Plan { get; set; }
    }
}
