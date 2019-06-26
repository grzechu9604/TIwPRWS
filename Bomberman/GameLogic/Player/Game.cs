using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bomberman.GameLogic.Player
{
    public class Game
    {
        public Player FirstPlayer { get; private set; }
        public Player SecondPlayer { get; private set; }

        public Game()
        {
        }

        public void SetFirstPlayer(Player p)
        {
            if (FirstPlayer != null)
            {
                throw new InvalidOperationException("Gra ma już gracza!");
            }

            FirstPlayer = p;
        }

        public void SetSecondPlayer(Player p)
        {
            if (SecondPlayer != null)
            {
                throw new InvalidOperationException("Gra ma już gracza!");
            }

            SecondPlayer = p;
        }

        public bool IsReady => FirstPlayer != null && SecondPlayer != null;
    }
}
