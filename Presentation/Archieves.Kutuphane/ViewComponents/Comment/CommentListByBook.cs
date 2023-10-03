using Archieves.Persistence.Concretes;
using Archieves.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Archieves.Kutuphane.ViewComponents.Comment
{
    public class CommentListByBook : ViewComponent
    {
        private readonly CommentService commentService;
        public CommentListByBook()
        {
            commentService = new CommentService();
        }
        public IViewComponentResult Invoke(int id)
        {
            var values = commentService.GetAll().Where(x => x.BookId == id).ToList();
            if (values != null)
                return View(values);
            else
                return View();
        }
    }
}
