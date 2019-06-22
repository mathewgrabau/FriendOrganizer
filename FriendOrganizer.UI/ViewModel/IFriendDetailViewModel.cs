using System.Threading.Tasks;
using FriendOrganizer.Model;

namespace FriendOrganizer.UI.ViewModel
{
    public interface IFriendDetailViewModel
    {
        Friend Friend { get; set; }

        Task LoadAsync(int friendId);
    }
}