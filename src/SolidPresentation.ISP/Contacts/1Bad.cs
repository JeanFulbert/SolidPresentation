namespace SolidPresentation.ISP.Contacts.Bad
{
    public class Contact
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Telephone { get; set; }
    }

    public class Emailer
    {
        public void SendMessage(Contact contact, string subject, string body)
        {
            // Code to send email, using contact's email address and name
        }
    }

    public class Dialler
    {
        public void MakeCall(Contact contact)
        {
            // Code to dial telephone number of contact
        }
    }
}
