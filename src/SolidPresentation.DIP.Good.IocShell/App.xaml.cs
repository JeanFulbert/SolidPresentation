namespace SolidPresentation.DIP.Good.IocShell
{
    using System.Windows;
    using LiteDB;
    using SimpleInjector;
    using SolidPresentation.DIP.Good.PersistLiteDb;
    using SolidPresentation.DIP.Good.Services;
    using SolidPresentation.DIP.Good.Services.Repositories;
    using SolidPresentation.DIP.Good.Utils;
    using SolidPresentation.DIP.Good.Views;
    using SolidPresentation.DIP.Good.Views.Services;

    public partial class App
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = this.BuildContainer();

            var personListWindow = container.GetInstance<PersonListWindow>();
            personListWindow.Show();
        }

        private Container BuildContainer()
        {
            var container = new Container();

            var liteDbRepository =
                new LiteDbPersonRepository(
                    new LiteDatabase(@"local.db"));

            container.RegisterSingleton<IPersonRepository>(liteDbRepository);
            container.RegisterSingleton<IPersonCreationService, PersonCreationService>();
            container.RegisterSingleton<IConfirmationService, ConfirmationService>();
            container.RegisterSingleton<IEmailSender, EmailSender>();

            return container;
        }
    }
}
