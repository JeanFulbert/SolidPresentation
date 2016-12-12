namespace SolidPresentation.OCP.Example1.Good
{
    using System;
    using SolidPresentation.OCP.Example1.Db;

    public class Client
    {
        public void ReadProducts()
        {
            var simpleRepo = new ProductRepository(new DbContext());

            var repo = 
                new ProductRepositoryWithCacheProxy(
                    new ProductRepositoryStopwatchProxy(
                        new ProductRepositoryLoggerProxy(simpleRepo)));

            var repoWithCacheDuration =
                new ProductRepositoryStopwatchProxy(
                new ProductRepositoryWithCacheAndDurationProxy(
                    simpleRepo, TimeSpan.FromMinutes(1)));
        }
    }
}
