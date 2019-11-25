using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}


		[Route("Home/{statusCode}")]
		public IActionResult HttpStatusCodeHandler(int StatusCode)
		{
			switch(StatusCode)
			{
				case 404:
					ViewBag.ErrorMessage = "Wybacz, nie mamy strony o podanym adresie";
					break;
			}
			return View("NotFound");
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		[Route("Home")]
		public IActionResult Error()
		{
			var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
			ViewBag.ExceptionPath = exceptionDetails.Path;
			ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
			ViewBag.StackTrace = exceptionDetails.Error.StackTrace;
			return View("Error");
			//return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
