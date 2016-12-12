using System;
using System.Linq;
using System.Collections.Generic;

namespace SolidPresentation.OCP.Example2.Good
{
    public class OrCompositeFilterSpecification : ProductFilterSpecificationBase
	{
		private readonly IEnumerable<ProductFilterSpecificationBase> specifications;

		public OrCompositeFilterSpecification (params ProductFilterSpecificationBase[] specifications)
		{
			this.specifications = specifications;
		}

		public override bool IsValid (Product product)
		{
			return this.specifications.Any(s => s.IsValid(product));
		}
	}
}

