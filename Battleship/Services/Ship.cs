using Battleship.Interfaces;

namespace Battleship.Services
{
    public class Ship : IShip
    {

        public bool DestroyShip(int[] hitPosition, int[,] board, Models.Ship ship)
        {
            if (ship.IsHorizontal && hitPosition[0].Equals(ship.StartRow) && hitPosition[1] >= ship.StartColumn &&
                hitPosition[1] <= (ship.Length - 1) + ship.StartColumn)
            {
                //check for already hit.
                if (board[hitPosition[0], hitPosition[1]] != 1)
                {
                    board[hitPosition[0], hitPosition[1]] = 1;
                    ship.HitCount++;
                    return true;

                }
            }
            else if (!ship.IsHorizontal && hitPosition[1].Equals(ship.StartColumn) && hitPosition[0] >= ship.StartRow &&
                     hitPosition[0] <= (ship.Length - 1) + ship.StartRow)
            {
                //check for already hit.
                if (board[hitPosition[0], hitPosition[1]] != 1)
                {
                    board[hitPosition[0], hitPosition[1]] = 1;
                    ship.HitCount++;
                    return true;

                }
            }
            return false;
        }

    }
}
