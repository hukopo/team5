using System.Collections.Generic;

namespace thegame.backend
{
    public class MoveHandler
    {
        public static GameField MakeMove(GameField previousField, Move move)
        {
            var newField = new GameField(previousField.Size);
            for(var i = 0; i < previousField.Size; i++)
            for (var j = 0; j < previousField.Size; j++)
                newField.Field[i, j] = previousField.Field[i, j];

            if (move == Move.Right)
            {
                for(var i = 0; i < newField.Size; i++)
                    MoveRowRight(newField.Field, i);
            }

            return newField;
        }

        public static bool CanMakeMove(GameField field)
        {
            return false;
        }

        public static void MoveRowRight(int[,] field, int rowIndex)
        {
            var filledItems = new List<int>();
            for(var col = 0; col < field.GetLength(1); col++)
                if (field[rowIndex, col] != 0)
                    filledItems.Add(field[rowIndex, col]);
            var resultItems = new List<int>();
            for (var index = filledItems.Count; index > 0; index--)
            {
                if (filledItems[index] == filledItems[index - 1])
                {
                    resultItems.Add(filledItems[index] * 2);
                    index--;
                }
                else
                {
                    resultItems.Add(filledItems[index]);
                }
            }

            for (var index = 0; index < field.GetLength(1); index++)
                field[rowIndex, index] = 0;
            for (var index = 0; index < resultItems.Count; index++)
                field[rowIndex, field.GetLength(1) - 1 - index] = resultItems[index];
            
        }


    }
}
