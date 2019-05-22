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
      var imgStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PlayerVsAIMediator.Resources.arrow_icon.png");
      if (imgStream != null)
      {
        ArrowIcon = new Bitmap(imgStream);
      }
    }

    protected override void InitStateController()
    {
      StateController = new StateController(new HumanPlayer(this), new HumanPlayer(this));
    }

    public void DrawArrow(int column)
    {
      using (Graphics f = CreateGraphics())
      {
        f.Clear(Color.Transparent);
        f.DrawImage(ArrowIcon, column * SlotDiameter, 0);
      }
    }

    public static int GetSelectedColumn(MouseEventArgs e) => e.X / SlotDiameter;

    private Image ArrowIcon { get; }
  }
}
