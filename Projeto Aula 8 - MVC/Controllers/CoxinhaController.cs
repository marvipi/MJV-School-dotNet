using Microsoft.AspNetCore.Mvc;

namespace Projeto_Aula_8___MVC.Controllers;
public class CoxinhaController : Controller
{
	public IActionResult Index()
	{
		return View();
	}

	public IActionResult Pastel()
	{
		return View();
	}
}
