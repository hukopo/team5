using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.backend;

namespace thegame.Controllers
{
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpGet("{userId}/score")]
        public IActionResult Score([FromRoute] Guid userId)
        {
            var score = GamesKeeper.GetScore(userId);
            return Ok(score);
        }

        [HttpPost("/create")]
        [Produces("application/json")]
        public IActionResult CreateGame()
        {
            var game = GamesKeeper.CreateNewGame(4);
            return Ok(game.Id);
        }
        
        [HttpGet("{userId}/map")]
        [Produces("application/json")]
        public IActionResult Map([FromRoute] Guid userId)
        {
            var mapRepo = GamesKeeper.GetMap(userId);
            if (mapRepo != null)
                return Ok(mapRepo);
            return BadRequest();
        }

        [Route("{userId}/move/{side}")]
        [Produces("application/json")]
        public IActionResult Move([FromRoute] Guid userId, [FromRoute] string direction)
        {
            var dirs = Enum.GetNames(typeof(Direction)).Select(x => x.ToLower());
            if (dirs.Contains(direction))
            {
                Enum.TryParse("red", true , out Direction dir);
                GamesKeeper.MakeMove(userId, dir);
                return Ok(direction);
            }
            return BadRequest();
        }
    }
}