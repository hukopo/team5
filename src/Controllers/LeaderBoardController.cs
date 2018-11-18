using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Models;
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

        [HttpPost]
        public IActionResult LeaderBoard([FromBody] int difficulty)
        {
            var finishedGames = gameProvider
                .GetAllGames()
                .Where(g => g.IsFinished)
                .Where(g => g.Difficulty == difficulty)
                .ToList();

            if (finishedGames.Count == 0)
                return new ObjectResult(new LeaderboardDto(0));

            return new ObjectResult(new LeaderboardDto(finishedGames
                .Min(game => game.Score)));
        }
    }
}
