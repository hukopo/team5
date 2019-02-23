using System;

namespace thegame.backend
{
    public class Player
    {
        public readonly string Login;
        public readonly Guid Id;

        public Player(Guid id, string login)
        {
            Id = id;
            Login = login;
        }
    }
}