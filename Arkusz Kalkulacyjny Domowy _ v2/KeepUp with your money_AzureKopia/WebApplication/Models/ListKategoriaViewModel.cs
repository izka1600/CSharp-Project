using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class ListKategoriaViewModel
	{
		public ICollection<KategoriaViewModel> Items { get; set; }
	}
}
