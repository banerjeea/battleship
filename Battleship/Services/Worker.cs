using System;
using System.Collections.Generic;
using Battleship.Interfaces;

namespace Battleship.Services
{
    public class Worker : IWorker
    {
        public readonly IBoard Board;
        public readonly IShip Ship;
        public readonly IInputValidation InputValidation;


        public Worker(IBoard board, IShip ship, IInputValidation inputValidation)
        {
            Board = board;
            Ship = ship;
            InputValidation = inputValidation;
        }

        public bool AddShips(int startRow, int startColumn, int length, int alignment, ref List<Models.Ship> shipList, Models.Board board)
        {
            var ship = new Models.Ship
            {
                StartRow = startRow,
                StartColumn = startColumn,
                Length = length,
                IsHorizontal = alignment == 0
            };


            if (!Board.CheckOverlap(shipList, ship, board.BoardDimension))
            {
                return false;
            }
            shipList.Add(ship);
            return true;
        }

        public void Attack(ref List<Models.Ship> shipList, Models.Board board)
        {
                Console.WriteLine("Board is ready.");

                Board.PrintBoard(board.BoardDimension);

                while (shipList.Count != 0)
                {
                    Console.WriteLine("Enter hit position");
                    var input = Console.ReadLine();
                    if (InputValidation.ValidatePosition(input))
                    {
                        var hitPos = Array.ConvertAll(input.Split(","), int.Parse);

                        foreach (var s in shipList)
                        {
                            if (Ship.DestroyShip(hitPos, board.BoardDimension, s))
                            {
                                Console.WriteLine(Environment.NewLine + "Hit!");
                                Board.ReprintOnHit(hitPos[0], hitPos[1], board.BoardDimension);
                            }
                            else
                            {
                                Console.WriteLine("No hit.Try again!" + Environment.NewLine);
                            }
                            if (s.HitCount != s.Length) continue;
                            shipList.Remove(s);
                            break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Invalid hit location.Try again!"+ Environment.NewLine);
                    }

                }
                Console.WriteLine("You win!");

        }
    }
}
