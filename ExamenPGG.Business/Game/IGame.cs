﻿using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.GameObject
{
    public interface IGame
    {
        List<IPlayer> PlayerList { get; set; }
        IPlayer CurrentPlayer { get; set; }
        IPlayer WinningPlayer { get; set; }
        DateTime StartTime { get; set; }
        DateTime EndTime { get; set; }
        public int RoundNumber { get; set; }
        IGameBoard GameBoard { get; set; }
        ILogger Logger { get; set; }
        public IDice Dice { get; set; }
        public bool IsDiceButtonEnabled { get; }
        public int CurrentplayerID { get; }

        void InitializeNewGame(List<IPlayer> playerList);
        void StartGame();

        void CanPlayerMove();

        void ChangeCurrentPlayer();

        void IncrementScore();

        void EndGame();
    }
}