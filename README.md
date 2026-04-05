# Maze Game

A text-based console maze adventure built with **.NET 9**. You explore procedurally generated rooms, collect treasure, deal with threats, and try to reach the exit with as much loot as possible.

## Requirements

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

## Solution layout

| Project            | Role                                              |
| ------------------ | ------------------------------------------------- |
| `Maze.Game`        | Console entry point and game loop                 |
| `Maze.Game.Common` | Shared helpers (console UI, JSON deserialization) |
| `Maze.Game.Tests`  | Unit tests (xUnit)                                |

Source lives under `src/`. Open `src/MazeGame.sln` in Visual Studio or build from the command line.

## Build and run

From the repository root:

```bash
dotnet build src/MazeGame.sln
dotnet run --project src/Maze.Game/Maze.Game.csproj
```

To run tests:

```bash
dotnet test src/MazeGame.sln
```

`Config.json` and `Resources/*.json` are loaded from the **application directory** (next to `Maze.Game.dll`), not from the shell’s current directory, so the game finds them after a normal build regardless of where you run `dotnet run` from.

## Configuration

Edit `src/Maze.Game/Config.json`:

| Property        | Description                                                 |
| --------------- | ----------------------------------------------------------- |
| `NumberOfRooms` | How many rooms are generated                                |
| `MazeName`      | Display name for the maze                                   |
| `MazeSeed`      | Seed for the random number generator (reproducible layouts) |

Treasure and threat definitions are loaded from `src/Maze.Game/Resources/Treasures.json` and `src/Maze.Game/Resources/Threats.json` (copied next to the built assembly on build).

## How to play

After entering your name, you can use these **pre-maze** commands (short forms in parentheses):

- `debugmaze` (`dm`) — print details about each generated room
- `reseedmaze <number>` (`rs`) — regenerate the maze with a new integer seed
- `startgame` (`sg`) — begin play

**In-game** commands (type the command when prompted; short forms in parentheses):

- `checkpassages` (`cp`) — list exits from the current room (`n`, `s`, `e`, `w`)
- `takepassage n` (`tp`) — move through a passage (threats in the room can block you)
- `checkitems` (`ci`) — list treasures and threats present
- `collectitem <name>` (`co`) — pick up treasure (collecting a threat by mistake costs treasure)
- `hititem <name>` (`hi`) — use a hammer on an item (works on some threats when that is the correct solution)
- `defuseitem <name>` (`di`) — attempt to defuse a threat (works when `defuse` is the configured solution)
- `dropcoin` (`dc`) — leave a coin in the room to mark you have visited (requires at least 1 treasure)
- `resetmaze` (`rm`) — confirm and regenerate the maze from the config seed (resets progress)

Reach the **exit passage** to finish a run. On the results screen you can `restartgame` (`rg`) or `endgame` (`eg`).

## Documentation

Design notes, test plans, and coursework documents are under `docs/` (Word/PDF).

## License

This project is licensed under the MIT License — see [LICENSE](LICENSE).
