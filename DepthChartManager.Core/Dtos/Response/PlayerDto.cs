namespace DepthChartManager.Core.Dtos.Response
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public LeagueDto League { get; set; }
        public TeamDto Team { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int PositionDepth { get; set; }
    }
}