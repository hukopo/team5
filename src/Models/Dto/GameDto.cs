using System;

namespace thegame.Models
{
    public class GameDto
    {
        public GameDto(CellDto[] cells, int width, int height, Guid id, bool isFinished, int score, int difficulty)
        {
            Cells = cells;
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
    }
}