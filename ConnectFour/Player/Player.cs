using System;
using System.Drawing;

namespace Player
{
  public abstract class Player
  {
    /// <summary>
    ///   unique identifier for this player
    /// </summary>
    public abstract string PlayerName { get; }

    public Color Color { get; set; }
    public Image Arrow { get; set; }
    public Guid ID = Guid.NewGuid();
  }
}
