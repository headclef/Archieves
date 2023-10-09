using Archieves.Domain.Entities;
using Archieves.Persistence.Concretes;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Archieves.Kutuphane.Controllers
{
    public class LogInController : Controller
    {
        private readonly UserService userService;
        public LogInController()
        {
            userService = new UserService();
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> IndexAsync(User user)
        {
            var userControl = userService.GetAll().FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (userControl != null)
            {
                if (userControl.Status != false)
                {
                    // User Validation
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);

                    // TODO: Google Recaptcha çalışmıyor, çalıştırılacak.
                    await Post();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Hesabınız aktif değil. Lütfen yönetici ile iletişime geçiniz.";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Kullanıcı adı veya şifre hatalı";
                return View();
            }
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "LogIn");
        }
        // Google Recaptcha
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var captchaImage = HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(captchaImage))
            {
                ViewBag.Message = "ReCaptcha boş hatası aldınız.";
                return RedirectToAction("Index", "LogIn");
            }

            var verified = await CheckCaptcha();
            if (!verified)
            {
                ViewBag.Message = "ReCaptcha 'yı işaretlememe hatası aldınız.";
                return RedirectToAction("Index", "LogIn");
            }
            return View();
        }
        public async Task<bool> CheckCaptcha()
        {
            var postData = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("secret", "6LdZ4gwoAAAAAKDbfI6jbyUCp78JEGGWYsIQctMs"),
                new KeyValuePair<string, string>("response", HttpContext.Request.Form["google-recaptcha-response"])
            };
            var client = new HttpClient();
            var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", new FormUrlEncodedContent(postData));
            var json = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            return json.Value<bool>("success");
        }
    }
}
