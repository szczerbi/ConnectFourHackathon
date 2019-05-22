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
      CurrentPlayer = state.player1;
      GameState = state.empty;
      Player1 = player1;
      Player2 = player2;
      PlayerMap.Add(state.player1, Player1);
      PlayerMap.Add(state.player2, Player2);
      GameBoard = gameBoard;
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

    public int GetNextAvailableRow(int column) => Referee.GetNextAvailableRow(_boardState, column);

    public state PlacePiece(int column)
    {
      var row = GetNextAvailableRow(column);
      if (row != Constants.Invalid)
      {
        _boardState[column, row] = CurrentPlayer;
        GameBoard.DrawGamePiece(column, row);
        GameState = CheckForEndGame();
        if (GameState == state.empty)
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
      if (CurrentPlayer == state.player1)
      {
        CurrentPlayer = state.player2;
      }
      else
      {
        CurrentPlayer = state.player1;
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
          PlacePiece(column);
        }
      }
    }

    public state CheckForEndGame() => Referee.CheckForWin(_boardState, CurrentPlayer);

    private readonly IPlayer Player1;
    private readonly IPlayer Player2;

    protected readonly state[,] _boardState = new state[Constants.BoardWidth, Constants.BoardHeight];
    private readonly Dictionary<state, IPlayer> PlayerMap = new Dictionary<state, IPlayer>();

    private state CurrentPlayer;
    private Board GameBoard;

    public static readonly Color PlayerOneColor = Color.Red;
    public static readonly Color PlayerTwoColor = Color.Yellow;
  }
}
