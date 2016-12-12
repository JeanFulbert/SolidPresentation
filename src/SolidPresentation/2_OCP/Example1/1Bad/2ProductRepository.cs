namespace SolidPresentation.OCP.Example1.Bad.Step2
{
    using System;
    using System.Collections.Generic;
    using SolidPresentation.OCP.Example1.Db;

    public class ProductRepository
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
            Logger.Log("Before GetAllProducts");
            var products = this.context.Products;
            Logger.Log("After GetAllProducts: " + products.Count + " products");

            return products;
        }
    }
}
