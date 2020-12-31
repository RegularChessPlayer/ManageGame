using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.Input
{
    public class FriendInput
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
