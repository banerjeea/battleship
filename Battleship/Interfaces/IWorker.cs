using System.Collections.Generic;

namespace Battleship.Interfaces
{
    public interface IWorker
    {
        bool AddShips(int startRow, int startColumn, int length, int alignment, ref List<Models.Ship> shipList, Models.Board board);

        void Attack(ref List<Models.Ship> shipList, Models.Board board);
    }
}
