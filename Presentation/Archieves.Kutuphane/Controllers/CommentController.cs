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
        private readonly RatingService ratingService;
        public CommentController()
        {
            commentService = new CommentService();
            userService = new UserService();
            ratingService = new RatingService();
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
            if (ratingService.GetAll().Where(x => x.BookId == comment.BookId).Count() > 0)
            {
                var rating = ratingService.GetAll().Where(x => x.BookId == comment.BookId).FirstOrDefault();
                rating.Rate += comment.Rate;
                rating.Count += 1;
                ratingService.Update(rating);
            }
            else
            {
                var rating = new Rating();
                rating.BookId = comment.BookId;
                rating.Rate = comment.Rate;
                rating.Count = 1;
                rating.Date = DateTime.Now;
                rating.Status = true;
                ratingService.Add(rating);
            }
            User authenticatedUser = GetAuthenticatedUser();
            comment.UserId = authenticatedUser.Id;
            comment.Name = authenticatedUser.Name;
            comment.Surname = authenticatedUser.Surname;
            comment.Date = DateTime.Now;
            comment.Status = true;
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
