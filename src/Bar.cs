namespace Tetris {
    /// <summary>
    /// The Bar Shape
    /// ****
    /// </summary>
    public class Bar : Shape {

        #region Ctor

        public Bar() {
            this.AddShape(new int[,] { { 1, 1, 1, 1 } });
            this.AddShape(new int[,] { { 1 }, { 1 }, { 1 }, { 1 } });
        }

        #endregion

    }
}
