using System;
using System.Collections.Generic;

namespace SolidPresentation.OCP.Example2.Good
{
    public class ColorFilterSpecification : ProductFilterSpecificationBase
    {
        private readonly ProductColor color;

        public ColorFilterSpecification(ProductColor color)
        {
            this.color = color;
        }

        public override bool IsValid(Product product)
        {
            return product.Color == this.color;
        }
    }
}

