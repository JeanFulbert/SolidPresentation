namespace SolidPresentation.OCP.Example1.Good
{
    using System.Collections.Generic;

    public interface IProductRepository
    {
        IReadOnlyCollection<Product> GetAllProducts();
    }
}
