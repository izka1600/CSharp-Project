using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArkuszDataBase.Models
{
	public partial class RaportFromMonths
	{
		[Key]
		public DateTime DateOfTransaction { get; set; }
		public string Kategoria { get; set; }
		public string Podkategoria { get; set; }
		public double Kwota { get; set; }

	}
}
