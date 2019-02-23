using System;

namespace thegame.backend
{
    public class Game
    {
        public readonly Guid Id;
        public readonly GameField GameField;
        public readonly GameStatus Status;

        public Game(Guid id, int size)
        {
            Id = id;
            Status = GameStatus.InProcess;
            GameField = new GameField(size);
        }
    }
}