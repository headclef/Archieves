﻿using Archieves.Domain.Entities;
using Archieves.Persistence.Contexts;
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
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> IndexAsync(User user)
        {
            /*var reCaptchaResponse = HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(reCaptchaResponse))
            {
                return Content("Lütfen güvenlik doğrulamasını yapınız.");
            }

            // Google reCAPTCHA doğrulamasını kontrol et
            var secretKey = "6LdZ4gwoAAAAAKDbfI6jbyUCp78JEGGWYsIQctMs"; // reCAPTCHA'nın sağladığı gizli anahtar
            var reCaptchaVerified = await GoogleCaptcha.IsReCaptchaValidAsync(reCaptchaResponse, secretKey);

            if (!reCaptchaVerified)
            {
                return Content("Güvenlik doğrulaması başarısız.");
            }*/

            using (var context = new ArchievesDbContext()) // İleriki zamanlarda controller üzerinden kaldırılıp servis katmanına alınacak.
            {
                var userControl = context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
                if (userControl != null)
                {
                    /*
                    HttpContext.Session.SetString("Email", user.Email);
                    return RedirectToAction("Index", "Home");
                    */
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email)
                    };
                    var userIdentity = new ClaimsIdentity(claims, "login");
                    ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                    await HttpContext.SignInAsync(principal);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = "Kullanıcı adı veya şifre hatalı";
                    return View();
                }
            }
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "LogIn");
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var captchaImage = HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(captchaImage))
            {
                return Content("Lütfen güvenlik doğrulamasını yapınız.");
            }

            var verified = await CheckCaptcha();
            if (!verified)
            {
                return Content("Lütfen güvenlik doğrulamasını yapınız.");
            }
            if (verified)
            {
                return Content("Güvenlik doğrulaması başarılı.");
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
