namespace Tetris {
    /// <summary>
    /// The L Shape
    /// *
    /// *
    /// **
    /// </summary>
    public class LShape: Shape {

        #region Ctor

        public LShape() {
            this.AddShape(new int[,] { { 1, 0 }, { 1, 0 }, { 1, 1 } });
            this.AddShape(new int[,] { { 1, 1, 1 }, { 1, 0, 0 } });
            this.AddShape(new int[,] { { 1, 1 }, { 0, 1 }, { 0, 1 } });
            this.AddShape(new int[,] { { 0, 0, 1 }, { 1, 1, 1 } });
        }

        #endregion


    }
}
