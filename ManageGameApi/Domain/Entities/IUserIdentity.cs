using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.Entities
{
    public interface IUserIdentity
    {
        long UserId { get; }
        string Name { get; }
    }

}
