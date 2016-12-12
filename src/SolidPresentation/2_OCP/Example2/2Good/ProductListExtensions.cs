using System;
using System.Linq;
using System.Collections.Generic;

namespace SolidPresentation.OCP.Example2.Good
{
	public static class ProductListExtensions
	{
		public static IEnumerable<Product> FilterBy(
			this IEnumerable<Product> products,
			ProductFilterSpecificationBase filterSpecification)
		{
			return products.Where (p => filterSpecification.IsValid (p));
		}
	}
}

