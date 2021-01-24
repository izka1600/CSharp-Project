using System;
using System.Collections.Generic;

namespace DB_Model_EFCore.Models
{
    public partial class Books
    {
        public Books()
        {
            BooksRental = new HashSet<BooksRental>();
        }

        public int BookId { get; set; }
        public int? CoverId { get; set; }
        public int? AuthorsId { get; set; }
        public int? DataCarrierId { get; set; }
        public string Name { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual Authors Authors { get; set; }
        public virtual BookCovers Cover { get; set; }
        public virtual DataCarriers DataCarrier { get; set; }
        public virtual ICollection<BooksRental> BooksRental { get; set; }
    }
}
