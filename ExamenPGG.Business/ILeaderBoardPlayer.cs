namespace ExamenPGG.Business._00_Interfaces
{
    public interface ILeaderBoardPlayer
    {
        string LeaderName { get; set; }
        int LeaderScore { get; set; }
        int Icon { get; set; }
        DateTime LeaderDate { get; set; }
    }
}