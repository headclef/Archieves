using Microsoft.AspNetCore.Mvc;

namespace KütüphaneOtomasyonu.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
