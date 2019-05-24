using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Util;

namespace Mediator
{
  public partial class Board : Form
  {
    public Board()
    {
      InitializeComponent();
      InitStateController();
      InitImages();
      GameBoard.Paint += Board_Paint;
    }

    public StateController StateController { get; protected set; }

    protected virtual void InitStateController()
    {
      StateController = new StateController(null, null, this);
    }

    private void Board_Paint(object sender, PaintEventArgs e)
    {
      Pen line = new Pen(Color.Black);
      const int lineXi = 0, lineXf = Constants.BoardWidth * SlotDiameter;
      const int lineYi = 0, lineYf = Constants.BoardHeight * SlotDiameter;
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

    public void DrawGamePiece(int column, int row)
    {
      if (StateController.WinState != WinState.InPlay)
      {
        return;
      }

      var color = StateController.GetCurrentPlayerColor();
      var myBrush = new SolidBrush(color);
      int x = column * SlotDiameter;
      int y = (Constants.BoardHeight - 1 - row) * SlotDiameter;
      using (var f = GameBoard.CreateGraphics())
      {
        f.FillEllipse(myBrush, x, y, SlotDiameter, SlotDiameter);
      }
    }

    public void HandleWinState(WinState winState)
    {
      string message;
      switch (winState)
      {
        case WinState.Draw:
          message = "Game Over! It's a draw.";
          break;
        case WinState.Player1:
        case WinState.Player2:
          message =
            $"{StateController.GetCurrentPlayer().PlayerName} ({StateController.GetCurrentPlayerColor().Name}) wins the game!";
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

    private Image RedArrow { get; set; }

    private Image YellowArrow { get; set; }

    protected void DrawArrow(int column)
    {
      using (Graphics f = CreateGraphics())
      {
        f.Clear(BackColor);
        f.DrawImage(RedArrow, column * SlotDiameter, 0);
      }
    }

    private void InitImages()
    {
      var assembly = Assembly.GetExecutingAssembly();
      var redImgStream = assembly.GetManifestResourceStream("Mediator.Resources.red_arrow.png");
      if (redImgStream != null)
      {
        RedArrow = new Bitmap(redImgStream);
      }
      var yellowImgStream = assembly.GetManifestResourceStream("Mediator.Resources.yellow_arrow.png");
      if (yellowImgStream != null)
      {
        YellowArrow = new Bitmap(yellowImgStream);
      }
    }

    public const int SlotDiameter = 100;
  }
}
