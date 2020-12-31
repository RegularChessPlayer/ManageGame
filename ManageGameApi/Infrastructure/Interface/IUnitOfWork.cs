using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Infrastructure.Interface
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
