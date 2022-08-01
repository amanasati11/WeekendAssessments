using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Waffle_Shop.Models;
using Waffle_Shop.ViewModel;

namespace Waffle_Shop.Controllers
{
    [Authorize]
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

        public IActionResult Create()
        {
            return View();
        }
        // Post Action Method
        
        public async Task<IActionResult> CreateCategory(Category category)
        {
            int result = categoryRepository.CreateCategory(category);
            return RedirectToAction("AllCategory");

            /*using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("https://localhost:7287/api/Pie/InsertCategory", category))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllCategory");*/
        }

        
        public async Task<IActionResult> Edit(int id)
        {
            /*var category = new Category();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7287/api/Pie/GetCategory?id=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    category = JsonConvert.DeserializeObject<Category>(apiResponse);
                }
            }
            return View(category);*/

            var categoryFromDb = categoryRepository
                .AllCategories
                .FirstOrDefault(u => u.CategoryId == id);

            return View(categoryFromDb);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category category)
        {


            categoryRepository.UpdateCategory(category);
            return RedirectToAction("AllCategory");
            /*using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync("https://localhost:7287/api/Pie/UpdateCategory", category))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllCategory");*/
        }

        public IActionResult Delete(int id)
        {
            
            var categoryFromDb = categoryRepository
                .AllCategories
                .FirstOrDefault(u => u.CategoryId == id);          
            return View(categoryFromDb);
        }
        [HttpPost]
        public async Task<IActionResult> RemoveCategory(int categoryId)
        {
            /*var id = categoryId;*/
            var student = categoryRepository.AllCategories.FirstOrDefault(student => student.CategoryId == categoryId);
            categoryRepository.RemoveCategory(student);
            return RedirectToAction("AllCategory");
            /*using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7287/api/Pie/DeleteCategory?categoryID=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllCategory");*/
        }
    }
}
