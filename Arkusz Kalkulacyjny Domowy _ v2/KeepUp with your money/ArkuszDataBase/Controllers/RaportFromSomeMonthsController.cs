using ArkuszDataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ArkuszDataBase.Controllers
{
	public class RaportFromSomeMonthsController
	{
		Arkusz_WydatkiContext context = new Arkusz_WydatkiContext();

		public List<RaportFromMonths> RaportFromSomeMonths(ReportFromMonthsParametres raport)
		{
			var catParam = new SqlParameter("@UserId", raport.UserId);
			var catParam1 = new SqlParameter("@Plan_ID", raport.Plan_Id);
			var lista = context.RaportFromMonths.AsNoTracking().FromSql("dbo.RaportFromSomeMonths @UserId, @Plan_ID",catParam, catParam1).ToList();
			return lista;
			// AsNoTracking() ignore key definitions and just return the data as is
		}
	}
}
