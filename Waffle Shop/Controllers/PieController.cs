using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult List()
        {
            ViewBag.CurrentCategory = "Cheese Waffles";

            // Got the Pie Data
            var pies = pieRepository.AllPies;
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
        public ViewResult Details(int id)                        // action method
        {
            var pie = pieRepository
                .GetPieById(id);
                
            return View(pie);
        }
        public ViewResult PiesOfTheWeek()
        {
            var pie = pieRepository.PiesOfTheWeek;
            return View(pie);

        }
    }
}
