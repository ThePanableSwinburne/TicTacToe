using System;
using System.Runtime.InteropServices;

namespace TicTacToe
{
    public class Renderer
    {
        private Board _board;
        public const string UNDERLINE = "\x1B[4m";
        public const string RESET = "\x1B[0m";
        const int STD_OUTPUT_HANDLE = -11;
        const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 4;
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        public Renderer(Board board)
        {
            _board = board;
            var handle = GetStdHandle(STD_OUTPUT_HANDLE);
            uint mode;
            GetConsoleMode(handle, out mode);
            mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING;
            SetConsoleMode(handle, mode);
            StatusText = $"                                    It's {_board.PlayerTurn.Name}'s Turn!";
        }

        public string StatusText;

        public void RenderBoard()
        {
            Console.WriteLine(StatusText);
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {_board.board[0]}  |  {_board.board[1]}  |  {_board.board[2]}   ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {_board.board[3]}  |  {_board.board[4]}  |  {_board.board[5]}   ");
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine($"  {_board.board[6]}  |  {_board.board[7]}  |  {_board.board[8]}   ");
            Console.WriteLine("     |     |      ");
            StatusText = $"                                    It's {_board.PlayerTurn.Name}'s Turn!";

        }
    }
}