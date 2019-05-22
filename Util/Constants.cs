namespace Util
{
  public enum WinState
  {
    InPlay,
    Player1,
    Player2,
    Draw
  };

  public enum GameSlotState
  {
    Empty,
    Player1,
    Player2
  }

  public static class Constants
  {
    public static WinState PlayerToWinState(this GameSlotState player)
    {
      switch (player)
      {
        case GameSlotState.Player1:
          return WinState.Player1;
        case GameSlotState.Player2:
          return WinState.Player2;
        default:
          return WinState.InPlay;
      }
    }

    public const int BoardWidth = 7;
    public const int BoardHeight = 6;
    public const int Invalid = -1;
  }
}
