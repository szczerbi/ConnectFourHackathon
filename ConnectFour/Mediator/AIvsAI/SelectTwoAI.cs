using AIVsAIMediator;
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
      var dataSource = BotLister.ListBots();
      Player1AIList.DataSource = dataSource;
      Player1AIList.DisplayMember = "PlayerName";
      Player2AIList.DataSource = dataSource;
      Player2AIList.DisplayMember = "PlayerName";
    }

    private void button1_Click(object sender, System.EventArgs e)
    {
      Close();
      var board = new AIVsAIBoard();
      board.SetupPlayers((ArtificialPlayer)Player1AIList.SelectedItem, (ArtificialPlayer)Player2AIList.SelectedItem);
      board.Show();
    }
  }
}
