namespace SolidPresentation.OCP.Example1.Good
{
    using System;
    using System.Collections.Generic;

    public class ProductRepositoryWithCacheAndDurationProxy : IProductRepository
    {
        private readonly IProductRepository productRepository;
        private readonly TimeSpan cacheDuration;
        private IReadOnlyCollection<Product> cacheProducts;
        private DateTime lastAccess = DateTime.MinValue;

        public ProductRepositoryWithCacheAndDurationProxy(IProductRepository productRepository, TimeSpan cacheDuration)
        {
            if (productRepository == null)
            {
                throw new ArgumentNullException(nameof(productRepository));
            }

            this.productRepository = productRepository;
            this.cacheDuration = cacheDuration;
        }

        public IReadOnlyCollection<Product> GetAllProducts()
        {
            var now = DateTime.Now;
            var durationSinceLastAccess = now - lastAccess;
            if (durationSinceLastAccess > this.cacheDuration)
            {
                this.lastAccess = now;
                this.cacheProducts = this.productRepository.GetAllProducts();
            }

            return this.cacheProducts;
        }
    }
}
