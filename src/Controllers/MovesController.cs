using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
	[Route("api/games/{gameId}/moves")]
	public class MovesController : Controller
	{
		private readonly Dictionary<char, Vec> keyMoveOffsets = new Dictionary<char, Vec>
		{
			{(char)KeyMoves.Up, new Vec(0, -1)},
			{(char)KeyMoves.Down, new Vec(0, 1)},
			{(char)KeyMoves.Left, new Vec(-1, 0)},
			{(char)KeyMoves.Right, new Vec(1, 0)}
		};

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
				game.Cells.First(c => c.Id == "Player").Pos = userInput.ClickedPos;
			else if(keyMoveOffsets.ContainsKey(userInput.KeyPressed))
			{
				game.Cells.First(c => c.Id == "Player").Pos += keyMoveOffsets[userInput.KeyPressed];
			}

			return new ObjectResult(game);
		}
	}
}