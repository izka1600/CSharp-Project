using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class ListTransakcjaViewModel
	{
		public ICollection<TranskacjaViewModel> Items { get; set; }
	}
}
