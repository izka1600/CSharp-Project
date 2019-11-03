using ArkuszDataBase.Class;
using ArkuszDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArkuszDataBase.Controllers
{
	public class KategoriaController
	{
		Arkusz_WydatkiContext context = new Arkusz_WydatkiContext();

		public int DodajKategorie (NowaKategoria nazwa)
		{
			var kategoria = new Kategorie
			{
				Kategoria = nazwa.Kategoria,
				UzId = nazwa.IdUzytkownika
			};

			context.Kategorie.Add(kategoria);
			context.SaveChanges();
			int newId = kategoria.KatId;
			return newId;
		}

		public int DodajPodkategorie(NowaPodkategoria pkat)
		{
			var podkategoria = new Podkategorie();
			podkategoria.Podkategoria = pkat.Podkategoria;
			podkategoria.IdKategorii = pkat.IdKategorii;
			context.Podkategorie.Add(podkategoria);
			context.SaveChanges();
			int newId = podkategoria.PodId;
			return newId;
		}

		public void UsunKategorie(int id)
		{
				var upd = context.Kategorie.Find(id);
				context.Kategorie.Remove(upd);
				context.SaveChanges();
		}

		public void UsunPodkategorie(int id)
		{
			var upd = context.Podkategorie.Find(id);
			context.Podkategorie.Remove(upd);
			context.SaveChanges();
		}

		public List<Kategorie> WylistujKategorie()
		{
			return context.Kategorie.ToList();
		}

		public List<Podkategorie> WylistujPodkategorie()
		{
			return context.Podkategorie.ToList();
		}


	}
}
