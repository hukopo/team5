using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            {
                ++game.Score;

                game.Player.Pos = userInput.ClickedPos;

                CellDto targetCell = game.GetCellByPosition(userInput.ClickedPos);
                string targetColor = targetCell.Type;

                CellDto startCell = game.GetCellByPosition(new Vec(0, 0));
                string startColor = startCell.Type;

                HashSet<CellDto> cellsToColor = new HashSet<CellDto>();
                HashSet<CellDto> visitedCells = new HashSet<CellDto>();
                Queue<CellDto> cellQueue = new Queue<CellDto>();
                cellQueue.Enqueue(startCell);
                while (cellQueue.Count != 0)
                {
                    CellDto cell = cellQueue.Dequeue();
                    visitedCells.Add(cell);
                    if (cell.Type == startColor)
                    {
                        cellsToColor.Add(cell);
                        foreach (Vec neighbourPosition in GetNeighbours(cell.Pos, game.Height, game.Width))
                        {
                            CellDto neighbourCell = game.GetCellByPosition(neighbourPosition);
                            if (!visitedCells.Contains(neighbourCell))
                                cellQueue.Enqueue(neighbourCell);
                        }
                    }
                }

                foreach (CellDto cell in cellsToColor)
                {
                    cell.Type = targetColor;
                }

                game.IsFinished = IsGameFinished(game);
            }
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
            string color = game.GetCellByPosition(new Vec(0, 0)).Type;
            for (int i = 0; i < game.Height; ++i)
            {
                for (int j = 0; j < game.Width; ++j)
                {
                    CellDto cell = game.GetCellByPosition(new Vec(i, j));
                    if (cell.Type != color)
                        return false;
                }
            }
            return true;
        }
    }
}