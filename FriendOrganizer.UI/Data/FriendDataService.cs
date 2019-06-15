using FriendOrganizer.Model;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        public IEnumerable<Friend> GetAll()
        {
            // TODO need the loading from database.
            yield return new Friend { FirstName = "Mathew", LastName = "Grabau" };
            yield return new Friend { FirstName = "Charlie", LastName = "Brown" };
            yield return new Friend { FirstName = "Ned", LastName = "Flanders" };
            yield return new Friend { FirstName = "Hank", LastName = "Hill" };
        }
    }
}
