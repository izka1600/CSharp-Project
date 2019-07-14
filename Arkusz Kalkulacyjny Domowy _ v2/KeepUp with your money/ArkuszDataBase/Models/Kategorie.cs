using System;
using System.Collections.Generic;

namespace ArkuszDataBase.Models
{
    public partial class Kategorie
    {
        public Kategorie()
        {
            Podkategorie = new HashSet<Podkategorie>();
            Transakcje = new HashSet<Transakcje>();
        }

        public int KatId { get; set; }
        public string Kategoria { get; set; }

        public virtual ICollection<Podkategorie> Podkategorie { get; set; }
        public virtual ICollection<Transakcje> Transakcje { get; set; }
    }
}
