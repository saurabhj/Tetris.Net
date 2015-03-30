using System;

namespace Tetris {
    /// <summary>
    /// Contains all methods required for the board to function
    /// </summary>
    public class Board {

        #region Private Properties

        /// <summary>
        /// The length of the board
        /// </summary>
        private const int _length = 20;

        /// <summary>
        /// The breadth of the board
        /// </summary>
        private const int _breadth = 20;

        /// <summary>
        /// The upper margin to leave before rendering the board
        /// </summary>
        private const int _upperMargin = 2;

        /// <summary>
        /// The actual board
        /// </summary>
        private int[,] _board = new int[_length, _breadth];

        /// <summary>
        /// A temporary board used to render the board in UI
        /// </summary>
        private int[,] _tempBoard = new int[_length, _breadth];

        #endregion

        #region Public Properties

        public int Length {
            get { return _length; }
        }

        public int Breadth {
            get { return _breadth; }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Board"/> class.
        /// </summary>
        public Board() {
            _tempBoard = _board;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Draws the board.
        /// </summary>
        public void Draw() {
            Console.Clear();

            // Leave the margins on top
            for (var i = 0; i < _upperMargin; i++) {
                Console.WriteLine();
            }

            // Draw the board
            for (var i = 0; i < _length; i++) {
                Console.Write("|");                     // Borders
                for (var j = 0; j < _breadth; j++) {
                    Console.Write(_tempBoard[j, i] == 0 ? " " : "*");
                }
                Console.Write("|");                     // Borders
                Console.WriteLine();
            }

            // Base Border
            Console.Write("+");
            for (var i = 0; i < _breadth; i++) {
                Console.Write("-");
            }
            Console.WriteLine("+");

            // Write instruction
            Console.WriteLine("a: Left, d: Right, w: Counter Clockwise, s: Clockwise, esc: quit");
        }

        /// <summary>
        /// Adds the shape.
        /// </summary>
        /// <param name="activeShape">The active shape.</param>
        /// <param name="isPermanent">if set to <c>true</c> [is permanent].</param>
        public void AddShape(Shape activeShape, bool isPermanent) {
            // Calculating the positions of the board to be manipulated
            var shape = activeShape.GetGeometry();
            _tempBoard = (int[,])_board.Clone();

            for (var i = 0; i < activeShape.Length; i++) {
                for (var j = 0; j < activeShape.Breadth; j++) {
                    _tempBoard[activeShape.Position.X + j, activeShape.Position.Y + i] += shape[i, j];
                }
            }

            if (isPermanent) {
                _board = (int[,])_tempBoard.Clone();
            }

        }

        /// <summary>
        /// Determines whether [is valid move] [the specified active shape].
        /// </summary>
        /// <param name="activeShape">The active shape.</param>
        /// <param name="xShift">The x shift.</param>
        /// <param name="yShift">The y shift.</param>
        /// <returns></returns>
        public bool IsValidMove(Shape activeShape, int xShift, int yShift) {
            // Generating a temp version of the board
            var tempBoard = (int[,])_board.Clone();
            var shape = activeShape.GetGeometry();

            // Making sure that none of the positions are out of bound
            if (activeShape.Position.X + xShift < 0 || // Left Bound
                activeShape.Position.X + activeShape.Breadth + xShift > _breadth || // Right Bound
                activeShape.Position.Y + activeShape.Length >= _length) { // Bottom Bound
                return false;
            }

            // Adding the shifted shape to the board
            for (var i = 0; i < activeShape.Length; i++) {
                for (var j = 0; j < activeShape.Breadth; j++) {
                    tempBoard[activeShape.Position.X + xShift + j, activeShape.Position.Y + yShift + i] += shape[i, j];
                }
            }

            // Checking if any of the values > 1 in the tempBoard
            for (var i = 0; i < _length; i++) {
                for (var j = 0; j < _breadth; j++) {
                    if (tempBoard[i, j] > 1) {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Determines whether [is final move] [the specified active shape].
        /// </summary>
        /// <param name="activeShape">The active shape.</param>
        /// <returns></returns>
        public bool IsFinalMove(Shape activeShape) {
            // Getting the geometry of the shape
            var shape = activeShape.GetGeometry();

            // Check if any part of the active shape is 1 and is touching the base of the board
            for (var i = 0; i < activeShape.Length; i++) {
                for (var j = 0; j < activeShape.Breadth; j++) {
                    if (shape[i, j] > 0 && (activeShape.Position.Y + i + 1) == _length) {
                        return true;
                    }
                }
            }

            // Checking if any part of the active shape is touching another shape at the bottom
            for (var i = 0; i < activeShape.Length; i++) {
                for (var j = 0; j < activeShape.Breadth; j++) {
                    if (shape[i, j] > 0 && (_board[activeShape.Position.X + j, activeShape.Position.Y + i + 1] > 0)) {
                        return true;
                    }
                }
            }

            var leftMove = IsValidMove(activeShape, -1, 1);
            var rightMove = IsValidMove(activeShape, 1, 1);

            // Trying the clockwise move
            activeShape.RotateClockwise();
            var clockWiseMove = IsValidMove(activeShape, 0, 1);
            activeShape.RotateAntiClockwise();

            // Trying the anticlockwise move
            activeShape.RotateAntiClockwise();
            var antiClockwiseMove = IsValidMove(activeShape, 0, 1);
            activeShape.RotateClockwise();


            return !leftMove && !rightMove && !clockWiseMove && !antiClockwiseMove;
        }

        #endregion

    }
}
