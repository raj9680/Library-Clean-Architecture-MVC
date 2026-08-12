using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.ViewComponents
{
    public class CategoryDropdownViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoryDropdownViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetAllCategoryAsync();
            return View(categories);
        }
    }
}
