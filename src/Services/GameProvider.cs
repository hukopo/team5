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

		public GameDto CreateGame(Vec movingObjectPosition, int difficulty)
		{
			int width =0;
			int height=0;
			int numberOfColors=0;

			switch (difficulty)
			{
				case 1:
					width = 5;
					height = 5;
					numberOfColors = 3;
					break;
				case 2:
					width = 8;
					height = 8;
					numberOfColors = 4;
					break;
				case 3:
					width = 20;
					height = 20;
					numberOfColors = 5;
					break;
			}


			var testCells = new List<CellDto>();
			var colors = new[]
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
			for (var x = 0; x < width; x++)
				for (var y = 0; y < height; y++)
				{
					cellId++;
					testCells.Add(new CellDto(cellId.ToString(), new Vec(x, y), colors[random.Next(numberOfColors)], "", 0));
				}


			var game = new GameDto(testCells.ToArray(), true, true, width, height, Guid.NewGuid(), false, 0, difficulty);

			games.Add(game.Id, game);
            game.GenerateMatrix();

			return game;
		}
	}
}