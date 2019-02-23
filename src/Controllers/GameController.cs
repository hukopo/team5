using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace thegame.Controllers
{

    public enum Directions
    {
        Left,
        Right,
        Up,
        Down
    }
    
    [Route("api/game")]
    public class GameController : Controller
    {
        [HttpGet("score")]
        public IActionResult Score()
        {
            return Ok(50);
        }
        
        [HttpGet("map")]
        [Produces("application/json")]
        public IActionResult Map()
        {
            var map = new[,] {{0, 2, 0, 0}, {0, 0, 4, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}};
            
            return Ok(map);
        }

        [Route("move/{side}")]
        public IActionResult Move([FromRoute] string side)
        {
            var dirs = Enum.GetNames(typeof(Directions)).Select(x => x.ToLower());
            if (dirs.Contains(side))
                return Ok(side);
            return BadRequest();
        }
    }
}
