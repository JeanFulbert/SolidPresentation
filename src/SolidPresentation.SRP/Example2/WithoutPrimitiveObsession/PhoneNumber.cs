namespace SolidPresentation.SRP.Example2.BetterWithoutPrimitiveObsession
{
    using System;
    using System.Text.RegularExpressions;

    public class PhoneNumber
    {
        private static readonly Regex IsValidPhoneNumberRegex = new Regex(@"0\d{9}");

        private readonly string value;

        public PhoneNumber(string phoneNumber)
        {
            if (phoneNumber == null)
                throw new ArgumentNullException(nameof(phoneNumber));
            if (!IsValidPhoneNumberRegex.IsMatch(phoneNumber))
                throw new ArgumentException(nameof(phoneNumber), "phoneNumber is not a valid phone number.");

            this.value = phoneNumber;
        }

        public static implicit operator string(PhoneNumber phoneNumber)
        {
            return phoneNumber.value;
        }
    }
}