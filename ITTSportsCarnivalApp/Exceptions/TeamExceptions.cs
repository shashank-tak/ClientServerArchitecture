using System;

namespace Exceptions
{
    public class TeamExceptions : Exception
    {
        public TeamExceptions(string message)
            : base(message) { }
    }

    public class InvalidPlayerData : TeamExceptions
    {
        public InvalidPlayerData() : base("Players Data Invalid") { }
    }

    public class InvalidGameType : TeamExceptions
    {
        public InvalidGameType() : base("Invalid game type id.") { }
    }

    public class InvalidFilePath : TeamExceptions
    {
        public InvalidFilePath() : base("Invalid File Path.") { }
    }

    public class NotRequiredPlayerRegistered : TeamExceptions
    {
        public NotRequiredPlayerRegistered() : base("Number of players is more or less than required for the game.") { }
    }
}
