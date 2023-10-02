using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.ViewComponents.Admin
{
    public class AdminMessageNotification : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
