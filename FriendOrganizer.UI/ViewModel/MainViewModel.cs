using System;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System.Threading.Tasks;
using System.Windows;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IEventAggregator _eventAggregator;
        private IFriendDetailViewModel _friendDetailViewModel;

        // Switched to the model where creation happens properly.
        public MainViewModel(INavigationViewModel navigationViewModel, 
            Func<IFriendDetailViewModel> friendDetailViewModelCreator, 
            IEventAggregator eventAggregator)
        {
            _friendDetailViewModelCreator = friendDetailViewModelCreator;
            _eventAggregator = eventAggregator;

            NavigationViewModel = navigationViewModel;

            _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                .Subscribe(OnOpenFriendDetailView);

        }

        public INavigationViewModel NavigationViewModel { get; private set; }

        public IFriendDetailViewModel FriendDetailViewModel
        {
            get
            {
                return _friendDetailViewModel;
            }
            private set
            {
                _friendDetailViewModel = value;
                OnPropertyChanged();
            }
        }

        private Func<IFriendDetailViewModel> _friendDetailViewModelCreator;

        public async Task LoadAsync()
        {
            await NavigationViewModel.LoadAsync();
        }

        private async void OnOpenFriendDetailView(int friendId)
        {
            // Check for changes to alert the user if they are going to lose changes here
            if (FriendDetailViewModel != null && FriendDetailViewModel.HasChanges)
            {
                var result = MessageBox.Show("Unsaved changes, navigate away?", "Question", MessageBoxButton.OKCancel);
                if (result == MessageBoxResult.Cancel)
                {
                    return;
                }
            }
            FriendDetailViewModel = _friendDetailViewModelCreator();
            await FriendDetailViewModel.LoadAsync(friendId);
        }

    }
}
