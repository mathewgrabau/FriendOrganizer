using Autofac;
using FriendOrganizer.UI.ViewModel;
using FriendOrganizer.UI.Data;
using FriendOrganizer.DataAccess;
using Prism.Events;

namespace FriendOrganizer.UI.Startup
{
    public class Bootstrapper
    {
        public IContainer Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EventAggregator>().As<IEventAggregator>().SingleInstance();

            builder.RegisterType<FriendOrganizerDbContext>().AsSelf();
            builder.RegisterType<MainViewModel>().AsSelf();
            builder.RegisterType<NavigationViewModel>().As<INavigationViewModel>();
            builder.RegisterType<FriendDetailViewModel>().As<IFriendDetailViewModel>();
            builder.RegisterType<MainWindow>().AsSelf();
            builder.RegisterType<FriendDataService>().As<IFriendDataService>();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();    // Convenience for doing it.

            return builder.Build();
        }
    }
}
