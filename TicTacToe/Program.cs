using System;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Input;

namespace TicTacToe
{
    internal class Program
    {
        public static bool Running = true;
        static void Main(string[] args)
        {
            Player player1 = new Player('X', "Dan");
            Player player2 = new Player('O', "Jimmy");


            Board board = new Board(player1, player2);
            Renderer renderer = new Renderer(board);
            renderer.RenderBoard();

            while (Running)
            {
                ConsoleKey key = Console.ReadKey().Key;
                board.SetCursor(key);
                if (board.PlacePiece(key))
                {
                    if (board.HasWon()) break;
                    board.NextTurn();
                    Console.Clear();
                    renderer.RenderBoard();
                }

                ;
                Console.Clear();
                renderer.RenderBoard();

                if (key == ConsoleKey.Escape) return;

            }
            Console.Clear();
            renderer.RenderBoard();
            Console.WriteLine(board.PlayerTurn.Name + " HAS WON");

        }
    }
}
