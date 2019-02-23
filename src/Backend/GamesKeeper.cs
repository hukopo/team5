using System;

namespace thegame.backend
{
    public static class GamesKeeper
    {
        public static Guid CreateNewGame(int fieldSize)
        {
            throw new NotImplementedException();
        }

        public static void GetStatus(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public static int[,] GetMap(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public static int GetScore(Guid gameId)
        {
            throw new NotImplementedException();
        }

        public static int[,] MakeMove(Guid gameId, Direction direction)
        {
            throw new NotImplementedException();
        }
    }
}