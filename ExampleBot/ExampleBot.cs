using Player;
using Util;

namespace ExampleBot
{
  public class ExampleBot : ArtificialPlayer
  {
    public override string PlayerName => "Awesome Example Bot";

    public override int GetNextMove(GameSlotState[,] currentBoard)
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
