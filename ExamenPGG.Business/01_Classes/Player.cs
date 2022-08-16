using ExamenPGG.Business._00_Interfaces;

namespace ExamenPGG.Business._01_Classes
{
    internal class Player : IPlayer
    {
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string IconPath { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int CurrentSquare { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PositionX { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PositionY { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int PreviousSquare { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int TurnAmount { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int InActiveTurns { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int MovePlayerAsync(int moveAmount)
        {
            throw new NotImplementedException();
        }
    }
}
