using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerDBWebApp.Server.Services.CareerHistoryServices;
using SoccerDBWebApp.Shared.Models.CareerHistory;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CareerHistoryController : ControllerBase
    {
        // Field & Constructor to access service methods
        private readonly ICareerHistoryService _careerHistoryService;
        public CareerHistoryController(ICareerHistoryService careerHistoryService)
        {
            _careerHistoryService = careerHistoryService;
        }


        // CreateCareerHistory endpoint 

        [HttpPost("create")]
        public async Task<IActionResult> Create(CareerHistoryCreate model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest(ModelState);

            if (!await _careerHistoryService.CreateCareerHistoryAsync(model))
                return UnprocessableEntity();


            return Ok("CareerHistory created successfully");
        }

        // UpdateCareerHistory endpoint

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, CareerHistoryUpdate model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest(ModelState);

            if (model.Id != id)
                return BadRequest();

            if (!await _careerHistoryService.UpdateCareerHistoryAsync(id, model))
                return BadRequest();

            return Ok("CareerHistory updated successfully");
        }


        // DeleteCareerHistory endpoint

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var careerHistoryToDelete = await _careerHistoryService.GetCareerHistoryByIdAsync(id);

            if (careerHistoryToDelete is null)
                return NotFound();

            if (!await _careerHistoryService.DeleteCareerHistoryAsync(id))
                return BadRequest();

            return Ok($"CareerHistory {id} deleted successfully");
        }


        // GetAll endpoint

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var careerHistorys = await _careerHistoryService.GetAllCareerHistorysAsync();

            return Ok(careerHistorys);
        }


        // GetById endpoint

        [HttpGet("{id}")]

        public async Task<IActionResult> CareerHistory(int id)
        {
            var careerHistory = await _careerHistoryService.GetCareerHistoryByIdAsync(id);

            if (careerHistory is null)
                return NotFound();

            return Ok(careerHistory);
        }
    }
}
