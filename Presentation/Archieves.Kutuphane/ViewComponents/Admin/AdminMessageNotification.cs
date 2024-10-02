using Archieves.Kutuphane.Models.Message;
using Archieves.Kutuphane.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.ViewComponents.Admin
{
    public class AdminMessageNotification : ViewComponent
    {
        private readonly IArchievesService _archievesService;
        public AdminMessageNotification(IArchievesService archievesService)
        {
            _archievesService = archievesService;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var messages = (await _archievesService.GetMessagesAsync(id)).Value;
            return View(messages);
        }
    }
}
