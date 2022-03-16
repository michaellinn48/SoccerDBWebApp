using Microsoft.EntityFrameworkCore;
using SoccerDBWebApp.Server.Data;
using SoccerDBWebApp.Server.Models;
using SoccerDBWebApp.Shared.Models.CareerHistory;
using SoccerDBWebApp.Shared.Models.Club;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Services.ClubServices
{
    public class ClubService : IClubService
    {
        // Field & Constructor
        private readonly ApplicationDbContext _context;
        public ClubService(ApplicationDbContext context)
        {
            _context = context;
        }


        // CREATE
        public async Task<bool> CreateClubAsync(ClubCreate model)
        {
            var clubEntity = new Club()
            {
                Name = model.Name,
            };

            _context.Clubs.Add(clubEntity);

            return await _context.SaveChangesAsync() == 1;
        }


        // UPDATE

        public async Task<bool> UpdateClubAsync(int id, ClubUpdate model)
        {
            if (model is null)
                return false;

            if (model.Id != id)
                return false;

            var clubEntity = await _context.Clubs.FindAsync(id);

            if (clubEntity is null)
                return false;

            clubEntity.Name = model.Name;
            clubEntity.City = model.City;
            clubEntity.Country = model.Country;
            clubEntity.StadiumName = model.StadiumName;
            clubEntity.Manager = model.Manager;
            clubEntity.ClubLogoImage = model.ClubLogoImage;
            clubEntity.LeagueId = model.LeagueId;

            return await _context.SaveChangesAsync() == 1;


        }

        // DELETE

        public async Task<bool> DeleteClubAsync(int id)
        {
            var clubToDelete = await _context.Clubs.FindAsync(id);

            if (clubToDelete is null)
                return false;

            _context.Clubs.Remove(clubToDelete);

            return await _context.SaveChangesAsync() == 1;

        }

        /* GETS */

        // GET ALL

        public async Task<IEnumerable<ClubListItem>> GetAllClubsAsync()
        {
            var clubs = await _context.Clubs
                .Select(c => new ClubListItem
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
            return clubs;
        }


        // GET BY ID

        public async Task<ClubDetail> GetClubByIdAsync(int id)
        {

            var clubEntity = await _context.Clubs
                .Include(c => c.CareerHistorys)
                .FirstOrDefaultAsync(e => e.Id == id);


            return clubEntity is null ? null : new ClubDetail
            {
                Id = clubEntity.Id,
                Name = clubEntity.Name,
                City = clubEntity.City,
                Country = clubEntity.Country,
                StadiumName = clubEntity.StadiumName,
                Manager = clubEntity.Manager,
                ClubLogoImage = clubEntity.ClubLogoImage,
                LeagueId = clubEntity.LeagueId,
                CareerHistorys = clubEntity.CareerHistorys.Select(h => new CareerHistoryListItem()
                {
                    Id = h.Id,
                    PlayerName = h.PlayerName,
                    IsCurrentlyPlayingFor = h.IsCurrentlyPlayingFor,
                    StartYear = h.StartYear,
                    EndYear = h.EndYear,
                    Appearances = h.Appearances,
                    Goals = h.Goals,
                    PlayerId = h.PlayerId

                }).ToList()
            };
        }
    }
}
