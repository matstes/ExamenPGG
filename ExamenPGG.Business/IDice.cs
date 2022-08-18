namespace ExamenPGG.Business
{
    public interface IDice
    {
        Random dice { get; set; }

        int RollDice(int rollAmount);
    }
}