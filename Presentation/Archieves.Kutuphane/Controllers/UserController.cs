using Archieves.Kutuphane.Models.Comment;
using Archieves.Kutuphane.Models.User;
using Archieves.Kutuphane.Models.Rating;
using Archieves.Kutuphane.Services.Abstractions;
using Archieves.Kutuphane.ValidationRules;
using AutoMapper;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Archieves.Kutuphane.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICommentService _commentService;
        private readonly IRatingService _ratingService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, ICommentService commentService, IRatingService ratingService, IMapper mapper)
        {
            _userService = userService;
            _commentService = commentService;
            _ratingService = ratingService;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var user = await GetAuthenticatedUserAsync();
            return View(user);
        }
        #region Kullanıcı Panelindeki Yorum İşlemleri
        public async Task<IActionResult> CommentsList()
        {
            var authenticatedUser = await GetAuthenticatedUserAsync();
            var result = await _commentService.GetAllCommentsByUserIdandStatusAsync(authenticatedUser.Id, true);
            if (result.IsSuccess)
            {
                var comments = result.Value;
                return View(comments);
            }
            else
                return RedirectToAction("Error1", "Error");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateComment(int id)
        {
            var comment = (await _commentService.GetCommentByIdAsync(id)).Value;
            return View(comment);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateComment(CommentViewModel comment)
        {
            var updateComment = _mapper.Map<CommentUpdateModel>(comment);
            var rating = (await _ratingService.GetAllRatingsByBookIdAsync(comment.BookId)).Value.SingleOrDefault();
            if (rating is not null)
            {
                rating.Rate = comment.Rate;
                var updateRating = _mapper.Map<RatingUpdateModel>(rating);
                var ratingResult = await _ratingService.UpdateRatingAsync(updateRating);
                if (ratingResult.IsSuccess)
                {
                    ViewBag.ErrorMessage = "İşlem Başarılı.";
                    var commentResult = await _commentService.UpdateCommentAsync(updateComment);
                    if (commentResult.IsSuccess)
                    {
                        return RedirectToAction("CommentsList", "User");
                    }
                    else
                    {
                        return View(comment);
                    }
                }
                else
                {
                    return View(comment);
                }
            }
            else
            {
                return View(comment);
            }
        }
        public async Task<IActionResult> ReActivateComment(int id)
        {
            var result = await _commentService.GetCommentByIdAsync(id);
            if (result.IsSuccess)
            {
                var comment = result.Value;
                comment.Status = true;
                var updateComment = _mapper.Map<CommentUpdateModel>(comment);
                var updateResult = await _commentService.UpdateCommentAsync(updateComment);
                if (updateResult.IsSuccess)
                {
                    ViewBag.ErrorMessage = "İşlem başarılı!";
                    return RedirectToAction("CommentsList", "User");
                }
                else
                {
                    ViewBag.ErrorMessage = "An error occured while updating comment!";
                    return RedirectToAction("CommentsList", "User");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "An error occured while getting comment!";
                return RedirectToAction("CommentsList", "User");
            }
        }
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _commentService.GetCommentByIdAsync(id);
            if (result.IsSuccess)
            {
                var comment = result.Value;
                comment.Status = false;
                var updateComment = _mapper.Map<CommentUpdateModel>(comment);
                var updateResult = await _commentService.UpdateCommentAsync(updateComment);
                if (updateResult.IsSuccess)
                {
                    ViewBag.ErrorMessage = "İşlem başarılı!";
                    return RedirectToAction("CommentsList", "User");
                }
                else
                {
                    ViewBag.ErrorMessage = "An error occured while updating comment!";
                    return RedirectToAction("CommentsList", "User");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "An error occured while getting comment!";
                return RedirectToAction("CommentsList", "User");
            }
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
                var user = GetAuthenticatedUserAsync();
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
        public async Task<IActionResult> Profile()
        {
            var authenticatedUser = await GetAuthenticatedUserAsync();
            var userUpdateModel = _mapper.Map<UserUpdateModel>(authenticatedUser);
            return View(userUpdateModel);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserUpdateModel user)
        {
            var verifyUser = await FillInTheBlanks(user);
            var result = await _userService.UpdateUserAsync(verifyUser);
            if (result.IsSuccess)
            {
                var verifiedUser = result.Value;
                // return RedirectToAction("LogOut", "LogIn");
                return RedirectToAction("Profile", "User");
            }
            else
            {
                return RedirectToAction("Profile", "User");
            }
        }
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await GetAuthenticatedUserAsync(id);
            if (user is not null)
            {
                var updateUserControl = _mapper.Map<UserUpdateModel>(user);
                updateUserControl.Status = false;
                var updateUserResult = await _userService.UpdateUserAsync(updateUserControl);
                if (updateUserResult.IsSuccess)
                {
                    return RedirectToAction("Profile", "User");
                }
                else
                {
                    return RedirectToAction("Profile", "User");
                }
            }
            else
            {
                return RedirectToAction("Profile", "User");
            }
        }
        #endregion
        #region User Getters
        private async Task<UserViewModel?> GetAuthenticatedUserAsync()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var userResult = await _userService.GetUserByEmailAsync(email);
            if (userResult.IsSuccess)
            {
                var user = userResult.Value;
                return user;
            }
            else
            {
                return null;
            }
        }
        private async Task<UserViewModel?> GetAuthenticatedUserAsync(int id)
        {
            var userResult = await _userService.GetUserByIdAsync(id);
            if (userResult.IsSuccess)
            {
                var user = userResult.Value;
                return user;
            }
            else
            {
                return null;
            }
        }
        #endregion
        #region Input Verifier
        private async Task<UserUpdateModel> FillInTheBlanks(UserUpdateModel userUpdateModel)
        {
            var user = await GetAuthenticatedUserAsync();
            if (userUpdateModel.Name == String.Empty)
                userUpdateModel.Name = user.Name;
            if (userUpdateModel.Surname == String.Empty)
                userUpdateModel.Surname = user.Surname;
            if (userUpdateModel.Email == String.Empty)
                userUpdateModel.Email = user.Email;
            if (userUpdateModel.Password == String.Empty)
                userUpdateModel.Password = user.Password;
            if (userUpdateModel.Phone == String.Empty)
                userUpdateModel.Phone = user.Phone;
            if (userUpdateModel.Address == String.Empty)
                userUpdateModel.Address = user.Address;
            if (userUpdateModel.Image == String.Empty)
                userUpdateModel.Image = user.Image;
            return userUpdateModel;
        }
        #endregion
    }
}
