using SoccerDBWebApp.Shared.Models.League;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Services.LeagueServices
{
    public interface ILeagueService
    {
        Task<bool> CreateLeagueAsync(LeagueCreate model);
        Task<bool> UpdateLeagueAsync(int id, LeagueUpdate model);
        Task<bool> DeleteLeagueAsync(int id);
        Task<IEnumerable<LeagueListItem>> GetAllLeaguesAsync();
        Task<LeagueDetail> GetLeagueByIdAsync(int id);
    }
}
