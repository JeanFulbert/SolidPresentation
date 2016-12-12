namespace SolidPresentation.SRP.Example2.BetterWithoutPrimitiveObsession
{
    using System;

    public class StreetNumber
    {
        public int Number { get; }
        public BisTerQuarter? BisTerQuarter { get; }

        public StreetNumber(int number, BisTerQuarter? bisTerQuarter)
        {
            if (number <= 0)
                throw new ArgumentException ("number", "number must be strictly positive.");

            this.Number = number;
            this.BisTerQuarter = bisTerQuarter;
        }
    }
}