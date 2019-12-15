using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Model_EFCore.Class
{
    public class NewBookRental
    {
        public int? ReaderId { get; set; }
        public int? BookId { get; set; }
        public string Comment { get; set; }
    }
}
