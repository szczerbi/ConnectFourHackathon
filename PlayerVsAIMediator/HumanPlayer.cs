using System.Windows.Forms;
using Player;
using Util;

namespace PlayerVsAIMediator
{
  public class HumanPlayer : IPlayer
  {
    public HumanPlayer()
    {
    }

    public string PlayerName => "Human";
  }
}
