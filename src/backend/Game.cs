using System;

namespace thegame.backend
{
    public class Game
    {
        public readonly Guid Id;
        public readonly GameField GameField;
        public readonly GameStatus Status;
    }
}