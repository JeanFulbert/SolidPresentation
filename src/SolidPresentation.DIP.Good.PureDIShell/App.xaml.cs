namespace SolidPresentation.DIP.Good.PureDIShell
{
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using LiteDB;
    using SolidPresentation.DIP.Good.Domain.Models;
    using SolidPresentation.DIP.Good.Fakes;
    using SolidPresentation.DIP.Good.PersistLiteDb;
    using SolidPresentation.DIP.Good.Services;
    using SolidPresentation.DIP.Good.Utils;
    using SolidPresentation.DIP.Good.ViewModels.Persons;
    using SolidPresentation.DIP.Good.Views;
    using SolidPresentation.DIP.Good.Views.Services;

    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
            var listPersonView = this.Build();

            listPersonView.Show();
        }

        private PersonListWindow Build()
        {
            return null;
        }

        #region Builds
        //private PersonListWindow BuildOnlyWithFakes()
        //{
        //    return
        //        new PersonListWindow(
        //            new PersonListViewModel(
        //                new MemoryPersonRepository(),
        //                new FakePersonCreationService(GetDummyPersons()),
        //                new FakeConfirmationService(true),
        //                new PersonEmailService(new FakeEmailSender())));
        //}

        //private PersonListWindow BuildWithMessageBox()
        //{
        //    return
        //        new PersonListWindow(
        //            new PersonListViewModel(
        //                new MemoryPersonRepository(),
        //                new FakePersonCreationService(GetDummyPersons()),
        //                new ConfirmationService(),
        //                new PersonEmailService(new FakeEmailSender())));
        //}

        //private PersonListWindow BuildWithMessageBoxAndPersistance()
        //{
        //    return
        //        new PersonListWindow(
        //            new PersonListViewModel(
        //                new LiteDbPersonRepository(new LiteDatabase(@"local.db")),
        //                new FakePersonCreationService(GetDummyPersons()),
        //                new ConfirmationService(),
        //                new PersonEmailService(new FakeEmailSender())));
        //}

        //private PersonListWindow BuildWithoutEmailSender()
        //{
        //    return
        //        new PersonListWindow(
        //            new PersonListViewModel(
        //                new LiteDbPersonRepository(new LiteDatabase(@"local.db")),
        //                new PersonCreationService(),
        //                new ConfirmationService(),
        //                new PersonEmailService(new FakeEmailSender())));
        //}

        //private PersonListWindow BuildFull()
        //{
        //    return
        //        new PersonListWindow(
        //            new PersonListViewModel(
        //                new LiteDbPersonRepository(new LiteDatabase(@"local.db")),
        //                new PersonCreationService(),
        //                new ConfirmationService(),
        //                new PersonEmailService(new EmailSender())));
        //}
        #endregion

        private static IReadOnlyList<Person> GetDummyPersons()
        {
            var jeanPierre =
                new Person(
                    Person.JustCreatedId,
                    "Jean-Pierre", "Durand",
                    new DateTime(1960, 02, 03),
                    new Email("jeanpierre.durand@caramail.com"),
                    new Address(18, "rue des gens heureux", new PostalCode("44555"), "Nantes la vallée"));
            var jeannineMichelle =
                new Person(
                    Person.JustCreatedId,
                    "Jeannine-Michelle", "Durand",
                    new DateTime(1958, 05, 30),
                    new Email("jeanninemichelle.durand44@caramail.com"),
                    new Address(19, "rue des gens heureux", new PostalCode("44555"), "Nantes la vallée"));

            return new[] { jeanPierre, jeannineMichelle };
        }
    }
}
