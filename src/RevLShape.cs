namespace Tetris {
    /// <summary>
    /// The Reverse L Shape
    ///  *
    ///  *
    /// **
    /// </summary>
    public class RevLShape: Shape {

        #region Ctor

        public RevLShape() {
            this.AddShape(new int[,] { { 0, 1 }, { 0, 1 }, { 1, 1 } });
            this.AddShape(new int[,] { { 1, 0, 0 }, { 1, 1, 1 } });
            this.AddShape(new int[,] { { 1, 1 }, { 1, 0 }, { 1, 0 } });
            this.AddShape(new int[,] { { 1, 1, 1 }, { 0, 0, 1 } });
        }

        #endregion


    }
}
