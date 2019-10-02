using ArkuszDataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArkuszDataBase.Controllers
{
	public class RaportFromSomeMonthsController
	{
		Arkusz_WydatkiContext context = new Arkusz_WydatkiContext();

		public List<RaportFromMonths> RaportFromSomeMonths(ReportFromMonthsParametres raport)
		{
			return context.RaportFromMonths.FromSql("dbo.RaportFromSomeMonths @UserId={0}, @Plan_ID={1}", raport.UserId, raport.Plan_Id).ToList();

		}
	}
}
