namespace SolidPresentation.DIP.Good.Domain.Models
{
    using System;
    using System.Text.RegularExpressions;

    public class PostalCode : ValueObject<PostalCode>
    {
        private static readonly Regex IsPostalCodeRegex = new Regex(@"^(2A|2B|\d{2})\d{3}$");

        private readonly string postalCode;

        public PostalCode(string postalCode)
        {
            if (postalCode == null)
            {
                throw new ArgumentNullException(nameof(postalCode));
            }

            if (!IsValid(postalCode))
            {
                throw new ArgumentException("The format of the postal code is not valid.");
            }

            this.postalCode = postalCode;
        }

        public override string ToString()
        {
            return this.postalCode;
        }

        public static implicit operator string(PostalCode p)
        {
            return p?.postalCode;
        }

        public static bool IsValid(string postalCode)
        {
            return IsPostalCodeRegex.IsMatch(postalCode);
        }

        protected override bool EqualsCore(PostalCode other)
        {
            return this.postalCode == other.postalCode;
        }

        protected override int GetHashCodeCore()
        {
            return this.postalCode.GetHashCode();
        }
    }
}