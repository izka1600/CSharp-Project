using System;

namespace DB_Model_EFCore.Class
{
    public class BookRental
    {
        public int RentalId { get; set; }
        public int? ReaderId { get; set; }
        public int? BookId { get; set; }
        public string Comment { get; set; }
        public DateTime? RentalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
