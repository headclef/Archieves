using Microsoft.AspNetCore.Mvc;

namespace KütüphaneOtomasyonu.Controllers
{
	public class AboutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
