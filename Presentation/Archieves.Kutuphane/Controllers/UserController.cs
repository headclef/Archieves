using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Services.Abstractions;
using Archieves.Kutuphane.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Archieves.Kutuphane.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        public UserController(IUserService userService, ICommentService commentService)
        {
            _userService = userService;
            _commentService = commentService;
        }
        public IActionResult Index()
        {
            UserViewModel user = GetAuthenticatedUser();
            return View(user);
        }
        #region Kullanıcı Panelindeki Yorum İşlemleri
        public IActionResult CommentsList()
        {
            var authenticatedUser = GetAuthenticatedUser();
            var comments = _commentService.GetAllCommentsAsync(authenticatedUser.Id, true).Result.Value;
            return View(comments);
        }
        [HttpGet]
        public IActionResult UpdateComment(int id)
        {
            return View(_commentService.GetCommentByIdAsync(id));
        }
        [HttpPost]
        public IActionResult UpdateComment(CommentUpdateModel comment)
        {
            _commentService.UpdateCommentAsync(comment);
            return RedirectToAction("CommentsList", "User");
        }
        public IActionResult DeleteComment(int id)
        {
            var comment = _commentService.GetCommentByIdAsync(id).Result.Value;
            comment.Status = false;
            CommentUpdateModel commentUpdateModel = new CommentUpdateModel
            {
                Id = comment.Id,
                Content = comment.Content,
                Rate = comment.Rate,
                Date = comment.Date,
                Status = false,
            };
            _commentService.UpdateCommentAsync(commentUpdateModel);
            return RedirectToAction("CommentsList", "User");
        }
        [HttpGet]
        public IActionResult AddComment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddComment(CommentAddModel comment)
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
                comment.Status = true;
                comment.Date = DateTime.Now;
                _commentService.AddCommentAsync(comment);
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
        public IActionResult Profile(UserUpdateModel user)
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
                _userService.UpdateUserAsync(user);
            }
            return RedirectToAction("LogOut", "LogIn");
        }
        public IActionResult DeleteUser()
        {
            var authenticatedUser = GetAuthenticatedUser();
            UserUpdateModel userUpdateModel = new UserUpdateModel
            {
                Id = authenticatedUser.Id,
                Name = authenticatedUser.Name,
                Surname = authenticatedUser.Surname,
                Email = authenticatedUser.Email,
                Password = authenticatedUser.Password,
                Phone = authenticatedUser.Phone,
                Address = authenticatedUser.Address,
                Image = authenticatedUser.Image,
                Date = authenticatedUser.Date,
                Status = false,
            };
            _userService.UpdateUserAsync(userUpdateModel);
            return RedirectToAction("LogOut", "LogIn");
        }
        #endregion
        private UserViewModel GetAuthenticatedUser()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var authenticatedUser = _userService.GetUserByEmailAsync(email).Result.Value;
            return authenticatedUser;
        }
        private ICollection<bool> ControlPropertiesOfUser(UserUpdateModel user)
        {
            bool Date = user.Date == null ? false : true;
            bool Image = user.Image == null ? false : true;
            return new List<bool>() { Date, Image};
        }
    }
}
