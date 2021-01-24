using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class KategoriaViewModel
	{
		[BindNever]

		public int KatId { get; set; }

		[Display(Name = "Nazwa kategorii")]
		[StringLength(100, ErrorMessage = "Nazwa kategorii jest za długa")]
		public string Kategoria { get; set; }

		public int UzId { get; set; }

	}
}
