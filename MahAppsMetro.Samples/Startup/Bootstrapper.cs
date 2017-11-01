using MahAppsMetro.Samples.Core;
using MahAppsMetro.Samples.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;


namespace MahAppsMetro.Samples.Startup
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            Container.RegisterType(typeof(object), typeof(ViewA), "ViewA");
            Container.RegisterType(typeof(object), typeof(ViewB), "ViewB");

            Container.RegisterType<Navigation>(new ContainerControlledLifetimeManager());
        }
    }
}
