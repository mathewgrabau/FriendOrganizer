using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private int _id;

        public NavigationItemViewModel(int id, string displayMember)
        {
            _id = id;
            _displayMember = displayMember;
        }

        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

    }
}
