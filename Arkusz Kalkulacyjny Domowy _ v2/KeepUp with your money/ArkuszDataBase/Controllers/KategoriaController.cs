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

		public void DodajKategorie (string nazwa)
		{
			var kategoria = new Kategorie();
			kategoria.Kategoria = nazwa;
			context.Kategorie.Add(kategoria);
			context.SaveChanges();
		}

		public void DodajPodkategorie(int idKategorii, string nazwaPodkategorii)
		{
			var podkategoria = new Podkategorie();
			podkategoria.Podkategoria = nazwaPodkategorii;
			podkategoria.IdKategorii = idKategorii;
			context.Podkategorie.Add(podkategoria);
			context.SaveChanges();
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
