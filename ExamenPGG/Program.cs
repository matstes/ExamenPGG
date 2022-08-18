using ExamenPGG.Business;
using ExamenPGG.Business.Bootup;
using ExamenPGG.Business.Game;
using ExamenPGG.Business.Squares;


//GAMESTATE = BOOT
//Input player number
//Input player names
//Continue to main loop
Bootup boot = new Bootup();
while (boot.isReady == false)
{
    Console.WriteLine(boot.AskPlayerNumber());
    boot.InitialPlayerNumber();
    while (boot.playerNumber >= 0 && boot.playerNumber <= 5 && boot.isReady == false)
    {
        Console.WriteLine(boot.AskPlayerNames());
        boot.InputPlayerNames();
    }
}

//GAMESTATE = MAIN LOOP
    //TODO

//GAMESTATE = FINALIZE
    //TODO