using Archieves.Domain.Entities;
using Archieves.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Archieves.Kutuphane.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            List<User> users = GetAuthenticatedUser();
            return View(users);
        }
        private List<User> GetAuthenticatedUser()
        {
            using (var context = new ArchievesDbContext())
            {
                string email = User.FindFirstValue(ClaimTypes.Email);
                List<User> authenticatedUser = context.Users.Where(x => x.Email == email).ToList();
                return authenticatedUser;
            }
        }
    }
}
