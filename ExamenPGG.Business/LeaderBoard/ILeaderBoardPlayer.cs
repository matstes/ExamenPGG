namespace ExamenPGG.Business.LeaderBoard
{
    public interface ILeaderBoardPlayer
    {
        string LeaderName { get; set; }
        int LeaderScore { get; set; }
        string Icon { get; set; }
        DateTime LeaderDate { get; set; }
    }
}