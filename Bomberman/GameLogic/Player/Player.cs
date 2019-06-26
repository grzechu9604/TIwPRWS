using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace Bomberman.GameLogic.Player
{
    public enum Direction
    {
        UP = 1,
        DOWN = 2,
        RIGHT = 3,
        LEFT = 4
    }
    public class Player
    {
        public readonly Game Game;
        public readonly uint ID;
        public Direction Direction;
        public Point Coordinates;
        public byte Score;
        public DateTime NextShotMinimalTimestamp;

        public Player(uint id, int x, int y, Game game)
        {
            ID = id;
            Coordinates = new Point(x, y);
            Direction = Direction.UP;
            Score = 0;
            Game = game;
            NextShotMinimalTimestamp = DateTime.Now;
        }
    }
}
