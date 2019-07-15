using System;
using System.Windows.Forms;

namespace ConnectFour
{
  public partial class ConnectFourStartPage : Form
  {
    public ConnectFourStartPage()
    {
      InitializeComponent();
    }

    private void AIVsAI_Click(object sender, EventArgs e)
    {
      var selectPlayers = new SelectTwoAI();
      selectPlayers.Show();
    }

    private void PlayerVsAI_Click(object sender, EventArgs e)
    {
      var selectPlayers = new SelectAI();
      selectPlayers.Show();
    }
  }
}
