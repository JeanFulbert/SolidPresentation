namespace SolidPresentation.OCP.Example1.Bad.Step4
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using SolidPresentation.OCP.Example1.Db;

    public class ProductRepository
    {
        private readonly DbContext context;

        private IReadOnlyCollection<Product> cacheProducts;

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

            if (this.cacheProducts == null)
            {
                this.cacheProducts = this.context.Products;
            }
            
            Logger.Log("After GetAllProducts: " + this.cacheProducts.Count + " products");
            stopwatch.Stop();
            Logger.Log("GetAllProducts: " + stopwatch.ElapsedMilliseconds + "ms");

            return this.cacheProducts;
        }
    }
}
