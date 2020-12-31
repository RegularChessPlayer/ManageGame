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
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository _friendRepository;
        private readonly IUserIdentity _userIdentity;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public FriendService(IFriendRepository friendRepository, 
            IUserIdentity userIdentity, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _friendRepository = friendRepository;
            _userIdentity = userIdentity;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<FriendResponse> DeleteFriendAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<FriendDTO>> ListFriendAsync()
        {
            var userManageId = _userIdentity.UserId;
            var friends = await _friendRepository.ListAsync(userManageId);
            return _mapper.Map<IEnumerable<Friend>, IEnumerable<FriendDTO>>(friends);
        }

        public FriendDTO MapFriendToFriendDTO(Friend friend)
        {
            throw new NotImplementedException();
        }

        public Task<FriendResponse> SaveFriendAsync(FriendInput friendInput)
        {
            throw new NotImplementedException();
        }

        public Task<FriendResponse> UpdateFriendAsync(long id, FriendInput friendInput)
        {
            throw new NotImplementedException();
        }
    }
}
