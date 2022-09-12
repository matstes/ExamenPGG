using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.PlayerObject
{
    public interface IPlayer
    {
        ISquare CurrentSquare { get; }
        string IconPath { get; set; }
        int InActiveTurns { get; set; }
        string Name { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        double ScaleXplayer { get; set; }
        ISquare PreviousSquare { get; set; }
        int TurnAmount { get; set; }
        public bool IsHuman { get; }
        public int Direction { get; set; }
        public int LastThrow { get; set; }

        Task<ISquare> MovePlayerVisualy(int moveAmount);

        ISquare MovePlayer(int moveAmount);

        ISquare MoveToSquare(int squareID);
    }
}