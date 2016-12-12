using System;
using System.Collections.Generic;

namespace SolidPresentation.OCP.Example2.Good
{
	public class Client
	{
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
			var specification =
				new AndCompositeFilterSpecification (
					new ColorFilterSpecification (ProductColor.Yellow),
					new SizeFilterSpecification (ProductSize.Large));
			
			foreach (var p in products.FilterBy(specification))
			{
				Console.WriteLine (p.ToString());
			}
		}
	}
}

