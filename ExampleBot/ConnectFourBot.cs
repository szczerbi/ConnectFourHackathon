using Player;
using Util;

public class ConnectFourBot : ArtificialPlayer
{
  public override string PlayerName => "Awesome Example Bot";

  public override int GetNextMove(Player.Player[,] currentBoard)
  {
    for (int i = 0; i < Constants.BoardWidth; i++)
    {
      if (currentBoard.CheckIfValidMove(currentBoard.GetNextAvailableRow(i)))
      {
        return i;
      }
    }

    return 0;
  }
}