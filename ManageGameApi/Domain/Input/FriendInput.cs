﻿using System.ComponentModel.DataAnnotations;

namespace ManageGameApi.Domain.Input
{
    public class FriendInput
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
