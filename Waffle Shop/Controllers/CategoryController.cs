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

        // Get Action Method
        public IActionResult Create()
        {
            return View();
        }

        // Get Action Method
        public IActionResult Edit(int id)
        {
            
            var categoryFromDb = categoryRepository
                .AllCategories
                .FirstOrDefault(u => u.CategoryId == id);
            
            return View(categoryFromDb);
        }

        public IActionResult Delete(int id)
        {
            
            var categoryFromDb = categoryRepository
                .AllCategories
                .FirstOrDefault(u => u.CategoryId == id);          
            return View(categoryFromDb);
        }
    }
}
