using System.Linq;
using Microsoft.AspNetCore.Mvc;
using thegame.Services;

namespace thegame.Controllers
{
	public class Leaderboard
	{
		public int bestScore;

		public Leaderboard(int bestScore)
		{
			this.bestScore = bestScore;
		}
	}

    [Route("api/leaderboard")]
    public class LeaderBoardController
    {
	    private object locker = new object();
        private readonly GameProvider gameProvider;

        public LeaderBoardController(GameProvider gameProvider)
        {
            this.gameProvider = gameProvider;
        }

        [HttpPost]
        public IActionResult LeaderBoard([FromBody] int difficulty)
        {
            //TODO decide what to return
	        var gamesCount = gameProvider
				.GetAllGames()
		        .Where(g => g.IsFinished)
		        .Count(g => g.Difficulty == difficulty);

			if (gamesCount == 0)
				return new ObjectResult(new Leaderboard(0));

            var gamesasd = gameProvider
                .GetAllGames()
                .Where(g => g.IsFinished)
	            .Where(g => g.Difficulty == difficulty)
	            .ToList();

	        var nextThing = gamesasd
                .Select(g => g.Score)
                .OrderBy(i => i)
	            .First();

			var bestGame = new Leaderboard(nextThing);

	        return new ObjectResult(bestGame);
        }
    }
}
