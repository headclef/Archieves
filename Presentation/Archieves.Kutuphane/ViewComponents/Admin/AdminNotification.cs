using Archieves.Kutuphane.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.ViewComponents.Admin
{
    public class AdminNotification : ViewComponent
    {
        private readonly IArchievesService _archievesService;
        public AdminNotification(IArchievesService archievesService)
        {
            _archievesService = archievesService;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
