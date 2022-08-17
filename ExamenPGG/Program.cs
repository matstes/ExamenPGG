using ExamenPGG.Business;
using ExamenPGG.Business.Game;
using ExamenPGG.Business.Squares;

ISquareFactory squareFactory = new SquareFactory();
IGameBoard gameBoard = new GameBoard(squareFactory);
IDice dice = new Dice();

foreach (var square in gameBoard.Squares)
{
    Console.WriteLine($" ID: {square.ID} \t SquareType: {square.SquareType.ToString()}");
}


List<string> list = new List<string>() { "Kate", "John", "Paul", "Eve", "Hugo" };

void ChangePlayer(List<string> list) 
{
    string temp = list[0];
    list.Remove(list[0]);
    list.Insert(list.Count, temp);
    foreach (var i in list)
    {
        Console.Write($"{ i }");
    }
    Console.WriteLine("");
}

ChangePlayer(list);
ChangePlayer(list);
ChangePlayer(list);
ChangePlayer(list);
ChangePlayer(list);
ChangePlayer(list);
ChangePlayer(list);
ChangePlayer(list);




