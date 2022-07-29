using Microsoft.AspNetCore.Mvc;
using PieAPI.Models;

namespace PieAPI.Controllers
{
    [ApiController]
    [Route("api/Pie")]
    public class PieController : ControllerBase
    {
        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this.pieRepository = pieRepository;
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        [Route("GetAllPies")]
        public IActionResult GetAllPies()
        {
            try
            {
                var AllPies = this.pieRepository.AllPies;
                return Ok(AllPies);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpGet]
        [Route("PieOfTheWeek")]
        public IActionResult PieOfTheWeek()
        {
            try
            {
                var PieOfTheWeek = this.pieRepository.PiesOfTheWeek;
                return Ok(PieOfTheWeek);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpGet]
        [Route("GetAllCategories")]
        public IActionResult GetAllCategories()
        {
            try
            {
                var AllCategories = this.categoryRepository.AllCategories;
                return Ok(AllCategories);

            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
    }
}
