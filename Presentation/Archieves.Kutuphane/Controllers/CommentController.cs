using Archieves.Domain.Entities;
using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.Rating;
using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Archieves.Kutuphane.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IRatingService _ratingService;
        public CommentController(ICommentService commentService, IUserService userService, IRatingService ratingService)
        {
            _commentService = commentService;
            _userService = userService;
            _ratingService = ratingService;
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
        public IActionResult AddCommentPartial(CommentAddModel comment)
        {
            if (_ratingService.GetAllRatingsByBookIdAsync(comment.BookId) is not null)
            {
                var rating = new RatingUpdateModel();
                rating.Rate = comment.Rate;
                _ratingService.UpdateRatingAsync(rating);
            }
            else
            {
                var rating = new RatingAddModel();
                rating.BookId = comment.BookId;
                rating.Rate = comment.Rate;
                rating.Count = 1;
                rating.Date = DateTime.Now;
                rating.Status = true;
                _ratingService.AddRatingAsync(rating);
            }
            UserViewModel authenticatedUser = GetAuthenticatedUser();
            comment.UserId = authenticatedUser.Id;
            comment.Date = DateTime.Now;
            comment.Status = true;
            _commentService.AddCommentAsync(comment);
            return RedirectToAction("BookDetails", "Book", new { id = comment.BookId });
        }
        #endregion
        private UserViewModel GetAuthenticatedUser()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var authenticatedUser = _userService.GetUserByEmailAsync(email).Result.Value;
            return authenticatedUser;
        }
    }
}
