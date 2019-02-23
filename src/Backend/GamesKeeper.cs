using System;
using System.Collections.Generic;

namespace thegame.backend
{
    public static class GamesKeeper
    {
        private static Dictionary<Guid, Game> games = new Dictionary<Guid, Game>();

        public static Game CreateNewGame(int fieldSize)
        {
            var newGame = new Game(Guid.NewGuid(), fieldSize);
            games.Add(newGame.Id, newGame);
            return newGame;
        }

        public static GameStatus GetStatus(Guid gameId)
        {
            return games[gameId].GameStatus;
        }

        public static int[,] GetMap(Guid gameId)
        {
            return games[gameId].GameField.Field;
        }

        public static int GetScore(Guid gameId)
        {
            return games[gameId].Score;
        }

        public static int[,] MakeMove(Guid gameId, Direction direction)
        {
            games[gameId].MakeMove(direction);
            return games[gameId].GameField.Field;
        }
    }
}