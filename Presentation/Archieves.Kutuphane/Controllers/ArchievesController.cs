using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Services.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Security.Claims;
using Archieves.Kutuphane.Models.Subscriber;
using Archieves.Kutuphane.ValidationRules;
using FluentValidation.Results;
using Archieves.Kutuphane.Models.Author;
using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.Rating;
using Archieves.Kutuphane.Models.Book;

namespace Archieves.Kutuphane.Controllers
{
    public class ArchievesController : Controller
    {
        private readonly IArchievesService _archievesService;
        private readonly IMapper _mapper;
        public static string? _name = null;
        public ArchievesController(IArchievesService archievesService, IMapper mapper)
        {
            _archievesService = archievesService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public IActionResult IndexHome()
        {
            return View();
        }

        #region LogIn / LogOut
        [AllowAnonymous]
        [HttpGet]
        public IActionResult IndexLogIn()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> IndexLogIn(UserViewModel userViewModel)
        {
            LogInValidator lv = new LogInValidator();
            ValidationResult vr = lv.Validate(userViewModel);
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
                var model = (await _archievesService.GetUserAsync(userViewModel)).Value;
                if (model is not null)
                {

                    if (model.Status is not false or null)
                    {
                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                        new Claim(ClaimTypes.Name, model.Name != null ? model.Name : ""),
                        new Claim(ClaimTypes.Surname, model.Surname != null ? model.Surname : ""),
                        new Claim(ClaimTypes.Email, model.Email != null ? model.Email : "")
                    };
                        var userIdentity = new ClaimsIdentity(claims, "login");
                        ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                        await HttpContext.SignInAsync(principal);

                        var result = await Post();
                        if (!result)
                            return View();
                        else
                            return RedirectToAction("IndexHome", "Archieves");
                    }
                    else
                    {
                        ViewBag.LogInMessage = "Hesabınız aktif değil." +
                            "\nLütfen bir yönetici ile iletişime geçiniz ya da bize bilet gönderiniz.";
                        return View();
                    }
                }
                else
                {
                    ViewBag.LogInMessage = "Kullanıcı adı veya şifre hatalı!";
                    return View();
                }
            }
        }
        public async Task<IActionResult> IndexLogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("IndexLogIn", "Archieves");
        }
        #endregion
        #region Register
        [AllowAnonymous]
        [HttpGet]
        public IActionResult IndexRegister()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> IndexRegister(UserViewModel userViewModel)
        {
            var model = (await _archievesService.GetUserAsync(userViewModel)).Value;
            if (model is null)
            {
                UserValidator uv = new UserValidator();
                ValidationResult vr = uv.Validate(userViewModel);
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
                    var result = await _archievesService.AddUserAsync(userViewModel);
                    if (result.IsSuccess)
                    {
                        return RedirectToAction("IndexLogIn", "Archieves");
                    }
                    else
                    {
                        ViewBag.RegisterMessage = "Kayıt işlemi başarısız oldu.";
                        return View();
                    }
                }
            }
            else
            {
                ViewBag.RegisterMessage = "Bu e - posta adresi kullanılmaktadır.";
                return View();
            }
        }
        #endregion
        #region About
        [HttpGet]
        public IActionResult IndexAbout()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> IndexAbout(SubscriberViewModel subscriber)
        {
            SubscriberValidator sv = new SubscriberValidator();
            ValidationResult vr = sv.Validate(subscriber);
            if (!vr.IsValid)
            {
                foreach (var error in vr.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return View();
            }
            else
            {
                await _archievesService.AddSubscriberAsync(subscriber);
                return RedirectToAction("IndexAbout", "Archieves");
            }
        }
        #endregion
        #region Contact
        [AllowAnonymous]
        public IActionResult IndexContact()
        {
            return View();
        }
        #endregion
        #region Error
        // TODO: 404, 500 gibi hata kodları alması gerekli ancak her seferinde 0 alıyor, incelenecek!
        [Route("/Archieves/IndexErrorPage")]
        [AllowAnonymous]
        public IActionResult IndexErrorPage(int errorCode)
        {
            if (errorCode == 404)
                return RedirectToAction("IndexError1", "Archieves");
            else if (errorCode == 500)
                return RedirectToAction("IndexError2", "Archieves");
            else
                return Content("Bir hata oluştu...");
        }
        [AllowAnonymous]
        public IActionResult IndexError1()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult IndexError2()
        {
            return View();
        }
        #endregion
        #region Author
        [HttpGet]
        public IActionResult AddAuthor()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorViewModel authorViewModel)
        {
            AuthorValidator av = new AuthorValidator();
            ValidationResult vr = av.Validate(authorViewModel);
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
                var model = (await _archievesService.GetAuthorAsync(authorViewModel)).Value;
                if (model is null)
                {
                    authorViewModel.Status = true;
                    var result = await _archievesService.AddAuthorAsync(authorViewModel);
                    if (result.IsSuccess)
                    {
                        // TODO: IndexUser sayfasını oluştur.
                        return RedirectToAction("IndexUser", "Archieves");
                    }
                    else
                    {
                        ViewBag.AuthorMessage = "Yazar ekleme işlemi başarısız oldu.";
                        return View();
                    }
                }
                else
                {
                    ViewBag.AuthorMessage = "Hali hazırda var olan bir yazarı tekrar ekleyemezsiniz.";
                    return View();
                }
            }
        }
        #endregion
        #region Book
        [HttpGet]
        public async Task<IActionResult> IndexBook(BookPagerModel bookPagerModel)
        {
            if (_name is not null)
            {
                var model = await _archievesService.GetBookListAsync(bookPagerModel, _name);
                return View(model);
            }
            else
            {
                var model = await _archievesService.GetBookListAsync(bookPagerModel);
                return View("IndexBook", model);
            }
        }
        public async Task<IActionResult> IndexBookDetails(int id)
        {
            var model = (await _archievesService.GetBookAsync(id)).Value;
            return View(model);
        }
        #endregion
        #region Comment
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public async Task<IActionResult> AddCommentPartial(CommentViewModel comment)
        {
            var control = (await _archievesService.GetRatingsAsync(Convert.ToInt32(comment.BookId))).Value;
            if (control is not null)
            {
                var rating = new RatingViewModel();
                rating.Rate = comment.Rate;
                await _archievesService.UpdateRatingAsync(rating);
            }
            else
            {
                var rating = new RatingViewModel();
                rating.BookId = comment.BookId;
                rating.Rate = comment.Rate;
                rating.Count = 1;
                rating.Date = DateTime.Now;
                rating.Status = true;
                await _archievesService.AddRatingAsync(rating);
            }
            UserViewModel authenticatedUser = await GetAuthenticatedUser();
            comment.UserId = authenticatedUser.Id;
            comment.Date = DateTime.Now;
            comment.Status = true;
            await _archievesService.AddCommentAsync(comment);
            return RedirectToAction("IndexBookDetails", "Archieves", new { id = comment.BookId });
        }
        #endregion
        #region User
        public async Task<IActionResult> IndexUser()
        {
            var user = await GetAuthenticatedUser();
            return View(user);
        }
        public async Task<IActionResult> CommentList()
        {
            var user = await GetAuthenticatedUser();
            var model = (await _archievesService.GetCommentsAsync(user.Id)).Value;
            if (model is not null)
            {
                return View(model);
            }
            else
            {
                ViewBag.CommentMessage = "Henüz hiçbir yorumunuz bulunmamaktadır.";
                return View();
            }
        }
        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {
            var model = (await _archievesService.GetCommentAsync(id)).Value;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateComment(CommentViewModel comment)
        {
            var ratingModel = (await _archievesService.GetRatingAsync((int)comment.BookId)).Value;
            if (ratingModel is not null)
            {
                ratingModel.Rate = comment.Rate;
                await _archievesService.UpdateRatingAsync(ratingModel);
                await _archievesService.UpdateCommentAsync(comment);
                return RedirectToAction("CommentList", "Archieves");
            }
            else
            {
                ViewBag.UpdateCommentMessage = "Yorum güncelleme işlemi başarısız oldu.";
                return View();
            }
        }
        public async Task<IActionResult> DeleteComment(int id)
        {
            var model = (await _archievesService.GetCommentAsync(id)).Value;
            if (model is not null)
            {
                await _archievesService.DeleteCommentAsync(id);
                return RedirectToAction("CommentList", "Archieves");
            }
            else
            {
                ViewBag.DeleteCommentMessage = "Yorum silme işlemi başarısız oldu.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CommentViewModel commentViewModel)
        {
            CommentValidator cv = new CommentValidator();
            ValidationResult vr = cv.Validate(commentViewModel);
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
                var authenticatedUser = await GetAuthenticatedUser();
                commentViewModel.UserId = authenticatedUser.Id;
                commentViewModel.Date = DateTime.Now;
                commentViewModel.Status = true;
                await _archievesService.AddCommentAsync(commentViewModel);
                return RedirectToAction("IndexUser", "Archieves");

            }
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await GetAuthenticatedUser();
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserViewModel userViewModel)
        {
            // TODO: View sayfasındaki placeholder 'ları value ile değiştir.
            await _archievesService.UpdateUserAsync(userViewModel);
            return View(userViewModel);
        }
        public async Task<IActionResult> DeleteUser(int id)
        {
            var model = (await _archievesService.GetUserAsync(id)).Value;
            if (model is not null)
            {
                await _archievesService.DeleteUserAsync(id);
                return RedirectToAction("IndexLogOut", "Archieves");
            }
            else
            {
                ViewBag.DeleteUserMessage = "Kullanıcı silme işlemi başarısız oldu.";
                return View();
            }
        }
        [HttpGet]
        public IActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddBook(BookViewModel bookViewModel)
        {
            BookValidator bv = new BookValidator();
            ValidationResult vr = bv.Validate(bookViewModel);
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
                if ((await _archievesService.GetBookAsync(bookViewModel)).Value is not null)
                {
                    ViewBag.AddBookMessage = "Hali hazırda var olan bir kitabı tekrar ekleyemezsiniz.";
                    return View();
                }
                else
                {
                    var author = (await _archievesService.GetAuthorAsync(Convert.ToInt32(bookViewModel.AuthorId))).Value;
                    bookViewModel.AuthorName = author.Name;
                    bookViewModel.AuthorSurname = author.Surname;
                    bookViewModel.Status = true;
                    var fileName = await UploadFile(HttpContext.Request.Form.Files["Image"]);
                    bookViewModel.Image = $"/images/{fileName}";
                    await _archievesService.AddBookAsync(bookViewModel);
                    return RedirectToAction("IndexBookDetails", "Archieves", (await _archievesService.GetBooksAsync()).Value.Count);
                }
            }
        }
        #endregion

        #region Methods
        [HttpPost]
        private async Task<bool> Post()
        {
            var captchaImage = HttpContext.Request.Form["g-recaptcha-response"];
            if (string.IsNullOrEmpty(captchaImage))
            {
                ViewBag.LogInMessage = "ReCaptcha boş hatası aldınız.";
                return false;
            }
            var verified = await CheckCaptcha(captchaImage);
            if (!verified)
            {
                ViewBag.LogInMessage = "ReCaptcha 'yı işaretlememe hatası aldınız.";
                return false;
            }
            return true;
        }
        private async Task<bool> CheckCaptcha(string capthcaImage)
        {
            var postData = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("secret", "6LdZ4gwoAAAAAKDbfI6jbyUCp78JEGGWYsIQctMs"),
                new KeyValuePair<string, string>("response", capthcaImage)
            };
            var client = new HttpClient();
            var response = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", new FormUrlEncodedContent(postData));
            var json = (JObject)JsonConvert.DeserializeObject(await response.Content.ReadAsStringAsync());
            return json.Value<bool>("success");
        }
        private async Task<UserViewModel> GetAuthenticatedUser()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var authenticatedUser = (await _archievesService.GetUserAsync(Convert.ToInt32(id))).Value;
            return authenticatedUser;
        }
        private async Task<string> UploadFile(IFormFile? file)
        {
            if (file is not null && file.Length > 0)
            {
                var allowedFileTypes = new[] { ".jpg", ".jpeg", ".png" };
                if (!allowedFileTypes.Contains(Path.GetExtension(file.FileName)))
                {
                    ModelState.AddModelError("ImageFile", "Yalnızca .jpg, .jpeg, .png, .pdf uzantılı dosyalar yükleyebilirsiniz.");
                    return "";
                }
                else
                {
                    var filePath = Path.Combine("wwwroot", "images");
                    var name = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var fileName = Path.Combine(Directory.GetCurrentDirectory(), filePath, name);
                    using (var fileStream = new FileStream(fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return name;
                }
            }
            else
                return "";
        }
        [HttpPost]
        public async Task<IActionResult> SearchBooks(string name)
        {
            if (name is not null)
            {
                _name = name;
                var model = await _archievesService.GetBookListAsync(new BookPagerModel { Number = 1, Size = 9 }, name);
                return View("IndexBook", model);
            }
            else
                return RedirectToAction("IndexBook", "Archieves");
        }
        public IActionResult Book(BookPagerModel bpm)
        {
            _name = null;
            return RedirectToAction("IndexBook", "Archieves", bpm);
        }
        #endregion
    }
}