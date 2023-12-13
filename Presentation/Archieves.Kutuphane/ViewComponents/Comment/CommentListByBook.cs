using Archieves.Kutuphane.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.ViewComponents.Comment
{
    public class CommentListByBook : ViewComponent
    {
        private readonly IArchievesService _archievesService;
        public CommentListByBook(IArchievesService archievesService)
        {
            _archievesService = archievesService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var values = _archievesService.GetCommentsAsync(id).Result.Value;
            if (values != null)
                return View(values);
            else
                return View();
        }
    }
}
