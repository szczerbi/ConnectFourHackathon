using System.Windows.Forms;
using Player;
using Util;

namespace PlayerVsAIMediator
{
  public class HumanPlayer : IPlayer
  {
    public HumanPlayer(PlayerVsAIBoard board)
    {
      Board = board;
      Board.GameBoard.MouseMove += Board_MouseHover;
      Board.GameBoard.MouseClick += Board_MouseClick;
    }

    private void Board_MouseClick(object sender, MouseEventArgs e)
    {
      if (Board.StateController.GetCurrentPlayer() is HumanPlayer)
      {
        int column = PlayerVsAIBoard.GetSelectedColumn(e);
        Board.DrawGamePiece(sender as Control, column);
      }
    }

    private void Board_MouseHover(object sender, MouseEventArgs e)
    {
      if (Board.StateController.GameState != state.empty || !(Board.StateController.GetCurrentPlayer() is HumanPlayer))
      {
        return;
      }

      int column = PlayerVsAIBoard.GetSelectedColumn(e);
      if (column != _currentHoverColumn)
      {
        Board.DrawArrow(column);
        _currentHoverColumn = column;
      }
    }

    public string PlayerName => "Human";

    public PlayerType Type => PlayerType.Human;

    private readonly PlayerVsAIBoard Board;

    private int _currentHoverColumn = -1;
  }
}
