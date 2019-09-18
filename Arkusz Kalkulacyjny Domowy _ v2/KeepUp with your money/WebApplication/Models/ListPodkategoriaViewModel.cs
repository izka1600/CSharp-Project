using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class ListPodkategoriaViewModel
	{
		public ICollection<PodkategoriaViewModel> Items { get; set; }
	}
}
