using AutoMapper;
using DepthChartManager.Core.Dtos.Request;
using DepthChartManager.Core.Dtos.Response;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class GetBackupPlayersCommand : IRequest<CommandResult<IEnumerable<PlayerDto>>>
    {
        public GetBackupPlayersCommand(GetBackupPlayersDto getBackupPlayersDto)
        {
            GetBackupPlayersDto = getBackupPlayersDto;
        }

        public GetBackupPlayersDto GetBackupPlayersDto { get; }
    }

    public class GetBackupPlayersCommandHandler : IRequestHandler<GetBackupPlayersCommand, CommandResult<IEnumerable<PlayerDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ISportRepository _sportRepository;

        public GetBackupPlayersCommandHandler(IMapper mapper, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _sportRepository = sportRepository;
        }

        public Task<CommandResult<IEnumerable<PlayerDto>>> Handle(GetBackupPlayersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var backupPlayerPositions = _sportRepository.GetBackups(request.GetBackupPlayersDto.PlayerId, request.GetBackupPlayersDto.LeagueId, request.GetBackupPlayersDto.TeamId, request.GetBackupPlayersDto.Name, request.GetBackupPlayersDto.Position);
                return Task.FromResult(new CommandResult<IEnumerable<PlayerDto>>(_mapper.Map<IEnumerable<PlayerDto>>(backupPlayerPositions)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CommandResult<IEnumerable<PlayerDto>>(ex.Message));
            }
        }
    }
}