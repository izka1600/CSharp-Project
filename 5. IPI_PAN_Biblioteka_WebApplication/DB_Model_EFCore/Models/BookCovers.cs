using System;
using System.Collections.Generic;

namespace DB_Model_EFCore.Models
{
    public partial class BookCovers
    {
        public BookCovers()
        {
            Books = new HashSet<Books>();
        }

        public int CoverId { get; set; }
        public string Name { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual ICollection<Books> Books { get; set; }
    }
}
