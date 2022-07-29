using Microsoft.AspNetCore.Mvc;
using Waffle_Shop.Models;

namespace Waffle_Shop.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IActionResult AllCategory()
        {
            var category = categoryRepository.AllCategories;
            return View(category);
        }
    }
}
