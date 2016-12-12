namespace SolidPresentation.DIP.Bad.Business.Models
{
    using System;
    using System.Text.RegularExpressions;

    public class Email : ValueObject<Email>
    {
        private static readonly Regex IsEmailRegex = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");

        private readonly string email;

        public Email(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (!IsValid(email))
            {
                throw new ArgumentException("Email format invalid.");
            }

            this.email = email;
        }

        public static bool IsValid(string email)
        {
            return IsEmailRegex.IsMatch(email);
        }

        public static implicit operator string(Email e)
        {
            return e?.email;
        }

        protected override bool EqualsCore(Email other)
        {
            return this.email == other.email;
        }

        protected override int GetHashCodeCore()
        {
            return this.email.GetHashCode();
        }
    }
}
