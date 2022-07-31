using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PieShopAPI.Models;

namespace PieShopAPI.Controllers
{

    [ApiController]
    [Route("api/Pie")]
    public class PieController : ControllerBase
    {
        private readonly IMapper mapper;

        private readonly IPieRepository pieRepository;
        private readonly ICategoryRepository categoryRepository;

        public PieController(IMapper mapper, IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            this.mapper = mapper;
            this.pieRepository = pieRepository;
            this.categoryRepository = categoryRepository;
        }
        [HttpGet]
        [Route("GetAllPies")]
        public IActionResult GetAllPies()
        {
            try
            {
                var pies = this.pieRepository.AllPies;
               
                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpGet]
        [Route("GetPieOfTheWeek")]
        public IActionResult GetPieOfTheWeek()
        {
            try
            {
                var pies = this.pieRepository.PiesOfTheWeek;

                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpGet]
        [Route("GetFruitPies")]
        public IActionResult GetFruitPies()
        {
            try
            {
                var pies = this.pieRepository.FruitsPies();

                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpGet]
        [Route("GetCheesePies")]
        public IActionResult GetCheesePies()
        {
            try
            {
                var pies = this.pieRepository.CheesePies();

                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpGet]
        [Route("GetSeasonalPies")]
        public IActionResult GetSeasonalPies()
        {
            try
            {
                var pies = this.pieRepository.SeasonalPies();

                return Ok(pies);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpGet]
        [Route("Details")]
        public IActionResult Details(int id)
        {
            //got the pie data
            var pies = this.pieRepository.AllPies.FirstOrDefault(pies => pies.PieId == id);

            //passing data to view
            return Ok(pies);

        }
        [HttpPost]
        [Route("InsertPie")]
        public IActionResult InsertPie(Pie pie)
        {
            try
            {
                var insertedPie = this.pieRepository.InsertPie(pie);
                return CreatedAtRoute("GetAllPies", new { id = insertedPie.PieId },insertedPie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpPut]
        [Route("UpdatePie")]
        public IActionResult UpdateStudent(Pie pie)
        {
            try
            {
                var updatePie = this.pieRepository.UpdatePie(pie);
                return Ok(updatePie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
        [HttpDelete]
        [Route("DeletePie")]
        public IActionResult DeleteStudent(int pieId)
        {
            try
            {
                var deletepie = this.pieRepository.DeletePie(pieId);
                return Ok(deletepie);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Server error");
            }
        }
    }
}
