using ExamenPGG.Business.Logging;
using ExamenPGG.Business.PlayerObject;

namespace ExamenPGG.Business.Squares
{
    public class Standard : ISquare
    {
        public int ID { get; set; }
        public SquareType SquareType { get; set; }

        public ILogger _logger = new Logger();
        public Standard(int id)
        {
            ID = id;
            SquareType = SquareType.Standard;
        }

        public virtual void HandlePlayer(IPlayer player)
        {
            _logger.LogSpecialSquare(this, player);
        }
    }
}