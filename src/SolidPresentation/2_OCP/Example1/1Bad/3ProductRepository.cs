namespace SolidPresentation.OCP.Example1.Bad.Step3
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Logger.Log("Before GetAllProducts");
            var products = this.context.Products;
            Logger.Log("After GetAllProducts: " + products.Count + " products");
            stopwatch.Stop();
            Logger.Log("GetAllProducts: " + stopwatch.ElapsedMilliseconds + "ms");

            return products;
        }
    }
}
