namespace ExamenPGG.Business._00_Interfaces
{
    public interface IDice
    {
        Random dice { get; set; }
        int RollDice(int rollAmount);
    }
}