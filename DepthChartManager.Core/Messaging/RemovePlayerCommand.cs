using AutoMapper;
using DepthChartManager.Core.Dtos.Request;
using DepthChartManager.Core.Dtos.Response;
using DepthChartManager.Core.Interfaces.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DepthChartManager.Core.Messaging
{
    public class RemovePlayerCommand : IRequest<CommandResult<PlayerDto>>
    {
        public RemovePlayerCommand(RemovePlayerDto removePlayerDto)
        {
            RemovePlayerDto = removePlayerDto;
        }

        public RemovePlayerDto RemovePlayerDto { get; }
    }

    public class RemovePlayerCommandHandler : IRequestHandler<RemovePlayerCommand, CommandResult<PlayerDto>>
    {
        private readonly IMapper _mapper;
        public readonly ISportRepository _sportRepository;

        public RemovePlayerCommandHandler(IMapper mapper, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _sportRepository = sportRepository;
        }

        public Task<CommandResult<PlayerDto>> Handle(RemovePlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = _sportRepository.RemovePlayer(request.RemovePlayerDto.Id, request.RemovePlayerDto.LeagueId, request.RemovePlayerDto.TeamId, request.RemovePlayerDto.Name, request.RemovePlayerDto.Position);
                return Task.FromResult(new CommandResult<PlayerDto>(_mapper.Map<PlayerDto>(player)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CommandResult<PlayerDto>(ex.Message));
            }
        }
    }
}