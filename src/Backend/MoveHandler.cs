using System.Collections.Generic;
using System.Linq;

namespace thegame.backend
{
    public static class MoveHandler
    {
        public static int MakeMove(GameField field, Direction move)
        {
            var totalPoints = 0;
            if (move == Direction.Right)
            {
                for (var i = 0; i < field.Size; i++)
                    totalPoints += MoveRowRight(field.Field, i);
            }
            else if (move == Direction.Left)
            {
                for (var i = 0; i < field.Size; i++)
                    totalPoints += MoveRowLeft(field.Field, i);
            }
            else if (move == Direction.Down)
            {
                for (var i = 0; i < field.Size; i++)
                    totalPoints += MoveColDown(field.Field, i);
            }
            else
            {
                for (var i = 0; i < field.Size; i++)
                    totalPoints += MoveColUp(field.Field, i);
            }

            return totalPoints;
        }

        public static int MoveColDown(int[,] field, int colIndex)
        {
            var filledItems = new List<int>();
            for (var col = 0; col < field.GetLength(0); col++)
                if (field[col, colIndex] != 0)
                    filledItems.Add(field[col, colIndex]);
            filledItems.Reverse();
            var resultItems = Reduce(filledItems, out var pointsAdded);

            for (var index = 0; index < field.GetLength(0); index++)
                field[index, colIndex] = 0;
            for (var index = 0; index < resultItems.Count; index++)
                field[field.GetLength(0) - 1 - index, colIndex] = resultItems[index];
            return pointsAdded;
        }

        public static int MoveColUp(int[,] field, int colIndex)
        {
            var height = field.GetLength(1);
            var filledItems = new List<int>();
            for (var row = 0; row < height; row++)
                if (field[row, colIndex] != 0)
                    filledItems.Add(field[row, colIndex]);
            
            var resultItems = Reduce(filledItems, out var pointsAdded);

            for (var index = 0; index < height; index++)
                field[index, colIndex] = 0;
            for (var index = 0; index < resultItems.Count; index++)
                field[index, colIndex] = resultItems[index];
            return pointsAdded;
        }

        public static List<int> Reduce(List<int> filledItems, out int pointAdded)
        {
            pointAdded = 0;
            var resultItems = new List<int>();
            var index = 0;
            for (; index < filledItems.Count - 1; index++)
            {
                if (filledItems[index] == filledItems[index + 1])
                {
                    pointAdded += filledItems[index] * 2;
                    resultItems.Add(filledItems[index] * 2);
                    index++;

                }
                else
                {
                    resultItems.Add(filledItems[index]);
                }
            }

            if (index == filledItems.Count - 1)
                resultItems.Add(filledItems[index]);

            return resultItems;
        }

        public static int MoveRowLeft(int[,] field, int rowIndex)
        {
            var width = field.GetLength(0);
            var filledItems = new List<int>();
            for (var col = 0; col < width; col++)
                if (field[rowIndex, col] != 0)
                    filledItems.Add(field[rowIndex, col]);
            var resultItems = Reduce(filledItems, out var pointsAdded);

            for (var index = 0; index < width; index++)
                field[rowIndex, index] = 0;
            for (var index = 0; index < resultItems.Count; index++)
                field[rowIndex, index] = resultItems[index];
            return pointsAdded;
        }

        public static int MoveRowRight(int[,] field, int rowIndex)
        {
            var filledItems = new List<int>();
            for(var col = 0; col < field.GetLength(0); col++)
                if (field[rowIndex, col] != 0)
                    filledItems.Add(field[rowIndex, col]);
            filledItems.Reverse();
            var resultItems = Reduce(filledItems, out var pointsAdded);

            for (var index = 0; index < field.GetLength(0); index++)
                field[rowIndex, index] = 0;
            for (var index = 0; index < resultItems.Count; index++)
                field[rowIndex, field.GetLength(0) - 1 - index] = resultItems[index];
            return pointsAdded;
        }
    }
}
