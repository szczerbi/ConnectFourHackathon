using AIVsAIMediator;
using Mediator;
using PlayerVsAIMediator;
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
      _gameBoard = new AIVsAIBoard();
      _gameBoard.Show();
    }

    private void PlayerVsAI_Click(object sender, EventArgs e)
    {
      _gameBoard = new PlayerVsAIBoard();
      _gameBoard.Show();
    }

    private Board _gameBoard;
  }
}
