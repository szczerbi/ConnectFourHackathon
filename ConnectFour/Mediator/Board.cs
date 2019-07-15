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
      InitImages();
      GameBoard.Paint += Board_Paint;
    }

    public void SetupPlayers(Player.Player player1, Player.Player player2)
    {
      player1.Arrow = YellowArrow;
      player1.Color = Color.Yellow;
      player2.Arrow = RedArrow;
      player2.Color = Color.Red;
      StateController = new StateController(player1, player2, this);
    }

    public StateController StateController { get; protected set; }

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

      var currentPlayer = StateController.GetCurrentPlayer();
      var myBrush = new SolidBrush(currentPlayer.Color);
      int x = column * SlotDiameter;
      int y = (Constants.BoardHeight - 1 - row) * SlotDiameter;
      DrawPreviousArrow(column, currentPlayer.Arrow);
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
        case WinState.Win:
          var currentPlayer = StateController.GetCurrentPlayer();
          message =
            $"{currentPlayer.PlayerName} ({currentPlayer.Color.Name}) wins the game!";
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

    protected Image RedArrow { get; private set; }

    protected Image YellowArrow { get; private set; }

    protected void DrawArrow(int column, Image currentArrow, Image previousArrow)
    {
      using (Graphics f = CreateGraphics())
      {
        f.Clear(BackColor);
        f.DrawImage(previousArrow, _previousColumn * SlotDiameter, 0);
        f.DrawImage(currentArrow, column * SlotDiameter, 0);
      }
    }

    private void InitImages()
    {
      var assembly = Assembly.GetExecutingAssembly();
      var redImgStream = assembly.GetManifestResourceStream("Main.Mediator.Resources.red_arrow.png");
      if (redImgStream != null)
      {
        RedArrow = new Bitmap(redImgStream);
      }
      var yellowImgStream = assembly.GetManifestResourceStream("Main.Mediator.Resources.yellow_arrow.png");
      if (yellowImgStream != null)
      {
        YellowArrow = new Bitmap(yellowImgStream);
      }
    }

    private void DrawPreviousArrow(int column, Image arrow)
    {
      using (Graphics f = CreateGraphics())
      {
        f.Clear(BackColor);
        f.DrawImage(arrow, column * SlotDiameter, 0);
        _previousColumn = column;
      }
    }

    public const int SlotDiameter = 100;
    private int _previousColumn = -1;
  }
}
