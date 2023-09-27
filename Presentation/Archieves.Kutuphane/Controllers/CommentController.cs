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
        CommentService commentService = new CommentService(new EfCommentRepository());
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
                if (User.Identity.IsAuthenticated) //TODO: User verilerine erişim sağlanarak, atanma gerçekleştirilmeli.
                {
                    string email = User.FindFirstValue(ClaimTypes.Email);
                    var authenticatedUser = context.Users.SingleOrDefault(x => x.Email == email);
                    comment.UserId = authenticatedUser.Id;
                    comment.Name = authenticatedUser.Name;
                    comment.Surname = authenticatedUser.Surname;
                    comment.Status = true;
                    comment.Date = DateTime.Now;

                    commentService.Add(comment);
                }
            }
            return PartialView();
        }
    }
}
