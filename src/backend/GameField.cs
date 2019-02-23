namespace thegame.backend
{
    public class GameField
    {
        public readonly int Size;
        public readonly int[,] Field;

        public GameField(int size)
        {
            Size = size;
            Field = new int[size,size];
        }
    }
}
