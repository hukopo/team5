using Microsoft.AspNetCore.Mvc;

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
        
        [HttpGet("map")]
        [Produces("application/json")]
        public IActionResult Map()
        {
            return Ok(new[,]{{0,2,0,0},{0,0,4,0},{0,0,0,0},{0,0,0,0}});
        }
        
    }
}
