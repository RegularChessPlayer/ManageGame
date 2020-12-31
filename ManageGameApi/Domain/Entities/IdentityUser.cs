using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ManageGameApi.Domain.Entities
{
    public class IdentityUser : IUserIdentity
    {

        private readonly IHttpContextAccessor _accessor;

        public IdentityUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        public long UserId =>
                   Convert.ToInt64(GetClaims()
                       .FirstOrDefault(x => x.Type.Equals("id")).Value);
        public string Name =>
           GetClaims()
           .FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;

        private IEnumerable<Claim> GetClaims() => _accessor.HttpContext.User.Claims;

    }
}
