using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Entities;
using ManageGameApi.Domain.Input;
using ManageGameApi.Extensions;
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
    [Authorize]
    public class LocateGameController : ControllerBase
    {
        ILocateGameService _locateGameService;
        public LocateGameController(ILocateGameService locateGameService)
        {
            _locateGameService = locateGameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FriendLocateGameDTO>>> ListsAsync()
        {
            var locateGames = await _locateGameService.ListAsync();
            return Ok(locateGames);
        }


        [HttpPost]
        public async Task<IActionResult> PostCreateGameAsync([FromBody] LocateGameInput locateGameInput)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _locateGameService.SaveLocateGameAsync(locateGameInput);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.LocateGame);

        }

        [HttpDelete("{gameId}/{friendId}")]
        public async Task<IActionResult> DeleteAsync(long gameId, long friendId)
        {
            var result = await _locateGameService.DeleteLocateGameAsync(gameId, friendId);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.LocateGame);
        }



    }
}
