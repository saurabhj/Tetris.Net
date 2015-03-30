namespace Tetris {
    /// <summary>
    /// The Square Shape
    /// **
    /// **
    /// </summary>
    public class Square : Shape {

        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Square"/> class.
        /// </summary>
        public Square() {
            this.AddShape(new int[,] { { 1, 1 }, { 1, 1 } });
        }

        #endregion



    }
}
