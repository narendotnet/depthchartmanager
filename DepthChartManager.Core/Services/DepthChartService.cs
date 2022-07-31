using DepthChartManager.Core.Dtos.Request;
using DepthChartManager.Core.Dtos.Response;
using DepthChartManager.Core.Interfaces.Services;
using DepthChartManager.Core.Messaging;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Services
{
    public class DepthChartService : IDepthChartService
    {
        private readonly IMediator _mediator;

        public DepthChartService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<LeagueDto> AddLeague(int id, string leagueName)
        {
            var result = await _mediator.Send(new AddLeagueCommand(new CreateLeagueDto
            {
                Id = id,
                Name = leagueName
            }));

            return result.Result;
        }

        public async Task<TeamDto> AddTeam(int id, int leagueId, string teamName)
        {
            var result = await _mediator.Send(new AddTeamCommand(new CreateTeamDto
            {
                Id = id,
                LeagueId = leagueId,
                Name = teamName
            }));

            return result.Result;
        }

        public async Task<PlayerDto> AddPlayerToDepthChart(int id, int leagueId, int teamId, string playerName, string position, int? positionDepth)
        {
            var result = await _mediator.Send(new AddPlayerCommand(new CreatePlayerDto
            {
                Id = id,
                LeagueId = leagueId,
                TeamId = teamId,
                Name = playerName,
                Position = position,
                PositionDepth = positionDepth
            }));

            return result.Result;
        }

        public async Task<PlayerDto> RemovePlayerFromDepthChart(int playerId, int leagueId, int teamId, string playerName, string position)
        {
            var result = await _mediator.Send(new RemovePlayerCommand(new RemovePlayerDto
            {
                Id = playerId,
                LeagueId = leagueId,
                TeamId = teamId,
                Name = playerName,
                Position = position
            }));

            return result.Result;
        }

        public async Task<IEnumerable<PlayerDto>> GetBackups(int playerId, int leagueId, int teamId, string name, string position)
        {
            var result = await _mediator.Send(new GetBackupPlayersCommand(new GetBackupPlayersDto
            {
                PlayerId = playerId,
                LeagueId = leagueId,
                TeamId = teamId,
                Name = name,
                Position = position
            }));

            return result.Result;
        }

        public async Task<IEnumerable<PlayerDto>> GetFullDepthChart(int leagueId, int teamId)
        {
            var result = await _mediator.Send(new GetFullDepthChartCommand(new GetFullDepthChartDto
            {
                LeagueId = leagueId,
                TeamId = teamId
            }));

            return result.Result;
        }
    }
}