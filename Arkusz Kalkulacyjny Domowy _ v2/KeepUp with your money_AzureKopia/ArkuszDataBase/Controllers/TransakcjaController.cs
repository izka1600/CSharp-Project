using ArkuszDataBase.Class;
using ArkuszDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArkuszDataBase.Controllers
{
	public class TransakcjaController
	{
		Arkusz_WydatkiContext context = new Arkusz_WydatkiContext();

		public int DodajTransakcje(NowaTransakcja newTrans)
		{
			var transakcja = new Transakcje();
			transakcja.Data = newTrans.Data;
			transakcja.IdKategorii = newTrans.IdKategorii;
			transakcja.IdPodkategorii = newTrans.IdPodkategorii;
			transakcja.IdUzytkownika = newTrans.IdUzytkownika;
			transakcja.Kwota = newTrans.Kwota;
			transakcja.PlanId = newTrans.PlanId;
			context.Transakcje.Add(transakcja);
			context.SaveChanges();
			int newId = transakcja.TransId;
			return newId;
		}

		//public void DodajTransakcje(int uzyt, DateTime data, int kat, int pod, double kwota)
		//{
		//	var transakcja = new Transakcje();
		//	transakcja.IdUzytkownika = uzyt;
		//	transakcja.Data = data;
		//	transakcja.IdKategorii = kat;
		//	transakcja.IdPodkategorii = pod;
		//	transakcja.Kwota = kwota;
		//	context.Transakcje.Add(transakcja);
		//	context.SaveChanges();
		//}

		public void UsunTransakcje(int Id)
		{
			var upd = context.Transakcje.Find(Id);
			context.Transakcje.Remove(upd);
			context.SaveChanges();
		}

		public List<Transakcje> WylistujTranskacje()
		{
			return context.Transakcje.ToList();
		}

		public Transakcje WyszukajTranskacje(int id)
		{
			return context.Transakcje.Find(id);
		}

		public void AdministratorZaktualizaujTransakcje(int Id, DateTime data, int IdUz, int IdKat, int IdPod, double kwota, int PlanID)
		{
			var upd = context.Transakcje.Find(Id);
			upd.Data = data;
			upd.IdUzytkownika = IdUz;
			upd.IdKategorii = IdKat;
			upd.IdPodkategorii = IdPod;
			upd.Kwota = kwota;
			upd.PlanId = PlanID;

			context.SaveChanges();
		}

		public void UzytkownikZaktualizaujTransakcje(int Id, DateTime data, int IdKat, int IdPod, double kwota)
		{
			var upd = context.Transakcje.Find(Id);
			upd.Data = data;
			upd.IdKategorii = IdKat;
			upd.IdPodkategorii = IdPod;
			upd.Kwota = kwota;

			context.SaveChanges();
		}
	}
}
