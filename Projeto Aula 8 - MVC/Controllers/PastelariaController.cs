using Microsoft.AspNetCore.Mvc;
using Projeto_Aula_8___MVC.Models;

namespace Projeto_Aula_8___MVC.Controllers;
public class PastelariaController : Controller
{
	public IActionResult Index()
	{
		var a = ViewBag.Autenticado;
		var b = ViewData["Nome"];
		var c = TempData["Oito"];

		return View();
	}

	[HttpPost]
	public IActionResult Index(string Recheio)
	{
		var a = ViewBag.Autenticado;
		var b = ViewData["Nome"];
		var c = TempData["Oito"];

		return View();
	}

	public IActionResult Menu()
	{
		var pasteis = new List<PastelViewModel>()
		{
			new PastelViewModel("Queijo", 5.35M),
			new PastelViewModel("Carne", 4.99M),
			new PastelViewModel("Palmito", 6.00M),
			new PastelViewModel("Catupiri", 2.24M),
		};
		return View(pasteis);
	}
}
