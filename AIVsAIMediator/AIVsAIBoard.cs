using Mediator;

namespace AIVsAIMediator
{
  public partial class AIVsAIBoard : Board
  {
    public AIVsAIBoard()
    {
      InitializeComponent();
      StateController = new AutomatedStateController();
    }
  }

  public class AutomatedStateController : Mediator.StateController
  {
    public AutomatedStateController() {}
  }
}
