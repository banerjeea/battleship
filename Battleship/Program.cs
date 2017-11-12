using System;
using System.Collections.Generic;
using Battleship.Interfaces;
using M = Battleship.Models;
using S = Battleship.Services;

namespace Battleship
{
    public class Program
    {
        private const string ErrorMessage = "Wrong Input. Must be integer and in range. Hit any key to quit and try again.";
        private static bool _validState;
         
        static void Main()
        {
            IInputValidation inputValidation = new S.InputValidation();
            var userInput = new M.UserInput();

            Console.WriteLine("Welcome to Battleship!");
            Console.WriteLine("Enter your ship's start position. Example: 3,4");

            var input = Console.ReadLine();
            if (!inputValidation.ValidatePosition(input))
                Console.WriteLine(ErrorMessage);
            else
            {
                    userInput.StartRow = Convert.ToInt32(input.Split(",")[0]);
                    userInput.StartColumn = Convert.ToInt32(input.Split(",")[1]);
                    Console.WriteLine("Enter length of your ship. 0 < Length <= 10.");
                    var length2 = Console.ReadLine();

                    if (!inputValidation.ValidateLength(length2))
                        Console.WriteLine(ErrorMessage);
                    else
                    {
                        userInput.Length = Convert.ToInt32(length2);
                        Console.WriteLine("Enter 0 for horizontal and 1 for vertical alignment of ship.");
                        var alignment2 = Console.ReadLine();

                        if (!inputValidation.ValidateAlignment(alignment2))
                            Console.WriteLine(ErrorMessage);
                        else
                        {
                            userInput.Alignment = Convert.ToInt32(alignment2);
                            _validState = true;

                        }
                    }

            }

            if (_validState)
            {
                IShip ship = new S.Ship();
                IBoard board = new S.Board();
                IWorker worker = new S.Worker(board, ship, inputValidation);

                var userboard = new M.Board
                {
                    BoardDimension = new int[10, 10]
                };
                var shipList = new List<M.Ship>();
                if (!worker.AddShips(userInput.StartRow, userInput.StartColumn, userInput.Length, userInput.Alignment,
                    ref shipList, userboard))
                {
                    Console.WriteLine("ship too large or overlap. Hit any key to quit and retry.");

                }
                else
                {
                    
                    worker.Attack(ref shipList, userboard);
                }
            }

            Console.ReadKey();
        }

    }

}
