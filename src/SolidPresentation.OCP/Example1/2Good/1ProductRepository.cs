namespace SolidPresentation.OCP.Example1.Good
{
    using System;
    using System.Collections.Generic;
    using SolidPresentation.OCP;
    using SolidPresentation.OCP.Example1.Db;

    public class ProductRepository : IProductRepository
    {
        private readonly DbContext context;

        public ProductRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
        }

        public IReadOnlyCollection<Product> GetAllProducts()
        {
            var products = this.context.Products;
            return products;
        }
    }
}
