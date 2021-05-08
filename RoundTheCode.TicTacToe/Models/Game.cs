using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoundTheCode.TicTacToe.Models
{
    public class Game
    {
        public List<WinningCombination> WinningCombinations = new List<WinningCombination>
        {
            new WinningCombination(1, 2, 3),
            new WinningCombination(4, 5, 6),
            new WinningCombination(7, 8, 9),
            new WinningCombination(1, 4, 7),
            new WinningCombination(2, 5, 8),
            new WinningCombination(3, 6, 9),
            new WinningCombination(1, 5, 9),
            new WinningCombination(3, 5, 7)
        };

        public int OWinner { get; set; }

        public int XWinner { get; set; }


        public List<Square> Squares { get; protected set; }

        public MarkEnum NextTurn { get; set; }

        public MarkEnum? Winner { get; set; }

        public Game()
        {
            ResetGame();
        }

        public void Next()
        {
            foreach (var winningCombination in WinningCombinations)
            {
                if (Squares[winningCombination.Square1 - 1].Mark == MarkEnum.O && Squares[winningCombination.Square2 - 1].Mark == MarkEnum.O && Squares[winningCombination.Square3 - 1].Mark == MarkEnum.O)
                {
                    Winner = MarkEnum.O;
                }
                else if (Squares[winningCombination.Square1 - 1].Mark == MarkEnum.X && Squares[winningCombination.Square2 - 1].Mark == MarkEnum.X && Squares[winningCombination.Square3 - 1].Mark == MarkEnum.X)
                {
                    Winner = MarkEnum.X;
                }

            }

            if (Winner.HasValue)
            {
                if (Winner == MarkEnum.O)
                {
                    OWinner += 1;
                }
                if (Winner == MarkEnum.X)
                {
                    XWinner += 1;
                }

                NextTurn = Winner.Value;
            }
            else
            {
                if (NextTurn == MarkEnum.O)
                {
                    NextTurn = MarkEnum.X;
                }
                else
                {
                    NextTurn = MarkEnum.O;
                }
            }
        }

        public void ResetGame()
        {
            Squares = new List<Square>();
            NextTurn = (Winner.HasValue ? Winner.Value : (NextTurn == MarkEnum.O ? MarkEnum.X : MarkEnum.O));
            Winner = null;

            for (var tt=1;tt<=9;tt++)
            {
                Squares.Add(new Square(tt));
            }
        }

    }
}
