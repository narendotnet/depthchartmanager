using AutoMapper;
using DepthChartManager.Core.Dtos.Response;
using DepthChartManager.Domain;

namespace DepthChartManager.Core
{
    public class SportMappingProfile : Profile
    {
        public SportMappingProfile()
        {
            CreateMap<League, LeagueDto>();
            CreateMap<Player, PlayerDto>();
            CreateMap<Team, TeamDto>();
        }
    }
}