using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ArkuszDataBase.Class
{
	public class NowaPodkategoria
	{
		public int? IdKategorii { get; set; }
		[Display(Name = "Nazwa podkategorii")]
		[StringLength(100, ErrorMessage = "Nazwa podkategorii jest za długa")]
		public string Podkategoria { get; set; }

	}
}
