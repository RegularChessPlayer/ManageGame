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
    public interface ILocateGameService
    {
        Task<IEnumerable<FriendLocateGameDTO>> ListAsync();
        Task<LocateGameResponse> SaveLocateGameAsync(LocateGameInput locateGameInput);
        Task<LocateGameResponse> DeleteLocateGameAsync(long gameId, long friendId);

    }
}
