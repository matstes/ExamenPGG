using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Player
{
    public interface IPlayer
    {
        ISquare CurrentSquare { get; }
        string IconPath { get; set; }
        int InActiveTurns { get; set; }
        string Name { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        ISquare PreviousSquare { get; set; }
        int TurnAmount { get; set; }

        ISquare MovePlayer(int moveAmount);
        ISquare MoveToSquare(int squareID);
    }
}