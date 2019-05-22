using Mediator;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Util;

namespace PlayerVsAIMediator
{
  public partial class PlayerVsAIBoard : Board
  {
    public PlayerVsAIBoard()
    {
      InitializeComponent();
      this.GameBoard.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Board_MouseHover);
      this.GameBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Board_MouseClick);
      var imgStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PlayerVsAIMediator.Resources.arrow_icon.png");
      if (imgStream != null)
      {
        ArrowIcon = new Bitmap(imgStream);
      }
    }

    private void Board_MouseClick(object sender, MouseEventArgs e)
    {
      int column = GetSelectedColumn(e);
      DrawGamePiece(sender as Control, column);
    }

    private void Board_MouseHover(object sender, MouseEventArgs e)
    {
      if (StateController.GameState != state.empty)
      {
        return;
      }
      using (Graphics f = CreateGraphics())
      {
        int column = GetSelectedColumn(e);
        if (column != _currentHoverColumn)
        {
          f.Clear(BackColor);
          f.DrawImage(ArrowIcon, column * SlotDiameter, 0);
          _currentHoverColumn = column;
        }
      }
    }

    private static int GetSelectedColumn(MouseEventArgs e) => e.X / SlotDiameter;

    private static Image ArrowIcon { get; set; }

    private int _currentHoverColumn = -1;
  }
}
