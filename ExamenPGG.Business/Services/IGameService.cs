using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.LeaderBoard;

namespace ExamenPGG.Business.Services
{
    public interface IGameService
    {
        Task LogGameToDB(IGame game);
        Task<List<ILeaderBoardPlayer>> GetTop10();
    }
}
