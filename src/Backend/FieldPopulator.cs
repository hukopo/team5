using System;
using System.Collections.Generic;
using thegame.backend;

namespace thegame.Backend
{
    public static class FieldPopulator
    {
        public static void Populate(GameField field)
        {
            var emptyCells = new List<Tuple<int, int>>();
            for(var i = 0; i < field.Size; i++)
                for(var j = 0; j < field.Size; j++)
                    if (field.Field[i, j] == 0)
                        emptyCells.Add(Tuple.Create(i, j));

            var rnd = new Random();
            if (emptyCells.Count == 0)
                return;

            var cellIndex = rnd.Next(0, emptyCells.Count);
            var cell = emptyCells[cellIndex];

            var val = rnd.NextDouble();
            field.Field[cell.Item1, cell.Item2] = val < 0.8 ? 2 : 4;
        }
    }
}
