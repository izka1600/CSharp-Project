using System;
using System.Collections.Generic;

namespace ArkuszDataBase.Models
{
    public partial class Podkategorie
    {
        public Podkategorie()
        {
            Transakcje = new HashSet<Transakcje>();
        }

        public int PodId { get; set; }
        public int? IdKategorii { get; set; }
        public string Podkategoria { get; set; }

        public virtual Kategorie IdKategoriiNavigation { get; set; }
        public virtual ICollection<Transakcje> Transakcje { get; set; }
    }
}
