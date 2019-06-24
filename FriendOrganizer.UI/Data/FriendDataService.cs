using FriendOrganizer.Model;
using System.Collections.Generic;
using FriendOrganizer.DataAccess;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Threading;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private Func<FriendOrganizerDbContext> _contextCreator;

        public FriendDataService(Func<FriendOrganizerDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<Friend> GetByIdAsync(int friendId)
        {
            using (var context = _contextCreator())
            {
                return await context.Friends.AsNoTracking().SingleAsync(x => x.Id == friendId);
            }
        }

        public async Task SaveAsync(Friend friend)
        {
            using (var context = _contextCreator())
            {
                context.Friends.Attach(friend); // need to make it known
                context.Entry(friend).State = EntityState.Modified; // Indicate this has been changed.
                await context.SaveChangesAsync();
            }
        }
    }
}
