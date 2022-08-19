using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares.Types
{
    public class FallTrap : Standard, ISquare
    {
        public FallTrap(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.Start;
        }

        public override void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} entered squareID: {ID}");
        }
    }
}