using Archieves.Kutuphane.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.ViewComponents.Admin
{
    public class LatestBooks : ViewComponent
    {
        private readonly IBookService _bookService;
        public LatestBooks(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}