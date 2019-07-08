using Autofac;
using FriendOrganizer.UI.ViewModel;
using FriendOrganizer.DataAccess;
using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.Data.Repositories;
using Prism.Events;
using FriendOrganizer.UI.View.Services;

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
            builder.RegisterType<FriendRepository>().As<IFriendRepository>();
            builder.RegisterType<LookupDataService>().AsImplementedInterfaces();    // Convenience for doing it.

            builder.RegisterType<MessageDialogService>().As<IMessageDialogService>();

            return builder.Build();
        }
    }
}
