using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.ViewComponents
{
    public class BookDropdownViewComponent: ViewComponent
    {
        private readonly IBookService _bookService;
        public BookDropdownViewComponent(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BooksDropdownDto> book = await _bookService.GetAllBooks();
            return View(book);
        }
    }
}
