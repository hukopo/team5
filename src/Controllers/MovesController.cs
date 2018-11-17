using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
                game.Player.Pos = userInput.ClickedPos;
            else if (keyMoveOffsets.ContainsKey(userInput.KeyPressed))
                game.Player.Pos += keyMoveOffsets[userInput.KeyPressed];

            //TODO replace with right game logic
            game.IsFinished = IsGameFinished(game);
            game.Score = game.Player.Pos.Y;

            return new ObjectResult(game);
        }

        //TODO find right place for this function
        private bool IsGameFinished(GameDto game)
        {
            return game.Player.Pos.X == 0;
        }
    }
}