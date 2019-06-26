using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

namespace Bomberman.GameLogic.Player
{
    public class GameFactory
    {
        private readonly object createGameLokc = new object();
        public static GameFactory Instance = new GameFactory();
        private GameFactory()
        {
        }

        public List<Game> Games = new List<Game>();

        public Player ConnectPlayer(uint? playerId = null)
        {
            Player player = null;
            if (playerId.HasValue)
            {
                player = GetPlayerIfExists(playerId.Value);
                if (player != null)
                {
                    return player;
                }
            }

            lock (createGameLokc)
            {
                Game game = Games.FirstOrDefault(g => g.SecondPlayer == null);

                if (game != null)
                {
                    player = new Player(PlayerIdProvider.Instance.GetId(), 10, 10, game);
                    game.SetSecondPlayer(player);
                    Monitor.Pulse(createGameLokc);
                    return player;
                }
                else
                {
                    game = new Game();
                    player = new Player(PlayerIdProvider.Instance.GetId(), 0, 0, game);
                    game.SetFirstPlayer(player);
                    Games.Add(game);
                    Monitor.Wait(createGameLokc);
                    return player;
                }
            }
        }

        public Player GetPlayerIfExists(uint playerId)
        {
            var game = Games.Find(g => g.FirstPlayer.ID.Equals(playerId) || g.SecondPlayer.ID.Equals(playerId));
            if (game != null)
            {
                return game.FirstPlayer.ID.Equals(playerId) ? game.FirstPlayer : game.SecondPlayer;
            }
            else
            {
                return null;
            }
        }
    }
}
