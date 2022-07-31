using DepthChartManager.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DepthChartManager.Domain
{
    public class Team
    {
        private List<Player> _players = new List<Player>();

        public Team(int id, League league, string name)
        {
            Contract.Requires<Exception>(league != null, Resource.LeagueNameIsInvalid);
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.TeamNameIsInvalid);

            Id = id;
            League = league;
            Name = name;
        }
        public int Id { get; }
        public League League { get; }
        public string Name { get; }
        public IEnumerable<Player> Players => _players.AsReadOnly();

        public Player AddPlayer(int id, string name, string position, int? positionDepth)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.PlayerNameIsInvalid);
            Contract.Requires<Exception>(!_players.Exists(player => string.Equals(player.Name, name, StringComparison.OrdinalIgnoreCase)), Resource.PlayerAlreadyExistsWithinTeam);

            int index = (int)(positionDepth ?? (_players.Count() == 0 ? 0 : _players.Where(x => x.Position == position).Last().PositionDepth + 1));
            var player = new Player(id, League, this, name, position, index);
            _players.Add(player);
            return player;
        }
        public Player RemovePlayer(int playerId, string name, string position)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.PlayerNameIsInvalid);

            var player = _players.Find(p => p.Id == playerId && string.Equals(name, p.Name, StringComparison.OrdinalIgnoreCase) && string.Equals(position, p.Position, StringComparison.OrdinalIgnoreCase));
            _players.Remove(player);
            return player;
        }
        public IEnumerable<Player> GetBackups(int playerId, string name, string position)
        {
            Contract.Requires<Exception>(!string.IsNullOrWhiteSpace(name), Resource.PlayerNameIsInvalid);

            var playerPositionDepth = _players.FindIndex(p => p.Id == playerId && string.Equals(position, p.Position, StringComparison.OrdinalIgnoreCase));
            var players = _players.Where(pp => pp.Position == position).Skip(playerPositionDepth + 1);
            return players;
        }
        public IEnumerable<Player> GetFullDepthChart(int leagueId, int teamId)
        {
            var players = _players.Where(pp => pp.League.Id == leagueId && pp.Team.Id == teamId);
            return players;
        }
    }
}