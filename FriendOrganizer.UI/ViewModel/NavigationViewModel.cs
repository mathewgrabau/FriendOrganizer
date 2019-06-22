using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : INavigationViewModel
    {
        private ILookupDataService _lookupService;

        public ObservableCollection<LookupItem> Friends { get; private set; }

        public NavigationViewModel(ILookupDataService lookupService)
        {
            _lookupService = lookupService;
            Friends = new ObservableCollection<LookupItem>();
        }

        public async Task LoadAsync()
        {
            var lookup = await _lookupService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookup)
            {
                Friends.Add(item);
            }
        }
    }
}
