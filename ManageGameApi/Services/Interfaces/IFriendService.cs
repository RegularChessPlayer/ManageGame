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
    public interface IFriendService
    {
        Task<IEnumerable<FriendDTO>> ListFriendAsync();
        Task<FriendResponse> SaveFriendAsync(FriendInput friendInput);
        Task<FriendResponse> UpdateFriendAsync(long id, FriendInput friendInput);
        Task<FriendResponse> DeleteFriendAsync(long id);
        FriendDTO MapFriendToFriendDTO(Friend friend);
    }
}
