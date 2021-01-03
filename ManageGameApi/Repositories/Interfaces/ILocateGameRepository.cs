using ManageGameApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Repositories.Interfaces
{
    public interface ILocateGameRepository
    {
        Task<IEnumerable<FriendGame>> ListAsync(long useManagerId);
        Task AddAsync(LocateGame locateGame);
        Task<LocateGame> FindByIdAsync(long GameId, long FriendId);
        void Update(LocateGame locateGame);
        void Remove(LocateGame locateGame);

    }
}
