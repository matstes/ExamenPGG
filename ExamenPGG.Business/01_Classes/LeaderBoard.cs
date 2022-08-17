using ExamenPGG.Business._00_Interfaces;

namespace ExamenPGG.Business._01_Classes
{
    internal class LeaderBoard : ILeaderBoard
    {
        public List<ILeaderBoardPlayer> Top10Players { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public List<ILeaderBoardPlayer> UpdateLeaderBoard()
        {
            throw new NotImplementedException();
        }
    }
}
