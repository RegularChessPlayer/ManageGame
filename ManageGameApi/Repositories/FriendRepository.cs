using ManageGameApi.Domain.Entities;
using ManageGameApi.Infrastructure;
using ManageGameApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Repositories
{
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public FriendRepository(DataContext context) : base(context)
        {

        }

        public async Task AddAsync(Friend friend)
        {
            await _context.Friend.AddAsync(friend);

        }

        public async Task<Friend> FindByIdAsync(long id)
        {
            return await _context.Friend.FindAsync(id);
        }

        public async Task<IEnumerable<Friend>> ListAsync(long useManagerId)
        {
           return await _context.Friend
                .Where(f => f.UserManageId == useManagerId)
                .ToListAsync();
        }

        public void Remove(Friend friend)
        {
            _context.Friend.Remove(friend);
        }

        public void Update(Friend friend)
        {
            _context.Friend.Update(friend);
        }
    }
}
