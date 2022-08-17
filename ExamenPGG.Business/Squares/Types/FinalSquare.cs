using ExamenPGG.Business.Player;

namespace ExamenPGG.Business.Squares
{
    public class FinalSquare : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        public FinalSquare(int id)
        {
            ID = id;
            SquareType = SquareType.Final;
        }

        public void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} reached the EndBoss!");
        }
    }
}
