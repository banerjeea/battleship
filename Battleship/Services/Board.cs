using System;
using System.Collections.Generic;
using Battleship.Interfaces;

namespace Battleship.Services
{
    public class Board : IBoard
    {
        public void PrintBoard(int[,] board)
        {
            for (int i = 0; i <= board.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= board.GetLength(1) - 1; j++)
                {
                    Console.Write(board[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
        public void ReprintOnHit(int row, int col, int[,] board)
        {
            for (int i = 0; i <= board.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= board.GetLength(1) - 1; j++)
                {
                    if (board[row, col] == 0)
                    {
                        board[row, col] = 1;

                    }
                    Console.Write(board[i, j] + " ");

                }

                Console.WriteLine();
            }
            Console.WriteLine(Environment.NewLine);
        }

        public bool CheckOverlap(List<Models.Ship> ships, Models.Ship ship, int[,] board)
        {
            var horizontalCondition =
                ship.IsHorizontal && ship.StartColumn + ship.Length - 1 <= board.GetLength(1);
            var verticalCondition =
                !ship.IsHorizontal && ship.StartRow + ship.Length - 1 <= board.GetLength(0);

            if (ships.Count > 0)
            {
                foreach (var s in ships)
                {
                    if (horizontalCondition)
                    {
                        if (s.StartRow == ship.StartRow && s.StartColumn >= ship.StartColumn &&
                            s.StartColumn + s.Length - 1 <= ship.StartColumn)
                        {
                            return false;
                        }
                    }
                    else if (verticalCondition)
                    {
                        if (s.StartColumn == ship.StartColumn && s.StartRow >= ship.StartRow &&
                            s.StartRow + s.Length - 1 <= ship.StartRow)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }

                }
            }
            else
            {
                return horizontalCondition || verticalCondition;
            }

            return false;
        }
    }
}
