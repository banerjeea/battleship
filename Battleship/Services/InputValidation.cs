using System;
using System.Collections.Generic;
using System.Text;
using Battleship.Interfaces;

namespace Battleship.Services
{
    public class InputValidation : IInputValidation
    {
        public bool ValidatePosition(string input)
        {
            if (!input.Contains(","))
                return false;
            var pos = input.Split(",");
            return (int.TryParse(pos[0], out int output1) && output1 >= 0 && output1 <= 10) &&
                   (int.TryParse(pos[1], out int output2) && output2 >= 0 && output2 <= 10);
        }

        public bool ValidateLength(string input)
        {
           
             return int.TryParse(input, out int output) && output > 0 && output <= 10;
        }

        public bool ValidateAlignment(string input)
        {

            return int.TryParse(input, out int output) && output == 0 || output == 1;
        }
    }
}
