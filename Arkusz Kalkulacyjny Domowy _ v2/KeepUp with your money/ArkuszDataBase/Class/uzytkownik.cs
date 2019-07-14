using System;
using System.Collections.Generic;
using System.Text;

namespace ArkuszDataBase.Class
{
	class uzytkownik
	{
		public int UzytId { get; set; }
		public string Imie { get; set; }
		public string Nazwisko { get; set; }
		public string Nick { get; set; }
		public string EMail { get; set; }
		public DateTime? DataDodania { get; set; }
		public DateTime? OstatnieLogowanie { get; set; }
	}
}
