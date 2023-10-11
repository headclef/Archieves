using Archieves.Kutuphane.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.ViewComponents.Comment
{
    public class CommentListByBook : ViewComponent
    {
        private readonly ICommentService _commentService;
        public CommentListByBook(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.GetAllCommentsByBookIdAsync(id).Result.Value;
            if (values != null)
                return View(values);
            else
                return View();
        }
    }
}
