using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using thegame.Models;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/games/{gameId}/moves")]
    public class MovesController : Controller
    {
        private readonly Dictionary<Guid, Mutex> gameMutexes = new Dictionary<Guid, Mutex>();

        private readonly GameProvider gameProvider;

        public MovesController(GameProvider gameProvider)
        {
            this.gameProvider = gameProvider;
        }

        [HttpPost]
        public IActionResult Moves(Guid gameId, [FromBody]UserInputForMovesPost userInput)
        {
            Game game = gameProvider.GetGame(gameId);

            if (!gameMutexes.ContainsKey(gameId))
                gameMutexes.Add(game.Id, new Mutex());
            Mutex mutex = gameMutexes[gameId];
            mutex.WaitOne();

            if (game.IsFinished) return new ObjectResult(game.GenerateDto());

            if (userInput.ClickedPos != null || userInput.HasKeypress())
            {
                ++game.Score;

                game.Player.Pos = userInput.ClickedPos;

                CellDto startCell = game.GetCellByPosition(new Vec(0, 0));
                string startColor = startCell.Type;

                CellDto targetCell = GetTargetCell(game, startColor, userInput);
                string targetColor = "";
                targetColor = targetCell.Type;


                HashSet<CellDto> cellsToColor = new HashSet<CellDto>();
                HashSet<CellDto> visitedCells = new HashSet<CellDto>();
                Queue<CellDto> cellQueue = new Queue<CellDto>();
                cellQueue.Enqueue(startCell);
                visitedCells.Add(startCell);
                while (cellQueue.Count != 0)
                {
                    CellDto cell = cellQueue.Dequeue();
                    if (cell.Type == startColor)
                    {
                        cellsToColor.Add(cell);
                        foreach (Vec neighbourPosition in GetNeighbours(cell.Pos, game.Height, game.Width))
                        {
                            CellDto neighbourCell = game.GetCellByPosition(neighbourPosition);
                            if (cell.Type == startColor && !visitedCells.Contains(neighbourCell))
                            {
                                cellQueue.Enqueue(neighbourCell);
                                visitedCells.Add(neighbourCell);
                            }
                        }
                    }
                }

                foreach (CellDto cell in cellsToColor)
                {
                    cell.Type = targetColor;
                }

                game.IsFinished = game.IsSameColor();
            }
            mutex.ReleaseMutex();
            return new ObjectResult(game.GenerateDto());
        }

        private CellDto GetTargetCell(Game game, string startColor, UserInputForMovesPost userInput)
        {
            CellDto targetCell = userInput.ClickedPos == null ? 
                null : game.GetCellByPosition(userInput.ClickedPos);

            if (userInput.HasKeypress())
            {
                targetCell = game.Cells.First(c => c.Type != startColor && c.Id != "Player" && c.Pos != null);
                game.Cells.First(c => c.Pos == null).Pos = targetCell.Pos;
            }
            else
            {
                targetCell = game.Cells.First(c => c.Pos == userInput.ClickedPos && c.Id != "Player");
            }

            return targetCell;
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
    }
}