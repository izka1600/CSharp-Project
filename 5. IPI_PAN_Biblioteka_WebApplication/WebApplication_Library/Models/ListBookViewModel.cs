using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication_Library.Models
{
	public class ListBookViewModel
	{
		public ICollection<BookViewModel> Items { get; set; }
	}
}
