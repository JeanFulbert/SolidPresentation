using System;
using System.Collections.Generic;

namespace SolidPresentation.OCP.Example2.Bad.ColorOnly
{
    public class ProductFilter
    {
        public IEnumerable<Product> ByColor(IReadOnlyCollection<Product> products, ProductColor productColor)
        {
            foreach (var product in products)
            {
                if (product.Color == productColor)
                    yield return product;
            }
        }
    }

    public class Client
    {
        private readonly ProductFilter productFilter = new ProductFilter();
        private readonly IReadOnlyCollection<Product> products =
            new List<Product> {
                new Product(ProductColor.Blue, ProductSize.Small),
                new Product(ProductColor.Blue, ProductSize.Medium),
                new Product(ProductColor.Brown, ProductSize.Medium),
                new Product(ProductColor.Gold, ProductSize.ReallyBig),
                new Product(ProductColor.Red, ProductSize.Large),
                new Product(ProductColor.Yellow, ProductSize.Large),
                new Product(ProductColor.Yellow, ProductSize.Small)
            };

        public void ShowYellowProducts()
        {
            var filteredProducts = this.productFilter.ByColor(products, ProductColor.Yellow);

            foreach (var p in filteredProducts)
            {
                Console.WriteLine(p.ToString());
            }
        }
    }
}

