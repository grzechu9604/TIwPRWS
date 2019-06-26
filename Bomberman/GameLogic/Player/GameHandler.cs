using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;

namespace Bomberman.GameLogic.Player
{
    public class GameHandler
    {
        public static GameHandler Instance = new GameHandler();
        private GameHandler()
        {
            InitTimer();
        }

        private readonly List<Game> Games = GameFactory.Instance.Games;

        public void HandleDirectionChange(uint playerId, Direction direction)
        {
            var player = GameFactory.Instance.GetPlayerIfExists(playerId);
            if (player != null)
            {
                player.Direction = direction;
            }
        }

        public void HandleShot(uint playerId)
        {
            var player = GameFactory.Instance.GetPlayerIfExists(playerId);
            var secoundPlayer = player.Game.FirstPlayer.ID.Equals(player.ID) ? player.Game.SecondPlayer : player.Game.FirstPlayer;
            if (player.Coordinates.X.Equals(secoundPlayer.Coordinates.X) || player.Coordinates.Y.Equals(secoundPlayer.Coordinates.Y))
            {
                player.Score++;
            }
            player.NextShotMinimalTimestamp = DateTime.Now.AddSeconds(1.0d);
        }

        private Timer timer;
        private void InitTimer()
        {
            timer = new Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 500; // in miliseconds
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            ConductGames();
        }

        private void ConductGames()
        {
            Parallel.ForEach(Games.Where(g => g.IsReady), g =>
            {
                g.FirstPlayer.DoStep();
                g.SecondPlayer.DoStep();
            });
        }
    }
}
