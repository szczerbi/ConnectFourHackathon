using System.Drawing;
using Util;

namespace Player
{
  public interface IPlayer
  {
    Point GetNextMove(state[][] currentBoard);
  }
}
