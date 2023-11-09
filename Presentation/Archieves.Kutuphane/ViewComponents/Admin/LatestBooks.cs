using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.ViewComponents.Admin
{
    public class LatestBooks : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}