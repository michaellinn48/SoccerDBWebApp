using Microsoft.EntityFrameworkCore;
using SoccerDBWebApp.Server.Data;
using SoccerDBWebApp.Server.Models;
using SoccerDBWebApp.Shared.Models.CareerHistory;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Services.CareerHistoryServices
{
    public class CareerHistoryService : ICareerHistoryService
    {
        // Field & Constructor
        private readonly ApplicationDbContext _context;
        public CareerHistoryService(ApplicationDbContext context)
        {
            _context = context;
        }


        // CREATE
        public async Task<bool> CreateCareerHistoryAsync(CareerHistoryCreate model)
        {
            var careerHistoryEntity = new CareerHistory()
            {
                PlayerName = model.PlayerName,
                ClubName = model.ClubName,
                IsCurrentlyPlayingFor = model.IsCurrentlyPlayingFor
            };

            _context.CareerHistorys.Add(careerHistoryEntity);

            return await _context.SaveChangesAsync() == 1;
        }


        // UPDATE

        public async Task<bool> UpdateCareerHistoryAsync(int id, CareerHistoryUpdate model)
        {
            if (model is null)
                return false;

            if (model.Id != id)
                return false;

            var careerHistoryEntity = await _context.CareerHistorys.FindAsync(id);

            if (careerHistoryEntity is null)
                return false;

            careerHistoryEntity.PlayerName = model.PlayerName;
            careerHistoryEntity.ClubName = model.ClubName;
            careerHistoryEntity.IsCurrentlyPlayingFor = model.IsCurrentlyPlayingFor;
            careerHistoryEntity.StartYear = model.StartYear;
            careerHistoryEntity.EndYear = model.EndYear;
            careerHistoryEntity.Appearances = model.Appearances;
            careerHistoryEntity.Goals = model.Goals;
            careerHistoryEntity.PlayerId = model.PlayerId;
            careerHistoryEntity.ClubId = model.ClubId;

            return await _context.SaveChangesAsync() == 1;


        }

        // DELETE

        public async Task<bool> DeleteCareerHistoryAsync(int id)
        {
            var careerHistoryToDelete = await _context.CareerHistorys.FindAsync(id);

            if (careerHistoryToDelete is null)
                return false;

            _context.CareerHistorys.Remove(careerHistoryToDelete);

            return await _context.SaveChangesAsync() == 1;

        }

        /* GETS */

        // GET ALL

        public async Task<IEnumerable<CareerHistoryListItem>> GetAllCareerHistorysAsync()
        {
            var careerHistorys = await _context.CareerHistorys
                .Select(ch => new CareerHistoryListItem
                {
                    Id = ch.Id,
                    PlayerName = ch.PlayerName,
                    ClubName = ch.ClubName,
                    IsCurrentlyPlayingFor = ch.IsCurrentlyPlayingFor
                }).ToListAsync();
            return careerHistorys;
        }


        // GET BY ID

        public async Task<CareerHistoryDetail> GetCareerHistoryByIdAsync(int id)
        {

            var careerHistoryEntity = await _context.CareerHistorys
                .FirstOrDefaultAsync(e => e.Id == id);


            return careerHistoryEntity is null ? null : new CareerHistoryDetail
            {
                Id = careerHistoryEntity.Id,
                PlayerName = careerHistoryEntity.PlayerName,
                ClubName = careerHistoryEntity.ClubName,
                IsCurrentlyPlayingFor = careerHistoryEntity.IsCurrentlyPlayingFor,
                StartYear = careerHistoryEntity.StartYear,
                EndYear = careerHistoryEntity.EndYear,
                Appearances = careerHistoryEntity.Appearances,
                Goals = careerHistoryEntity.Goals,
                PlayerId = careerHistoryEntity.PlayerId,
                ClubId = careerHistoryEntity.ClubId
            };
        }
    }
}
