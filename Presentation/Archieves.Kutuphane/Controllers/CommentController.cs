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
        private readonly BookService bookService;
        public CommentController()
        {
            commentService = new CommentService();
            userService = new UserService();
            bookService = new BookService();
        }
        public IActionResult Index()
        {
            return View();
        }
        #region Kitap Detayları Sayfasındaki Yorum İşlemleri
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            // Hali hazırda authenticated.
            User authenticatedUser = GetAuthenticatedUser();
            comment.UserId = authenticatedUser.Id;
            comment.Name = authenticatedUser.Name;
            comment.Surname = authenticatedUser.Surname;
            comment.Status = true;
            comment.Date = DateTime.Now;

            commentService.Add(comment);
            return PartialView();   //TODO: Yorum eklendikten sonra, yorumlar yeniden listelenmeli.
                                    //TODO: Yorum eklendikten sonra, yorum ekleme alanı temizlenmeli.
                                    //TODO: Yorum eklendikten sonra, sayfanın değişmemesi sağlanmalı.
        }
        #endregion
        #region Admin Panelindeki Yorum İşlemleri
        public IActionResult CommentsList() // TODO: Yorumlar listelenirken oluşan hatalar giderilmeli.
        {
            var authenticatedUser = GetAuthenticatedUser();
            var comments = commentService.GetAllByUserId(authenticatedUser.Id);
            return View(comments);
        }
        [HttpGet]
        public IActionResult UpdateComment(int id)
        {
            return View(commentService.GetById(id));
        }
        [HttpPost]
        public IActionResult UpdateComment(Comment comment)
        {
            commentService.Update(comment);
            return RedirectToAction("CommentsList", "Comment");
        }
        public IActionResult DeleteComment(int id)
        {
            commentService.Delete(commentService.GetById(id));
            return RedirectToAction("CommentsList", "Comment");
        }
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            CommentValidator cv = new CommentValidator();
            ValidationResult vr = cv.Validate(comment);
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
                var user = GetAuthenticatedUser();
                comment.UserId = user.Id;
                comment.Name = user.Name;
                comment.Surname = user.Surname;
                comment.Status = true;
                comment.Date = DateTime.Now;
                commentService.Add(comment);
                return RedirectToAction("CommentsList", "Comment");
            }
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
