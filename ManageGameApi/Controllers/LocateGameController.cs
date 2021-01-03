using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Entities;
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



    }
}
