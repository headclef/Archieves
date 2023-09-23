using Archieves.Persistence.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Archieves.Kutuphane.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        BookService bookService = new BookService(new EfBookRepository());
        public BookController(ILogger<BookController> logger)
        {
            _logger = logger;
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
