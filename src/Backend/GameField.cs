namespace thegame.backend
{
    public class GameField
    {
        public readonly int[,] Field;

        public GameField(int size)
        {
            Field = new int[size,size];
        }
    }
}
