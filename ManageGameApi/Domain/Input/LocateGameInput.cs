using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.Input
{
    public class LocateGameInput
    {
        [Required]
        public long GameId { get; set; }

        [Required]
        public long FriendId { get; set; }
    }
}
