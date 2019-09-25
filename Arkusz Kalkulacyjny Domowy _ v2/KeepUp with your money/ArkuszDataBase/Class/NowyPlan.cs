using System;
using System.Collections.Generic;
using System.Text;

namespace ArkuszDataBase.Class
{
	public class NowyPlan
	{
		public DateTime? Miesiąc { get; set; }
		public decimal? ZalozonaKwota { get; set; }
		public decimal? FaktycznaKwota { get; set; }
		public int IdUzytkownika { get; set; }
	}
}
