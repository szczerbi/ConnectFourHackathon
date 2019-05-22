using Util;

namespace Player
{
  public interface IPlayer
  {
    /// <summary>
    /// unique identifier for this player
    /// </summary>
    string PlayerName { get; }

    PlayerType Type { get; }
  }
}
