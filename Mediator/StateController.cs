using System.Collections.Generic;
using Player;
using System.Drawing;
using Util;

namespace Mediator
{
  public class StateController
  {
    public StateController(IPlayer player1, IPlayer player2)
    {
      CurrentPlayer = state.player1;
      GameState = state.empty;
      Player1 = player1;
      Player2 = player2;
      PlayerMap.Add(state.player1, Player1);
      PlayerMap.Add(state.player2, Player2);
    }

    public state GameState { get; private set; }

    public IPlayer GetCurrentPlayer() => PlayerMap[CurrentPlayer];

    public Color GetCurrentPlayerColor()
    {
      switch (CurrentPlayer)
      {
        case state.player1:
          return PlayerOneColor;
        case state.player2:
          return PlayerTwoColor;
        default:
          return Color.Black;
      }
    }

    public int GetNextAvailableRow(int column)
    {
      for (int row = 0; row < Constants.BoardHeight; row++)
      {
        if (_board[column, row] == state.empty)
        {
          return row;
        }
      }

      return -1;
    }

    public state PlacePiece(int column, int row)
    {
      _board[column, row] = CurrentPlayer;
      GameState = CheckForEndGame();
      if (GameState == state.empty)
      {
        UpdateCurrentState();
      }

      return GameState;
    }

    private void UpdateCurrentState()
    {
      if (CurrentPlayer == state.player1)
      {
        CurrentPlayer = state.player2;
      }
      else
      {
        CurrentPlayer = state.player1;
      }
      //TODO ask bot for next move here
      var bot = GetCurrentPlayer() as IArtificialPlayer;
      if (bot != null)
      {
        bot.GetNextMove(_board);
      }
    }

    public state CheckForEndGame()
    {
      // horizontalCheck
      for (int j = 0; j < Constants.BoardHeight - 3; j++)
      {
        for (int i = 0; i < Constants.BoardWidth; i++)
        {
          if (_board[i,j] == CurrentPlayer && _board[i, j + 1] == CurrentPlayer && _board[i, j + 2] == CurrentPlayer && _board[i, j + 3] == CurrentPlayer)
          {
            return CurrentPlayer;
          }
        }
      }
      // verticalCheck
      for (int i = 0; i < Constants.BoardWidth - 3; i++)
      {
        for (int j = 0; j < Constants.BoardHeight; j++)
        {
          if (_board[i, j] == CurrentPlayer && _board[i + 1,j] == CurrentPlayer && _board[i + 2, j] == CurrentPlayer && _board[i + 3, j] == CurrentPlayer)
          {
            return CurrentPlayer;
          }
        }
      }
      // ascendingDiagonalCheck
      for (int i = 3; i < Constants.BoardWidth; i++)
      {
        for (int j = 0; j < Constants.BoardHeight - 3; j++)
        {
          if (_board[i, j] == CurrentPlayer && _board[i - 1, j + 1] == CurrentPlayer && _board[i - 2, j + 2] == CurrentPlayer && _board[i - 3, j + 3] == CurrentPlayer)
            return CurrentPlayer;
        }
      }
      // descendingDiagonalCheck
      for (int i = 3; i < Constants.BoardWidth; i++)
      {
        for (int j = 3; j < Constants.BoardHeight; j++)
        {
          if (_board[i, j] == CurrentPlayer && _board[i - 1, j - 1] == CurrentPlayer && _board[i - 2, j - 2] == CurrentPlayer && _board[i - 3, j - 3] == CurrentPlayer)
            return CurrentPlayer;
        }
      }
      // board full check
      var winState = state.draw;
      foreach (var state in _board)
      {
        if (state == state.empty)
        {
          winState = state.empty;
          break;
        }
      }

      return winState;
    }

    private readonly IPlayer Player1;
    private readonly IPlayer Player2;

    protected state[,] _board = new state[Constants.BoardWidth, Constants.BoardHeight];
    private Dictionary<state, IPlayer> PlayerMap = new Dictionary<state, IPlayer>();

    private state CurrentPlayer;

    public static readonly Color PlayerOneColor = Color.Red;
    public static readonly Color PlayerTwoColor = Color.Yellow;
  }
}
