using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Services.Interfaces
{
    public interface ILocateGameService
    {
        Task<IEnumerable<FriendLocateGameDTO>> ListAsync();

    }
}
