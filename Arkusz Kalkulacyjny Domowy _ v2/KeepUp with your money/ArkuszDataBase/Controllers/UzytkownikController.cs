using ArkuszDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArkuszDataBase.Controllers
{
	public class UzytkownikController
	{
		Arkusz_WydatkiContext context = new Arkusz_WydatkiContext();
		public int StworzNowegoUzytkownika(string firstName, string lastName, string nick, string email)
		{
			var nowyUzytkownik = new Uzytkownik
			{
				Imie = firstName,
				Nazwisko = lastName,
				Nick = nick,
				EMail = email,
			};

			context.Uzytkownik.Add(nowyUzytkownik);
			context.SaveChanges();
			int newId = nowyUzytkownik.UzytId;
			return newId;
		}

		public List<Uzytkownik> WylistujUzytkownikow()
		{
			return context.Uzytkownik.Where(r => r.DataUsuniecia == null).ToList();
		}

		public Uzytkownik ZnajdzUzytkownika(int id)
		{
			return context.Uzytkownik.Find(id);
		}

		public void ZaktualizujUzytkownika(int Id, string firstName, string lastName, string nick, string email)
		{
			var upd = context.Uzytkownik.Find(Id);
			upd.Imie = firstName;
			upd.Nazwisko = lastName;
			upd.Nick = nick;
			upd.EMail = email;
			context.SaveChanges();
		}

		public void UsunUzytkownika(int Id)
		{
			var upd = context.Uzytkownik.Find(Id);
			upd.DataUsuniecia = DateTime.Now;
			context.SaveChanges();
		}

	}
}
