namespace ExamenPGG.Business.Player
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public int CurrentSquare { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int PreviousSquare { get; set; }
        public int TurnAmount { get; set; }
        public int InActiveTurns { get; set; }

        public int MovePlayer(int moveAmount)
        {
            throw new NotImplementedException();
        }
    }
}
