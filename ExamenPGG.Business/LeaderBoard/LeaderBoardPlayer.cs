namespace ExamenPGG.Business.LeaderBoard
{
    public class LeaderBoardPlayer : ILeaderBoardPlayer
    {
        public string LeaderName { get; set; }
        public int LeaderScore { get; set; }
        public string Icon { get; set; }
        public DateTime LeaderDate { get; set; }
    }
}
