using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            List<AllBooksDto> allBooks = await _bookService.ListAllBooksDto();
            return View(allBooks);
        }

        public IActionResult AddBook()
        {
            return View();
        }

        public IActionResult EditBook()
        {
            return View();
        }

        public IActionResult IssueBook()
        {
            return View();
        }
        
        public IActionResult ReturnBook()
        {
            return View();
        }

        public IActionResult DeleteBook()
        {
            return RedirectToAction("Index");
        }
    }
}
