using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoundTheCode.TicTacToe.Models
{
    public class Square
    {
        public int Number { get; }

        public MarkEnum? Mark { get; set; }

        public Square(int number)
        {
            Number = number;
        }

    }
}
