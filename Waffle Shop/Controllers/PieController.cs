using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Waffle_Shop.Models;
using Waffle_Shop.ViewModel;

namespace Waffle_Shop.Controllers
{
    public class PieController : Controller
    {
        private readonly IMapper mapper; 
        // Field - Object for Repository Class
        private readonly IPieRepository pieRepository;

        public PieController(IPieRepository pieRepository, IMapper mapper)
        {   
            // Object of PieRepository class
            this.pieRepository = pieRepository;
            this.mapper = mapper;
        }
        [Authorize]
        public async Task<ViewResult> List()
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
            ViewBag.CurrentCategory = "Cheese Waffles";

            // Got the Pie Data
            /*var pies = pieRepository.AllPies;*/
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            pieListViewModel.CurrentCategory = "Cheese Cake";

            // Passing data to view
            return View(pieListViewModel);

            //var pies = pieRepository.AllPies;
            //var pieMini = mapper.Map<PieMini>(pies);
            //return View(pieMini);
        }
        [Authorize]
        public async Task<IActionResult> Details(int id)                        // action method
        {
            /*var pie = pieRepository
                .GetPieById(id);
                
            return View(pie);*/
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
        public async Task<ViewResult> PiesOfTheWeek()
        {
            IEnumerable<Pie> pies = new List<Pie>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7287/api/Pie/PieOfTheWeek"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    pies = JsonConvert.DeserializeObject<IEnumerable<Pie>>(apiResponse);
                }
            }
            /*var pie = pieRepository.PiesOfTheWeek;
            return View(pie);*/
            PieListViewModel pieListViewModel = new PieListViewModel();
            pieListViewModel.Pies = pies;
            return View(pies);
        }
    }
}
