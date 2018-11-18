namespace thegame.Models
{
    public class LeaderboardDto
    {
        public int BestScore;

        public LeaderboardDto(int bestScore)
        {
            BestScore = bestScore;
        }
    }
}
