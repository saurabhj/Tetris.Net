using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tetris {
    /// <summary>
    /// The abstract Shape Class. Implments most of the basic functionality for shapes.
    /// </summary>
    public abstract class Shape {

        #region Private Properties

        private readonly List<int[,]> _shapes = new List<int[,]>();
        private Point _position;

        private int state = 0;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Point Position {
            get { return _position; }
            set { _position = value; }
        }

        /// <summary>
        /// Gets the length.
        /// </summary>
        /// <value>
        /// The length.
        /// </value>
        public int Length {
            get { return _shapes[state].GetLength(0); }
        }

        /// <summary>
        /// Gets the breadth.
        /// </summary>
        /// <value>
        /// The breadth.
        /// </value>
        public int Breadth {
            get { return _shapes[state].GetLength(1); }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Adds a particular shape to the list of shapes.
        /// </summary>
        /// <param name="shape">The shape.</param>
        protected void AddShape(int[,] shape) {
            _shapes.Add(shape);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Rotates the shape clockwise.
        /// </summary>
        public void RotateClockwise() {
            state = Math.Abs(state + 1) % _shapes.Count;
        }

        /// <summary>
        /// Rotates the shape anti clockwise.
        /// </summary>
        public void RotateAntiClockwise() {
            state--;
            if (state < 0) {
                state = _shapes.Count - 1;
            }
        }

        /// <summary>
        /// Gets the geometry of the shape in the particular rotation.
        /// </summary>
        /// <returns></returns>
        public int[,] GetGeometry() {
            return _shapes[state];
        }

        /// <summary>
        /// Sets the X Position to the specified value
        /// </summary>
        /// <param name="x">The x.</param>
        public void SetX(int x) {
            _position.X = x;
        }

        /// <summary>
        /// Sets the Y Position to the specified value
        /// </summary>
        /// <param name="y">The y.</param>
        public void SetY(int y) {
            _position.Y = y;
        }

        /// <summary>
        /// Moves the shape by the specified offset
        /// </summary>
        /// <param name="xShift">The x shift.</param>
        /// <param name="yShift">The y shift.</param>
        public void Move(int xShift, int yShift) {
            _position.Offset(xShift, yShift);
        }

        #endregion
    }
}
