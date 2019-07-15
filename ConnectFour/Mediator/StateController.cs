using System.Drawing;
using System.Threading;
using Player;
using Util;

namespace Mediator
{
  public class StateController
  {
    public StateController(Player.Player player1, Player.Player player2, Board gameBoard)
    {
      WinState = WinState.InPlay;
      Player1 = player1;
      Player2 = player2;
      CurrentPlayer = Player1;
      GameBoard = gameBoard;
    }

    public WinState WinState { get; private set; }

    public Player.Player GetCurrentPlayer() => CurrentPlayer;

    public Player.Player GetOtherPlayer() => CurrentPlayer == Player1 ? Player2 : Player1;

    public int GetNextAvailableRow(int column) => _boardState.GetNextAvailableRow(column);

    public WinState PlacePiece(int column)
    {
      var row = GetNextAvailableRow(column);
      if (row != Constants.Invalid)
      {
        _boardState[column, row] = CurrentPlayer;
        GameBoard.DrawGamePiece(column, row);
        WinState = CheckForEndGame();
        if (WinState == WinState.InPlay)
        {
          UpdateCurrentState();
          GetNextBotMove();
        }
        else
        {
          GameBoard.HandleWinState(WinState);
        }
      }

      return WinState;
    }

    private WinState CheckForEndGame() => Referee.CheckForWin(_boardState, CurrentPlayer);

    private void UpdateCurrentState()
    {
      if (CurrentPlayer.ID == Player1.ID)
      {
        CurrentPlayer = Player2;
      }
      else
      {
        CurrentPlayer = Player1;
      }
    }

    public void GetNextBotMove()
    {
      var currentBot = GetCurrentPlayer() as ArtificialPlayer;
      if (currentBot != null)
      {
        int column = currentBot.GetNextMove(_boardState);
        if (_boardState.CheckIfValidMove(column))
        {
          // waiting here because bots play super fast and it's easier to follow this way
          Thread.Sleep(500);
          PlacePiece(column);
        }
      }
    }

    private Player.Player CurrentPlayer;
    private readonly Player.Player Player1;
    private readonly Player.Player Player2;
    private readonly Board GameBoard;

    private readonly Player.Player[,] _boardState = new Player.Player[Constants.BoardWidth, Constants.BoardHeight];
  }
}
