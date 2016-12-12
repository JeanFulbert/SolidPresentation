using System;
using System.Collections.Generic;

namespace SolidPresentation.OCP.Example2.Bad.ColorAndSize
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

		public IEnumerable<Product> ByColorAndSize(
			IReadOnlyCollection<Product> products, 
			ProductColor productColor, 
			ProductSize productSize)
		{
			foreach (var product in products)
			{
				if (product.Color == productColor && product.Size == productSize)
					yield return product;
			}
		}

		public IEnumerable<Product> BySize(
			IReadOnlyCollection<Product> products,
			ProductSize productSize)
		{
			foreach (var product in products)
			{
				if (product.Size == productSize)
					yield return product;
			}
		}
	}

	public class Client
	{
		private readonly ProductFilter productFilter = new ProductFilter ();
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

		public void ShowYellowAndLargeProducts()
		{
			var filteredProducts = this.productFilter.ByColorAndSize (products, ProductColor.Yellow, ProductSize.Large);

			foreach (var p in filteredProducts)
			{
				Console.WriteLine (p.ToString());
			}
		}
	}
}

