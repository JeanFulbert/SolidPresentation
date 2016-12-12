namespace SolidPresentation.OCP
{
    public class Product
    {
        public Product(ProductColor color, ProductSize size)
        {
            this.Color = color;
            this.Size = size;
        }
        
        public ProductColor Color { get; private set; }
        public ProductSize Size { get; private set; }
    }
}