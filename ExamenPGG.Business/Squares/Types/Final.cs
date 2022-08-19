using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Final : BaseSquare, ISquare
    {
        public Final(int id) : base(id)
        {
            ID = id;
            SquareType = SquareType.Final;
        }

        public override void HandlePlayer(IPlayer player)
        {
            Console.WriteLine($"Player {player.Name} reached the EndBoss!");
        }
    }
}