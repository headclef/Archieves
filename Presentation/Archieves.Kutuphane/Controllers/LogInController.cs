using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Archieves.Kutuphane.Controllers
{
    public class LogInController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
