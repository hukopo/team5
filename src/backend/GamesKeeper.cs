using System;

namespace thegame.backend
{
    public class GamesKeeper
    {
        public Guid CreateNewGame()
        {
            throw new NotImplementedException();
        }

        public void GetStatus(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public int[,] GetMap(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public int GetScore(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public int[,] MakeMove(Guid gameId, Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}