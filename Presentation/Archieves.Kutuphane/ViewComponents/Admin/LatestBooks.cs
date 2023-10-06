using Archieves.Persistence.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.ViewComponents.Admin
{
    public class LatestBooks : ViewComponent
    {
        BookService bookService;
        public LatestBooks()
        {
            bookService = new BookService();
        }
        public IViewComponentResult Invoke(int id)
        {
            return View();
        }
    }
}