namespace Tetris {
    /// <summary>
    /// The Z-Shape
    ///  *
    /// **
    /// *
    /// </summary>
    public class ZShape: Shape {

        #region Ctor

        public ZShape() {
            this.AddShape(new int[,] { { 0, 1 }, { 1, 1 }, { 1, 0 } });
            this.AddShape(new int[,] { { 1, 1, 0 }, { 0, 1, 1 } });
        }

        #endregion


    }
}
