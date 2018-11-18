using System;
using System.Collections.Generic;
using System.Linq;
using thegame.Models;

namespace thegame.Services
{
    public class GameProvider
    {
        private readonly Dictionary<Guid, GameDto> games = new Dictionary<Guid, GameDto>();

        public GameDto GetGame(Guid gameId) => games.ContainsKey(gameId) ? games[gameId] : null;

        public IEnumerable<GameDto> GetAllGames() => games.Select(pair => pair.Value);

        public GameDto CreateGame(Vec movingObjectPosition)
        {
            var width = 10;
            var height = 8;
            var testCells = new[]
            {
                new CellDto("1", new Vec(2, 4), "color1", "", 0),
                new CellDto("2", new Vec(5, 4), "color1", "", 0),
                new CellDto("3", new Vec(3, 1), "color2", "", 20),
                new CellDto("4", new Vec(1, 0), "color2", "", 20),
                new CellDto("Player", movingObjectPosition, "color4", "☺", 10),
            };

            var game = new GameDto(testCells, true, true, width, height, Guid.NewGuid(), movingObjectPosition.X == 0,
                movingObjectPosition.Y);

            games.Add(game.Id, game);

            return game;
        }
    }
}