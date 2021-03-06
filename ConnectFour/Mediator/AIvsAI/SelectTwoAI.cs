﻿using AIVsAIMediator;
using Player;
using System.Windows.Forms;

namespace ConnectFour
{
  public partial class SelectTwoAI : Form
  {
    public SelectTwoAI()
    {
      InitializeComponent();
      BindDataSource();
    }

    private void BindDataSource()
    {
      Player1AIList.DataSource = BotLister.ListBots();
      Player1AIList.DisplayMember = "PlayerName";
      Player2AIList.DataSource = BotLister.ListBots();
      Player2AIList.DisplayMember = "PlayerName";
    }

    private void button1_Click(object sender, System.EventArgs e)
    {
      Close();
      var board = new AIVsAIBoard();
      board.SetUpPlayers((ArtificialPlayer)Player1AIList.SelectedItem, (ArtificialPlayer)Player2AIList.SelectedItem);
      board.Show();
    }
  }
}
