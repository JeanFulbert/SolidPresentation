using System;
using System.Collections.Generic;

namespace SolidPresentation.OCP.Example2.Good
{
	public class SizeFilterSpecification : ProductFilterSpecificationBase
	{
		private readonly ProductSize size;

		public SizeFilterSpecification(ProductSize size)
		{
			this.size = size;
		}

		public override bool IsValid (Product product)
		{
			return product.Size == this.size;
		}
	}
}

