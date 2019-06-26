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

        public void DoStep()
        {
            switch (Direction)
            {
                case Direction.UP:
                    ChangeYByValue(-1);
                    break;
                case Direction.DOWN:
                    ChangeYByValue(1);
                    break;
                case Direction.RIGHT:
                    ChangeXByValue(1);
                    break;
                case Direction.LEFT:
                    ChangeXByValue(-1);
                    break;
            }
        }

        private void ChangeXByValue(int value)
        {
            if (value > 0 && Coordinates.X == GameConsts.MaxX)
            {
                Coordinates.X = 0;
            }
            else if (value < 0 && Coordinates.X == 0)
            {
                Coordinates.X = GameConsts.MaxX;
            }
            else
            {
                Coordinates.X += value;
            }
        }

        private void ChangeYByValue(int value)
        {
            if (value > 0 && Coordinates.Y == GameConsts.MaxY)
            {
                Coordinates.Y = 0;
            }
            else if (value < 0 && Coordinates.Y == 0)
            {
                Coordinates.Y = GameConsts.MaxY;
            }
            else
            {
                Coordinates.Y += value;
            }
        }
    }
}
