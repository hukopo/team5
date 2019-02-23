using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.backend;

namespace thegame.Controllers
{
    
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpGet("score")]
        public IActionResult Score()
        {
            return Ok(50);
        }
        
        [HttpGet("{userId}/map")]
        [Produces("application/json")]
        public IActionResult Map([FromRoute] Guid userId)
        {
            var mapRepo = GamesKeeper.GetMap(userId);
            var map = new[,] {{0, 2, 0, 0}, {0, 8, 4, 0}, {128, 0, 0, 16}, {0, 32, 64, 0}};
            return Ok(map);
        }

        [Route("{userId}/move/{side}")]
        public IActionResult Move([FromRoute] Guid userId, [FromRoute] string direction)
        {
            var dirs = Enum.GetNames(typeof(Direction)).Select(x => x.ToLower());
            if (dirs.Contains(direction))
            {
//                GamesKeeper.MakeMove(userId, direction);
                return Ok(direction);
            }
            return BadRequest();
        }
    }
}
