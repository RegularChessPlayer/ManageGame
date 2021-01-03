using AutoMapper;
using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Entities;
using ManageGameApi.Domain.Input;
using ManageGameApi.Domain.Output;
using ManageGameApi.Infrastructure.Interface;
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
        private readonly IUnitOfWork _unitOfWork;


        public LocateGameService(ILocateGameRepository locateGameRepository,
             IUserIdentity userIdentity, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _locateGameRepository = locateGameRepository;
            _userIdentity = userIdentity;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
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

        public async Task<LocateGameResponse> SaveLocateGameAsync(LocateGameInput locateGameInput)
        {
            try
            {
                var locateGame = _mapper.Map<LocateGameInput, LocateGame>(locateGameInput);
                locateGame.UserManageId = _userIdentity.UserId;

                await _locateGameRepository.AddAsync(locateGame);
                await _unitOfWork.CompleteAsync();

                return new LocateGameResponse(locateGame);
            }
            catch (Exception e)
            {
                return new LocateGameResponse($"An error occurred when saving the game: {e.Message}");
            }
        }

        public async Task<LocateGameResponse> DeleteLocateGameAsync(long gameId, long friendId)
        {
            var existingLocateGame = await _locateGameRepository.FindByIdAsync(gameId, friendId);

            if (existingLocateGame == null)
                return new LocateGameResponse("Friend not found");

            try
            {
                _locateGameRepository.Remove(existingLocateGame);
                await _unitOfWork.CompleteAsync();

                return new LocateGameResponse(existingLocateGame);
            }
            catch (Exception ex)
            {
                return new LocateGameResponse($"An error occurred when deleting the game: {ex.Message}");
            }

        }


    }
}
