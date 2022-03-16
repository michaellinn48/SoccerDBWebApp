using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerDBWebApp.Server.Services.LeagueServices;
using SoccerDBWebApp.Shared.Models.League;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        // Field & Constructor to access service methods
        private readonly ILeagueService _leagueService;
        public LeagueController(ILeagueService leagueService)
        {
            _leagueService = leagueService;
        }


        // CreateLeague endpoint 

        [HttpPost("create")]
        public async Task<IActionResult> Create(LeagueCreate model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest(ModelState);

            if (!await _leagueService.CreateLeagueAsync(model))
                return UnprocessableEntity();


            return Ok("League created successfully");
        }

        // UpdateLeague endpoint

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, LeagueUpdate model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest(ModelState);

            if (model.Id != id)
                return BadRequest();

            if (!await _leagueService.UpdateLeagueAsync(id, model))
                return BadRequest();

            return Ok("League updated successfully");
        }


        // DeleteLeague endpoint

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var leagueToDelete = await _leagueService.GetLeagueByIdAsync(id);

            if (leagueToDelete is null)
                return NotFound();

            if (!await _leagueService.DeleteLeagueAsync(id))
                return BadRequest();

            return Ok($"League {id} deleted successfully");
        }


        // GetAll endpoint

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var leagues = await _leagueService.GetAllLeaguesAsync();

            return Ok(leagues);
        }


        // GetById endpoint

        [HttpGet("{id}")]

        public async Task<IActionResult> League(int id)
        {
            var league = await _leagueService.GetLeagueByIdAsync(id);

            if (league is null)
                return NotFound();

            return Ok(league);
        }
    }
}
