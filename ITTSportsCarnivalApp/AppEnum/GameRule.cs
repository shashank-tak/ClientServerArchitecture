using System.ComponentModel;

namespace ENUM
{
    public enum GameRule
    {
        [Description("CricketCount")]
        CricketCount = 11,

        [Description("BadmintonCount")]
        BadmintonCount = 2,

        [Description("ChessCount")]
        ChessCount = 1,
    }
}
