using Microsoft.AspNetCore.Mvc;
using Waffle_Shop.Models;

namespace Waffle_Shop.Components
{
    public class CategoryMenu: ViewComponent
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryMenu(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IViewComponentResult Invoke()
        {
            var categories = this.categoryRepository.AllCategories;
            return View(categories);
        }
    }
}
