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
      this.GameBoard.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawGamePiece);
      StateController = new ManualStateController();
      var imgStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PlayerVsAIMediator.Resources.arrow_icon.png");
      ArrowIcon = new Bitmap(imgStream);
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

    private static Image ArrowIcon { get; set; }

    protected int _currentHoverColumn = -1;
  }

  public class ManualStateController : Mediator.StateController
  {
    public ManualStateController() {}
  }

}
