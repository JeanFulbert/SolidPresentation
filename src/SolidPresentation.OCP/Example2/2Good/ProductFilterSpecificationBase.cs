using System;
using System.Collections.Generic;

namespace SolidPresentation.OCP.Example2.Good
{
	public abstract class ProductFilterSpecificationBase
	{
		public abstract bool IsValid(Product product);
	}
}

