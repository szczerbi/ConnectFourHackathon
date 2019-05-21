using System;
using System.Windows.Forms;

namespace ConnectFour
{
  static class PlayConnectFour
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      using (var form1 = new ConnectFourHome())
      {
        Application.Run(form1);
      }
    }
  }
}
