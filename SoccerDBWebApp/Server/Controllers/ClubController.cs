using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerDBWebApp.Server.Services.ClubServices;
using SoccerDBWebApp.Shared.Models.Club;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        // Field & Constructor to access service methods
        private readonly IClubService _clubService;
        public ClubController(IClubService clubService)
        {
            _clubService = clubService;
        }


        // CreateClub endpoint 

        [HttpPost("create")]
        public async Task<IActionResult> Create(ClubCreate model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest(ModelState);

            if (!await _clubService.CreateClubAsync(model))
                return UnprocessableEntity();


            return Ok("Club created successfully");
        }

        // UpdateClub endpoint

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, ClubUpdate model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest(ModelState);

            if (model.Id != id)
                return BadRequest();

            if (!await _clubService.UpdateClubAsync(id, model))
                return BadRequest();

            return Ok("Club updated successfully");
        }


        // DeleteClub endpoint

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var clubToDelete = await _clubService.GetClubByIdAsync(id);

            if (clubToDelete is null)
                return NotFound();

            if (!await _clubService.DeleteClubAsync(id))
                return BadRequest();

            return Ok($"Club {id} deleted successfully");
        }


        // GetAll endpoint

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clubs = await _clubService.GetAllClubsAsync();

            return Ok(clubs);
        }


        // GetById endpoint

        [HttpGet("{id}")]

        public async Task<IActionResult> Club(int id)
        {
            var club = await _clubService.GetClubByIdAsync(id);

            if (club is null)
                return NotFound();

            return Ok(club);
        }
    }
}
