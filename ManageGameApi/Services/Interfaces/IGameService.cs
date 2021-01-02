using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Entities;
using ManageGameApi.Domain.Input;
using ManageGameApi.Domain.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Services.Interfaces
{
    public interface IGameService
    {
        Task<IEnumerable<GameDTO>> ListGameAsync();
        Task<GameResponse> SaveGameAsync(GameInput gameInput);
        Task<GameResponse> UpdateGameAsync(long id, GameInput gameInput);
        Task<GameResponse> DeleteGameAsync(long id);
        GameDTO MapGameToGameDTO(Game game);

    }
}
