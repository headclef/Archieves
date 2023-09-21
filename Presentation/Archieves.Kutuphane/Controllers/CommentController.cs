using Archieves.Persistence.Concretes;
using Archieves.Persistence.Contexts;
using KütüphaneOtomasyonu.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
                var doesExist = context.Users.Where(x => x.Name == comment.Name && x.Surname == comment.Surname).ToList();
                if (doesExist.Any())
                {
                    foreach (var item in doesExist)
                        comment.UserId = item.Id;
                    comment.BookId = 4; //TODO: BookId should be dynamic
                    comment.Status = true;
                    comment.Date = DateTime.Now;
                    commentService.Add(comment);
                }
            }
            return PartialView();
        }
    }
}
