using System;
using System.Linq;
using System.Runtime.ExceptionServices;

namespace TicTacToe
{
    public class Board
    {
        public Player PlayerTurn { get; set; }

        Player _player1, _player2;

        private int pointer = 0;
        private Renderer renderer;
        public string[] board = Enumerable.Repeat(" ", 9).ToArray();

        public bool HasWon()
        {
            //Horizontal
            for (int row = 0; row < 3; row++)
            {
                var first = StripSpecials(board[0 + row * 3]);
                var second = StripSpecials(board[1 + row * 3]);
                var third = StripSpecials(board[2 + row * 3]);

                if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(second) ||
                    string.IsNullOrWhiteSpace(third))
                    break;
                if (first == second && second == third)
                {
                    return true;
                }
            }

            //Vertical
            for (int col = 0; col < 3; col ++)
            {
                var first = StripSpecials(board[col + 0 * 3]);
                var second = StripSpecials(board[col + 1 * 3]);
                var third = StripSpecials(board[col + 2 * 3]);

                if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(second) ||
                    string.IsNullOrWhiteSpace(third))
                    break;
                if (first == second && second == third)
                {
                    return true;
                }
            }

            while (true)
            {
                var first = StripSpecials(board[2]);
                var second = StripSpecials(board[4]);
                var third = StripSpecials(board[6]);

                if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(second) ||
                    string.IsNullOrWhiteSpace(third))
                    break;
                if (first == second && second == third)
                {
                    return true;
                }
            }

            while (true)
            {
                var first = StripSpecials(board[0]);
                var second = StripSpecials(board[4]);
                var third = StripSpecials(board[8]);

                if (string.IsNullOrWhiteSpace(first) || string.IsNullOrWhiteSpace(second) ||
                    string.IsNullOrWhiteSpace(third))
                    break;
                if (first == second && second == third)
                {
                    return true;
                }
            }
            return false;

        }

        private void Select(int index)
        {
            if (board[index].Contains(Renderer.UNDERLINE)) return;
            board[index] = Renderer.UNDERLINE + board[index] + Renderer.RESET;
        }

        public void NextTurn()
        {
            if (_player1 == PlayerTurn)
                PlayerTurn = _player2;
            else
                PlayerTurn = _player1;
        }

        public string StripSpecials(string toStrip)
        {
            string strippedString = toStrip;
            if (strippedString.Contains(Renderer.UNDERLINE))
            {
                strippedString = strippedString.Replace(Renderer.UNDERLINE, "");
            }
            if (strippedString.Contains(Renderer.RESET))
            {
                strippedString = strippedString.Replace(Renderer.RESET, "");
            }

            return strippedString;
        }

        public bool PlacePiece(ConsoleKey key)
        {
            if (key != ConsoleKey.Spacebar) return false;
            string pieceWithoutUnderline = board[pointer];
            pieceWithoutUnderline = pieceWithoutUnderline.Replace(Renderer.UNDERLINE, string.Empty);
            pieceWithoutUnderline = pieceWithoutUnderline.Replace(Renderer.RESET, string.Empty);
            if (!string.IsNullOrWhiteSpace(pieceWithoutUnderline)) return false;

            string playerChar = "X";

            board[pointer] = PlayerTurn.Piece.ToString();
            return true;
            //if (HasWon())
            //{
            //    Program.Running = false;
            //    return;
            //}

            //NextTurn();
            //Console.Clear();
        }

        public void DeselectAll()
        {
            for (int i = 0; i < board.Length; i++)
            {
                if (board[i].Contains(Renderer.UNDERLINE))
                    board[i] = board[i].Replace(Renderer.UNDERLINE, string.Empty);
            }
        }

        public void SetCursor(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    pointer = Math.Clamp(pointer + 1, 0, 8);
                    Console.Clear();
                    DeselectAll();
                    Select(pointer);
                    break;
                case ConsoleKey.LeftArrow:
                    pointer = Math.Clamp(pointer - 1, 0, 8);
                    Console.Clear();
                    DeselectAll();
                    Select(pointer);
                    break;
                case ConsoleKey.UpArrow:
                    pointer = Math.Clamp(pointer - 3, 0, 8);
                    Console.Clear();
                    DeselectAll();
                    Select(pointer);
                    break;
                case ConsoleKey.DownArrow:
                    pointer = Math.Clamp(pointer + 3, 0, 8);
                    Console.Clear();
                    DeselectAll();
                    Select(pointer);
                    break;
            }
        }

        public Board(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
            PlayerTurn = _player1;
        }

    }

}