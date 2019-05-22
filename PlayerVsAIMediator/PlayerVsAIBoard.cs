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
      GameBoard.MouseMove += Board_MouseHover;
      GameBoard.MouseClick += Board_MouseClick;
      var imgStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PlayerVsAIMediator.Resources.arrow_icon.png");
      if (imgStream != null)
      {
        ArrowIcon = new Bitmap(imgStream);
      }
    }

    protected override void InitStateController()
    {
      StateController = new StateController(new HumanPlayer(), new ExampleBot.ExampleBot(), this);
    }

    private void Board_MouseClick(object sender, MouseEventArgs e)
    {
      if (StateController.GameState == GameState.Empty && StateController.GetCurrentPlayer() is HumanPlayer)
      {
        int column = GetSelectedColumn(e);
        StateController.PlacePiece(column);
      }
    }

    private void Board_MouseHover(object sender, MouseEventArgs e)
    {
      if (StateController.GameState != GameState.Empty || !(StateController.GetCurrentPlayer() is HumanPlayer))
      {
        return;
      }

      int column = GetSelectedColumn(e);
      if (column != _currentHoverColumn)
      {
        DrawArrow(column);
        _currentHoverColumn = column;
      }
    }

    private void DrawArrow(int column)
    {
      using (Graphics f = CreateGraphics())
      {
        f.Clear(BackColor);
        f.DrawImage(ArrowIcon, column * SlotDiameter, 0);
      }
    }

    private static int GetSelectedColumn(MouseEventArgs e) => e.X / SlotDiameter;

    private Image ArrowIcon { get; }

    private int _currentHoverColumn = -1;
  }
}
