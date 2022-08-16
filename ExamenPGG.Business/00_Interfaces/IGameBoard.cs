namespace ExamenPGG.Business._00_Interfaces
{
    public interface IGameBoard
    {
        List<ISquare> Squares { get; set; }

        ISquareFactory SquareFactory { get; set; }

        List<ISquare> FillBoard();
    }
}