using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Player
{
  public static class BotLister
  {
    public static List<ArtificialPlayer> ListBots()
    {
      var bots = new List<ArtificialPlayer>();
      var allAssemblies = new List<Assembly>();
      string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

      foreach (string dll in Directory.GetFiles(path, "*.dll"))
      {
        allAssemblies.Add(Assembly.LoadFile(dll));
      }
      foreach (var assembly in allAssemblies)
      {
        foreach (var type in assembly.GetTypes())
        {
          var myInterfaceType = typeof(ArtificialPlayer);
          if (type != myInterfaceType && myInterfaceType.IsAssignableFrom(type))
          {
            bots.Add((ArtificialPlayer) Activator.CreateInstance(myInterfaceType));
          }
        }
      }
      return bots;
    }
  }
}
