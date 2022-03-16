using Microsoft.EntityFrameworkCore;
using SoccerDBWebApp.Server.Data;
using SoccerDBWebApp.Server.Models;
using SoccerDBWebApp.Shared.Models.CareerHistory;
using SoccerDBWebApp.Shared.Models.Player;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Services.PlayerServices
{
    public class PlayerService : IPlayerService
    {
        // Field & Constructor
        private readonly ApplicationDbContext _context;
        public PlayerService(ApplicationDbContext context)
        {
            _context = context;
        }


        // CREATE
        public async Task<bool> CreatePlayerAsync(PlayerCreate model)
        {
            var playerEntity = new Player()
            {
                Name = model.Name,
            };

            _context.Players.Add(playerEntity);

            return await _context.SaveChangesAsync() == 1;
        }


        // UPDATE

        public async Task<bool> UpdatePlayerAsync(int id, PlayerUpdate model)
        {
            if (model is null)
                return false;

            if (model.Id != id)
                return false;

            var playerEntity = await _context.Players.FindAsync(id);

            if (playerEntity is null)
                return false;
          
            playerEntity.Name = model.Name;
            playerEntity.Age = model.Age;
            playerEntity.Height = model.Height;
            playerEntity.Positions = model.Positions;
            playerEntity.PlayerImage = model.PlayerImage;

            return await _context.SaveChangesAsync() == 1;


        }

        // DELETE

        public async Task<bool> DeletePlayerAsync(int id)
        {
            var playerToDelete = await _context.Players.FindAsync(id);

            if (playerToDelete is null)
                return false;

            _context.Players.Remove(playerToDelete);

            return await _context.SaveChangesAsync() == 1;

        }

        /* GETS */

        // GET ALL

        public async Task<IEnumerable<PlayerListItem>> GetAllPlayersAsync()
        {
            var players = await _context.Players
                .Select(p => new PlayerListItem
                {
                    Id = p.Id,
                    Name = p.Name
                }).ToListAsync();
            return players;
        }


        // GET BY ID

        public async Task<PlayerDetail> GetPlayerByIdAsync(int id)
        {        

            var playerEntity = await _context.Players
                .Include(p => p.CareerHistorys)
                .FirstOrDefaultAsync(e => e.Id == id);

            
            return playerEntity is null ? null : new PlayerDetail
            {
                Id = playerEntity.Id,
                Name = playerEntity.Name,
                Age = playerEntity.Age,
                Height = playerEntity.Height,
                Positions = playerEntity.Positions,
                PlayerImage = playerEntity.PlayerImage,
                CareerHistorys = playerEntity.CareerHistorys.Select(c => new CareerHistoryListItem()
                {
                    Id = c.Id,
                    ClubName = c.ClubName,
                    StartYear = c.StartYear,
                    EndYear = c.EndYear,
                    Appearances = c.Appearances,
                    Goals = c.Goals,
                    ClubId = c.ClubId

                }).ToList()
            };
        }
    }
}
