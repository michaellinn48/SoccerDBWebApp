using SoccerDBWebApp.Shared.Models.Club;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Services.ClubServices
{
    public interface IClubService
    {
        Task<bool> CreateClubAsync(ClubCreate model);
        Task<bool> UpdateClubAsync(int id, ClubUpdate model);
        Task<bool> DeleteClubAsync(int id);
        Task<IEnumerable<ClubListItem>> GetAllClubsAsync();
        Task<ClubDetail> GetClubByIdAsync(int id);
    }
}
