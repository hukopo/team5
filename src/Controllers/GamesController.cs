using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
	    private readonly GameProvider gameProvider;

		public GamesController(GameProvider gameProvider)
		{
			this.gameProvider = gameProvider;
		}

		[HttpPost]
        public IActionResult Index()
        {
            return new ObjectResult(gameProvider.CreateGame(new Vec(1, 1)));
        }
    }
}
