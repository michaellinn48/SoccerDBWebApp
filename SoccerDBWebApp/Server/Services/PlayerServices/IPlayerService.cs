using SoccerDBWebApp.Shared.Models.Player;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SoccerDBWebApp.Server.Services.PlayerServices
{
    public interface IPlayerService
    {
        Task<bool> CreatePlayerAsync(PlayerCreate model);
        Task<bool> UpdatePlayerAsync(int id, PlayerUpdate model);
        Task<bool> DeletePlayerAsync(int id);
        Task<IEnumerable<PlayerListItem>> GetAllPlayersAsync();
        Task<PlayerDetail> GetPlayerByIdAsync(int id);
    }
}
