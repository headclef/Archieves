using Archieves.Domain.Entities;
using Archieves.Persistence.Concretes;
using Archieves.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
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
        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialAddComment(Comment comment)
        {
            using (var context = new ArchievesDbContext())
            {
                if (User.Identity.IsAuthenticated)
                {
                    User authenticatedUser = GetAuthenticatedUser();
                    comment.UserId = authenticatedUser.Id;
                    comment.Name = authenticatedUser.Name;
                    comment.Surname = authenticatedUser.Surname;
                    comment.Status = true;
                    comment.Date = DateTime.Now;

                    commentService.Add(comment);
                }
            }
            return PartialView();   //TODO: Yorum eklendikten sonra, yorumlar yeniden listelenmeli.
                                    //TODO: Yorum eklendikten sonra, yorum ekleme alanı temizlenmeli.
                                    //TODO: Yorum eklendikten sonra, sayfanın değişmemesi sağlanmalı.
        }
        public async Task<IActionResult> CommentsList() // TODO: Yorumlar listelenirken oluşan hatalar giderilmeli.
        {
            var authenticatedUser = GetAuthenticatedUser();
            var comments = commentService.GetAllByUserId(authenticatedUser.Id);
            return View(comments);
        }
        private User GetAuthenticatedUser()
        {
            string email = User.FindFirstValue(ClaimTypes.Email);
            var authenticatedUser = userService.GetAll().Where(u => u.Email == email).FirstOrDefault();
            return authenticatedUser;
        }
    }
}
