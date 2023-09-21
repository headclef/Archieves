using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error1(int errorCode)
        {
            return View();
        }
    }
}
