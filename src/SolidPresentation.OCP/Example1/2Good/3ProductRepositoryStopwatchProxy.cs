namespace SolidPresentation.OCP.Example1.Good
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using SolidPresentation.OCP.Example1.Db;

    public class ProductRepositoryStopwatchProxy : IProductRepository
    {
        private readonly IProductRepository productRepository;

        public ProductRepositoryStopwatchProxy(IProductRepository productRepository)
        {
            if (productRepository == null)
            {
                throw new ArgumentNullException(nameof(productRepository));
            }

            this.productRepository = productRepository;
        }

        public IReadOnlyCollection<Product> GetAllProducts()
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var products = this.productRepository.GetAllProducts();

            stopwatch.Stop();
            Logger.Log("GetAllProducts: " + stopwatch.ElapsedMilliseconds + "ms");

            return products;
        }
    }
}
