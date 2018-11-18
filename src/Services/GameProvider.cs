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
            var width = 5;
            var height = 5;

	        var testCells = new List<CellDto>();
	        var colors = new string[5]
	        {
				"color0",
				"color1",
				"color2",
				"color3",
				"color4"
	        };

	        testCells.Add(new CellDto("Player", new Vec(1, 1), "color1", "", -1));

			var random = new Random();

	        var cellId = 1;
			for(var x=0; x<width; x++)
	        for (var y = 0; y < height; y++)
	        {
		        cellId++;
		        testCells.Add(new CellDto(cellId.ToString(),new Vec(x,y), colors[random.Next(5)],"",0));
	        }


            var game = new GameDto(testCells.ToArray(), true, true, width, height, Guid.NewGuid(), movingObjectPosition.X == 0,
                movingObjectPosition.Y);

            games.Add(game.Id, game);

            return game;
        }
    }
}