using Maze.Game.Common;
using System.Collections.Generic;

namespace Maze.Game
{
    internal static class CommandCatalog
    {
        public static readonly IReadOnlyList<PlayerCommandSpec> MazeInitialization = new[]
        {
            new PlayerCommandSpec("debugmaze", shortAlias: "dm"),
            new PlayerCommandSpec("reseedmaze", " {No.}", "rs"),
            new PlayerCommandSpec("startgame", shortAlias: "sg"),
        };

        public static readonly IReadOnlyList<PlayerCommandSpec> InGame = new[]
        {
            new PlayerCommandSpec("checkpassages", shortAlias: "cp"),
            new PlayerCommandSpec("takepassage", " {n, s, e, w}", "tp"),
            new PlayerCommandSpec("checkitems", shortAlias: "ci"),
            new PlayerCommandSpec("collectitem", " {item name}", "co"),
            new PlayerCommandSpec("hititem", " {item name}", "hi"),
            new PlayerCommandSpec("defuseitem", " {item name}", "di"),
            new PlayerCommandSpec("dropcoin", shortAlias: "dc"),
            new PlayerCommandSpec("resetmaze", shortAlias: "rm"),
        };

        public static readonly IReadOnlyList<PlayerCommandSpec> Results = new[]
        {
            new PlayerCommandSpec("restartgame", shortAlias: "rg"),
            new PlayerCommandSpec("endgame", shortAlias: "eg"),
        };
    }
}
