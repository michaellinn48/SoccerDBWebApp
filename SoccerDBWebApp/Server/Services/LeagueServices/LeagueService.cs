using Microsoft.EntityFrameworkCore;
using SoccerDBWebApp.Server.Data;
using SoccerDBWebApp.Server.Models;
using SoccerDBWebApp.Shared.Models.Club;
using SoccerDBWebApp.Shared.Models.League;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Services.LeagueServices
{
    public class LeagueService : ILeagueService
    {
        // Field & Constructor
        private readonly ApplicationDbContext _context;
        public LeagueService(ApplicationDbContext context)
        {
            _context = context;
        }


        // CREATE
        public async Task<bool> CreateLeagueAsync(LeagueCreate model)
        {
            var leagueEntity = new League()
            {
                Name = model.Name,
            };

            _context.Leagues.Add(leagueEntity);

            return await _context.SaveChangesAsync() == 1;
        }


        // UPDATE

        public async Task<bool> UpdateLeagueAsync(int id, LeagueUpdate model)
        {
            if (model is null)
                return false;

            if (model.Id != id)
                return false;

            var leagueEntity = await _context.Leagues.FindAsync(id);

            if (leagueEntity is null)
                return false;

            leagueEntity.Name = model.Name;
            leagueEntity.Country = model.Country;
            leagueEntity.TierLevel = model.TierLevel;
            leagueEntity.LeagueLogoImage = model.LeagueLogoImage;

            return await _context.SaveChangesAsync() == 1;


        }

        // DELETE

        public async Task<bool> DeleteLeagueAsync(int id)
        {
            var leagueToDelete = await _context.Leagues.FindAsync(id);

            if (leagueToDelete is null)
                return false;

            _context.Leagues.Remove(leagueToDelete);

            return await _context.SaveChangesAsync() == 1;

        }

        /* GETS */

        // GET ALL

        public async Task<IEnumerable<LeagueListItem>> GetAllLeaguesAsync()
        {
            var leagues = await _context.Leagues
                .Select(l => new LeagueListItem
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToListAsync();
            return leagues;
        }


        // GET BY ID

        public async Task<LeagueDetail> GetLeagueByIdAsync(int id)
        {

            var leagueEntity = await _context.Leagues
                .Include(l => l.Clubs)
                .FirstOrDefaultAsync(e => e.Id == id);


            return leagueEntity is null ? null : new LeagueDetail
            {
                Id = leagueEntity.Id,
                Name = leagueEntity.Name,
                Country = leagueEntity.Country,
                TierLevel = leagueEntity.TierLevel,
                LeagueLogoImage = leagueEntity.LeagueLogoImage,
                Clubs = leagueEntity.Clubs.Select(c => new ClubListItem()
                {
                    Id = c.Id,
                    Name = c.Name,
                    City = c.City,
                    Manager = c.Manager,
                    ClubLogoImage = c.ClubLogoImage

                }).ToList()
            };
        }
    }
}
