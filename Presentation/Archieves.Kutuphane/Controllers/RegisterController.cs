using Archieves.Domain.Entities;
using Archieves.Kutuphane.ValidationRules;
using Archieves.Persistence.Concretes;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserService userService;
        public RegisterController()
        {
            userService = new UserService();
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(User user)
        {
            if (userService.GetAll().Where(x => x.Email == user.Email).Count() == 0)
            {
                UserValidator uv = new UserValidator();
                ValidationResult vr = uv.Validate(user);
                if (!vr.IsValid)
                {
                    foreach (var item in vr.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                    return View();
                }
                else
                {
                    user.Status = true;
                    user.Image = "empty";
                    userService.Add(user);
                    return RedirectToAction("Index", "Login");
                }
            }
            else
            {
                ViewBag.Message = "Bu e-posta adresi kullanılmaktadır.";
                return View();
            }
        }
    }
}