using System;
using System.Collections.Generic;

namespace DB_Model_EFCore.Models
{
    public partial class Readers
    {
        public Readers()
        {
            BooksRental = new HashSet<BooksRental>();
        }

        public int ReaderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AccessRights { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public virtual ICollection<BooksRental> BooksRental { get; set; }
    }
}
