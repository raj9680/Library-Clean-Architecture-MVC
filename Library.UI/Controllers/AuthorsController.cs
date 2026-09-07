using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IActionResult> Index(int page=1, int pageSize=4, string? searchByName = null, int result = 10)
        {
            PaginatedAllAuthorsDto allAuthorDto = await _authorService.GetAllAuthorsAsync(page, pageSize, searchByName);
            TempData["DeletedResult"] = result;
            return View(allAuthorDto);
        }

        public IActionResult AddAuthor()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> AddAuthor(AuthorDto author)
        {
            ViewBag.Country = author.CountryId;
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(e => e.Errors).Select(el => el.ErrorMessage).ToList();
                return View(author);
            }

            await _authorService.AddAuthorAsync(author);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> EditAuthor(Guid id)
        {
            if(id == Guid.Empty)
            {
                RedirectToAction("Index");
            }

            AuthorDto author = await _authorService.GetAuthorByIdAsync(id);
            ViewBag.Country = author.CountryId;
            return View(author);
        }


        [HttpPost]
        public async Task<IActionResult> EditAuthor(AuthorDto author)
        {
            ViewBag.Country = author.CountryId;
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(e => e.Errors).Select(el => el.ErrorMessage).ToList();
                return View(author);
            }

            int updatedRows = await _authorService.UpdateAuthorAsync(author);
            if (updatedRows == 0)
                throw new NullReferenceException("Not updated");

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteAuthor(Guid Id)
        {
            if(Id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            int result = await _authorService.DeleteAuthorAsync(Id);

            return RedirectToAction("Index", new { result = result });
        }
    }
}
