using System;
using System.Linq;

namespace thegame.Models
{
    public class GameDto
    {
        public GameDto(CellDto[] cells, bool monitorKeyboard, bool monitorMouseClicks, int width, int height, Guid id, bool isFinished, int score, int difficulty)
        {
            Cells = cells;
            MonitorKeyboard = monitorKeyboard;
            MonitorMouseClicks = monitorMouseClicks;
            Width = width;
            Height = height;
            Id = id;
            IsFinished = isFinished;
            Score = score;
	        Difficulty = difficulty;
        }

        public CellDto[] Cells;
        public int Width;
        public int Height;
        public bool MonitorKeyboard;
        public bool MonitorMouseClicks;
        public Guid Id;
        public bool IsFinished;
        public int Score;
	    public int Difficulty;

        public CellDto Player => Cells.First(c => c.Id == "Player");
        public CellDto GetCellByPosition(Vec vec) => cellMatrix[vec.X, vec.Y];

        private CellDto[,] cellMatrix;

        public void GenerateMatrix()
        {
            cellMatrix = new CellDto[Height, Width];
            for (int i = 0; i < Height; ++i)
                for (int j = 0; j < Width; ++j)
                    cellMatrix[i, j] = Cells.First(c => c.Pos == new Vec(i, j) && c.Id != "Player");
        }
    }
}