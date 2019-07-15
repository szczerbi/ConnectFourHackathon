using Mediator;
using System;
using System.Windows.Forms;
using Util;

namespace AIVsAIMediator
{
  public partial class AIVsAIBoard : Board
  {
    public AIVsAIBoard()
    {
      InitializeComponent();
      GameBoard.Paint += PlayGame;
    }

    private void PlayGame(object sender, PaintEventArgs e)
    {
      StateController.GetNextBotMove();
    }
  }
}
