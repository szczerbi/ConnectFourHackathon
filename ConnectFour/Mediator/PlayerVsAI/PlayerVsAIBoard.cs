﻿using System.Drawing;
using System.Windows.Forms;
using Mediator;
using Player;
using Util;
using System.Linq;

namespace PlayerVsAIMediator
{
  public partial class PlayerVsAIBoard : Board
  {
    public PlayerVsAIBoard()
    {
      InitializeComponent();
      GameBoard.MouseMove += Board_MouseHover;
      GameBoard.MouseClick += Board_MouseClick;
    }

    private void Board_MouseClick(object sender, MouseEventArgs e)
    {
      if (StateController.WinState == WinState.InPlay && StateController.GetCurrentPlayer() is HumanPlayer)
      {
        int column = GetSelectedColumn(e);
        StateController.PlacePiece(column);
      }
    }

    private void Board_MouseHover(object sender, MouseEventArgs e)
    {
      var currentPlayer = StateController.GetCurrentPlayer();
      if (StateController.WinState != WinState.InPlay || !(currentPlayer is HumanPlayer))
      {
        return;
      }

      int column = GetSelectedColumn(e);
      if (column != _currentHoverColumn)
      {
        DrawArrow(column, currentPlayer.Arrow, StateController.GetOtherPlayer().Arrow);
        _currentHoverColumn = column;
      }
    }

    private static int GetSelectedColumn(MouseEventArgs e) => e.X / SlotDiameter;

    private int _currentHoverColumn = -1;
  }
}
