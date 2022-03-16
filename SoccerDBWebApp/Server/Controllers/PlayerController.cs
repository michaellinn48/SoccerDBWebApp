using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerDBWebApp.Server.Services.PlayerServices;
using SoccerDBWebApp.Shared.Models.Player;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        // Field & Constructor to access service methods
        private readonly IPlayerService _playerService;
        public PlayerController(IPlayerService playerService)
        {
            _playerService = playerService;
        }


        // CreatePlayer endpoint 

        [HttpPost("create")]
        public async Task<IActionResult> Create(PlayerCreate model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest(ModelState);

            if (!await _playerService.CreatePlayerAsync(model))
                return UnprocessableEntity();


            return Ok("Player created successfully");
        }

        // UpdatePlayer endpoint

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, PlayerUpdate model)
        {
            if (!ModelState.IsValid || model == null)
                return BadRequest(ModelState);

            if (model.Id != id)
                return BadRequest();

            if (!await _playerService.UpdatePlayerAsync(id, model))
                return BadRequest();

            return Ok("Player updated successfully");
        }


        // DeletePlayer endpoint

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var playerToDelete = await _playerService.GetPlayerByIdAsync(id);

            if (playerToDelete is null)
                return NotFound();

            if (!await _playerService.DeletePlayerAsync(id))
                return BadRequest();

            return Ok($"Player {id} deleted successfully");
        }


        // GetAll endpoint

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var players = await _playerService.GetAllPlayersAsync();

            return Ok(players);
        }


        // GetById endpoint

        [HttpGet("{id}")]

        public async Task<IActionResult> Player(int id)
        {
            var player = await _playerService.GetPlayerByIdAsync(id);

            if (player is null)
                return NotFound();

            return Ok(player);
        }
    }
}
