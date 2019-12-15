using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ArkuszDataBase.Class
{
	public class NowyPlan
	{
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public DateTime? Miesiąc { get; set; }
		public decimal? ZalozonaKwota { get; set; }
		public decimal? FaktycznaKwota { get; set; }
		public int IdUzytkownika { get; set; }

		public bool Active { get; set; }
		public int Warning { get; set; }
	}
}
