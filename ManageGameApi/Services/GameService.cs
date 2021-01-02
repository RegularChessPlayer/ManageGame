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
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IUserIdentity _userIdentity;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GameService(IGameRepository gameRepository,
            IUserIdentity userIdentity, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _gameRepository = gameRepository;
            _userIdentity = userIdentity;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GameDTO>> ListGameAsync()
        {
            var userManageId = _userIdentity.UserId;
            var games = await _gameRepository.ListAsync(userManageId);
            return _mapper.Map<IEnumerable<Game>, IEnumerable<GameDTO>>(games);
        }

        public async Task<GameResponse> SaveGameAsync(GameInput gameInput)
        {
            try
            {
                var game = _mapper.Map<GameInput, Game>(gameInput);
                game.UserManageId = _userIdentity.UserId;

                await _gameRepository.AddAsync(game);
                await _unitOfWork.CompleteAsync();

                return new GameResponse(game);
            }
            catch (Exception e)
            {
                return new GameResponse($"An error occurred when saving the game: {e.Message}");
            }
        }

        public async Task<GameResponse> UpdateGameAsync(long id, GameInput gameInput)
        {
            var existingGame = await _gameRepository.FindByIdAsync(id);

            if (existingGame == null)
                return new GameResponse("Game not found");

            existingGame.Name = existingGame.Name;

            try
            {
                _gameRepository.Update(existingGame);
                await _unitOfWork.CompleteAsync();

                return new GameResponse(existingGame);
            }
            catch (Exception ex)
            {
                return new GameResponse($"An error occurred when updating the game: {ex.Message}");
            }
        }

        public async Task<GameResponse> DeleteGameAsync(long id)
        {
            var existingGame= await _gameRepository.FindByIdAsync(id);

            if (existingGame == null)
                return new GameResponse("Friend not found");

            try
            {
                _gameRepository.Remove(existingGame);
                await _unitOfWork.CompleteAsync();

                return new GameResponse(existingGame);
            }
            catch (Exception ex)
            {
                return new GameResponse($"An error occurred when deleting the game: {ex.Message}");
            }
        }

        public GameDTO MapGameToGameDTO(Game game)
        {
            return _mapper.Map<Game, GameDTO>(game);
        }

    }
}
