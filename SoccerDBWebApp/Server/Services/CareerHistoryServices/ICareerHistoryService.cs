using SoccerDBWebApp.Shared.Models.CareerHistory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Services.CareerHistoryServices
{
    public interface ICareerHistoryService
    {
        Task<bool> CreateCareerHistoryAsync(CareerHistoryCreate model);
        Task<bool> UpdateCareerHistoryAsync(int id, CareerHistoryUpdate model);
        Task<bool> DeleteCareerHistoryAsync(int id);
        Task<IEnumerable<CareerHistoryListItem>> GetAllCareerHistorysAsync();
        Task<CareerHistoryDetail> GetCareerHistoryByIdAsync(int id);
    }
}
