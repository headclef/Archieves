using Archieves.Persistence.Concretes;
using Archieves.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KütüphaneOtomasyonu.ViewComponents.Comment
{
    public class CommentListByBook : ViewComponent
    {
        CommentManager commentManager = new CommentManager(new EfCommentRepository());
        public IViewComponentResult Invoke(int id)
        {
            using (var context = new ArchievesDbContext())
            {
                var values = context.Comments.Include(x => x.Book).Where(x => x.BookId == id).ToList();
                if (values != null)
                    return View(values);
                else
                    return View();
            }
        }
    }
}
