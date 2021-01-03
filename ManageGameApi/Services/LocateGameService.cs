using AutoMapper;
using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Entities;
using ManageGameApi.Repositories.Interfaces;
using ManageGameApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Services
{
    public class LocateGameService : ILocateGameService
    {
        private readonly ILocateGameRepository _locateGameRepository;
        private readonly IUserIdentity _userIdentity;
        private readonly IMapper _mapper;

        public LocateGameService(ILocateGameRepository locateGameRepository,
             IUserIdentity userIdentity, IMapper mapper)
        {
            _locateGameRepository = locateGameRepository;
            _userIdentity = userIdentity;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FriendLocateGameDTO>> ListAsync()
        {
            var userManageId = _userIdentity.UserId;
            var friendGames = await _locateGameRepository.ListAsync(userManageId);

            var friendLocateGameDTO = friendGames
                .GroupBy(flg => flg.Friend, (friend, game) =>
                        new FriendLocateGame
                        {
                            Friend = friend,
                            Games = game.Select(gameItem => gameItem.Game).ToList()
                        })
                .Select(x => _mapper.Map<FriendLocateGame, FriendLocateGameDTO>(x))
                .ToList(); 

            return friendLocateGameDTO;

        }
    }
}
