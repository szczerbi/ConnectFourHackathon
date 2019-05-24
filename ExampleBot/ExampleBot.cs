using Player;
using Util;

namespace ExampleBot
{
  public class ExampleBot : IArtificialPlayer
  {
    public string PlayerName => "Awesome Example Bot";

    public int GetNextMove(GameSlotState[,] currentBoard)
    {
      for (int i = 0; i < Constants.BoardWidth; i++)
      {
        if (currentBoard[i, Constants.BoardHeight - 1] == GameSlotState.Empty)
        {
          return i;
        }
      }

      return 0;
    }
  }
}
