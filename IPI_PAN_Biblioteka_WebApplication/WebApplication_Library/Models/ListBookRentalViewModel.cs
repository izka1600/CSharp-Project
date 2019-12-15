using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Library.Models
{
	public class ListBookRentalViewModel
	{
		public List<DB_Model_EFCore.Class.BookRental> Rentals { get; set; }
}
}
