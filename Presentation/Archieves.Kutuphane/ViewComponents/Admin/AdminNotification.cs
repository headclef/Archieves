using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.ViewComponents.Admin
{
    public class AdminNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
