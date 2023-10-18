using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Services.Abstractions;
using Archieves.Kutuphane.ValidationRules;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public RegisterController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserAddModel user)
        {
            if (_userService.GetUserByEmailAsync(user.Email).Result.Value is null)
            {
                UserValidator uv = new UserValidator();
                ValidationResult vr = uv.Validate(_mapper.Map<UserViewModel>(user));
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
                    _userService.AddUserAsync(user);
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