using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.DTO
{
    public class FriendLocateGameDTO
    {
        public FriendDTO Friend { get; set; }
        public IList<GameDTO> Games { get; set; }
    }
}
