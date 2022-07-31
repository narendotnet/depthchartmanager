using DepthChartManager.Domain;
using System.Collections.Generic;

namespace DepthChartManager.Core.Interfaces.Repositories
{
    public interface ISportRepository
    {
        League AddLeague(int id, string name);
        //IEnumerable<League> GetLeagues();
        Team AddTeam(int leagueId, string teamName);
        //IEnumerable<Team> GetTeams(int leagueId);
        Player AddPlayer(int id, int leagueId, int teamId, string name, string position, int? positionDepth);
        Player RemovePlayer(int id, int leagueId, int teamId, string name, string position);
        IEnumerable<Player> GetBackups(int playerId, int leagueId, int teamId, string name, string position);
        IEnumerable<Player> GetFullDepthChart(int leagueId, int teamId);
    }
}