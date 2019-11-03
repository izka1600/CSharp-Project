using ArkuszDataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArkuszDataBase.Controllers
{
	public class AddTransactionToPlanController
	{
		Arkusz_WydatkiContext context = new Arkusz_WydatkiContext();

		public void AddTransactionToPlan(UpdateFaktycznyPlan fplan)
		{
			context.Database.ExecuteSqlCommand("dbo.AddTransactionToPlan @Amount={0}, @Plan_ID={1}", fplan.Amount, fplan.Plan_ID);
			context.SaveChanges();
		}
	}
}
