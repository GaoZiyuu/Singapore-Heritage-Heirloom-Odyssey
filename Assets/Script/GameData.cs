using System;

/// <summary>
/// Represents user data including username, email, and status.
/// </summary>
public class gameData
{
    /// <summary>
    /// The checkpoint of user within the game
    /// </summary>
    public int gameCheckpoint;

    /// <summary>
    /// The timing of the player when finishing the rickshaw mini game.
    /// </summary>
    public string rickshawTiming;


    /// <summary>
    /// Initializes a new instance of the <see cref="GameData"/> class.
    /// </summary>
    /// <param name="gameCheckpoint">The checkpoint of user within the game.</param>
    /// <param name="rickshawTiming">The timing of the player when finishing the rickshaw mini game.</param>
    public gameData(int gameCheckpoint, string rickshawTiming)
    {
        this.gameCheckpoint = gameCheckpoint;
        this.rickshawTiming = rickshawTiming;
    }
}
