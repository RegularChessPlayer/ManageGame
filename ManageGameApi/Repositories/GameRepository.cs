using ManageGameApi.Domain.Entities;
using ManageGameApi.Infrastructure;
using ManageGameApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Repositories
{
    public class GameRepository : BaseRepository, IGameRepository
    {
        public GameRepository(DataContext context) : base(context)
        {

        }

        public async Task AddAsync(Game game)
        {
            await _context.Game.AddAsync(game);
        }

        public async Task<Game> FindByIdAsync(long id)
        {
            return await _context.Game.FindAsync(id);
        }

        public async Task<IEnumerable<Game>> ListAsync(long useManagerId)
        {
            return await _context.Game
                         .Where(g => g.UserManageId == useManagerId)
                         .ToListAsync();
        }

        public void Remove(Game game)
        {
            _context.Game.Remove(game);
        }

        public void Update(Game game)
        {
            _context.Game.Update(game);
        }
    }
}
