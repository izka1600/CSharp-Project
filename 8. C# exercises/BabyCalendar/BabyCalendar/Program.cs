using Microsoft.VisualBasic;
using System;

namespace BabyCalendar
{
	class Program
	{
		static void Main(string[] args)
		{
			DateTime dUrodzenia = Convert.ToDateTime("1900-01-01");
			while (dUrodzenia == Convert.ToDateTime("1900-01-01"))
			{
				dUrodzenia = new WorkFlows().AskUser();
			};

			//Jaka jest różnica w tygodniach między dniem urodzenia a dzisiaj?
			Console.WriteLine("Dzisiaj jest " + DateTime.Now );
			Console.WriteLine("Różnica między dniem urodzenia a dzisiaj to " + DateAndTime.DateDiff(DateInterval.WeekOfYear,dUrodzenia,DateTime.Now) + " tygodni.");
			Console.ReadKey();
		}
	}
}
