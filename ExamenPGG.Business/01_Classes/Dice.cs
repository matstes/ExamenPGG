using ExamenPGG.Business._00_Interfaces;

namespace ExamenPGG.Business._01_Classes
{
    public class Dice : IDice
    {
        public Random dice { get; set; }

        public Dice()
        {
            dice = new Random();
        }
        public int RollDice(int rollAmount)
        {
            int diceTotal = 0;

            for (int i = 0; i < rollAmount; i++)
            {
                diceTotal += dice.Next(1, 7); ;
            }

            return diceTotal;
        }
    }
}
