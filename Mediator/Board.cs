using System.Drawing;
using System.Windows.Forms;
using Util;

namespace Mediator
{
  public partial class Board : Form
  {
    public Board()
    {
      InitializeComponent();
      this.GameBoard.Paint += new PaintEventHandler(this.Board_Paint);
    }

    private void Board_Paint(object sender, PaintEventArgs e)
    {
      Pen line = new Pen(Color.Black);
      int lineXi = 0, lineXf = Constants.BoardWidth *SlotDiameter;
      int lineYi = 0, lineYf = Constants.BoardHeight *SlotDiameter;
      var myBrush = new SolidBrush(Color.White);

      for (int startY = 0; startY <= Constants.BoardWidth * SlotDiameter; startY += SlotDiameter)
      {
        e.Graphics.DrawLine(line, startY, lineYi, startY, lineYf);
      }

      for (int startX = 0; startX <= Constants.BoardHeight * SlotDiameter; startX += SlotDiameter)
      {
        e.Graphics.DrawLine(line, lineXi, startX, lineXf, startX);
      }

      for (int y = 0; y <= Constants.BoardHeight * SlotDiameter; y += SlotDiameter)
      {
        for (int x = 0; x <= Constants.BoardWidth * SlotDiameter; x += SlotDiameter)
        {
          e.Graphics.FillEllipse(myBrush, new Rectangle(x, y, SlotDiameter, SlotDiameter));
        }
      }
    }

    public void DrawGamePiece(object sender, MouseEventArgs e)
    {
      if (StateController.GameState != state.empty)
      {
        return;
      }

      var color = StateController.GetCurrentPlayerColor();
      var myBrush = new SolidBrush(color);
      int column = GetSelectedColumn(e);
      int row = StateController.GetNextAvailableRow(column);
      if (row != Invalid)
      {
        int x = column * SlotDiameter;
        int y = (Constants.BoardHeight - 1 - row) * SlotDiameter;
        using (Graphics f = (sender as Control).CreateGraphics())
        {
          f.FillEllipse(myBrush, x, y, SlotDiameter, SlotDiameter);
        }

        var winState = StateController.PlacePiece(column, row);
        HandleWinState(winState);
      }
    }

    private static void HandleWinState(state winState)
    {
      string message;
      switch (winState)
      {
        case state.draw:
          message = "Game Over! It's a draw.";
          break;
        case state.player1:
          message = "Red Player wins the game!";
          break;
        case state.player2:
          message = "Yellow Player wins the game!";
          break;
        default:
          message = string.Empty;
          break;
      }

      if (!string.IsNullOrEmpty(message))
      {
        var gameWin = new GameWin(message);
        gameWin.Show();
      }
    }

    protected static int GetSelectedColumn(MouseEventArgs e) => e.X / SlotDiameter;

    protected StateController StateController;



    public const int SlotDiameter = 100;
    public const int Invalid = -1;
  }
}
