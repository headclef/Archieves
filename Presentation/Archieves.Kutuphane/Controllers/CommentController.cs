using Archieves.Domain.Entities;
using Archieves.Kutuphane.ValidationRules;
using Archieves.Persistence.Concretes;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Archieves.Kutuphane.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentService commentService;
        private readonly UserService userService;
        public CommentController()
        {
            commentService = new CommentService();
            userService = new UserService();
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Kitap Detayları Sayfasındaki Yorum İşlemleri
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult AddCommentPartial(Comment comment)
        {
            User authenticatedUser = GetAuthenticatedUser();
            comment.UserId = authenticatedUser.Id;
            comment.Name = authenticatedUser.Name;
            comment.Surname = authenticatedUser.Surname;
            comment.Status = true;
            comment.Date = DateTime.Now;
            commentService.Add(comment);
            return RedirectToAction("BookDetails", "Book", new { id = comment.BookId });
        }
        #endregion
        private User GetAuthenticatedUser()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var authenticatedUser = userService.GetAll().Where(u => u.Email == email).FirstOrDefault();
            return authenticatedUser;
        }
    }
}
