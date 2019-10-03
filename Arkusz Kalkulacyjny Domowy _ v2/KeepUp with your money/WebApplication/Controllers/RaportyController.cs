using AuthDatabase.Entities;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;
using WebApplication.Services;

namespace WebApplication.Controllers
{
	public class RaportyController : Controller
	{
		private readonly IAntiforgery _antiforgery;

		private readonly IArkuszService _arkuszService;
		private readonly UserManager<AppUser> _userManager;

		public RaportyController(
			IArkuszService arkuszService,
			UserManager<AppUser> userManager)


		{
			_arkuszService = arkuszService;
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
		{
			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return Challenge();
			}

			return View();
		}

		[Route("/WebApiRaportFromSomeMonths/PokazRaportZDanychMiesiecy")]
		public async Task<IActionResult> ListRaports([Bind(Prefix = "Item1")] ReportFromMonthsParametersViewModel trolololo)
		{

			var currentUser = await _userManager.GetUserAsync(User);
			if (currentUser == null)
			{
				return RedirectToAction("ListPlans");
			}
			ICollection<UzytkownikViewModel> UsersList = await _arkuszService.Get_Uzytkownicy();
			int UzId = 0;
			foreach (var item in UsersList)
			{
				if (item.EMail.ToUpper() == currentUser.Email.ToUpper())
				{
					UzId = item.UzytId;
				}
			}

			ICollection<PlanViewModel> currentPlanItems = await _arkuszService.Get_Plan();
			ICollection<PlanViewModel> NewPlanItems = new List<PlanViewModel>();
			foreach (var item in currentPlanItems)
			{
				if (item.IdUzytkownika == UzId || item.IdUzytkownika == 0)
				{
					NewPlanItems.Add(item);
				}
			}

			var model1 = new ListPlanViewModel()
			{
				Items = NewPlanItems
			};

			ReportFromMonthsParametersViewModel rap = new ReportFromMonthsParametersViewModel();

			if (String.IsNullOrEmpty(trolololo.Plan_Id))
			{
				
				int x = 0;
				foreach (var item in NewPlanItems)
				{
					if (item.PlanId>x)
					{
						x = item.PlanId;
					}
				}
				rap.UserId = UzId;
				rap.Plan_Id = x.ToString();
			}

			ICollection<ReportFromMonthsViewModel> currentRaportItems = await _arkuszService.GetRaportAsync(rap);

			var model = new ListReportFromMonthsViewModel()
			{
				Items = currentRaportItems
			};

			var tuple = new Tuple<ReportFromMonthsParametersViewModel, ListReportFromMonthsViewModel, ListPlanViewModel>(rap, model, model1);

			return View(tuple);


		}
	}
}
