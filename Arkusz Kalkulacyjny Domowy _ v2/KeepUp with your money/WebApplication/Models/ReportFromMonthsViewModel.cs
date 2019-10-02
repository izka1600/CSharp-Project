using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
	public class ReportFromMonthsViewModel
	{
		[Key]
		public DateTime DateOfTransaction { get; set; }
		public string Kategoria { get; set; }
		public string Podkategoria { get; set; }
		public double Kwota { get; set; }
	}
}
