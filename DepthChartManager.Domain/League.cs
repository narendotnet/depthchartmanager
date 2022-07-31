using DepthChartManager.Helpers;
using System;
using System.Collections.Generic;

namespace DepthChartManager.Domain
{
    public class League
    {
        private List<Team> _teams = new List<Team>();

        public League(int id, string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.LeagueNameIsInvalid);

            Id = id;
            Name = name;
        }

        public int Id { get; }

        public string Name { get; }

        public IEnumerable<Team> Teams => _teams.AsReadOnly();

        public Team GetTeam(int id)
        {
            return _teams.Find(t => t.Id == id);
        }

        public Team AddTeam(int id, string name)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.TeamNameIsInvalid);
            Contract.Requires<Exception>(!_teams.Exists(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase)), Resource.TeamAlreadyExists);

            var team = new Team(id,this, name);
            _teams.Add(team);
            return team;
        }
    }
}