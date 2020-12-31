using ManageGameApi.Domain.Entities;

namespace ManageGameApi.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(UserManage user);

    }
}
