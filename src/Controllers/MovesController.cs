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

            string targetColor = game.Cells.First(c => c.Pos == userInput.ClickedPos).Type;

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
                    foreach (Vec neighbour in GetNeighbours(cell.Pos))
                    {
                        CellDto neighbourCell = game.Cells.First(c => c.Pos == neighbour);
                        if (!visitedCells.Contains(neighbourCell))
                            cellQueue.Enqueue(neighbourCell);
                    }
                }
            }

            return new ObjectResult(game);
        }

        private IEnumerable<Vec> GetNeighbours(Vec vec)
        {
            yield return vec + new Vec(-1, 0);
            yield return vec + new Vec(1, 0);
            yield return vec + new Vec(0, -1);
            yield return vec + new Vec(0, 1);
        }

        //TODO check if all cell with same color
        //TODO find right place for this function
        private bool IsGameFinished(GameDto game)
        {
            return game.Player.Pos.X == 0;
        }
    }
}