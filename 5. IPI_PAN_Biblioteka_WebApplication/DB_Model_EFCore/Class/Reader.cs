using System;
using System.Collections.Generic;
using System.Text;

namespace DB_Model_EFCore.Class
{
    public class Reader
    {
        public int ReaderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AccessRights { get; set; }
    }
}
