using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.Entities
{
    public class FriendLocateGame
    {
        public Friend Friend { get; set; }
        public IList<Game> Games { get; set; }
    }
}
