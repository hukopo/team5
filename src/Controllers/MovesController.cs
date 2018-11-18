using Microsoft.AspNetCore.Mvc;
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

            game.Player.Pos = userInput.ClickedPos;

            CellDto targetCell = game.Cells.First(c => c.Pos == userInput.ClickedPos && c.Id != "Player");
            string targetColor = targetCell.Type;

            CellDto startCell = game.Cells.First(c => c.Pos == new Vec(0, 0));
            string startColor = startCell.Type;

            HashSet<CellDto> visitedCells = new HashSet<CellDto>();
            Queue<CellDto> cellQueue = new Queue<CellDto>();
            cellQueue.Enqueue(startCell);
            while (cellQueue.Count != 0)
            {
                CellDto cell = cellQueue.Dequeue();
                visitedCells.Add(cell);
                if (cell.Type == startColor)
                {
                    cell.Type = targetColor;
                    foreach (Vec neighbour in GetNeighbours(cell.Pos, game.Height, game.Width))
                    {
                        CellDto neighbourCell = game.Cells.First(c => c.Pos == neighbour);
                        if (!visitedCells.Contains(neighbourCell))
                            cellQueue.Enqueue(neighbourCell);
                    }
                }
            }

	        game.IsFinished = IsGameFinished(game);
	        
            return new ObjectResult(game);
        }

		private IEnumerable<Vec> GetNeighbours(Vec vec, int height, int width)
        {
            if (vec.X - 1 >= 0)
                yield return vec + new Vec(-1, 0);
            if (vec.X + 1 < width)
                yield return vec + new Vec(1, 0);
            if (vec.Y - 1 >= 0)
                yield return vec + new Vec(0, -1);
            if (vec.Y + 1 < height)
                yield return vec + new Vec(0, 1);
        }

        //TODO find right place for this function
        private bool IsGameFinished(GameDto game)
        {
	        string color = game.Cells.First(g => g.Id != "Player").Type;
	        foreach (CellDto cell in game.Cells.Where(g => g.Id != "Player"))
	        {
		        if (cell.Type != color)
			        return false;
	        }

	        return true;
        }
    }
}