using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Interfaces
{
    public interface IBoard
    {
        void PrintBoard(int[,] board);
        bool CheckOverlap(List<Models.Ship> ships, Models.Ship ship, int[,] board);
        void ReprintOnHit(int row, int col, int[,] board);
    }
}
