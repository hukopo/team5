namespace thegame.Models
{
    public class Vec
    {
        public Vec(int x, int y)
        {
            X = x;
            Y = y;
        }

        public readonly int X, Y;

        public static Vec operator +(Vec v1, Vec v2) => new Vec(v1.X + v2.X, v1.Y + v2.Y);
        public static bool operator ==(Vec v1, Vec v2) => v1?.X == v2?.X && v1?.Y == v2?.Y;
        public static bool operator !=(Vec v1, Vec v2) => !(v1 == v2);
    }
}