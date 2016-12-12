using System;

namespace SolidPresentation.SRP.Example2.BetterWithoutPrimitiveObsession
{
	public class Person
	{
		public string FirstName { get; }
		public string LastName { get; }
		public DateTime BirthDate { get; }
		public Address Address { get; }
		public ContactInfo Contact { get; }

		public Person(
			string firstName, string lastName, DateTime birthDate,
			Address address, ContactInfo contactInfo)
		{
			if (lastName == null)
				throw new ArgumentNullException (nameof(lastName));
			if (firstName == null)
				throw new ArgumentNullException (nameof(firstName));
			
			this.FirstName = firstName;
			this.LastName = lastName;
			this.BirthDate = birthDate;
			this.Address = address;
			this.Contact = contactInfo;
		}
	}
}

