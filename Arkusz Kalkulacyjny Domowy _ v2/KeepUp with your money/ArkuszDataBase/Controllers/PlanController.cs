using ArkuszDataBase.Class;
using ArkuszDataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArkuszDataBase.Controllers
{
	public class PlanController
	{
		Arkusz_WydatkiContext context = new Arkusz_WydatkiContext();

		public int DodajPlan(NowyPlan newPlan)
		{
			var plan = new Plan();
			plan.FaktycznaKwota = newPlan.FaktycznaKwota;
			plan.IdUzytkownika = newPlan.IdUzytkownika;
			plan.Miesiąc = newPlan.Miesiąc;
			plan.ZalozonaKwota = newPlan.ZalozonaKwota;
			context.Plan.Add(plan);
			context.SaveChanges();
			int newId = plan.PlanId;
			return newId;
		}


		public void UsunPlan(int Id)
		{
			var upd = context.Plan.Find(Id);
			context.Plan.Remove(upd);
			context.SaveChanges();
		}

		public List<Plan> WylistujPlany()
		{
			return context.Plan.ToList();
		}

		public void UzytkownikZaktualizaujPlan(UpdatePlan plan)
		{
			var upd = context.Plan.Find(plan.PlanId);
			upd.Miesiąc = plan.Miesiąc;
			upd.ZalozonaKwota = plan.ZalozonaKwota;

			context.SaveChanges();
		}
	}
}
