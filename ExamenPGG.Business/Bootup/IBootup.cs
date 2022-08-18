using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenPGG.Business.Bootup
{
    public interface IBootup
    {
        string AskPlayerNumber();
        void InitialPlayerNumber();
        string AskPlayerNames();
        void InputPlayerNames();
        void CreateGame();
    }
}
