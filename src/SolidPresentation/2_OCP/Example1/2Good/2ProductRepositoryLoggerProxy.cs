namespace SolidPresentation.OCP.Example1.Good
{
    using System;
    using System.Collections.Generic;
    using SolidPresentation.OCP.Example1.Db;

    public class ProductRepositoryLoggerProxy : IProductRepository
    {
        private readonly IProductRepository productRepository;

        public ProductRepositoryLoggerProxy(IProductRepository productRepository)
        {
            if (productRepository == null)
            {
                throw new ArgumentNullException(nameof(productRepository));
            }

            this.productRepository = productRepository;
        }

        public IReadOnlyCollection<Product> GetAllProducts()
        {
            Logger.Log("Before GetAllProducts");

            var products = this.productRepository.GetAllProducts();

            Logger.Log("After GetAllProducts: " + products.Count + " products");

            return products;
        }
    }
}
