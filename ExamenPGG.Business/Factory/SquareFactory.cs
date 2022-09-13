using ExamenPGG.Business.DiceObject;
using ExamenPGG.Business.Logging;
using ExamenPGG.Business.Squares;

namespace ExamenPGG.Business.Factory
{
    public class SquareFactory : ISquareFactory
    {
        private IDiceFactory _diceFactory;
        private IDice        MysteryDice;
        private ILogger      _logger;

        public SquareFactory(IDiceFactory diceFactory, ILogger logger)
        {
            _diceFactory = diceFactory;
            _logger = logger;
            MysteryDice = _diceFactory.CreateDice();
        }
        public ISquare CreateSquare(int id, SquareType SquareType)
        {
            switch (SquareType)
            {
                case SquareType.Start:
                    return new Start(id, _logger);
                case SquareType.Final:
                    return new Final(id, _logger);
                case SquareType.Standard:
                    return new Standard(id, _logger);
                case SquareType.Cobweb:
                    return new Cobweb(id, _logger);
                case SquareType.Ladder:
                    return new Ladder(id, _logger);
                case SquareType.FallTrap:
                    return new FallTrap(id, _logger);
                case SquareType.Mystery:
                    return new Mystery(id, MysteryDice, _logger);
                case SquareType.Bat:
                    return new Bat(id, _logger);
                default:
                    throw new ArgumentOutOfRangeException($"No valid square type: {nameof(SquareType)}");
            }
        }
    }
}