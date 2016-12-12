namespace SolidPresentation.OCP.Example1.Bad.Step5
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using SolidPresentation.OCP.Example1.Db;

    public class ProductRepository
    {
        private readonly DbContext context;
        private readonly TimeSpan cacheDuration;

        private IReadOnlyCollection<Product> cacheProducts;
        private DateTime lastAccess = DateTime.MinValue;

        public ProductRepository(DbContext context, TimeSpan cacheDuration)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.context = context;
            this.cacheDuration = cacheDuration;
        }

        public IReadOnlyCollection<Product> GetAllProducts()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Logger.Log("Before GetAllProducts");

            var now = DateTime.Now;
            var durationSinceLastAccess = now - lastAccess;
            if (durationSinceLastAccess > this.cacheDuration)
            {
                this.lastAccess = now;
                this.cacheProducts = this.context.Products;
            }
            
            Logger.Log("After GetAllProducts: " + this.cacheProducts.Count + " products");
            stopwatch.Stop();
            Logger.Log("GetAllProducts: " + stopwatch.ElapsedMilliseconds + "ms");

            return this.cacheProducts;
        }
    }
}
