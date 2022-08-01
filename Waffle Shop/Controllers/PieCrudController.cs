using Microsoft.AspNetCore.Mvc;
using Waffle_Shop.Models;

namespace Waffle_Shop.Controllers
{
    public class PieCrudController : Controller
    {
        private readonly IPieRepository pieRepository;

        public PieCrudController(IPieRepository pieRepository)
        {
            // Object of PieRepository class
            this.pieRepository = pieRepository;
        }

        public IActionResult AllPies()
        {
            var AllPies = pieRepository.AllPies;
            return View(AllPies);
        }

        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateNewPie(Pie pie)
        {
            int result = pieRepository.CreatePie(pie);
            return RedirectToAction("AllPies");
            /*using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("https://localhost:7287/api/Pie/InsertCategory", category))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllCategory");*/
        }
        public IActionResult Edit(int id)
        {

            var PieFromDb = pieRepository
                .AllPies
                .FirstOrDefault(u => u.PieId == id);
            return View(PieFromDb);
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePie(Pie pie)
        {


            pieRepository.UpdatePie(pie);
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

            var pieFromDb = pieRepository
                .AllPies
                .FirstOrDefault(u => u.PieId == id);
            return View(pieFromDb);
        }
        [HttpPost]
        public async Task<IActionResult> RemovePie(int pieId)
        {
            /*var id = categoryId;*/
            var pie = pieRepository.AllPies.FirstOrDefault(u => u.PieId == pieId);
            pieRepository.RemovePie(pie);
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
