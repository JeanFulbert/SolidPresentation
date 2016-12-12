namespace SolidPresentation.LSP.Violations.Invariants.Better
{

    public class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public int Area { get { return this.Width * this.Height; } }
    }

    public class Square
    {
        public int Size { get; set; }

        public int Area { get { return this.Size * this.Size; } }
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
}
