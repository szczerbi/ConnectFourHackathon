using Player;
using Util;

namespace ExampleBot
{
  public class ExampleBot : IArtificialPlayer
  {
    public string PlayerName => "Awesome Example Bot";

    public int GetNextMove(GameSlotState[,] currentBoard)
    {
      return 0;
    }
  }
}
