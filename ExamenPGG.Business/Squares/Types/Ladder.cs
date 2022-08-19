using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares.Types
{
    public class Ladder : Standard, ISquare
    {
        public Ladder(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.Ladder;
        }

        public override void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} entered squareID: {ID}");
        }
    }
}