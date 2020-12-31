using AutoMapper;
using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.MapEntityDTO
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Friend, FriendDTO>();
        }

    }
}
