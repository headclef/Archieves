using Archieves.Kutuphane.Models.Notification;
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
            var notifications = _archievesService.GetNotificationsAsync().Result.Value;
            // En büyük ID'ye sahip "Etkinlik" tipindeki nesneyi bulma
            var etkinlikNotification = notifications
                .Where(n => n.Type == "Etkinlik")
                .OrderByDescending(n => n.Id)
                .FirstOrDefault();
            // En büyük ID'ye sahip "Kitap" tipindeki nesneyi bulma
            var kitapNotification = notifications
                .Where(n => n.Type == "Kitap")
                .OrderByDescending(n => n.Id)
                .FirstOrDefault();
            List<NotificationViewModel> model = new List<NotificationViewModel>();
            if (etkinlikNotification != null)
            {
                model.Add(new NotificationViewModel
                {
                    Id = 0,
                    Message = etkinlikNotification.Message,
                    Type = etkinlikNotification.Type,
                    Icon = etkinlikNotification.Icon,
                    Date = etkinlikNotification.Date,
                    Status = etkinlikNotification.Status
                });
            }
            if (kitapNotification != null)
            {
                model.Add(new NotificationViewModel
                {
                    Id = 1,
                    Message = kitapNotification.Message,
                    Type = kitapNotification.Type,
                    Icon = kitapNotification.Icon,
                    Date = kitapNotification.Date,
                    Status = kitapNotification.Status
                });
            }
            return View(model);
        }
    }
}
