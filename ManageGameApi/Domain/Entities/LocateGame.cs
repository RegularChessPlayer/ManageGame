using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.Entities
{
    public class LocateGame
    {
        public long GameId { get; set; }
        public long FriendId { get; set; }
        
        public long UserManageId { get; set; }
        public UserManage UserManage { get; set; }
        
    }
}
