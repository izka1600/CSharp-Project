using ArkuszDataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkuszDataBase.Controllers
{
	public class TransakcjaController
	{
		Arkusz_WydatkiContext context = new Arkusz_WydatkiContext();

		public void DodajTransakcje(int uzyt, int kat, int pod, double kwota)
		{
			var transakcja = new Transakcje();
			transakcja.IdUzytkownika = uzyt;
			transakcja.IdKategorii = kat;
			transakcja.IdPodkategorii = pod;
			transakcja.Kwota = kwota;
			context.Transakcje.Add(transakcja);
			context.SaveChanges();
		}

		public void DodajTransakcje(DateTime data,  int uzyt, int kat, int pod, double kwota)
		{
			var transakcja = new Transakcje();
			transakcja.IdUzytkownika = uzyt;
			transakcja.IdKategorii = kat;
			transakcja.IdPodkategorii = pod;
			transakcja.Kwota = kwota;
			transakcja.Data = data;
			context.Transakcje.Add(transakcja);
			context.SaveChanges();
		}

	}
}
