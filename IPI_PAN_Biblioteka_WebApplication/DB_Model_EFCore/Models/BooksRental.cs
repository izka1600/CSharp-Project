using System;
using System.Collections.Generic;

namespace DB_Model_EFCore.Models
{
    public partial class BooksRental
    {
        public int RentalId { get; set; }
        public int? ReaderId { get; set; }
        public int? BookId { get; set; }
        public string Comment { get; set; }
        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual Books Book { get; set; }
        public virtual Readers Reader { get; set; }
    }
}
