using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Models
{
    public class UserInput
    {
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public int Length { get; set; }
        public int Alignment { get; set; }

    }
}
