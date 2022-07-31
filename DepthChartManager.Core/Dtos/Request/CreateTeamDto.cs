namespace DepthChartManager.Core.Dtos.Request
{
    public class CreateTeamDto
    {
        public int Id { get; set; }
        public int LeagueId { get; set; }
        public string Name { get; set; }
    }
}