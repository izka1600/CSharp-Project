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
		public async Task<IActionResult> ListRaports()
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
			ReportFromMonthsParametersViewModel rap = new ReportFromMonthsParametersViewModel
			{
				UserId = UzId,
				Plan_Id = "3"
			};

			ICollection<ReportFromMonthsViewModel> currentRaportItems = await _arkuszService.GetRaportAsync(rap);

			var model = new ListReportFromMonthsViewModel()
			{
				Items = currentRaportItems
			};
			return View(model);


		}
	}
}
