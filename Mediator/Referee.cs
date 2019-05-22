using Util;

namespace Mediator
{
  public static class Referee
  {
    public static GameState CheckForWin(GameState[,] board, GameState currentPlayer)
    {
      // horizontalCheck
      for (int j = 0; j < Constants.BoardHeight - 3; j++)
      {
        for (int i = 0; i < Constants.BoardWidth; i++)
        {
          if (board[i, j] == currentPlayer && board[i, j + 1] == currentPlayer && board[i, j + 2] == currentPlayer && board[i, j + 3] == currentPlayer)
          {
            return currentPlayer;
          }
        }
      }
      // verticalCheck
      for (int i = 0; i < Constants.BoardWidth - 3; i++)
      {
        for (int j = 0; j < Constants.BoardHeight; j++)
        {
          if (board[i, j] == currentPlayer && board[i + 1, j] == currentPlayer && board[i + 2, j] == currentPlayer && board[i + 3, j] == currentPlayer)
          {
            return currentPlayer;
          }
        }
      }
      // ascendingDiagonalCheck
      for (int i = 3; i < Constants.BoardWidth; i++)
      {
        for (int j = 0; j < Constants.BoardHeight - 3; j++)
        {
          if (board[i, j] == currentPlayer && board[i - 1, j + 1] == currentPlayer && board[i - 2, j + 2] == currentPlayer && board[i - 3, j + 3] == currentPlayer)
            return currentPlayer;
        }
      }
      // descendingDiagonalCheck
      for (int i = 3; i < Constants.BoardWidth; i++)
      {
        for (int j = 3; j < Constants.BoardHeight; j++)
        {
          if (board[i, j] == currentPlayer && board[i - 1, j - 1] == currentPlayer && board[i - 2, j - 2] == currentPlayer && board[i - 3, j - 3] == currentPlayer)
            return currentPlayer;
        }
      }
      // board full check
      var winState = GameState.Draw;
      foreach (var state in board)
      {
        if (state == GameState.Empty)
        {
          winState = GameState.Empty;
          break;
        }
      }

      return winState;
    }

    public static int GetNextAvailableRow(this GameState[,] board, int column)
    {
      for (int row = 0; row < Constants.BoardHeight; row++)
      {
        if (board[column, row] == GameState.Empty)
        {
          return row;
        }
      }

      return Constants.Invalid;
    }

    public static bool CheckIfValidMove(this GameState[,] board, int column) =>
      column >= 0 && column < Constants.BoardWidth && GetNextAvailableRow(board, column) != Constants.Invalid;
  }
}
