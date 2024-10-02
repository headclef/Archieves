using Archieves.Kutuphane.Services.Abstractions;
using Archieves.Kutuphane.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.ViewComponents.Admin
{
    public class AdminUsers : ViewComponent
    {
        private readonly IArchievesService _archievesService;
        public AdminUsers(IArchievesService archievesService)
        {
            _archievesService = archievesService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = (await _archievesService.GetUsersAsync()).Value;
            return View(users);
        }
    }
}
