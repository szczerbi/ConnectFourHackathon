namespace Util
{
  public enum GameState
  {
    empty,
    player1,
    player2,
    draw
  };

  public enum PlayerType
  {
    Human,
    Bot
  };

  public static class Constants
  {
    public const int BoardWidth = 7;
    public const int BoardHeight = 6;
    public const int Invalid = -1;
  }
}
