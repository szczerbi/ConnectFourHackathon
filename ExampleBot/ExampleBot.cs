﻿using Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace ExampleBot
{
  public class ExampleBot : IArtificialPlayer
  {
    public string PlayerName => "Awesome Example Bot";
    public int GetNextMove(GameState[,] currentBoard)
    {
      return 0;
    }
  }
}