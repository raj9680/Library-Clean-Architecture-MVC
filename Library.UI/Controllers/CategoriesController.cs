using Library.Application.DTOs;
using Library.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Library.UI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(string searchByName, int result = 10)
        {
            List<CategoryDto> cat = await _categoryService.ListAllCategoryAsync(searchByName);
            ViewBag.SearchBy = searchByName;
            TempData["DeletedResult"] = result;
            return View(cat);
        }

        public async Task<IActionResult> AddCategory()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto category)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(e => e.Errors).Select(e1 => e1.ErrorMessage).ToList();
                return View(category);
            }
            int updated = await _categoryService.AddCategoryAsync(category);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditCategory(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return View();
            }
            CategoryDto cDto = await _categoryService.GetCategoryByIdAsync(Id);
            return View(cDto);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(CategoryDto cat)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Errors = ModelState.Values.SelectMany(e => e.Errors).Select(e1 => e1.ErrorMessage).ToList();
                return View(cat);
            }

            await _categoryService.EditCategoryAsync(cat);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteCategory(Guid Id)
        {
            if (Id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }
            
            int res = await _categoryService.DeleteCategoryAsync(Id);
            return RedirectToAction("Index", new { result = res});
        }
    }
}
