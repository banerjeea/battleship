using System;
using System.Collections.Generic;
using System.Text;

namespace Battleship.Models
{
    public class Ship
    {
        public int StartRow { get; set; }
        public int StartColumn { get; set; }
        public int Length { get; set; }
        public int HitCount { get; set; }
        public bool IsHorizontal { get; set; }
    }
}
