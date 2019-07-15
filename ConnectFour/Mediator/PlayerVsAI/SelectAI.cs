using Player;
using PlayerVsAIMediator;
using System.Windows.Forms;

namespace ConnectFour
{
  public partial class SelectAI : Form
  {
    public SelectAI()
    {
      InitializeComponent();
      BindDataSource();
    }

    private void BindDataSource()
    {
      var dataSource = BotLister.ListBots();
      AIPlayerList.DataSource = dataSource;
      AIPlayerList.DisplayMember = "PlayerName";
    }

    private void button1_Click(object sender, System.EventArgs e)
    {
      Close();
      var board = new PlayerVsAIBoard();
      board.SetupPlayers(new HumanPlayer(), (ArtificialPlayer) AIPlayerList.SelectedItem);
      board.Show();
    }
  }
}
