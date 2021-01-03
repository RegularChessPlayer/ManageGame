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

    }
}
