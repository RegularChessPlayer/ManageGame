using ManageGameApi.Domain.Entities;
using ManageGameApi.Infrastructure;
using ManageGameApi.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Repositories
{
    public class UserManageRepository : BaseRepository, IUserManageRepository
    {

        public UserManageRepository(DataContext context) : base(context)
        {

        }

        public UserManage Get(string username, string password)
        {
            
            return _context.UserManage
                .Where(x => x.Email.ToLower() == username.ToLower()
                && x.Password == x.Password)
                .FirstOrDefault();
        }
    }
}
