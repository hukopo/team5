using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
	    private readonly GameProvider gameProvider;

	    public MovesController(GameProvider gameProvider)
	    {
		    this.gameProvider = gameProvider;
	    }

		[HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            var game = gameProvider.GetGame(gameId);
            if (userInput.ClickedPos != null)
                game.Cells.First(c => c.Type == "color4").Pos = userInput.ClickedPos;
            return new ObjectResult(game);
        }
    }
}