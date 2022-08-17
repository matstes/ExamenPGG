namespace ExamenPGG.Business.LeaderBoard
{
    public interface ILeaderBoard
    {
        List<ILeaderBoardPlayer> Top10Players { get; set; }

        List<ILeaderBoardPlayer> UpdateLeaderBoard();
    }
}