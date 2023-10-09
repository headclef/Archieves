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
            User user = GetAuthenticatedUser();
            return View(user);
        }
        #region Kullanıcı Panelindeki Yorum İşlemleri
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
        #region Kullanıcı Panelindeki Profil İşlemleri
        [HttpGet]
        public IActionResult Profile()
        {
            var authenticatedUser = GetAuthenticatedUser();
            return View(authenticatedUser);
        }
        [HttpPost]
        public IActionResult Profile(User user)
        {
            var authenticatedUser = GetAuthenticatedUser();
            var controlledUser = ControlPropertiesOfUser(user);
            UserValidator uv = new UserValidator();
            ValidationResult vr = uv.Validate(user);
            if (!vr.IsValid)
            {
                foreach (var item in vr.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(GetAuthenticatedUser());
            }
            else
            {
                user.Id = authenticatedUser.Id;
                user.Date = controlledUser.ElementAt(0) == false ? authenticatedUser.Date : user.Date;
                user.Image = controlledUser.ElementAt(1) == false ? authenticatedUser.Image : user.Image;
                userService.Update(user);
            }
            return RedirectToAction("LogOut", "LogIn");
        }
        public IActionResult DeleteUser()
        {
            var authenticatedUser = GetAuthenticatedUser();
            authenticatedUser.Status = false;
            userService.Update(authenticatedUser);
            return RedirectToAction("LogOut", "LogIn");
        }
        #endregion
        private User GetAuthenticatedUser()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var authenticatedUser = userService.GetAll().Where(u => u.Email == email).FirstOrDefault();
            return authenticatedUser;
        }
        private ICollection<bool> ControlPropertiesOfUser(User user)
        {
            bool Date = user.Date == null ? false : true;
            bool Image = user.Image == null ? false : true;
            return new List<bool>() { Date, Image};
        }
    }
}
