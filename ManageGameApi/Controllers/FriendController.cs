using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Entities;
using ManageGameApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManageGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FriendController : ControllerBase
    {
        IFriendService _friendService;

        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;                
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendDTO>>> GetFriendsAsync()
        {
           
            var friendsDTO = await _friendService.ListFriendAsync();
            return Ok(friendsDTO);
        }


    }

}
