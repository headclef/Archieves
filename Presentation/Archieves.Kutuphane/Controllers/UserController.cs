using Archieves.Domain.Entities;
using Archieves.Persistence.Concretes;
using Archieves.Persistence.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Archieves.Kutuphane.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService userService;
        public UserController()
        {
            userService = new UserService();
        }
        public IActionResult Index()
        {
            List<User> users = GetAuthenticatedUser();
            return View(users);
        }
        private List<User> GetAuthenticatedUser()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            List<User> authenticatedUser = userService.GetAll().Where(x => x.Email == email).ToList();
            return authenticatedUser;
        }
    }
}
