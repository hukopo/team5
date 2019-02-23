using System.Collections.Generic;
using System.Linq;

namespace thegame.backend
{
    public static class MoveHandler
    {
        public static void MakeMove(GameField field, Direction move)
        {
            if (move == Direction.Right)
            {
                for (var i = 0; i < field.Size; i++)
                    MoveRowRight(field.Field, i);
            }
            else if (move == Direction.Left)
            {
                for (var i = 0; i < field.Size; i++)
                    MoveRowLeft(field.Field, i);
            }
            else if (move == Direction.Down)
            {
                for (var i = 0; i < field.Size; i++)
                    MoveColDown(field.Field, i);
            }
            else
            {
                for (var i = 0; i < field.Size; i++)
                    MoveColUp(field.Field, i);
            }
        }

        public static void MoveColDown(int[,] field, int colIndex)
        {
            var filledItems = new List<int>();
            for (var col = 0; col < field.GetLength(0); col++)
                if (field[col, colIndex] != 0)
                    filledItems.Add(field[col, colIndex]);
            filledItems.Reverse();
            var resultItems = Reduce(filledItems);
            
            for (var index = 0; index < field.GetLength(0); index++)
                field[index, colIndex] = 0;
            for (var index = 0; index < resultItems.Count; index++)
                field[field.GetLength(0) - 1 - index, colIndex] = resultItems[index];
        }

        public static void MoveColUp(int[,] field, int colIndex)
        {
            var height = field.GetLength(1);
            var filledItems = new List<int>();
            for (var row = 0; row < height; row++)
                if (field[row, colIndex] != 0)
                    filledItems.Add(field[row, colIndex]);
            var resultItems = Reduce(filledItems);

            for (var index = 0; index < height; index++)
                field[index, colIndex] = 0;
            for (var index = 0; index < resultItems.Count; index++)
                field[index, colIndex] = resultItems[index];
        }

        public static List<int> Reduce(List<int> filledItems)
        {
            var resultItems = new List<int>();
            var index = 0;
            for (; index < filledItems.Count - 1; index++)
            {
                if (filledItems[index] == filledItems[index + 1])
                {
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

        public static void MoveRowLeft(int[,] field, int rowIndex)
        {
            var width = field.GetLength(0);
            var filledItems = new List<int>();
            for (var col = 0; col < width; col++)
                if (field[rowIndex, col] != 0)
                    filledItems.Add(field[rowIndex, col]);
            var resultItems = Reduce(filledItems);

            for (var index = 0; index < width; index++)
                field[rowIndex, index] = 0;
            for (var index = 0; index < resultItems.Count; index++)
                field[rowIndex, index] = resultItems[index];
        }

        public static void MoveRowRight(int[,] field, int rowIndex)
        {
            var filledItems = new List<int>();
            for(var col = 0; col < field.GetLength(0); col++)
                if (field[rowIndex, col] != 0)
                    filledItems.Add(field[rowIndex, col]);
            filledItems.Reverse();
            var resultItems = Reduce(filledItems);

            for (var index = 0; index < field.GetLength(0); index++)
                field[rowIndex, index] = 0;
            for (var index = 0; index < resultItems.Count; index++)
                field[rowIndex, field.GetLength(0) - 1 - index] = resultItems[index];   
        }
    }
}
