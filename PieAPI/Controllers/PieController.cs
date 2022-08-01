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
        [HttpGet("{id}", Name = "GetPieID")]
        public IActionResult GetPieID(int id)
        {
            try
            {
                var student = this.pieRepository.AllPies.FirstOrDefault(student => student.PieId == id);
                if (student == null)
                    return NotFound("Pie Not found For this ID");
                return Ok(student);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }

        }
        [HttpPost]
        [Route("InsertPie")]
        public IActionResult InsertPie(Pie pie)
        {
            try
            {
                var NewPie = this
                                .pieRepository
                                .InsertPie(pie);
                return Ok(NewPie);
                /*return CreatedAtRoute("GetPieID", new { NewPie.PieId }, NewPie);*/
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpPut]
        [Route("UpdatePie")]
        public IActionResult UpdatePie(Pie pie)
        {
            try
            {
                var updatedPie = this
                                .pieRepository
                                .UpdatePie(pie);
                return Ok(updatedPie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpDelete]
        [Route("DeletePie")]
        public IActionResult DeletePie(int pieID)
        {
            try
            {
                var DeletedPie = this
                    .pieRepository
                    .DeletePie(pieID);
                return Ok(DeletedPie);
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
        /*[HttpGet("{id}", Name = "GetCategory")]*/
        [HttpGet]
        [Route("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            try
            {
                var category = this.categoryRepository.AllCategories.FirstOrDefault(category => category.CategoryId == id);
                if (category == null)
                    return NotFound("Category Not found For this ID");
                return Ok(category);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpPost]
        [Route("InsertCategory")]
        public IActionResult InsertCategory(Category category)
        {

            try
            {
                var InsertCategory = this
                                .categoryRepository
                                .InsertCategory(category);
                return Ok(InsertCategory);
                /*return CreatedAtRoute("GetCategory", new { id = InsertCategory.CategoryId }, InsertCategory);*/
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpPut]
        [Route("UpdateCategory")]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {
                var UpdatedCategory = this
                                .categoryRepository
                                .UpdateCategory(category);
                return Ok(UpdatedCategory);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
        [HttpDelete]
        [Route("DeleteCategory")]
        public IActionResult DeleteCategory(int categoryID)
        {
            try
            {
                var category = this.categoryRepository.AllCategories.FirstOrDefault(category => category.CategoryId == categoryID);
                if (category == null)
                {
                    return BadRequest("Category not found, try some other valid id");
                }
                var DeletedCategory = this
                    .categoryRepository
                    .DeleteCategory(categoryID);
                return Ok(DeletedCategory);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server Error");
            }
        }
    }
}
