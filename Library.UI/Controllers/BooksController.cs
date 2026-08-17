using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService,
            IWebHostEnvironment webHostEnvironment)
        {
            _bookService = bookService;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index(string? searchBy, string? searchByCategory, int page=1, int pageSize=4)
        {
            PaginatedAllBooksDto allBooks = await _bookService.ListAllBooksAsync(searchBy, searchByCategory, page, pageSize);
            ViewBag.SearchBy = searchBy;
            ViewBag.SearchByCategory = searchByCategory;
            return View(allBooks);
        }

        public async Task<IActionResult> AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(AddBookDto book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(e => e.Errors).Select(e1 => e1.ErrorMessage).ToList();
                return View();
            }

            string? fileName = null;
            string? filePath = null;

            try
            {
                #region ImageUpload Operation
                
                if (book.Image != null && book.Image.Length > 0)
                {
                    // Create folder
                    var uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "img");

                    Directory.CreateDirectory(uploadFolder);

                    // Unique file name
                    fileName = $"{Guid.NewGuid()}{Path.GetExtension(book.Image.FileName)}";

                    // File Path
                    filePath = Path.Combine(uploadFolder, fileName);

                    // File uploading
                    await using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await book.Image.CopyToAsync(stream);
                    }
                }
                #endregion
                
                book.ImageFileName = fileName;
                AddBookDto result = await _bookService.AddBookAsync(book);
            }
            catch
            {
                // if db -> failed, remove uploaded file
                if (filePath != null && System.IO.File.Exists(filePath))
                {
                    System.IO.File.Delete(filePath);
                }

                throw;
            }

            // it will make another get request to "books/Index"
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditBook(Guid id)
        {
            EditBookDto editBookDto = await _bookService.EditBookAsync(id);
            return View(editBookDto);
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
