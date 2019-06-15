using FriendOrganizer.Model;
using FriendOrganizer.UI.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FriendOrganizer.UI.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private IFriendDataService _friendDataService;
        private Friend _selectedFriend;

        public MainViewModel(IFriendDataService dataService)
        {
            Friends = new ObservableCollection<Friend>();
            _friendDataService = dataService;
        }

        public event PropertyChangedEventHandler PropertyChanged;

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

        public void Load()
        {
            var friends = _friendDataService.GetAll();

            // Clear existing collection
            Friends.Clear();

            foreach (var f in friends)
            {
                Friends.Add(f);
            }
        }

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
