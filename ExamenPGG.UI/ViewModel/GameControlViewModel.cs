﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExamenPGG.Business.GameObject;
using ExamenPGG.Business.Logging;
using ExamenPGG.UI.View;
using System.Text;

namespace ExamenPGG.UI.ViewModel
{
    public partial class GameControlViewModel : ObservableObject
    {
        [ObservableProperty]
        private IGame game;
        [ObservableProperty]
        private ILogger logger;
        
        public GameControlViewModel(IGame game, ILogger logger)
        {
            Game = game;
            Logger = logger;
        }

        [RelayCommand]
        private async Task RollDiceAsync()
        {
            await Game.ExecuteDiceRoll();
        }
    }
}
