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
        _boardState[column, row] = CurrentPlayerToGameSlotState();
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

    private WinState CheckForEndGame() => Referee.CheckForWin(_boardState, CurrentPlayerToGameSlotState());

    private void UpdateCurrentState()
    {
      if (CurrentPlayer == Player1)
      {
        CurrentPlayer = Player2;
      }
      else
      {
        CurrentPlayer = Player1;
      }
    }

    private void GetNextBotMove()
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

    private GameSlotState CurrentPlayerToGameSlotState()
    {
      if (CurrentPlayer == Player1)
      {
        return GameSlotState.Player1;
      }

      return GameSlotState.Player2;
    }

    private Player.Player CurrentPlayer;
    private readonly Player.Player Player1;
    private readonly Player.Player Player2;
    private readonly Board GameBoard;

    private readonly GameSlotState[,] _boardState = new GameSlotState[Constants.BoardWidth, Constants.BoardHeight];

    public static readonly Color PlayerOneColor = Color.Red;
    public static readonly Color PlayerTwoColor = Color.Yellow;
  }
}
