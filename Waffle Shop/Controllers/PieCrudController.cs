using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Waffle_Shop.Models;

namespace Waffle_Shop.Controllers
{
    [Authorize]
    public class PieCrudController : Controller
    {
        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;

        public PieCrudController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            // Object of PieRepository class
            this.pieRepository = pieRepository;
            this.categoryRepository = categoryRepository;
        }

        /*public IActionResult AllPies()
        {
            var AllPies = pieRepository.AllPies;
            return View(AllPies);
        }*/

        public async Task<ViewResult> AllPies()
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7287/api/Pie/GetAllPies"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            return View(pies);
        }
        public IActionResult Create()
        {
            //application - you have to change this one to get it from API
            var categories = this.categoryRepository.AllCategories;
            List<SelectListItem> categoryItems = new List<SelectListItem>();
            foreach (var category in categories)
            {
                categoryItems.Add(new SelectListItem { Text = category.CategoryName, Value = category.CategoryId.ToString() });
            }

            ViewBag.categoryItems = categoryItems;
            return View();
        }
        public async Task<IActionResult> CreateNewPie(Pie pie)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("https://localhost:7287/api/Pie/InsertPie", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllPies");
        }
        public async Task<IActionResult> Edit(int id)
        {
            var pie = new Pie();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7287/api/Pie/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pie = JsonConvert.DeserializeObject<Pie>(apiResponse);
                }
            }
            return View(pie);
        }
        public async Task<IActionResult> UpdatePie(Pie pie)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync("https://localhost:7287/api/Pie/UpdatePie", pie))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllPies");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var pie = new Pie();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7287/api/Pie/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pie = JsonConvert.DeserializeObject<Pie>(apiResponse);
                }
            }
            return View(pie);
        }
        public async Task<IActionResult> RemovePie(int pieId)
        {
            var id = pieId;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7287/api/Pie/DeletePie?pieID=" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllPies");
        }
    }
}
