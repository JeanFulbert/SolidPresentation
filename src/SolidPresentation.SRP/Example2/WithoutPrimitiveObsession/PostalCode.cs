namespace SolidPresentation.SRP.Example2.BetterWithoutPrimitiveObsession
{
    using System;
    using System.Text.RegularExpressions;

    public class PostalCode
    {
        private static readonly Regex IsValidPostalCodeRegex = new Regex(@"^(\d{2}|2A|2B)\d{3}$");

        private readonly string value;

        public PostalCode(string postalCode)
        {
            if (postalCode == null)
                throw new ArgumentNullException(nameof(postalCode));
            if (!IsValidPostalCodeRegex.IsMatch(postalCode))
                throw new ArgumentException(nameof(postalCode), "postalCode is not a valid postal code.");

            this.value = postalCode;
        }

        public static implicit operator string(PostalCode postalCode)
        {
            return postalCode.value;
        }
    }
}