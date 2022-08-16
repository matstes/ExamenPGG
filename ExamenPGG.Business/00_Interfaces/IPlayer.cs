namespace ExamenPGG.Business._00_Interfaces
{
    public interface IPlayer
    {
        string Name { get; set; }

        string IconPath { get; set; }

        int CurrentSquare { get; set; }
        int PositionX { get; set; }
        int PositionY { get; set; }
        int PreviousSquare { get; set; }

        int MovePlayerAsync(int moveAmount);

        int TurnAmount { get; set; }

        int InActiveTurns { get; set; }
    }
}