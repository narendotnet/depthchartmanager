using DepthChartManager.Helpers;
using System;

namespace DepthChartManager.Domain
{
    public class Player
    {
        public Player(int id, League league, Team team, string name, string position, int? positionDepth)
        {
            Contract.Requires<Exception>(league != null, Resource.LeagueNameIsInvalid);
            Contract.Requires<Exception>(team != null, Resource.TeamNameIsInvalid);
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.PlayerNameIsInvalid);

            Id = id;
            League = league;
            Team = team;
            Name = name;
            Position = position;
            PositionDepth = positionDepth;
        }
        public int Id { get; }
        public League League { get; }
        public Team Team { get; }
        public string Name { get; }
        public string Position { get; }
        public int? PositionDepth { get; }
    }
}