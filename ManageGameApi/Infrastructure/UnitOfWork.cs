using ManageGameApi.Infrastructure.Interface;
using System.Threading.Tasks;

namespace ManageGameApi.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CompleteAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

    }
}
