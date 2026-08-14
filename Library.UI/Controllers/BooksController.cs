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

        public async Task<IActionResult> Index(string? searchBy, string? searchByCategory, int page=1, int pageSize=5)
        {
            PaginatedAllBooksDto allBooks = await _bookService.ListAllBooksDto(searchBy, searchByCategory, page, pageSize);
            ViewBag.SearchBy = searchBy;
            ViewBag.SearchByCategory = searchByCategory;
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
