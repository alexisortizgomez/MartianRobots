using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MartianRobots
{
    public class Robot
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Orientation Orientation { get; private set; }
        public bool IsLost { get; private set; }
        private Mars _mars;

        public Robot(int x, int y, Orientation orientation, Mars mars)
        {
            X = x;
            Y = y;
            Orientation = orientation;
            _mars = mars;
        }

        public void ExecuteCommand(Command command)
        {
            if (!IsLost)
            {
                switch (command)
                {
                    case Command.forward:
                        MoveFoward();
                        break;
                    case Command.right:
                        MoveRight();
                        break;
                    case Command.left:
                        MoveLeft();
                        break;
                    default:
                        throw new ArgumentException($"Comando {command} no reconocido");
                }
            }
        }

        private void MoveFoward()
        {
            var nextPosition = NextPositionIfMovedForward();

            if (IsOutOfBounds(nextPosition.X, nextPosition.Y))
            {
                if (!_mars.IsScented(X, Y))
                {
                    IsLost = true;
                    _mars.AddScentedCoordinate(X, Y);
                }
            }
            else
            {
                X = nextPosition.X;
                Y = nextPosition.Y;
            }
        }

        private void MoveRight()
        {
            if (Orientation == Orientation.west)
                Orientation = Orientation.north;
            else
                Orientation++;
        }

        private void MoveLeft()
        {
            if (Orientation == Orientation.north)
                Orientation = Orientation.west;
            else
                Orientation--;
        }

        private Coordinate NextPositionIfMovedForward()
        {
            var nextPosition = new Coordinate(X, Y);

            if (Orientation == Orientation.north)
                nextPosition.Y++;
            else if (Orientation == Orientation.east)
                nextPosition.X++;
            else if (Orientation == Orientation.south)
                nextPosition.Y--;
            else if (Orientation == Orientation.west)
                nextPosition.X--;

            return nextPosition;
        }

        private bool IsOutOfBounds(int x, int y)
        {
            return x > _mars.XBound || x < 0 || y > _mars.YBound || y < 0;
        }
    }
}
