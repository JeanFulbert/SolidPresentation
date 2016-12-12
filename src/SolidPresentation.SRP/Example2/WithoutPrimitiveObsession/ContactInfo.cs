namespace SolidPresentation.SRP.Example2.BetterWithoutPrimitiveObsession
{
    public class ContactInfo
    {
        public Email Email { get; }
        public PhoneNumber MobilePhoneNumber { get; }
        public PhoneNumber HomePhoneNumber { get; }

        public ContactInfo(Email email, PhoneNumber mobile, PhoneNumber home)
        {
            this.Email = email;
            this.MobilePhoneNumber = mobile;
            this.HomePhoneNumber = home;
        }
    }
}