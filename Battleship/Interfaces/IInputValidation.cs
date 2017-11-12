using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Interfaces
{
    public interface IInputValidation
    {
        bool ValidatePosition(string input);
        bool ValidateLength(string input);
        bool ValidateAlignment(string input);
    }
}
