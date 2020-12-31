using ManageGameApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Repositories.Interfaces
{
    public interface IFriendRepository
    {
        Task<IEnumerable<Friend>> ListAsync(long useManagerId);
        Task AddAsync(Friend friend);
        Task<Friend> FindByIdAsync(long id);
        void Update(Friend friend);
        void Remove(Friend friend);
    }
}
