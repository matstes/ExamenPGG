using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.LeaderBoard;
using System.Collections.ObjectModel;

namespace ExamenPGG.Business.Services
{
    public interface IGameService
    {
        Task LogGameToDB(IGame game);
        Task<ObservableCollection<ILeaderBoardPlayer>> GetTop10();
    }
}
