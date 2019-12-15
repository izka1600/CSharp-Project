using System;

namespace DB_Model_EFCore.Class
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime PublicationDate { get; set; }
        public string CoverName { get; set; }
        public string DataCarrierName { get; set; }
    }
}