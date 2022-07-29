using Microsoft.AspNetCore.Mvc;
using Waffle_Shop.Models;

namespace Waffle_Shop.Components
{
    public class CategoryMenuNew: ViewComponent
    {
        private ICategoryRepository categoryRepository;

        public CategoryMenuNew(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;    
        }
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
