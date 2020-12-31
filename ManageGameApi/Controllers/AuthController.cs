using ManageGameApi.Domain.Entities;
using ManageGameApi.Repositories.Interfaces;
using ManageGameApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public ITokenService _authService;
        public IUserManageRepository _userManageRepository;

        public AuthController(ITokenService authService, 
            IUserManageRepository userManageRepository)
        {
            _authService = authService;
            _userManageRepository = userManageRepository;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserManage user)
        {
            var existingUser = _userManageRepository.Get(user.Email, user.Password);

            if (existingUser == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = _authService.GenerateToken(existingUser);
            existingUser.Password = "";

            return new
            {
                user = existingUser,
                token = token
            };

        }

    }
}
