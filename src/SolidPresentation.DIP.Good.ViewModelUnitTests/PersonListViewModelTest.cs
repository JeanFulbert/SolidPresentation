namespace SolidPresentation.DIP.Good.ViewModelUnitTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Moq;
    using NUnit.Framework;
    using SolidPresentation.DIP.Good.Domain.Models;
    using SolidPresentation.DIP.Good.Services;
    using SolidPresentation.DIP.Good.Services.Repositories;
    using SolidPresentation.DIP.Good.ViewModels.Persons;

    [TestFixture]
    public class PersonListViewModelTest
    {
        [Test]
        public void ShouldNotLoadPersonsWhenLoadIsNotCalled()
        {
            var sut = new PersonListViewModel(
                Mock.Of<IPersonRepository>(),
                Mock.Of<IEditPersonService>(),
                Mock.Of<IMessageBoxService>(),
                new PersonEmailService(Mock.Of<IEmailSender>()));

            Assert.That(sut.Persons, Is.Empty);
            Assert.That(sut.SelectedPersons, Is.Empty);
        }

        [Test]
        public async Task ShouldLoadPersonsWhenLoadIsCalled()
        {
            var sut = new PersonListViewModel(
                new GetAllDummyPersonsRepository(),
                Mock.Of<IEditPersonService>(),
                Mock.Of<IMessageBoxService>(),
                new PersonEmailService(Mock.Of<IEmailSender>()));

            await sut.LoadAsync();

            Assert.That(sut.Persons.Select(vm => vm.Person), Is.EquivalentTo(PersonsFactory.All));
            Assert.That(sut.SelectedPersons, Is.Empty);
        }

        [Test]
        public async Task ShouldDoNothingWhenAddIsCancelled()
        {
            var personRepoMock = new Mock<IPersonRepository>();
            personRepoMock
                .Setup(r => r.GetAll())
                .Returns(new List<Person>());

            var editPersonMock = new Mock<IEditPersonService>();
            editPersonMock
                .Setup(s => s.Create())
                .Returns(CancellableResult<Person>.Cancel());

            var emailSenderMock = new Mock<IEmailSender>();

            var sut = new PersonListViewModel(
                personRepoMock.Object,
                editPersonMock.Object,
                Mock.Of<IMessageBoxService>(),
                new PersonEmailService(emailSenderMock.Object));
            await sut.LoadAsync();

            await sut.AddNewPersonCommand.ExecuteAsync(null);

            Assert.That(sut.Persons, Is.Empty);
            Assert.That(sut.SelectedPersons, Is.Empty);

            personRepoMock.Verify(r => r.Save(It.IsAny<Person>()), Times.Never);
            emailSenderMock.Verify(
                s => s.Send(It.IsAny<Email>(), It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public async Task ShouldAddNewPersonWhenAddHasSucceeded()
        {
            var personRepoMock = new Mock<IPersonRepository>();
            personRepoMock
                .Setup(r => r.GetAll())
                .Returns(new List<Person>());

            var editPersonMock = new Mock<IEditPersonService>();
            editPersonMock
                .Setup(s => s.Create())
                .Returns(CancellableResult<Person>.Success(PersonsFactory.JeanPierre));

            var emailSenderMock = new Mock<IEmailSender>();

            var sut = new PersonListViewModel(
                personRepoMock.Object,
                editPersonMock.Object,
                Mock.Of<IMessageBoxService>(),
                new PersonEmailService(emailSenderMock.Object));
            await sut.LoadAsync();

            await sut.AddNewPersonCommand.ExecuteAsync(null);

            Assert.That(sut.Persons.Select(vm => vm.Person), Is.EquivalentTo(new[] { PersonsFactory.JeanPierre }));
            Assert.That(sut.SelectedPersons, Is.Empty);

            personRepoMock.Verify(r => r.Save(PersonsFactory.JeanPierre), Times.Once);
            emailSenderMock.Verify(
                s => s.Send(PersonsFactory.JeanPierre.Email, It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }

        [Test]
        public async Task ShouldNotAccessDeleteWhenNoPersonSelected()
        {
            var personRepoMock = new Mock<IPersonRepository>();
            personRepoMock
                .Setup(r => r.GetAll())
                .Returns(PersonsFactory.All);

            var messageBoxServiceMock = new Mock<IMessageBoxService>();
            messageBoxServiceMock
                .Setup(m => m.ShowQuestion(It.IsAny<string>()))
                .Returns(false);

            var emailSenderMock = new Mock<IEmailSender>();

            var sut = new PersonListViewModel(
                personRepoMock.Object,
                Mock.Of<IEditPersonService>(),
                messageBoxServiceMock.Object,
                new PersonEmailService(emailSenderMock.Object));
            await sut.LoadAsync();

            var canDelete = sut.DeletePersonsCommand.CanExecute(null);

            Assert.That(canDelete, Is.False);
        }

        [Test]
        public async Task ShouldDoNothingWhenRefusingToDeletePerson()
        {
            var personRepoMock = new Mock<IPersonRepository>();
            personRepoMock
                .Setup(r => r.GetAll())
                .Returns(PersonsFactory.All);

            var messageBoxServiceMock = new Mock<IMessageBoxService>();
            messageBoxServiceMock
                .Setup(m => m.ShowQuestion(It.IsAny<string>()))
                .Returns(false);

            var emailSenderMock = new Mock<IEmailSender>();

            var sut = new PersonListViewModel(
                personRepoMock.Object,
                Mock.Of<IEditPersonService>(),
                messageBoxServiceMock.Object,
                new PersonEmailService(emailSenderMock.Object));
            await sut.LoadAsync();

            var selectedPersons =
                sut.Persons
                    .Where(vm => vm.Person == PersonsFactory.JeanPierre)
                    .ToList();
            sut.SelectedPersons = selectedPersons;

            await sut.DeletePersonsCommand.ExecuteAsync(null);

            Assert.That(sut.Persons.Select(vm => vm.Person), Is.EquivalentTo(PersonsFactory.All));
            Assert.That(sut.SelectedPersons, Is.EquivalentTo(selectedPersons));

            personRepoMock.Verify(r => r.Remove(new[] { PersonsFactory.JeanPierre }), Times.Never);
            emailSenderMock.Verify(
                s => s.Send(PersonsFactory.JeanPierre.Email, It.IsAny<string>(), It.IsAny<string>()),
                Times.Never);
        }

        [Test]
        public async Task ShouldRemoveSelectedPersonWhenAcceptingToDeletePerson()
        {
            var personRepoMock = new Mock<IPersonRepository>();
            personRepoMock
                .Setup(r => r.GetAll())
                .Returns(PersonsFactory.All);

            var messageBoxServiceMock = new Mock<IMessageBoxService>();
            messageBoxServiceMock
                .Setup(m => m.ShowQuestion(It.IsAny<string>()))
                .Returns(true);

            var emailSenderMock = new Mock<IEmailSender>();

            var sut = new PersonListViewModel(
                personRepoMock.Object,
                Mock.Of<IEditPersonService>(),
                messageBoxServiceMock.Object,
                new PersonEmailService(emailSenderMock.Object));
            await sut.LoadAsync();

            var selectedPersons =
                sut.Persons
                    .Where(vm => vm.Person == PersonsFactory.JeanPierre)
                    .ToList();
            sut.SelectedPersons = selectedPersons;

            await sut.DeletePersonsCommand.ExecuteAsync(null);

            Assert.That(sut.Persons.Select(vm => vm.Person), Is.EquivalentTo(new[] { PersonsFactory.JeannineMichelle }));
            Assert.That(sut.SelectedPersons, Is.Empty);

            personRepoMock.Verify(r => r.Remove(new[] { PersonsFactory.JeanPierre }), Times.Once);
            emailSenderMock.Verify(
                s => s.Send(PersonsFactory.JeanPierre.Email, It.IsAny<string>(), It.IsAny<string>()),
                Times.Once);
        }
    }
}
