using Archieves.Domain.Entities;
using Archieves.Kutuphane.ValidationRules;
using Archieves.Persistence.Concretes;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Archieves.Kutuphane.Controllers
{
    public class UserController : Controller
    {
        private readonly UserService userService;
        private readonly CommentService commentService;
        public UserController()
        {
            userService = new UserService();
            commentService = new CommentService();
        }
        public IActionResult Index()
        {
            List<User> users = GetAuthenticatedUserList();
            return View(users);
        }
        #region Admin Panelindeki Yorum İşlemleri
        public IActionResult CommentsList()
        {
            var authenticatedUser = GetAuthenticatedUser();
            var comments = commentService.GetAllByUserId(authenticatedUser.Id).Where(x => x.Status == true);
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
            return RedirectToAction("CommentsList", "User");
        }
        public IActionResult DeleteComment(int id)
        {
            var comment = commentService.GetById(id);
            comment.Status = false;
            commentService.Update(comment);
            return RedirectToAction("CommentsList", "User");
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
                return RedirectToAction("CommentsList", "User");
            }
        }
        #endregion
        private User GetAuthenticatedUser()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var authenticatedUser = userService.GetAll().Where(u => u.Email == email).FirstOrDefault();
            return authenticatedUser;
        }
        private List<User> GetAuthenticatedUserList()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            List<User> authenticatedUser = userService.GetAll().Where(x => x.Email == email).ToList();
            return authenticatedUser;
        }
    }
}
