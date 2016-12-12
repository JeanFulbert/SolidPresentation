namespace SolidPresentation.OCP.Example1.Good
{
    using System;
    using System.Collections.Generic;

    public class ProductRepositoryWithCacheProxy : IProductRepository
    {
        private readonly IProductRepository productRepository;
        private IReadOnlyCollection<Product> cacheProducts;

        public ProductRepositoryWithCacheProxy(IProductRepository productRepository)
        {
            if (productRepository == null)
            {
                throw new ArgumentNullException(nameof(productRepository));
            }

            this.productRepository = productRepository;
        }

        public IReadOnlyCollection<Product> GetAllProducts()
        {
            if (this.cacheProducts == null)
            {
                this.cacheProducts = this.productRepository.GetAllProducts();
            }

            return this.cacheProducts;
        }
    }
}
