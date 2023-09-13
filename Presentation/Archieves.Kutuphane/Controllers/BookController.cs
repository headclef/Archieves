using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace KütüphaneOtomasyonu.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        BookManager _bookManager = new BookManager(new EfBookRepository());
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var values = _bookManager.GetAll();
            return View(values);
        }
        public IActionResult BookDetails(int id)
        {
            var values = _bookManager.GetAll(id);
            return View(values);
        }
    }
}
