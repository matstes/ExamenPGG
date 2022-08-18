using ExamenPGG.Business;
using ExamenPGG.Business.Bootup;
using ExamenPGG.Business.Game;
using ExamenPGG.Business.Logging;
using ExamenPGG.Business.Player;

//GAMESTATE = BOOT
List<IPlayer> gamePlayers = new List<IPlayer>();
Bootup boot = new Bootup();

while (boot.isReady == false)
{
    //Input player number
    Console.WriteLine(boot.AskPlayerNumber());
    boot.InitialPlayerNumber();

    //Input player names or simulate Computer name
    while (boot.playerNumber >= 0 && boot.playerNumber <= 5 && boot.isReady == false)
    {
        //TODO: This does not yet include a choice for player icons! Player NAME input ONLY for now!
        Console.WriteLine(boot.AskPlayerNames());
        boot.InputPlayerNames();
        //boot.activePlayers list (strings) is now created: List of player names ("Computer" or 1-5 real names)
        //boot.isReady is true if all input it complete: Continue to final part of boot sequence
    }
}
//Finalize boot sequence and create game instance:
for (int i = 0; i < boot.activePlayers.Count; i++)
{
    //Create list of player instances from the bootlist of player names:
    string newPlayerName = boot.activePlayers[i];
    Player newPlayer     = new Player()         ;
    newPlayer.Name       = newPlayerName        ;
    gamePlayers.Add(newPlayer);
}
DateTime currentTime    = new DateTime ();
IGameBoard newGameBoard = new GameBoard();
ILogger gameLogger      = new Logger   ();
Dice gameDice           = new Dice     ();
Game newGame            = new Game(gamePlayers, gamePlayers[0], currentTime, 1, newGameBoard, gameLogger, gameDice);



//GAMESTATE = MAIN LOOP

//GAMESTATE = FINALIZE
//TODO



