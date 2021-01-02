using ManageGameApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<Game>> ListAsync(long useManagerId);
        Task AddAsync(Game game);
        Task<Game> FindByIdAsync(long id);
        void Update(Game game);
        void Remove(Game game);

    }
}
