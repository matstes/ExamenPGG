using ExamenPGG.Business.LeaderBoard;
using ExamenPGG.Business.Services;
using System.Collections.ObjectModel;

namespace ExamenPGG.UI.ViewModel
{
    public class LeaderBoardViewModel
    {
        public ObservableCollection<ILeaderBoardPlayer> Top10 { get; set; }
        private IGameService _gameService;

        public LeaderBoardViewModel(IGameService service)
        {
            _gameService = service;
            UpdateLeaderBoard();
        }

        private async Task UpdateLeaderBoard()
        {
            Top10 = await _gameService.GetTop10();
        }
    }
}
