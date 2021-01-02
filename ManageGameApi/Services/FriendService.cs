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

        public async Task<IEnumerable<FriendDTO>> ListFriendAsync()
        {
            var userManageId = _userIdentity.UserId;
            var friends = await _friendRepository.ListAsync(userManageId);
            return _mapper.Map<IEnumerable<Friend>, IEnumerable<FriendDTO>>(friends);
        }

        public async Task<FriendResponse> SaveFriendAsync(FriendInput friendInput)
        {
            try
            {
                var friend = _mapper.Map<FriendInput, Friend>(friendInput);
                friend.UserManageId = _userIdentity.UserId;

                await _friendRepository.AddAsync(friend);
                await _unitOfWork.CompleteAsync();

                return new FriendResponse(friend);
            }
            catch (Exception e)
            {
                return new FriendResponse($"An error occurred when saving the friend: {e.Message} ");
            }
        }

        public async Task<FriendResponse> UpdateFriendAsync(long id, FriendInput friendInput)
        {

            var existingFriend = await _friendRepository.FindByIdAsync(id);

            if (existingFriend == null)
                return new FriendResponse("Friend not found");

            existingFriend.Name = friendInput.Name;

            try
            {

                _friendRepository.Update(existingFriend);
                await _unitOfWork.CompleteAsync();

                return new FriendResponse(existingFriend);
            }
            catch (Exception ex)
            {
                return new FriendResponse($"An error occurred when updating the friend: {ex.Message}");
            }


        }

        public async Task<FriendResponse> DeleteFriendAsync(long id)
        {
            var existingFriend = await _friendRepository.FindByIdAsync(id);

            if (existingFriend == null)
                return new FriendResponse("Friend not found");

            try
            {
                _friendRepository.Remove(existingFriend);
                await _unitOfWork.CompleteAsync();

                return new FriendResponse(existingFriend);
            }
            catch (Exception ex)
            {
                return new FriendResponse($"An error occurred when deleting the friend: {ex.Message}");
            }

        }

        public FriendDTO MapFriendToFriendDTO(Friend friend)
        {
            return _mapper.Map<Friend, FriendDTO>(friend);
        }

    }
}
