using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class PodkategoriaViewModel
	{
		[BindNever]

		public int PodId { get; set; }
		public int IdKategorii { get; set; }

		[Display(Name = "Nazwa podkategorii")]
		[StringLength(100, ErrorMessage = "Nazwa podkategorii jest za długa")]
		public string Podkategoria { get; set; }
	}
}
