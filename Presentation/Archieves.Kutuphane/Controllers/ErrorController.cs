using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        [Route("/Error/ErrorPage")]
        public IActionResult ErrorPage(int errorCode) // TODO: 404, 500 gibi hata kodları alması gerekli ancak her seferinde 0 alıyor, incelenecek!
        {

            if (errorCode == 404)
            {
                return RedirectToAction("Error1", "Error");
            }
            else if (errorCode == 500)
            {
                return RedirectToAction("Error2", "Error");
            }
            else
            {
                return Content("Bir hata oluştu...");
            }
        }
        public IActionResult Error1()
        {
            return View();
        }
        public IActionResult Error2()
        {
            return View();
        }
    }
}
