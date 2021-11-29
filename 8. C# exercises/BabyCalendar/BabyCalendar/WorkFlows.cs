using System;
using System.Collections.Generic;
using System.Text;

namespace BabyCalendar
{
	public class WorkFlows :IWorkFlows
	{
		public DateTime AskUser()
		{
			Console.WriteLine("Podaj datę urodzenia dziecka");
			string dataUrodzenia = Console.ReadLine();
			DateTime dUrodzenia = Convert.ToDateTime("1900-01-01");

			try
			{
				dUrodzenia = Convert.ToDateTime(dataUrodzenia);
			}
			catch (Exception)
			{

				Console.WriteLine("Niepoprawny format daty");
			}
			return dUrodzenia;
		}
	}
}
