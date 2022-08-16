namespace ExamenPGG.Business._00_Interfaces
{
    public interface ILeaderBoard
    {
        List<ILeaderBoardPlayer> Top10Players { get; set; }

        List<ILeaderBoardPlayer> UpdateLeaderBoard();
    }
}