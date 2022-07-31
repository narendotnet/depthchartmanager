using DepthChartManager.Core.Interfaces.Repositories;
using DepthChartManager.Domain;
using DepthChartManager.Helpers;
using System;
using System.Collections.Generic;

namespace DepthChartManager.Infrastructure.Repositories
{
    public class SportRepository : ISportRepository
    {
        private List<League> _leagues = new List<League>();

        public League AddLeague(int id, string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.LeagueNameIsInvalid);
            Contract.Requires<Exception>(!_leagues.Exists(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase)), Resource.LeagueAlreadyExists);

            var sport = new League(id,name);
            _leagues.Add(sport);
            return sport;
        }

        public League GetLeague(int leagueId)
        {
            return _leagues.Find(s => s.Id == leagueId);
        }

        //public IEnumerable<League> GetLeagues()
        //{
        //    return _leagues.AsReadOnly();
        //}

        public Team AddTeam(int leagueId, string teamName)
        {
            return GetLeague(leagueId)?.AddTeam(leagueId,teamName);
        }

        //public IEnumerable<Team> GetTeams(int leagueId)
        //{
        //    return GetLeague(leagueId)?.Teams;
        //}

        public Player AddPlayer(int id, int leagueId, int teamId, string name, string position, int? positionDepth)
        {
            return GetLeague(leagueId)?.GetTeam(teamId)?.AddPlayer(id, name, position, positionDepth);
        }

        public Player RemovePlayer(int id, int leagueId, int teamId, string name, string position)
        {
            return GetLeague(leagueId)?.GetTeam(teamId)?.RemovePlayer(id, name, position);
        }

        public IEnumerable<Player> GetBackups(int playerId, int leagueId, int teamId, string name, string position)
        {
            return GetLeague(leagueId)?.GetTeam(teamId)?.GetBackups(playerId, name, position);
        }

        public IEnumerable<Player> GetFullDepthChart(int leagueId, int teamId)
        {
            return GetLeague(leagueId)?.GetTeam(teamId)?.GetFullDepthChart(leagueId, teamId);
        }
    }
}