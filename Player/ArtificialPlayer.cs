using Util;

namespace Player
{
  public abstract class ArtificialPlayer : Player
  {
    /// <summary>
    ///   Returns the column index of the player's next move, given the current board state.
    /// </summary>
    /// <param name="currentBoard">
    ///   uniform 2d array representing the board. 0,0 is the top left corner of the board.
    ///   the board size and other constants can be found in the Util project
    /// </param>
    /// <returns>
    ///   integer index of the column the player would like to put a piece in.
    ///   if the column is invalid (full or out of bounds), GetNextMove will be called again on the same player.
    /// </returns>
    public abstract int GetNextMove(GameSlotState[,] currentBoard);
  }
}
