using ManageGameApi.Domain.DTO;
using ManageGameApi.Domain.Input;
using ManageGameApi.Extensions;
using ManageGameApi.Services;
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
    public class GameController : ControllerBase
    {
        IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameDTO>>> GetGamesAsync()
        {
            var gamesDTO = await _gameService.ListGameAsync();
            return Ok(gamesDTO);
        }


        [HttpPost]
        public async Task<IActionResult> PostCreateGameAsync([FromBody] GameInput gameInput)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _gameService.SaveGameAsync(gameInput);

            if (!result.Success)
                return BadRequest(result.Message);

            var gameDTO = _gameService.MapGameToGameDTO(result.Game);
            return Ok(gameDTO);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromBody] GameInput gameInput)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _gameService.UpdateGameAsync(id, gameInput);

            if (!result.Success)
                return BadRequest(result.Message);

            var gameDTO = _gameService.MapGameToGameDTO(result.Game);
            return Ok(gameDTO);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var result = await _gameService.DeleteGameAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var gameDTO = _gameService.MapGameToGameDTO(result.Game);
            return Ok(gameDTO);
        }


    }
}
