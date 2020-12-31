using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.Entities
{
    public class Game
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public long UserManageId { get; set; }
        public UserManage UserManage { get; set; }

    }
}
