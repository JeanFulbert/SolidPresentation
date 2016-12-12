namespace SolidPresentation.LSP.Violations.Invariants.Bad
{
    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int Area { get { return this.Width * this.Height; } }
    }

    public class RectangleAreaTest
    {
        public void ShouldHaveAreaOf20When4WidthAnd5Height(Rectangle rect)
        {
            rect.Width = 4;
            rect.Height = 5;
            Assert.AreEqual(20, rect.Area);
        }
    }

    #region Violation
    public class Square : Rectangle
    {
        private int width;
        public new int Width
        {
            get { return this.width; }
            set
            {
                this.width = value;
                this.height = value;
            }
        }

        private int height;
        public new int Height
        {
            get { return this.height; }
            set
            {
                this.width = value;
                this.height = value;
            }
        }
    }
    #endregion
}
