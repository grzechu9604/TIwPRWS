﻿using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Bomberman.GameLogic.Player
{
    public class GameStateSender
    {
        public static GameStateSender Instance = new GameStateSender();
        private GameStateSender()
        {
            InitTimer();
        }

        private ConcurrentDictionary<uint, WebSocket> sockets = new ConcurrentDictionary<uint, WebSocket>();

        public void AddSocket(uint playerId, WebSocket socket)
        {
            sockets.AddOrUpdate(playerId, socket, (key, oldValue) => socket);
        }

        private System.Timers.Timer timer;
        private void InitTimer()
        {
            timer = new System.Timers.Timer();
            timer.Elapsed += Timer_Elapsed;
            timer.Interval = 500; // in miliseconds
            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            SendGameStates();
        }

        private void SendGameStates()
        {
            Parallel.ForEach(sockets, s =>
            {
                var player = GameFactory.Instance.GetPlayerIfExists(s.Key);
                if (player.Game.IsReady)
                {
                    s.Value.SendAsync(player.GetGameState(), WebSocketMessageType.Binary, true, CancellationToken.None);
                }
            });
        }
    }
}
