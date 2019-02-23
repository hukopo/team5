namespace thegame.backend
{
    public class GameField
    {
        public readonly int[,] Field;
        public readonly int Size;

        public GameField(int size)
        {
            Size = size;
            Field = new int[size,size];
        }
    }
}
