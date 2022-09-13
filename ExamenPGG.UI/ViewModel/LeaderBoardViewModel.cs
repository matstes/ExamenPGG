using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.LeaderBoard;
using ExamenPGG.Business.Services;
using System.Collections.ObjectModel;

namespace ExamenPGG.UI.ViewModel
{
    public partial class LeaderBoardViewModel: ObservableObject
    {
        public ObservableCollection<ILeaderBoardPlayer> Top10 { get; set; }
        private IGameService _gameService;

        [ObservableProperty]
        private string emptyDB = null;

        public LeaderBoardViewModel(IGameService service)
        {
            _gameService = service;
            UpdateLeaderBoard();
        }

        private void UpdateLeaderBoard()
        {
            Top10 = _gameService.GetTop10().Result;

            if (Top10.Count == 0)
            {
                EmptyDB = "No data found, play a game!";
            }
        }

        [RelayCommand]
        private async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync($"..");
        }
    }
}
