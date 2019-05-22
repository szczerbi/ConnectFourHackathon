using System.Collections.Generic;
using Player;
using System.Drawing;
using Util;

namespace Mediator
{
  public class StateController
  {
    public StateController(IPlayer player1, IPlayer player2, Board gameBoard)
    {
      CurrentPlayer = GameSlotState.Player1;
      WinState = Util.WinState.InPlay;
      Player1 = player1;
      Player2 = player2;
      PlayerMap.Add(GameSlotState.Player1, Player1);
      PlayerMap.Add(GameSlotState.Player2, Player2);
      GameBoard = gameBoard;
    }

    public WinState WinState { get; private set; }

    public IPlayer GetCurrentPlayer() => PlayerMap[CurrentPlayer];

    public Color GetCurrentPlayerColor()
    {
      switch (CurrentPlayer)
      {
        case GameSlotState.Player1:
          return PlayerOneColor;
        case GameSlotState.Player2:
          return PlayerTwoColor;
        default:
          return Color.Black;
      }
    }

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

    private void UpdateCurrentState()
    {
      if (CurrentPlayer == GameSlotState.Player1)
      {
        CurrentPlayer = GameSlotState.Player2;
      }
      else
      {
        CurrentPlayer = GameSlotState.Player1;
      }
    }

    private void GetNextBotMove()
    {
      var currentBot = GetCurrentPlayer() as IArtificialPlayer;
      if (currentBot != null)
      {
        int column = currentBot.GetNextMove(_boardState);
        if (_boardState.CheckIfValidMove(column))
        {
          // waiting here because bots play super fast and it's easier to follow this way
          System.Threading.Thread.Sleep(500);
          PlacePiece(column);
        }
      }
    }

    public WinState CheckForEndGame() => Referee.CheckForWin(_boardState, CurrentPlayer);

    private readonly IPlayer Player1;
    private readonly IPlayer Player2;

    protected readonly GameSlotState[,] _boardState = new GameSlotState[Constants.BoardWidth, Constants.BoardHeight];
    private readonly Dictionary<GameSlotState, IPlayer> PlayerMap = new Dictionary<GameSlotState, IPlayer>();

    private GameSlotState CurrentPlayer;
    private Board GameBoard;

    public static readonly Color PlayerOneColor = Color.Red;
    public static readonly Color PlayerTwoColor = Color.Yellow;
  }
}
