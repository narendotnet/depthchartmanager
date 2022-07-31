namespace DepthChartManager.Core.Dtos.Request
{
    public class GetBackupPlayersDto
    {
        public int PlayerId { get; set; }
        public int LeagueId { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
    }
}