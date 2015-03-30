using System;
using System.Threading;

namespace Tetris {
    class Program {
        /// <summary>
        /// The Main Method
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main(string[] args) {
            // Init new game
            var game = new Game {State = true};

            // Initializing the board
            var board = new Board();

            // Getting active shape
            Shape activeShape = null;

            // Random number generator
            var rnd = new Random(DateTime.UtcNow.Millisecond);

            // Loop till the game is over
            while (game.State) {
                if (activeShape == null) {
                    activeShape = game.GetNewShape(rnd);
                    activeShape.SetX(rnd.Next(board.Breadth - activeShape.Breadth));
                    activeShape.SetY(0);

                    // Check if this is the final state of the shape, then the game is over
                    if (board.IsFinalMove(activeShape)) {
                        game.State = false;
                        break;
                    }
                }

                // Update the active shape on the board
                board.AddShape(activeShape, false);

                // Render the board
                board.Draw();
              
                var k = Console.ReadKey();
                switch (k.KeyChar) {
                    case 'a':
                    case 'A':
                        if (board.IsValidMove(activeShape, -1, 1)) {
                            activeShape.Move(-1, 1);
                        }
                        else {
                            FlashScreen(board, ConsoleColor.DarkMagenta);
                        }
                        break;

                    case 'd':
                    case 'D':
                        if (board.IsValidMove(activeShape, 1, 1)) {
                            activeShape.Move(1, 1);
                        }
                        else {
                            FlashScreen(board, ConsoleColor.DarkMagenta);
                        }
                        break;

                    case 'w':
                    case 'W':
                        activeShape.RotateAntiClockwise();
                        if (board.IsValidMove(activeShape, 0, 1)) {
                            activeShape.Move(0, 1);
                        }
                        else {
                            activeShape.RotateClockwise();
                            FlashScreen(board, ConsoleColor.DarkMagenta);
                        }
                        break;

                    case 's':
                    case 'S':
                        activeShape.RotateClockwise();
                        if (board.IsValidMove(activeShape, 0, 1)) {
                            activeShape.Move(0, 1);
                        }
                        else {
                            activeShape.RotateAntiClockwise();
                            FlashScreen(board, ConsoleColor.DarkMagenta);
                        }
                        break;

                    case (char)27:
                        game.State = false;
                        break;

                    default:
                        FlashScreen(board, ConsoleColor.Red);
                        break;
                }

                // Checking if this is the final move for the active shape, lock it
                if (board.IsFinalMove(activeShape)) {
                    board.AddShape(activeShape, true);
                    activeShape = null;
                    FlashScreen(board, ConsoleColor.Yellow);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Game Over. Hit any key to quit ...");
            Console.ReadKey();
        }

        /// <summary>
        /// Flashes the board with a different colour
        /// </summary>
        /// <param name="board">The board.</param>
        /// <param name="color">The color.</param>
        public static void FlashScreen(Board board, ConsoleColor color) {
            Console.ForegroundColor = color;
            Thread.Sleep(50);
            board.Draw();
            Thread.Sleep(50);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
