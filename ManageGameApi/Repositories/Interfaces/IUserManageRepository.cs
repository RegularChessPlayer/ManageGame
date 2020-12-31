using ManageGameApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Repositories.Interfaces
{
    public interface IUserManageRepository
    {
        UserManage Get(string username, string password);
    }

}
