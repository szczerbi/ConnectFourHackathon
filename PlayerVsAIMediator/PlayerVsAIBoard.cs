﻿using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Mediator;
using Util;

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

    protected override void InitStateController()
    {
      StateController = new StateController(new HumanPlayer(), new ExampleBot.ExampleBot(), this);
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
      if (StateController.WinState != WinState.InPlay || !(StateController.GetCurrentPlayer() is HumanPlayer))
      {
        return;
      }

      int column = GetSelectedColumn(e);
      if (column != _currentHoverColumn)
      {
        DrawArrow(column);
        _currentHoverColumn = column;
      }
    }

    private static int GetSelectedColumn(MouseEventArgs e) => e.X / SlotDiameter;

    private int _currentHoverColumn = -1;
  }
}
