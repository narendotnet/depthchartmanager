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
    public class AddLeagueCommand : IRequest<CommandResult<LeagueDto>>
    {
        public AddLeagueCommand(CreateLeagueDto createLeagueDto)
        {
            CreateLeagueDto = createLeagueDto;
        }

        public CreateLeagueDto CreateLeagueDto { get; }
    }

    public class AddLeagueCommandHandler : IRequestHandler<AddLeagueCommand, CommandResult<LeagueDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISportRepository _sportRepository;

        public AddLeagueCommandHandler(IMapper mapper, ISportRepository sportRepository)
        {
            _mapper = mapper;
            _sportRepository = sportRepository;
        }

        public Task<CommandResult<LeagueDto>> Handle(AddLeagueCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var league = _sportRepository.AddLeague(request.CreateLeagueDto.Id,request.CreateLeagueDto.Name);
                return Task.FromResult(new CommandResult<LeagueDto>(_mapper.Map<LeagueDto>(league)));
            }
            catch (Exception ex)
            {
                return Task.FromResult(new CommandResult<LeagueDto>(ex.Message));
            }
        }
    }
}