using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Entities;
using ManageGameApi.Domain.Input;
using ManageGameApi.Extensions;
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

        [HttpPost]
        public async Task<IActionResult> PostCreateFriendAsync([FromBody] FriendInput friendInput)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _friendService.SaveFriendAsync(friendInput);

            if (!result.Success)
                return BadRequest(result.Message);

            var friendDTO = _friendService.MapFriendToFriendDTO(result.Friend);
            return Ok(friendDTO);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] FriendInput friendInput)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _friendService.UpdateFriendAsync(id, friendInput);

            if (!result.Success)
                return BadRequest(result.Message);

            var friendDTO = _friendService.MapFriendToFriendDTO(result.Friend);
            return Ok(friendDTO);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _friendService.DeleteFriendAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var friendDTO = _friendService.MapFriendToFriendDTO(result.Friend);
            return Ok(friendDTO);
        }

    }

}
