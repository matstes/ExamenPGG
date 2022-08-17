namespace ExamenPGG.Business.Player
{
    public interface IPlayer
    {
        string Name { get; set; }

        string IconPath { get; set; }

        int CurrentSquare { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        int PreviousSquare { get; set; }

        int MovePlayer(int moveAmount);

        int TurnAmount { get; set; }

        int InActiveTurns { get; set; }
    }
}