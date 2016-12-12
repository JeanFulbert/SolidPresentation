namespace SolidPresentation.DIP.Good.ViewModelUnitTests
{
    using System;
    using System.Collections.Generic;
    using SolidPresentation.DIP.Good.Domain.Models;

    public static class PersonsFactory
    {
        public static Person JeanPierre { get; } =
            new Person(
                1,
                "Jean-Pierre", "Durand",
                new DateTime(1960, 02, 03),
                new Email("jeanpierre.durand@caramail.com"),
                new Address(18, "rue des gens heureux", new PostalCode("44555"), "Nantes la vallée"));

        public static Person JeannineMichelle { get; } =
            new Person(
                2,
                "Jeannine-Michelle", "Durand",
                new DateTime(1958, 05, 30),
                new Email("jeanninemichelle.durand44@caramail.com"),
                new Address(19, "rue des gens heureux", new PostalCode("44555"), "Nantes la vallée"));

        public static IReadOnlyCollection<Person> All { get; } =
            new[] { JeanPierre, JeannineMichelle };
    }
}
