namespace SolidPresentation.LSP.PostConditions.Bad
{
    public class ShippingCostCalculator
    {
        private const double Margin = 0.5;

        public virtual double Calculate(double packageWeightInKilograms, Size size, RegionInfo region)
        {
            var regionFactor = region == RegionInfo.Usa ? 1.2 : 1;

            return packageWeightInKilograms * (size.Volume / 100) * regionFactor + Margin;
        }
    }

    public class ShippingDescription
    {
        private readonly double packageWeightInKilograms;
        private readonly Size size;
        private readonly RegionInfo region;

        public ShippingDescription(double packageWeightInKilograms, Size size, RegionInfo region)
        {
            this.region = region;
            this.size = size;
            this.packageWeightInKilograms = packageWeightInKilograms;

        }

        public double GetTotalByShippingRatio(double totalCost, ShippingCostCalculator shippingCostCalculator)
        {
            var shippingCost = shippingCostCalculator.Calculate(this.packageWeightInKilograms, this.size, this.region);
            return totalCost / shippingCost;
        }
    }

    public class PremiumShippingCostCalculator : ShippingCostCalculator
    {
        public override double Calculate(double packageWeightInKilograms, Size size, RegionInfo region)
        {
            if (size.Volume > 1000)
                return 0;

            return base.Calculate(packageWeightInKilograms, size, region);
        }
    }

}

