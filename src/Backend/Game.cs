using System;
using System.Runtime.InteropServices.ComTypes;
using thegame.Backend;

namespace thegame.backend
{
    public class Game
    {
        public readonly Guid Id;
        public readonly int Size;
        public readonly GameStatus GameStatus;
        public readonly GameField GameField;
        public int Score { get; set; }

        public Game(Guid id, int size)
        {
            Id = id;
            Size = size;
            GameStatus = GameStatus.InProcess;
            GameField = new GameField(size);
            FieldPopulator.Populate(GameField);
        }

        public void MakeMove(Direction direction)
        {
            FieldPopulator.Populate(GameField);
            MoveHandler.MakeMove(GameField, direction);
        }
    }
}