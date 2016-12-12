using System;
using System.Linq;
using System.Collections.Generic;

namespace SolidPresentation.OCP.Example2.Good
{
	public class AndCompositeFilterSpecification : ProductFilterSpecificationBase
	{
		private readonly IEnumerable<ProductFilterSpecificationBase> specifications;

		public AndCompositeFilterSpecification (params ProductFilterSpecificationBase[] specifications)
		{
			this.specifications = specifications;
		}

		public override bool IsValid (Product product)
		{
			return this.specifications.All(s => s.IsValid(product));
		}
	}
}

