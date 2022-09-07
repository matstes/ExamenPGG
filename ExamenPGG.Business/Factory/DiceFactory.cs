using ExamenPGG.Business.DiceObject;

namespace ExamenPGG.Business.Factory
{
    public class DiceFactory : IDiceFactory
    {
        public IDice CreateDice()
        {
            return new Dice();
        }
    }
}
