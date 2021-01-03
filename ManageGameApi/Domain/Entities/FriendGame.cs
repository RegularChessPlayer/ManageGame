using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.Entities
{
    public class FriendGame
    {
        public Friend Friend { get; set; }
        public Game Game { get; set; }
    }
}
