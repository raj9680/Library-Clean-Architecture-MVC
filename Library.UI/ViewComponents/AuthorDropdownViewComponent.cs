using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.ViewComponents
{
    public class AuthorDropdownViewComponent: ViewComponent
    {
        private readonly IAuthorService _authorService;
        public AuthorDropdownViewComponent(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<AuthorDto> authors = await _authorService.GetAllAuthorAsync();
            return View(authors);
        }
    }
}
