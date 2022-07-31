using DepthChartManager.Core.Dtos.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Interfaces.Services
{
    public interface IDepthChartService
    {
        Task<LeagueDto> AddLeague(int leagueId, string leagueName);
        Task<TeamDto> AddTeam(int id,int leagueId, string teamName);
        Task<PlayerDto> AddPlayerToDepthChart(int playerId, int leagueId, int teamId, string playerName, string position, int? positionDepth);
        Task<PlayerDto> RemovePlayerFromDepthChart(int playerId, int leagueId, int teamId, string name, string position);
        Task<IEnumerable<PlayerDto>> GetBackups(int playerId, int leagueId, int teamId, string name, string position);
        Task<IEnumerable<PlayerDto>> GetFullDepthChart(int leagueId, int teamId);
    }
}