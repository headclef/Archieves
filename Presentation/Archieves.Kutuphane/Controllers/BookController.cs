using Archieves.Persistence.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace Archieves.Kutuphane.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService bookService;
        public BookController()
        {
            bookService = new BookService();
        }
        public IActionResult Index()
        {
            var values = bookService.GetAll();
            return View(values);
        }
        public IActionResult BookDetails(int id)
        {
            var values = bookService.GetAll(id);
            return View(values);
        }
    }
}
