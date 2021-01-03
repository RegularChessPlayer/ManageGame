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
    public class LocateGameRepository : BaseRepository, ILocateGameRepository
    {
        public LocateGameRepository(DataContext context) : base(context)
        {

        }

        public async Task<IEnumerable<FriendGame>> ListAsync(long useManagerId)
        {
            return await _context.LocateGame
                        .Where(lg => lg.UserManageId == useManagerId)
                        .Join(
                            _context.Friend,
                            locateGame => locateGame.FriendId,
                            friend => friend.Id,
                            (locateGame, friend) => new { locateGame, friend }
                        ).Join(
                            _context.Game,
                            lgFriend => lgFriend.locateGame.GameId,
                            game => game.Id,
                            (lgFriend, game) =>  new FriendGame { Friend = lgFriend.friend, Game = game }
                        ).ToListAsync();
        }

    }
}
