using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private ILookupDataService _lookupService;
        private IEventAggregator _eventAggregator;
        private NavigationItemViewModel _selectedFriend;

        public ObservableCollection<NavigationItemViewModel> Friends { get; private set; }

        public NavigationItemViewModel SelectedFriend
        {
            get
            {
                return _selectedFriend;
            }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged();
                if (_selectedFriend != null)
                {
                    // Publish teh event
                    _eventAggregator.GetEvent<OpenFriendDetailViewEvent>()
                        .Publish(_selectedFriend.Id);
                }
            }
        }

        public NavigationViewModel(ILookupDataService lookupService, IEventAggregator eventAggregator)
        {
            _lookupService = lookupService;
            _eventAggregator = eventAggregator;
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
        }

        private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
        {
            var item = Friends.Single(l => l.Id == obj.Id);
            item.DisplayMember = item.DisplayMember;
        }

        public async Task LoadAsync()
        {
            var lookup = await _lookupService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(new NavigationItemViewModel(item.Id, item.DisplayMember));
            }
        }
    }
}
