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
      CurrentPlayer = Util.GameState.Player1;
      GameState = Util.GameState.Empty;
      Player1 = player1;
      Player2 = player2;
      PlayerMap.Add(Util.GameState.Player1, Player1);
      PlayerMap.Add(Util.GameState.Player2, Player2);
      GameBoard = gameBoard;
    }

    public GameState GameState { get; private set; }

    public IPlayer GetCurrentPlayer() => PlayerMap[CurrentPlayer];

    public Color GetCurrentPlayerColor()
    {
      switch (CurrentPlayer)
      {
        case GameState.Player1:
          return PlayerOneColor;
        case GameState.Player2:
          return PlayerTwoColor;
        default:
          return Color.Black;
      }
    }

    public int GetNextAvailableRow(int column) => Referee.GetNextAvailableRow(_boardState, column);

    public GameState PlacePiece(int column)
    {
      var row = GetNextAvailableRow(column);
      if (row != Constants.Invalid)
      {
        _boardState[column, row] = CurrentPlayer;
        GameBoard.DrawGamePiece(column, row);
        GameState = CheckForEndGame();
        if (GameState == GameState.Empty)
        {
          UpdateCurrentState();
          GetNextBotMove();
        }
        else
        {
          GameBoard.HandleWinState(GameState);
        }
      }

      return GameState;
    }

    private void UpdateCurrentState()
    {
      if (CurrentPlayer == GameState.Player1)
      {
        CurrentPlayer = GameState.Player2;
      }
      else
      {
        CurrentPlayer = GameState.Player1;
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
          System.Threading.Thread.Sleep(500);
          PlacePiece(column);
        }
      }
    }

    public GameState CheckForEndGame() => Referee.CheckForWin(_boardState, CurrentPlayer);

    private readonly IPlayer Player1;
    private readonly IPlayer Player2;

    protected readonly GameState[,] _boardState = new GameState[Constants.BoardWidth, Constants.BoardHeight];
    private readonly Dictionary<GameState, IPlayer> PlayerMap = new Dictionary<GameState, IPlayer>();

    private GameState CurrentPlayer;
    private Board GameBoard;

    public static readonly Color PlayerOneColor = Color.Red;
    public static readonly Color PlayerTwoColor = Color.Yellow;
  }
}
