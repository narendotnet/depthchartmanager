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
    public class AddPlayerCommand : IRequest<CommandResult<PlayerDto>>
    {
        public AddPlayerCommand(CreatePlayerDto createPlayerDto)
        {
            AddPlayerDto = createPlayerDto;
        }

        public CreatePlayerDto AddPlayerDto { get; }
    }

    public class AddPlayerCommandHandler : IRequestHandler<AddPlayerCommand, CommandResult<PlayerDto>>
    {
        private readonly IMapper _mapper;
        public readonly ISportRepository _sportRepository;

        public AddPlayerCommandHandler(IMapper mapper, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _sportRepository = sportRepository;
        }

        public Task<CommandResult<PlayerDto>> Handle(AddPlayerCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = _sportRepository.AddPlayer(request.AddPlayerDto.Id,request.AddPlayerDto.LeagueId, request.AddPlayerDto.TeamId, request.AddPlayerDto.Name, request.AddPlayerDto.Position, request.AddPlayerDto.PositionDepth);
                return Task.FromResult(new CommandResult<PlayerDto>(_mapper.Map<PlayerDto>(player)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CommandResult<PlayerDto>(ex.Message));
            }
        }
    }
}