using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    internal class StandardSquare : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        private ILogger _logger;
        // TODO Inject loggger

        public StandardSquare(int id)
        {
            ID = id;
            SquareType = SquareType.Standard;
        }

        public void HandlePlayer(IPlayer player)
        {
            //todo
            //_logger.LogMessage($"Player {player.Name} entered squareID: {ID}");
            Console.WriteLine($"Player { player.Name } entered squareID: {ID}");
        }
    }
}