using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Services;

namespace thegame.Controllers
{
    [Route("api/leaderboard")]
    public class LeaderBoardController
    {
        private readonly GameProvider gameProvider;

        public LeaderBoardController(GameProvider gameProvider)
        {
            this.gameProvider = gameProvider;
        }

        [HttpGet]
        public IActionResult LeaderBoard()
        {
            //TODO decide what to return
            return new ObjectResult(gameProvider
                .GetAllGames()
                .Where(g => g.IsFinished)
                .Select(g => g.Score)
                .OrderByDescending(i => i));
        }
    }
}
