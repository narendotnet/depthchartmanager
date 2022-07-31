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
    public class GetFullDepthChartCommand : IRequest<CommandResult<IEnumerable<PlayerDto>>>
    {
        public GetFullDepthChartCommand(GetFullDepthChartDto getFullDepthChartDto)
        {
            GetFullDepthChartDto = getFullDepthChartDto;
        }

        public GetFullDepthChartDto GetFullDepthChartDto { get; }
    }

    public class GetFullDepthChartCommandHandler : IRequestHandler<GetFullDepthChartCommand, CommandResult<IEnumerable<PlayerDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ISportRepository _sportRepository;

        public GetFullDepthChartCommandHandler(IMapper mapper, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _sportRepository = sportRepository;
        }

        public Task<CommandResult<IEnumerable<PlayerDto>>> Handle(GetFullDepthChartCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var player = _sportRepository.GetFullDepthChart(request.GetFullDepthChartDto.LeagueId, request.GetFullDepthChartDto.TeamId);
                return Task.FromResult(new CommandResult<IEnumerable<PlayerDto>>(_mapper.Map<IEnumerable<PlayerDto>>(player)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CommandResult<IEnumerable<PlayerDto>>(ex.Message));
            }
        }
    }
}