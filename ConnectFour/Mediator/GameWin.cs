using System.Windows.Forms;

namespace Mediator
{
  public partial class GameWin : Form
  {
    public GameWin(string message)
    {
      InitializeComponent();
      label1.Text = message;
    }
  }
}
