using System;
using System.Windows.Forms;

namespace ConnectFour
{
  internal static class PlayConnectFour
  {
    /// <summary>
    ///   The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      using (var form1 = new ConnectFourStartPage())
      {
        Application.Run(form1);
      }
    }
  }
}
