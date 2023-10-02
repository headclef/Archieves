using Archieves.Persistence.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Archieves.Kutuphane.Controllers
{
    public class BookController : Controller
    {
        BookService bookService = new BookService();
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
