using System.Collections.Generic;

namespace ManageGameApi.Domain.Entities
{
    public class UserManage
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Friend> Friends { get; set; }
        public ICollection<Game> Games { get; set; }
        public ICollection<LocateGame> LocateGames { get; set; }

    }
}
