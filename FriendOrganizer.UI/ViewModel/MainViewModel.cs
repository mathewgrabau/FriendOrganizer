using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private IFriendDataService _friendDataService;
        private Friend _selectedFriend;

        public MainViewModel(IFriendDataService dataService)
        {
            Friends = new ObservableCollection<Friend>();
            _friendDataService = dataService;
        }

       
        public ObservableCollection<Friend> Friends { get; set; }

        public Friend SelectedFriend
        {
            get { return _selectedFriend; }
            set
            {
                _selectedFriend = value;
                OnPropertyChanged(nameof(SelectedFriend));
            }
        }

        public async Task LoadAsync()
        {
            var friends = await _friendDataService.GetAllAsync();

            // Clear existing collection
            Friends.Clear();

            foreach (var f in friends)
            {
                Friends.Add(f);
            }
        }
    }
}
