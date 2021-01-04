using AutoMapper;
using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Entities;
using ManageGameApi.Domain.Input;
using ManageGameApi.Domain.Output;
using ManageGameApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageGameApiTest.Services
{
    class FriendServiceFake : IFriendService
    {
        private readonly List<Friend> _friendRepository;

        public FriendServiceFake()
        {
            _friendRepository = new List<Friend>() {
                new Friend{ Id = 101, Name = "João Batista" },
                new Friend{ Id = 102, Name = "Maria Rita" },
                new Friend{ Id = 103, Name = "Marcos Oliveira" },
                new Friend{ Id = 104, Name = "Artur Rocha" },
                new Friend{ Id = 105, Name = "Viviane Almeida" },
            };
        }

        public Task<IEnumerable<FriendDTO>> ListFriendAsync()
        {
            IEnumerable<FriendDTO> friendsDTO = _friendRepository.Select(x => new FriendDTO { 
                Id = x.Id,
                Name = x.Name
            }).ToList();
            return Task.FromResult(friendsDTO);
        }

        public Task<FriendResponse>SaveFriendAsync(FriendInput friendInput)
        {
            var friend = new Friend() { Id = GeraId(), Name = friendInput.Name };
            _friendRepository.Add(friend);
            var friendResponse = new FriendResponse(friend);
            return Task.FromResult(friendResponse);
        }

        public Task<FriendResponse> UpdateFriendAsync(long id, FriendInput friendInput)
        {
            var friend = _friendRepository.Find(x => x.Id == id);
            friend.Name = friendInput.Name;
            var friendResponse = new FriendResponse(friend);
            return Task.FromResult(friendResponse);
        }

        public Task<FriendResponse> DeleteFriendAsync(long id)
        {
            var deleteFriend = _friendRepository.Find(x => x.Id == id);
            _friendRepository.Remove(deleteFriend);
            var friendResponse = new FriendResponse(deleteFriend);
            return Task.FromResult(friendResponse);
        }

        public FriendDTO MapFriendToFriendDTO(Friend friend)
        {
            return new FriendDTO() { Id = friend.Id, Name = friend.Name };
        }

        static int GeraId()
        {
            Random random = new Random();
            return random.Next(1, 100);
        }

    }
}
