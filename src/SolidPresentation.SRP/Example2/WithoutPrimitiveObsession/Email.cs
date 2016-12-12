namespace SolidPresentation.SRP.Example2.BetterWithoutPrimitiveObsession
{
    using System;
    using System.Text.RegularExpressions;

    public class Email
    {
        private static readonly Regex IsValidEmailRegex = new Regex (@"^.+@.+\..+$");

        private readonly string value;

        public Email(string email)
        {
            if (email == null)
                throw new ArgumentNullException ("email");
            if (!IsValidEmailRegex.IsMatch (email))
                throw new ArgumentException ("email", "email is not a valid email.");

            this.value = email;
        }

        public static implicit operator string(Email email)
        {
            return email.value;
        }
    }
}