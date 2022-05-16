using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public char Piece { get; set; }
        public string Name { get; set; }

        public Player(char piece, string name)
        {
            Piece = piece;
            Name = name;
        }
    }
}
