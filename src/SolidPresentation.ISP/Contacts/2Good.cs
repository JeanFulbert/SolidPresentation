namespace SolidPresentation.ISP.Contacts.Good
{
    public interface IEmailable
    {
        string Name { get; }
        string EmailAddress { get; }
    }

    public interface IDiallable
    {
        string Telephone { get; }
    }

    public class Contact : IEmailable, IDiallable
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string EmailAddress { get; set; }
        public string Telephone { get; set; }
    }

    public class MobileEngineer : IDiallable
    {
        public string Name { get; set; }
        public string Vehicle { get; set; }
        public string Telephone { get; set; }
    }

    public class Emailer
    {
        public void SendMessage(IEmailable target, string subject, string body)
        {
            // Code to send email, using target's email address and name
        }
    }

    public class Dialler
    {
        public void MakeCall(IDiallable target)
        {
            // Code to dial telephone number of target
        }
    }
}
