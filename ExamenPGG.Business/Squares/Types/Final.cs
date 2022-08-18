using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Final : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        public Final(int id)
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