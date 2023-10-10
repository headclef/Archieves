using Archieves.Kutuphane.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        public IActionResult Index()
        {
            var values = _bookService.GetAllBooksAsync();
            return View(values);
        }
        public IActionResult BookDetails(int id)
        {
            var values = _bookService.GetAllBooksByIdAsync(id);
            return View(values);
        }
    }
}
