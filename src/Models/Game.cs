using System;
using System.Linq;

namespace thegame.Models
{
    public class Game
    {
        public CellDto[] Cells;
        public int Width;
        public int Height;
        public Guid Id;
        public int Score;
        public int Difficulty;
        public bool IsFinished;

        public CellDto GetCellByPosition(Vec vec) => cellMatrix[vec.X, vec.Y];

        private readonly CellDto[,] cellMatrix;


        public Game(CellDto[] cells, int width, int height, Guid id, int score, int difficulty)
        {
            Cells = cells;
            Width = width;
            Height = height;
            Id = id;
            Score = score;
            Difficulty = difficulty;
            cellMatrix = GenerateMatrix();
        }

        private CellDto[,] GenerateMatrix()
        {
            CellDto[,] matrix = new CellDto[Height, Width];
            for (int i = 0; i < Height; ++i)
                for (int j = 0; j < Width; ++j)
                    matrix[i, j] = Cells.First(c => c.Pos == new Vec(i, j) && c.Id != "Player");
            return matrix;
        }

        public bool IsSameColor()
        {
            string color = GetCellByPosition(new Vec(0, 0)).Type;
            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    CellDto cell = GetCellByPosition(new Vec(i, j));
                    if (cell.Type != color)
                        return false;
                }
            }
            return true;
        }

        public GameDto GenerateDto()
        {
            return new GameDto(Cells, Width, Height, Id, IsFinished, Score, Difficulty);
        }

    }
}
