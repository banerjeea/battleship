using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Interfaces
{
    public interface IShip
    {
        bool DestroyShip(int[] hitPosition, int[,] board, Models.Ship ship);
    }
}
